using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System;
using DbProfiler.Proxy;
using Van.Parys.Data.Common;

namespace DbProfiler.Output
{
    public class DebugProfileOutput: IProfileOutput
    {
        #region Implementation of IProfileOutput

        public void CommandExecute(ProxyDbCommand command, TimeSpan duration, ExecuteMethod method, List<QueryExecutionPlan> executionPlan, object result)
        {
            var commandMessage = new Van.Parys.Data.Common.CommandMessage(command.CommandText, duration, method.ToString(), command.ProxyDbConnection.Guid) {QueryExecutionPlans = executionPlan, NonReaderResult = result};
            Debug.WriteLine(commandMessage.ToString());
        }

        public void ContextAttached(string contextName)
        {
            Debug.WriteLine(string.Format("{0} Attached!", contextName));
        }

        public void ConnectionChanged(ProxyDbConnection connection)
        {
            var connectionMessage = new ConnectionMessage() {ConnectionGUID = connection.Guid, Open = connection.State == ConnectionState.Open};
            Debug.WriteLine(connectionMessage.ToString());
        }

        #endregion
    }
}