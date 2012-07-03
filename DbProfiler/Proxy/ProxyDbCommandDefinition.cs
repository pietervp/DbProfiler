using System.Data.Common;

namespace DbProfiler.Proxy
{
    public class ProxyDbCommandDefinition : DbCommandDefinition
    {
        public DbCommandDefinition ProxiedDbCommandDefinition { get; set; }

        public ProxyDbCommandDefinition(DbCommandDefinition proxiedDbCommandDefinition)
        {
            ProxiedDbCommandDefinition = proxiedDbCommandDefinition;
        }

        public override DbCommand CreateCommand()
        {
            return new ProxyDbCommand(this.ProxiedDbCommandDefinition.CreateCommand());
        }
    }
}