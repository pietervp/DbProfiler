using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System;
using System.Runtime.Remoting;

namespace DbProfiler.Proxy
{
    public class ProxyDbDataAdapter : DbDataAdapter
    {
        public DbDataAdapter ProxiedDbDataAdapter { get; private set; }

        public ProxyDbDataAdapter(DbDataAdapter proxiedDbDataAdapter)
        {
            ProxiedDbDataAdapter = proxiedDbDataAdapter;
        }

        /// <summary>
        /// Retrieves the current lifetime service object that controls the lifetime policy for this instance.
        /// </summary>
        /// <returns>
        /// An object of type <see cref="T:System.Runtime.Remoting.Lifetime.ILease"/> used to control the lifetime policy for this instance.
        /// </returns>
        /// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission. </exception><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="RemotingConfiguration, Infrastructure"/></PermissionSet>
        public new object GetLifetimeService()
        {
            return ProxiedDbDataAdapter.GetLifetimeService();
        }

        /// <summary>
        /// Obtains a lifetime service object to control the lifetime policy for this instance.
        /// </summary>
        /// <returns>
        /// An object of type <see cref="T:System.Runtime.Remoting.Lifetime.ILease"/> used to control the lifetime policy for this instance. This is the current lifetime service object for this instance if one exists; otherwise, a new lifetime service object initialized to the value of the <see cref="P:System.Runtime.Remoting.Lifetime.LifetimeServices.LeaseManagerPollTime"/> property.
        /// </returns>
        /// <exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission. </exception><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="RemotingConfiguration, Infrastructure"/></PermissionSet>
        public override object InitializeLifetimeService()
        {
            return ProxiedDbDataAdapter.InitializeLifetimeService();
        }

        /// <summary>
        /// Creates an object that contains all the relevant information required to generate a proxy used to communicate with a remote object.
        /// </summary>
        /// <returns>
        /// Information required to generate a proxy.
        /// </returns>
        /// <param name="requestedType">The <see cref="T:System.Type"/> of the object that the new <see cref="T:System.Runtime.Remoting.ObjRef"/> will reference. </param><exception cref="T:System.Runtime.Remoting.RemotingException">This instance is not a valid remoting object. </exception><exception cref="T:System.Security.SecurityException">The immediate caller does not have infrastructure permission. </exception><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="Infrastructure"/></PermissionSet>
        public override ObjRef CreateObjRef(Type requestedType)
        {
            return ProxiedDbDataAdapter.CreateObjRef(requestedType);
        }

        /// <summary>
        /// Releases all resources used by the <see cref="T:System.ComponentModel.Component"/>.
        /// </summary>
        public new void Dispose()
        {
            ProxiedDbDataAdapter.Dispose();
        }

        /// <summary>
        /// Gets or sets the <see cref="T:System.ComponentModel.ISite"/> of the <see cref="T:System.ComponentModel.Component"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.ComponentModel.ISite"/> associated with the <see cref="T:System.ComponentModel.Component"/>, or null if the <see cref="T:System.ComponentModel.Component"/> is not encapsulated in an <see cref="T:System.ComponentModel.IContainer"/>, the <see cref="T:System.ComponentModel.Component"/> does not have an <see cref="T:System.ComponentModel.ISite"/> associated with it, or the <see cref="T:System.ComponentModel.Component"/> is removed from its <see cref="T:System.ComponentModel.IContainer"/>.
        /// </returns>
        public override ISite Site
        {
            get { return ProxiedDbDataAdapter.Site; }
            set { ProxiedDbDataAdapter.Site = value; }
        }

        /// <summary>
        /// Gets the <see cref="T:System.ComponentModel.IContainer"/> that contains the <see cref="T:System.ComponentModel.Component"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.ComponentModel.IContainer"/> that contains the <see cref="T:System.ComponentModel.Component"/>, if any, or null if the <see cref="T:System.ComponentModel.Component"/> is not encapsulated in an <see cref="T:System.ComponentModel.IContainer"/>.
        /// </returns>
        public new IContainer Container
        {
            get { return ProxiedDbDataAdapter.Container; }
        }

        public new event EventHandler Disposed
        {
            add { ProxiedDbDataAdapter.Disposed += value; }
            remove { ProxiedDbDataAdapter.Disposed -= value; }
        }

        /// <summary>
        /// Determines whether the <see cref="P:System.Data.Common.DataAdapter.AcceptChangesDuringFill"/> property should be persisted.
        /// </summary>
        /// <returns>
        /// true if the <see cref="P:System.Data.Common.DataAdapter.AcceptChangesDuringFill"/> property is persisted; otherwise false.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public override bool ShouldSerializeAcceptChangesDuringFill()
        {
            return ProxiedDbDataAdapter.ShouldSerializeAcceptChangesDuringFill();
        }

        /// <summary>
        /// Resets <see cref="P:System.Data.Common.DataAdapter.FillLoadOption"/> to its default state and causes <see cref="M:System.Data.Common.DataAdapter.Fill(System.Data.DataSet)"/> to honor <see cref="P:System.Data.Common.DataAdapter.AcceptChangesDuringFill"/>.
        /// </summary>
        /// <filterpriority>1</filterpriority>
        public new void ResetFillLoadOption()
        {
            ProxiedDbDataAdapter.ResetFillLoadOption();
        }

        /// <summary>
        /// Determines whether the <see cref="P:System.Data.Common.DataAdapter.FillLoadOption"/> property should be persisted.
        /// </summary>
        /// <returns>
        /// true if the <see cref="P:System.Data.Common.DataAdapter.FillLoadOption"/> property is persisted; otherwise false.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public override bool ShouldSerializeFillLoadOption()
        {
            return ProxiedDbDataAdapter.ShouldSerializeFillLoadOption();
        }

        /// <summary>
        /// Gets or sets a value indicating whether <see cref="M:System.Data.DataRow.AcceptChanges"/> is called on a <see cref="T:System.Data.DataRow"/> after it is added to the <see cref="T:System.Data.DataTable"/> during any of the Fill operations.
        /// </summary>
        /// <returns>
        /// true if <see cref="M:System.Data.DataRow.AcceptChanges"/> is called on the <see cref="T:System.Data.DataRow"/>; otherwise false. The default is true.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public new bool AcceptChangesDuringFill
        {
            get { return ProxiedDbDataAdapter.AcceptChangesDuringFill; }
            set { ProxiedDbDataAdapter.AcceptChangesDuringFill = value; }
        }

        /// <summary>
        /// Gets or sets whether <see cref="M:System.Data.DataRow.AcceptChanges"/> is called during a <see cref="M:System.Data.Common.DataAdapter.Update(System.Data.DataSet)"/>.
        /// </summary>
        /// <returns>
        /// true if <see cref="M:System.Data.DataRow.AcceptChanges"/> is called during an <see cref="M:System.Data.Common.DataAdapter.Update(System.Data.DataSet)"/>; otherwise false. The default is true.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public new bool AcceptChangesDuringUpdate
        {
            get { return ProxiedDbDataAdapter.AcceptChangesDuringUpdate; }
            set { ProxiedDbDataAdapter.AcceptChangesDuringUpdate = value; }
        }

        /// <summary>
        /// Gets or sets a value that specifies whether to generate an exception when an error is encountered during a row update.
        /// </summary>
        /// <returns>
        /// true to continue the update without generating an exception; otherwise false. The default is false.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public new bool ContinueUpdateOnError
        {
            get { return ProxiedDbDataAdapter.ContinueUpdateOnError; }
            set { ProxiedDbDataAdapter.ContinueUpdateOnError = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="T:System.Data.LoadOption"/> that determines how the adapter fills the <see cref="T:System.Data.DataTable"/> from the <see cref="T:System.Data.Common.DbDataReader"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Data.LoadOption"/> value.
        /// </returns>
        /// <filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/></PermissionSet>
        public new LoadOption FillLoadOption
        {
            get { return ProxiedDbDataAdapter.FillLoadOption; }
            set { ProxiedDbDataAdapter.FillLoadOption = value; }
        }

        /// <summary>
        /// Determines the action to take when incoming data does not have a matching table or column.
        /// </summary>
        /// <returns>
        /// One of the <see cref="T:System.Data.MissingMappingAction"/> values. The default is Passthrough.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">The value set is not one of the <see cref="T:System.Data.MissingMappingAction"/> values. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/></PermissionSet>
        public new MissingMappingAction MissingMappingAction
        {
            get { return ProxiedDbDataAdapter.MissingMappingAction; }
            set { ProxiedDbDataAdapter.MissingMappingAction = value; }
        }

        /// <summary>
        /// Determines the action to take when existing <see cref="T:System.Data.DataSet"/> schema does not match incoming data.
        /// </summary>
        /// <returns>
        /// One of the <see cref="T:System.Data.MissingSchemaAction"/> values. The default is Add.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">The value set is not one of the <see cref="T:System.Data.MissingSchemaAction"/> values. </exception><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/></PermissionSet>
        public new MissingSchemaAction MissingSchemaAction
        {
            get { return ProxiedDbDataAdapter.MissingSchemaAction; }
            set { ProxiedDbDataAdapter.MissingSchemaAction = value; }
        }

        /// <summary>
        /// Gets or sets whether the Fill method should return provider-specific values or common CLS-compliant values.
        /// </summary>
        /// <returns>
        /// true if the Fill method should return provider-specific values; otherwise false to return common CLS-compliant values.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override bool ReturnProviderSpecificTypes
        {
            get { return ProxiedDbDataAdapter.ReturnProviderSpecificTypes; }
            set { ProxiedDbDataAdapter.ReturnProviderSpecificTypes = value; }
        }

        /// <summary>
        /// Gets a collection that provides the master mapping between a source table and a <see cref="T:System.Data.DataTable"/>.
        /// </summary>
        /// <returns>
        /// A collection that provides the master mapping between the returned records and the <see cref="T:System.Data.DataSet"/>. The default value is an empty collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public new DataTableMappingCollection TableMappings
        {
            get { return ProxiedDbDataAdapter.TableMappings; }
        }

        public new event FillErrorEventHandler FillError
        {
            add { ProxiedDbDataAdapter.FillError += value; }
            remove { ProxiedDbDataAdapter.FillError -= value; }
        }

        /// <summary>
        /// Gets or sets an SQL statement used to select records in the data source.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Data.IDbCommand"/> that is used during <see cref="M:System.Data.Common.DbDataAdapter.Update(System.Data.DataSet)"/> to select records from data source for placement in the data set.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public new IDbCommand SelectCommand
        {
            get { return new ProxyDbCommand(ProxiedDbDataAdapter.SelectCommand); }
            set { ProxiedDbDataAdapter.SelectCommand = (value as ProxyDbCommand).ProxiedCommand; }
        }

        /// <summary>
        /// Gets or sets an SQL statement used to insert new records into the data source.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Data.IDbCommand"/> used during <see cref="M:System.Data.Common.DbDataAdapter.Update(System.Data.DataSet)"/> to insert records in the data source for new rows in the data set.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public new IDbCommand InsertCommand
        {
            get { return new ProxyDbCommand(ProxiedDbDataAdapter.InsertCommand); }
            set { ProxiedDbDataAdapter.InsertCommand = (value as ProxyDbCommand).ProxiedCommand; }
        }

        /// <summary>
        /// Gets or sets an SQL statement used to update records in the data source.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Data.IDbCommand"/> used during <see cref="M:System.Data.Common.DbDataAdapter.Update(System.Data.DataSet)"/> to update records in the data source for modified rows in the data set.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public new IDbCommand UpdateCommand
        {
            get { return new ProxyDbCommand(ProxiedDbDataAdapter.UpdateCommand); }
            set { ProxiedDbDataAdapter.UpdateCommand = (value as ProxyDbCommand).ProxiedCommand; }
        }

        /// <summary>
        /// Gets or sets an SQL statement for deleting records from the data set.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Data.IDbCommand"/> used during <see cref="M:System.Data.Common.DbDataAdapter.Update(System.Data.DataSet)"/> to delete records in the data source for deleted rows in the data set.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public new IDbCommand DeleteCommand
        {
            get { return new ProxyDbCommand(ProxiedDbDataAdapter.DeleteCommand); }
            set { ProxiedDbDataAdapter.DeleteCommand = (value as ProxyDbCommand).ProxiedCommand; }
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public new object Clone()
        {
            return ((ICloneable) ProxiedDbDataAdapter).Clone();
        }

        /// <summary>
        /// Configures the schema of the specified <see cref="T:System.Data.DataTable"/> based on the specified <see cref="T:System.Data.SchemaType"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Data.DataTable"/> that contains schema information returned from the data source.
        /// </returns>
        /// <param name="dataTable">The <see cref="T:System.Data.DataTable"/> to be filled with the schema from the data source. </param><param name="schemaType">One of the <see cref="T:System.Data.SchemaType"/> values. </param><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="ControlEvidence"/></PermissionSet>
        public new DataTable FillSchema(DataTable dataTable, SchemaType schemaType)
        {
            return ProxiedDbDataAdapter.FillSchema(dataTable, schemaType);
        }

        /// <summary>
        /// Adds a <see cref="T:System.Data.DataTable"/> named "Table" to the specified <see cref="T:System.Data.DataSet"/> and configures the schema to match that in the data source based on the specified <see cref="T:System.Data.SchemaType"/>.
        /// </summary>
        /// <returns>
        /// A reference to a collection of <see cref="T:System.Data.DataTable"/> objects that were added to the <see cref="T:System.Data.DataSet"/>.
        /// </returns>
        /// <param name="dataSet">A <see cref="T:System.Data.DataSet"/> to insert the schema in. </param><param name="schemaType">One of the <see cref="T:System.Data.SchemaType"/> values that specify how to insert the schema. </param><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="ControlEvidence"/></PermissionSet>
        public override DataTable[] FillSchema(DataSet dataSet, SchemaType schemaType)
        {
            return ProxiedDbDataAdapter.FillSchema(dataSet, schemaType);
        }

        /// <summary>
        /// Adds a <see cref="T:System.Data.DataTable"/> to the specified <see cref="T:System.Data.DataSet"/> and configures the schema to match that in the data source based upon the specified <see cref="T:System.Data.SchemaType"/> and <see cref="T:System.Data.DataTable"/>.
        /// </summary>
        /// <returns>
        /// A reference to a collection of <see cref="T:System.Data.DataTable"/> objects that were added to the <see cref="T:System.Data.DataSet"/>.
        /// </returns>
        /// <param name="dataSet">A <see cref="T:System.Data.DataSet"/> to insert the schema in. </param><param name="schemaType">One of the <see cref="T:System.Data.SchemaType"/> values that specify how to insert the schema. </param><param name="srcTable">The name of the source table to use for table mapping. </param><exception cref="T:System.ArgumentException">A source table from which to get the schema could not be found. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="ControlEvidence"/></PermissionSet>
        public new DataTable[] FillSchema(DataSet dataSet, SchemaType schemaType, string srcTable)
        {
            return ProxiedDbDataAdapter.FillSchema(dataSet, schemaType, srcTable);
        }

        /// <summary>
        /// Adds or refreshes rows in the <see cref="T:System.Data.DataSet"/>.
        /// </summary>
        /// <returns>
        /// The number of rows successfully added to or refreshed in the <see cref="T:System.Data.DataSet"/>. This does not include rows affected by statements that do not return rows.
        /// </returns>
        /// <param name="dataSet">A <see cref="T:System.Data.DataSet"/> to fill with records and, if necessary, schema. </param><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="ControlEvidence"/></PermissionSet>
        public override int Fill(DataSet dataSet)
        {
            return ProxiedDbDataAdapter.Fill(dataSet);
        }

        /// <summary>
        /// Adds or refreshes rows in the <see cref="T:System.Data.DataSet"/> to match those in the data source using the <see cref="T:System.Data.DataSet"/> and <see cref="T:System.Data.DataTable"/> names.
        /// </summary>
        /// <returns>
        /// The number of rows successfully added to or refreshed in the <see cref="T:System.Data.DataSet"/>. This does not include rows affected by statements that do not return rows.
        /// </returns>
        /// <param name="dataSet">A <see cref="T:System.Data.DataSet"/> to fill with records and, if necessary, schema. </param><param name="srcTable">The name of the source table to use for table mapping. </param><exception cref="T:System.SystemException">The source table is invalid. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="ControlEvidence"/></PermissionSet>
        public new int Fill(DataSet dataSet, string srcTable)
        {
            return ProxiedDbDataAdapter.Fill(dataSet, srcTable);
        }

        /// <summary>
        /// Adds or refreshes rows in a specified range in the <see cref="T:System.Data.DataSet"/> to match those in the data source using the <see cref="T:System.Data.DataSet"/> and <see cref="T:System.Data.DataTable"/> names.
        /// </summary>
        /// <returns>
        /// The number of rows successfully added to or refreshed in the <see cref="T:System.Data.DataSet"/>. This does not include rows affected by statements that do not return rows.
        /// </returns>
        /// <param name="dataSet">A <see cref="T:System.Data.DataSet"/> to fill with records and, if necessary, schema. </param><param name="startRecord">The zero-based record number to start with. </param><param name="maxRecords">The maximum number of records to retrieve. </param><param name="srcTable">The name of the source table to use for table mapping. </param><exception cref="T:System.SystemException">The <see cref="T:System.Data.DataSet"/> is invalid. </exception><exception cref="T:System.InvalidOperationException">The source table is invalid.-or- The connection is invalid. </exception><exception cref="T:System.InvalidCastException">The connection could not be found. </exception><exception cref="T:System.ArgumentException">The <paramref name="startRecord"/> parameter is less than 0.-or- The <paramref name="maxRecords"/> parameter is less than 0. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="ControlEvidence"/></PermissionSet>
        public new int Fill(DataSet dataSet, int startRecord, int maxRecords, string srcTable)
        {
            return ProxiedDbDataAdapter.Fill(dataSet, startRecord, maxRecords, srcTable);
        }

        /// <summary>
        /// Adds or refreshes rows in a specified range in the <see cref="T:System.Data.DataSet"/> to match those in the data source using the <see cref="T:System.Data.DataTable"/> name.
        /// </summary>
        /// <returns>
        /// The number of rows successfully added to or refreshed in the <see cref="T:System.Data.DataSet"/>. This does not include rows affected by statements that do not return rows.
        /// </returns>
        /// <param name="dataTable">The name of the <see cref="T:System.Data.DataTable"/> to use for table mapping. </param><exception cref="T:System.InvalidOperationException">The source table is invalid. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="ControlEvidence"/></PermissionSet>
        public new int Fill(DataTable dataTable)
        {
            return ProxiedDbDataAdapter.Fill(dataTable);
        }

        /// <summary>
        /// Adds or refreshes rows in a <see cref="T:System.Data.DataTable"/> to match those in the data source starting at the specified record and retrieving up to the specified maximum number of records.
        /// </summary>
        /// <returns>
        /// The number of rows successfully added to or refreshed in the <see cref="T:System.Data.DataTable"/>. This value does not include rows affected by statements that do not return rows.
        /// </returns>
        /// <param name="startRecord">The zero-based record number to start with. </param><param name="maxRecords">The maximum number of records to retrieve. </param><param name="dataTables">The <see cref="T:System.Data.DataTable"/> objects to fill from the data source.</param><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="ControlEvidence"/></PermissionSet>
        public new int Fill(int startRecord, int maxRecords, params DataTable[] dataTables)
        {
            return ProxiedDbDataAdapter.Fill(startRecord, maxRecords, dataTables);
        }

        /// <summary>
        /// Gets the parameters set by the user when executing an SQL SELECT statement.
        /// </summary>
        /// <returns>
        /// An array of <see cref="T:System.Data.IDataParameter"/> objects that contains the parameters set by the user.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public override IDataParameter[] GetFillParameters()
        {
            return ProxiedDbDataAdapter.GetFillParameters();
        }

        /// <summary>
        /// Calls the respective INSERT, UPDATE, or DELETE statements for each inserted, updated, or deleted row in the specified <see cref="T:System.Data.DataSet"/>.
        /// </summary>
        /// <returns>
        /// The number of rows successfully updated from the <see cref="T:System.Data.DataSet"/>.
        /// </returns>
        /// <param name="dataSet">The <see cref="T:System.Data.DataSet"/> used to update the data source. </param><exception cref="T:System.InvalidOperationException">The source table is invalid. </exception><exception cref="T:System.Data.DBConcurrencyException">An attempt to execute an INSERT, UPDATE, or DELETE statement resulted in zero records affected. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="ControlEvidence"/></PermissionSet>
        public override int Update(DataSet dataSet)
        {
            return ProxiedDbDataAdapter.Update(dataSet);
        }

        /// <summary>
        /// Calls the respective INSERT, UPDATE, or DELETE statements for each inserted, updated, or deleted row in the specified array of <see cref="T:System.Data.DataRow"/> objects.
        /// </summary>
        /// <returns>
        /// The number of rows successfully updated from the <see cref="T:System.Data.DataSet"/>.
        /// </returns>
        /// <param name="dataRows">An array of <see cref="T:System.Data.DataRow"/> objects used to update the data source. </param><exception cref="T:System.ArgumentNullException">The <see cref="T:System.Data.DataSet"/> is invalid. </exception><exception cref="T:System.InvalidOperationException">The source table is invalid. </exception><exception cref="T:System.SystemException">No <see cref="T:System.Data.DataRow"/> exists to update.-or- No <see cref="T:System.Data.DataTable"/> exists to update.-or- No <see cref="T:System.Data.DataSet"/> exists to use as a source. </exception><exception cref="T:System.Data.DBConcurrencyException">An attempt to execute an INSERT, UPDATE, or DELETE statement resulted in zero records affected. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="ControlEvidence"/></PermissionSet>
        public new int Update(DataRow[] dataRows)
        {
            return ProxiedDbDataAdapter.Update(dataRows);
        }

        /// <summary>
        /// Calls the respective INSERT, UPDATE, or DELETE statements for each inserted, updated, or deleted row in the specified <see cref="T:System.Data.DataTable"/>.
        /// </summary>
        /// <returns>
        /// The number of rows successfully updated from the <see cref="T:System.Data.DataTable"/>.
        /// </returns>
        /// <param name="dataTable">The <see cref="T:System.Data.DataTable"/> used to update the data source. </param><exception cref="T:System.ArgumentNullException">The <see cref="T:System.Data.DataSet"/> is invalid. </exception><exception cref="T:System.InvalidOperationException">The source table is invalid. </exception><exception cref="T:System.SystemException">No <see cref="T:System.Data.DataRow"/> exists to update.-or- No <see cref="T:System.Data.DataTable"/> exists to update.-or- No <see cref="T:System.Data.DataSet"/> exists to use as a source. </exception><exception cref="T:System.Data.DBConcurrencyException">An attempt to execute an INSERT, UPDATE, or DELETE statement resulted in zero records affected. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="ControlEvidence"/></PermissionSet>
        public new int Update(DataTable dataTable)
        {
            return ProxiedDbDataAdapter.Update(dataTable);
        }

        /// <summary>
        /// Calls the respective INSERT, UPDATE, or DELETE statements for each inserted, updated, or deleted row in the <see cref="T:System.Data.DataSet"/> with the specified <see cref="T:System.Data.DataTable"/> name.
        /// </summary>
        /// <returns>
        /// The number of rows successfully updated from the <see cref="T:System.Data.DataSet"/>.
        /// </returns>
        /// <param name="dataSet">The <see cref="T:System.Data.DataSet"/> to use to update the data source. </param><param name="srcTable">The name of the source table to use for table mapping. </param><exception cref="T:System.ArgumentNullException">The <see cref="T:System.Data.DataSet"/> is invalid. </exception><exception cref="T:System.InvalidOperationException">The source table is invalid. </exception><exception cref="T:System.Data.DBConcurrencyException">An attempt to execute an INSERT, UPDATE, or DELETE statement resulted in zero records affected. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="ControlEvidence"/></PermissionSet>
        public new int Update(DataSet dataSet, string srcTable)
        {
            return ProxiedDbDataAdapter.Update(dataSet, srcTable);
        }

        /// <summary>
        /// Gets or sets a value that enables or disables batch processing support, and specifies the number of commands that can be executed in a batch. 
        /// </summary>
        /// <returns>
        /// The number of rows to process per batch. Value isEffect0There is no limit on the batch size.1Disables batch updating.&gt; 1Changes are sent using batches of <see cref="P:System.Data.Common.DbDataAdapter.UpdateBatchSize"/> operations at a time.When setting this to a value other than 1 ,all the commands associated with the <see cref="T:System.Data.Common.DbDataAdapter"/> must have their <see cref="P:System.Data.IDbCommand.UpdatedRowSource"/> property set to None or OutputParameters. An exception will be thrown otherwise. 
        /// </returns>
        /// <filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/></PermissionSet>
        public override int UpdateBatchSize
        {
            get { return ProxiedDbDataAdapter.UpdateBatchSize; }
            set { ProxiedDbDataAdapter.UpdateBatchSize = value; }
        }
    }
}