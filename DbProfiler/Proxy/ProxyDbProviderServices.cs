using System.Data.Common;
using System.Data.Common.CommandTrees;
using System.Data.Metadata.Edm;

namespace DbProfiler.Proxy
{
    public class ProxyDbProviderServices : DbProviderServices
    {
        public readonly DbProviderServices ProxiedDbProviderServices;

        public ProxyDbProviderServices(DbProviderServices proxiedDbProviderServices)
        {
            this.ProxiedDbProviderServices = proxiedDbProviderServices;
        }

        public override DbCommandDefinition CreateCommandDefinition(DbCommand prototype)
        {
            var proxiedDbCommandDefinition = this.ProxiedDbProviderServices.CreateCommandDefinition(prototype);
            return new ProxyDbCommandDefinition(proxiedDbCommandDefinition);
        }

        protected override DbCommandDefinition CreateDbCommandDefinition(DbProviderManifest providerManifest, DbCommandTree commandTree)
        {
            var proxiedDbCommandDefinition = this.ProxiedDbProviderServices.CreateCommandDefinition(commandTree);
            return new ProxyDbCommandDefinition(proxiedDbCommandDefinition);
        }

        protected override void DbCreateDatabase(DbConnection connection, int? commandTimeout, StoreItemCollection storeItemCollection)
        {
            this.ProxiedDbProviderServices.CreateDatabase(((ProxyDbConnection)connection).ProxiedConnection, commandTimeout, storeItemCollection);
        }

        protected override string DbCreateDatabaseScript(string providerManifestToken, StoreItemCollection storeItemCollection)
        {
            return this.ProxiedDbProviderServices.CreateDatabaseScript(providerManifestToken, storeItemCollection);
        }

        protected override bool DbDatabaseExists(DbConnection connection, int? commandTimeout, StoreItemCollection storeItemCollection)
        {
            return this.ProxiedDbProviderServices.DatabaseExists(((ProxyDbConnection)connection).ProxiedConnection, commandTimeout, storeItemCollection);
        }

        protected override void DbDeleteDatabase(DbConnection connection, int? commandTimeout, StoreItemCollection storeItemCollection)
        {
            this.ProxiedDbProviderServices.DeleteDatabase(((ProxyDbConnection)connection).ProxiedConnection, commandTimeout, storeItemCollection);
        }

        protected override DbProviderManifest GetDbProviderManifest(string manifestToken)
        {
            return this.ProxiedDbProviderServices.GetProviderManifest(manifestToken);
        }

        protected override string GetDbProviderManifestToken(DbConnection connection)
        {
            return this.ProxiedDbProviderServices.GetProviderManifestToken(((ProxyDbConnection)connection).ProxiedConnection);
        }
    }
}
