using System;
using System.Collections.Generic;
using DbProfiler.Proxy;
using Van.Parys.Data.Common;

namespace DbProfiler
{
    public interface IProfiler
    {
        void CommandExecute(ProxyDbCommand command, TimeSpan duration, ExecuteMethod method, List<QueryExecutionPlan> executionPlan, object result = null);
        void ContextAttached(string contextName);
        void ConnectionChanged(ProxyDbConnection connection);
        ProfilingOptions Implementation { get; }
    }
}