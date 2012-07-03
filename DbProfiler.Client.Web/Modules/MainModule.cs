using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DbProfiler.Client.Web.Hubs;
using Nancy;
using Nancy.ModelBinding;
using SignalR;
using SignalR.Hubs;
using Van.Parys.Data.Common;

namespace DbProfiler.Client.Web.Modules
{
    public class MainModule : Nancy.NancyModule
    {
        public MainModule()
        {
            Post["/cmd/{session}/commandmsg"] = o =>
                                                  {
                                                      var commandMessage = this.Bind<CommandMessage>();

                                                      GlobalHost.ConnectionManager.GetHubContext<DbProfilerHub>().Clients.commandMessage(commandMessage);

                                                      return HttpStatusCode.OK;
                                                  };

            Post["/cmd/{session}/connectionmsg"] = o =>
                                                       {
                                                           var connectionMessage = this.Bind<ConnectionMessage>();

                                                           GlobalHost.ConnectionManager.GetHubContext<DbProfilerHub>().Clients.commandMessage(connectionMessage);

                                                           return HttpStatusCode.OK;
                                                       };

            Get["/"] = o => View[new IndexViewModel()];
        }
    }
}