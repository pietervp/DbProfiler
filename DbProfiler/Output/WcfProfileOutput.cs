using System.Collections.Generic;
using System.Data;
using System;
using System.ServiceModel;
using DbProfiler.Proxy;
using Van.Parys.Data.Common;

namespace DbProfiler.Output
{
    public class WcfProfileOutput : IProfileOutput
    {
        private object mutex = new object();
        private ChannelFactory<IProfilingService> profilingServiceClient;
        private bool endPointConnected = false;
        private const int reconnectAfter = 5;
        private int noConnectCounter = 0;

        public WcfProfileOutput()
        {
            Init();
        }

        private void Init()
        {
            profilingServiceClient = CreateChannelFactory();
            endPointConnected = true;

            try
            {
                profilingServiceClient.Open();
            }
            catch (CommunicationObjectFaultedException ex)
            {
                endPointConnected = false;
            }
        }

        internal ChannelFactory<IProfilingService> CreateChannelFactory()
        {
            var binding = new NetTcpBinding();

            binding.SendTimeout = TimeSpan.FromMinutes(1);
            binding.OpenTimeout = TimeSpan.FromMinutes(1);
            binding.CloseTimeout = TimeSpan.FromMinutes(1);
            binding.ReceiveTimeout = TimeSpan.FromMinutes(10);
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            binding.TransferMode = TransferMode.Buffered;

            var myChannelFactory = new ChannelFactory<IProfilingService>(binding, new EndpointAddress("net.tcp://localhost:6000"));

            return myChannelFactory;
        }

        internal bool IsAvailable()
        {
            lock (mutex)
            {
                if (endPointConnected) return true;

                noConnectCounter++;

                if (noConnectCounter == reconnectAfter)
                {
                    noConnectCounter = 0;
                    Init();
                    return endPointConnected;
                }
                else
                {
                    return false;
                }
            }
        }

        private IProfilingService GetChannel()
        {
            return profilingServiceClient.CreateChannel();
        }

        #region Implementation of IProfileOutput

        public void CommandExecute(ProxyDbCommand command, TimeSpan duration, ExecuteMethod method, List<QueryExecutionPlan> executionPlan, object result)
        {
            if (!IsAvailable()) return;

            var commandMessage = new CommandMessage(command.CommandText, duration, method.ToString(), command.ProxyDbConnection.Context) { QueryExecutionPlans = executionPlan };

            GetChannel().CommandExecute(commandMessage);
        }

        public void ContextAttached(string contextName)
        {
            if (!IsAvailable()) return;

            GetChannel().ContextAttached(contextName);
        }

        public void ConnectionChanged(ProxyDbConnection connection)
        {
            if (!IsAvailable()) return;

            GetChannel().ConnectionChanged(new ConnectionMessage() { ConnectionGUID = connection.Context, Open = connection.State == ConnectionState.Open });
        }

        #endregion
    }
}