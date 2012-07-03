using System.Linq;
using System;

namespace Van.Parys.Data.Common
{
    public interface IProfilingService
    {
        void CommandExecute(CommandMessage message);

        void ContextAttached(string contextName);
        
        void ConnectionChanged(ConnectionMessage message);
    }
}