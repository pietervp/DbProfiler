using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Van.Parys.Data.Common;

namespace DbProfiler.Proxy
{
    public class QueryStatisticsGenerator
    {
        private static bool profilingQuery;
        private const string SetShowplanAllOn = "SET SHOWPLAN_ALL ON";
        private const string SetShowplanAllOff = "SET SHOWPLAN_ALL OFF";

        public QueryStatisticsGenerator(Func<string> commandText, Func<DbConnection> proxyDbConnection)
        {
            CommandText = commandText;
            ProxyDbConnection = proxyDbConnection;
        }

        protected Func<string> CommandText { get; set; }
        protected Func<DbConnection> ProxyDbConnection { get; set; }

        internal List<QueryExecutionPlan> ProfileQueryExecutionPlan()
        {
            if (!ProxyGenerator.Options.IncludeQueryStatistics)
                return null;

            var executionPlan = new List<QueryExecutionPlan>();

            if (!profilingQuery)
            {
                try
                {
                    profilingQuery = true;

                    var cmd = ProxyDbConnection().CreateCommand() as ProxyDbCommand;
                    cmd.Connection = ProxyDbConnection();
                    cmd.CommandText = SetShowplanAllOn;
                    cmd.CommandType = CommandType.Text;
                    cmd.ProxiedCommand.ExecuteNonQuery();
                    cmd.CommandText = CommandText();
                    cmd.CommandType = CommandType.Text;
                    var statsReader = cmd.ProxiedCommand.ExecuteReader();

                    while (statsReader.Read())
                    {
                        executionPlan.Add(ParseReader(statsReader));
                    }

                    statsReader.Close();

                    cmd.CommandText = SetShowplanAllOff;
                    cmd.CommandType = CommandType.Text;
                    cmd.ProxiedCommand.ExecuteNonQuery();

                }
                catch (Exception exception)
                {
                    //Showplan not supported by SqlCe
                    if (exception.GetType().Name == "SqlCeException")
                    {
                        ProxyGenerator.Options.IncludeQueryStatistics = false;
                    }
                }
                finally
                {
                    profilingQuery = false;
                }
            }

            return executionPlan;
        }

        internal static QueryExecutionPlan ParseReader(DbDataReader reader)
        {
            var queryExecutionPlan = new QueryExecutionPlan();

            queryExecutionPlan.StmtText = GetValue(reader, 0);
            queryExecutionPlan.StmtId = GetValue(reader, 1);
            queryExecutionPlan.NodeId = GetValue(reader, 2);
            queryExecutionPlan.Parent = GetValue(reader, 3);
            queryExecutionPlan.PhysicalOp = GetValue(reader, 4);
            queryExecutionPlan.LogicalOp = GetValue(reader, 5);
            queryExecutionPlan.Argument = GetValue(reader, 6);
            queryExecutionPlan.DefinedValues = GetValue(reader, 7);
            queryExecutionPlan.EstimateRows = GetValue(reader, 8);
            queryExecutionPlan.EstimatedIO = GetValue(reader, 9);
            queryExecutionPlan.EstimateCPU = GetValue(reader, 10);
            queryExecutionPlan.AvgRowSize = GetValue(reader, 11);
            queryExecutionPlan.TotalSubtreeCost = GetValue(reader, 12);
            queryExecutionPlan.OutputList = GetValue(reader, 13);
            queryExecutionPlan.Warnings = GetValue(reader, 14);
            queryExecutionPlan.Type = GetValue(reader, 15);
            queryExecutionPlan.Parallel = GetValue(reader, 16);
            queryExecutionPlan.EstimateExecutions = GetValue(reader, 17);

            return queryExecutionPlan;
        }

        internal static string GetValue(DbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? String.Empty : reader.GetValue(index).ToString();
        }
    }
}