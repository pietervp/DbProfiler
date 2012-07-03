using System.Data;
using System.Data.Common;
using System.Linq;
using System;
using System.Reflection;
using DbProfiler.Output;
using DbProfiler.Proxy;

namespace DbProfiler
{
    public class ProxyGenerator
    {
        internal static GenericProfiler GenericProfiler;
        internal static ProfilingOptions Options { get; set; }
        internal static event EventHandler<EfQueryEventArgs> QueryExecuted;

        public static void Init(ProfilingOptions options = null)
        {
            //store the options
            Options = options ?? new ProfilingOptions();

            //DbProviderFactories has a private static method (thanks jetBrains decompiler!) which gives us a non copy of the available DbProviderFactories
            var dbProvidersFactoriesDataTable = typeof(DbProviderFactories).GetMethod("GetProviderTable", BindingFlags.NonPublic | BindingFlags.Static).Invoke(null, null) as DataTable;

            if(dbProvidersFactoriesDataTable == null)
                return;

            var dbProviderFactoryTypes = dbProvidersFactoriesDataTable.Rows.OfType<DataRow>().Select(x => x["InvariantName"].ToString()).ToList();
            
            foreach (var providerInvariantName in dbProviderFactoryTypes)
            {
                var factory = DbProviderFactories.GetFactory(providerInvariantName);

                //this should never happen, but check if dbFactoryProvider was already added to dataset
                if (factory.GetType().Assembly == typeof(ProxyDbProviderFactory<>).Assembly)
                {
                    continue;
                }

                OverrideDefaultFactory(factory.GetType(), providerInvariantName, dbProvidersFactoriesDataTable);
            }

            GenericProfiler = new GenericProfiler(Options);
        }

        private static void OverrideDefaultFactory(Type oringalFactoryType, string providerInvariantName, DataTable dbProvidersFactoriesDataTable)
        {
            //create new generic type ProxyDbProviderFactory<{TypeOfFactoryToProxy}>
            var factoryType = typeof(ProxyDbProviderFactory<>).MakeGenericType(new[] { oringalFactoryType });

            //call static method Initialize to construct the instance
            factoryType.GetMethod("Initialize", BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static).Invoke(null, null);

            //retrieve the datarow in which we will alter the Type to the newly contructed ProxyType
            var dataRowToEdit = dbProvidersFactoriesDataTable.Rows.Cast<DataRow>().FirstOrDefault<DataRow>(dt => ((string) dt["InvariantName"]) == providerInvariantName);

            if (dataRowToEdit == null)
                return;

            //set readOnly false to edit table
            dbProvidersFactoriesDataTable.Columns["AssemblyQualifiedName"].ReadOnly = false;

            //map the DbProvider to the new proxy
            dataRowToEdit["AssemblyQualifiedName"] = factoryType.AssemblyQualifiedName;

            //set readOnly back to original
            dbProvidersFactoriesDataTable.Columns["AssemblyQualifiedName"].ReadOnly = true;
        }

        internal static void OnQueryExecuted(EfQueryEventArgs e)
        {
            var handler = QueryExecuted;
            if (handler != null)
                handler(null, e);
        }
    }
}