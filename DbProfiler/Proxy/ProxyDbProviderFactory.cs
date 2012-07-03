using System.Data.Common;
using System;
using System.Reflection;
using System.Security;
using System.Security.Permissions;

namespace DbProfiler.Proxy
{
    public class ProxyDbProviderFactory<TFac> : DbProviderFactory, IServiceProvider where TFac : DbProviderFactory
    {
        public TFac ProxiedDbProvider { get; private set; }
        public static ProxyDbProviderFactory<TFac> Instance;
        
        private ProxyDbProviderFactory()
        {
            FieldInfo field = typeof(TFac).GetField("Instance", BindingFlags.Public | BindingFlags.Static);
            this.ProxiedDbProvider = (TFac)field.GetValue(null);
        }

        public static void Initialize()
        {
            Instance = new ProxyDbProviderFactory<TFac>();
        }
        
        public override DbCommandBuilder CreateCommandBuilder()
        {
            return ProxiedDbProvider.CreateCommandBuilder();
        }

        public override DbConnection CreateConnection()
        {
            return new ProxyDbConnection(ProxiedDbProvider.CreateConnection(), this);
        }

        public override DbConnectionStringBuilder CreateConnectionStringBuilder()
        {
            return ProxiedDbProvider.CreateConnectionStringBuilder();
        }

        public override DbDataAdapter CreateDataAdapter()
        {
            return new ProxyDbDataAdapter(ProxiedDbProvider.CreateDataAdapter());
        }

        public override bool CanCreateDataSourceEnumerator
        {
            get { return ProxiedDbProvider.CanCreateDataSourceEnumerator; }
        }

        public override DbDataSourceEnumerator CreateDataSourceEnumerator()
        {
            return ProxiedDbProvider.CreateDataSourceEnumerator();
        }

        public override CodeAccessPermission CreatePermission(PermissionState state)
        {
            return ProxiedDbProvider.CreatePermission(state);
        }

        public override DbParameter CreateParameter()
        {
            return ProxiedDbProvider.CreateParameter();
        }

        public override DbCommand CreateCommand()
        {
            return new ProxyDbCommand(ProxiedDbProvider.CreateCommand());
        }
        
        public object GetService(Type serviceType)
        {
            if (serviceType == GetType())
            {
                return ProxiedDbProvider;
            }

            DbProviderServices service;

            if (ProxiedDbProvider is IServiceProvider)
            {
                service = (ProxiedDbProvider as IServiceProvider).GetService(serviceType) as DbProviderServices;
            }
            else
            {
                service = null;
            }

            if (service != null)
            {
                return new ProxyDbProviderServices(service);
            }

            return null;
        }
    }
}