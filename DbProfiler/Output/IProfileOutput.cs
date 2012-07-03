using System.Collections.Generic;
using System;
using DbProfiler.Proxy;
using Van.Parys.Data.Common;

namespace DbProfiler.Output
{
    public interface IProfileOutput
    {
        void CommandExecute(ProxyDbCommand command, TimeSpan duration, ExecuteMethod method, List<QueryExecutionPlan> executionPlan, object result);
        void ContextAttached(string contextName);
        void ConnectionChanged(ProxyDbConnection connection);
    }
}