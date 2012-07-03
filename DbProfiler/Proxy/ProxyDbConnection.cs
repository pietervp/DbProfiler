using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System;
using System.Reflection;
using System.Transactions;
using IsolationLevel = System.Data.IsolationLevel;

namespace DbProfiler.Proxy
{
    public class ProxyDbConnection : DbConnection
    {
        public DbProviderFactory ProxiedFactory { get; private set; }
        public DbConnection ProxiedConnection { get; private set; }
        public string Guid { get; private set; }
        public string Context { get; set; }

        public ProxyDbConnection(DbConnection proxiedConnection, DbProviderFactory proxiedFactory)
        {
            ProxiedConnection = proxiedConnection;
            ProxiedFactory = proxiedFactory;
            Context = GetContext(this);
            Guid = System.Guid.NewGuid().ToString();
        }

        private static string GetContext(object callingObject)
        {
            StackTrace stackTrace = new StackTrace();
            var methodBases = stackTrace.GetFrames().Select(x =>x.GetMethod());

            var frame = methodBases.FirstOrDefault(x => x != null && x.DeclaringType != null && x.DeclaringType.Name != null && x.DeclaringType.FullName.Contains("WinForm") && !x.DeclaringType.Assembly.FullName.Contains("Sphinx.Base.Control"));

            if (frame == null) return null;

            MethodBase methodBase = frame;
            string memberName = methodBase.Name;

            string objectName;

            objectName = methodBase.DeclaringType.Name;

            return string.Format("{0}::{1} - ", objectName, memberName);
        }

        #region Overrides of DbConnection

        public new event StateChangeEventHandler StateChange
        {
            add
            {
                ProxiedConnection.StateChange += value;
            }
            remove
            {
                ProxiedConnection.StateChange -= value;
            }
        }

        protected override System.Data.Common.DbProviderFactory DbProviderFactory
        {
            get
            {
                return ProxiedFactory;
            }
        }

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            return ProxiedConnection.BeginTransaction(isolationLevel);
        }

        public override void Close()
        {
            ProxiedConnection.Close();

            ProxyGenerator.GenericProfiler.ConnectionChanged(this);
        }

        public override void ChangeDatabase(string databaseName)
        {
            ProxiedConnection.ChangeDatabase(databaseName);
        }

        public override void Open()
        {
            ProxiedConnection.Open();

            ProxyGenerator.GenericProfiler.ConnectionChanged(this);
        }

        public override string ConnectionString
        {
            get { return ProxiedConnection.ConnectionString; }
            set { ProxiedConnection.ConnectionString = value; }
        }

        public override string Database
        {
            get { return ProxiedConnection.Database; }
        }

        public override ConnectionState State
        {
            get { return ProxiedConnection.State; }
        }

        public override string DataSource
        {
            get { return ProxiedConnection.DataSource; }
        }

        public override string ServerVersion
        {
            get { return ProxiedConnection.ServerVersion; }
        }

        protected override DbCommand CreateDbCommand()
        {
            return new ProxyDbCommand(ProxiedConnection.CreateCommand());
        }

        public override void EnlistTransaction(Transaction transaction)
        {
            ProxiedConnection.EnlistTransaction(transaction);
        }

        public override DataTable GetSchema()
        {
            return ProxiedConnection.GetSchema();
        }

        public override DataTable GetSchema(string collectionName)
        {
            return ProxiedConnection.GetSchema(collectionName);
        }

        public override DataTable GetSchema(string collectionName, string[] restrictionValues)
        {
            return ProxiedConnection.GetSchema(collectionName, restrictionValues);
        }

        protected override void Dispose(bool disposing)
        {
            ProxiedConnection.Dispose();
            base.Dispose(disposing);
        }

        protected override object GetService(Type service)
        {
            return ((IServiceProvider)this.ProxiedConnection).GetService(service);
        }

        #endregion
    }
}