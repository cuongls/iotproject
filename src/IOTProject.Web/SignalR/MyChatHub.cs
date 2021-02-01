using Abp.Dependency;
using Abp.Runtime.Session;
using Castle.Core.Logging;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace IOTProject.Web.SignalR
{
    public class MyChatHub : Hub, ITransientDependency
    {
        public IAbpSession AbpSession { get; set; }

        public ILogger Logger { get; set; }

        public MyChatHub()
        {
            AbpSession = NullAbpSession.Instance;
            Logger = NullLogger.Instance;
        }

        public void SendMessage(string message)
        {
            Clients.All.getMessage(string.Format("User {0}: {1}", AbpSession.UserId, message));
            Logger.Debug(Context.ConnectionId + " send:" + message);
        }
        public async Task SendMessage2(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public async override Task OnConnected()
        {
            await base.OnConnected();
            Logger.Debug("A client connected to MyChatHub: " + Context.ConnectionId);
        }

        public async override Task OnDisconnected(bool stopCalled)
        {
            await base.OnDisconnected(stopCalled);
            Logger.Debug("A client disconnected from MyChatHub: " + Context.ConnectionId);
        }
    }
}