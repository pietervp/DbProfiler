using System.Collections.Generic;
using System;
using DbProfiler.Output;
using DbProfiler.Proxy;
using Van.Parys.Data.Common;

namespace DbProfiler
{
    public class GenericProfiler : IProfiler
    {
        private readonly IProfileOutput _profileOutput;

        public GenericProfiler(ProfilingOptions implementation)
        {
            Implementation = implementation;
            _profileOutput = Implementation.CreateOutput();
        }
        
        public void CommandExecute(ProxyDbCommand command, TimeSpan duration, ExecuteMethod method, List<QueryExecutionPlan> executionPlan, object result = null)
        {
            _profileOutput.CommandExecute(command, duration, method, executionPlan, result);
        }

        public void ContextAttached(string contextName)
        {
            _profileOutput.ContextAttached(contextName);
        }

        public void ConnectionChanged(ProxyDbConnection connection)
        {
            _profileOutput.ConnectionChanged(connection);
        }

        public ProfilingOptions Implementation
        {
            get;
            private set;
        }
    }
}