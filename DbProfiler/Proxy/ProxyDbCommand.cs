using System.Data;
using System.Data.Common;
using System;
using Van.Parys.Data.Common;

namespace DbProfiler.Proxy
{
    public class ProxyDbCommand : DbCommand
    {
        public DbCommand ProxiedCommand { get; set; }
        public ProxyDbConnection ProxyDbConnection;
        private QueryStatisticsGenerator _statisticsGenerator;

        public ProxyDbCommand(DbCommand proxiedCommand)
        {
            ProxiedCommand = proxiedCommand;
            _statisticsGenerator = new QueryStatisticsGenerator(() => CommandText, () => ProxyDbConnection);
        }

        #region Overrides of DbCommand

        public override object ExecuteScalar()
        {
            var executionPlan = _statisticsGenerator.ProfileQueryExecutionPlan();

            object executeScalarResult = null;

            var executeScalarAction = ((Action<DbCommand>) (cmd => executeScalarResult = cmd.ExecuteScalar()));
            var timeSpan = executeScalarAction.Measure(ProxiedCommand);
            
            ProxyGenerator.GenericProfiler.CommandExecute(this, timeSpan, ExecuteMethod.ExecuteScalar, executionPlan, executeScalarResult);
            
            return executeScalarResult;
        }

        public override void Prepare()
        {
            ProxiedCommand.Prepare();
        }

        public override string CommandText
        {
            get { return ProxiedCommand.CommandText; }
            set { ProxiedCommand.CommandText = value; }
        }

        public override int CommandTimeout
        {
            get { return ProxiedCommand.CommandTimeout; }
            set { ProxiedCommand.CommandTimeout = value; }
        }

        public override CommandType CommandType
        {
            get { return ProxiedCommand.CommandType; }
            set { ProxiedCommand.CommandType = value; }
        }

        public override UpdateRowSource UpdatedRowSource
        {
            get { return ProxiedCommand.UpdatedRowSource; }
            set { ProxiedCommand.UpdatedRowSource = value; }
        }

        protected override DbConnection DbConnection
        {
            get { return ProxiedCommand.Connection; }
            set
            {
                ProxyDbConnection = value as ProxyDbConnection;
                ProxiedCommand.Connection = (value as ProxyDbConnection).ProxiedConnection;
            }
        }

        protected override DbParameterCollection DbParameterCollection
        {
            get { return ProxiedCommand.Parameters; }
        }

        protected override DbTransaction DbTransaction
        {
            get { return ProxiedCommand.Transaction; }
            set { ProxiedCommand.Transaction = value; }
        }

        public override bool DesignTimeVisible
        {
            get { return ProxiedCommand.DesignTimeVisible; }
            set { ProxiedCommand.DesignTimeVisible = value; }
        }

        public override void Cancel()
        {
            ProxiedCommand.Cancel();
        }

        protected override DbParameter CreateDbParameter()
        {
            return ProxiedCommand.CreateParameter();
        }

        protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
        {
            var executionPlan = _statisticsGenerator.ProfileQueryExecutionPlan();

            DbDataReader dataReader;

            using(Measure.Scope)
            {
                dataReader = ProxiedCommand.ExecuteReader(behavior);
            }

            ProxyGenerator.GenericProfiler.CommandExecute(this, Measure.Was.Elapsed, ExecuteMethod.ExecuteDbDataReader, executionPlan, -1);
           
            return dataReader;
        }
        
        public override int ExecuteNonQuery()
        {
            var executionPlan = _statisticsGenerator.ProfileQueryExecutionPlan();
            int executeNonQuery;

            using (Measure.Scope)
            {
                executeNonQuery = ProxiedCommand.ExecuteNonQuery();
            }

            ProxyGenerator.GenericProfiler.CommandExecute(this, Measure.Was.Elapsed, ExecuteMethod.ExecuteNonQuery, executionPlan, executeNonQuery);

            return executeNonQuery;
        }

        #endregion

    }
}