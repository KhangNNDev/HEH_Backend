﻿using Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Services.ClaimExtensions;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;

namespace Services.Hubs
{
    public interface INotificationHub
    {
        Task NewNotification(NotificationModel model, string userId);
        Task NewNotificationCount(int count, string userId);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    public class NotificationHub : Hub, INotificationHub
    {
        public static ConcurrentDictionary<string, List<string>> ConnectedUsers = new ConcurrentDictionary<string, List<string>>();
        public IHubContext<NotificationHub> Current { get; set; }

        public NotificationHub(IHubContext<NotificationHub> current)
        {
            Current = current;
        }

        public async Task NewNotification(NotificationModel model, string userId)
        {
            try
            {
                List<string> ReceiverConnectionids;
                ConnectedUsers.TryGetValue(userId, out ReceiverConnectionids);
                await Current.Clients.Clients(ReceiverConnectionids).SendAsync("newNotify", model);
            }
            catch (Exception) { }
        }

        public async Task NewNotificationCount(int count, string userId)
        {
            try
            {
                List<string> ReceiverConnectionids;
                ConnectedUsers.TryGetValue(userId, out ReceiverConnectionids);
                await Current.Clients.Clients(ReceiverConnectionids).SendAsync("newNotifyCount", count);
            }
            catch (Exception) { }
        }

        public override Task OnConnectedAsync()
        {
            Trace.TraceInformation("MapHub started. ID: {0}", Context.ConnectionId);

            List<string> existingUserConnectionIds;
            ConnectedUsers.TryGetValue(Context.User.GetId(), out existingUserConnectionIds);

            if (existingUserConnectionIds == null)
            {
                existingUserConnectionIds = new List<string>();
            }

            existingUserConnectionIds.Add(Context.ConnectionId);
            ConnectedUsers.TryAdd(Context.User.GetId(), existingUserConnectionIds);
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            List<string> existingUserConnectionIds;
            ConnectedUsers.TryGetValue(Context.User.GetId(), out existingUserConnectionIds);

            existingUserConnectionIds.Remove(Context.ConnectionId);
            if (existingUserConnectionIds.Count == 0)
            {
                List<string> garbage;
                ConnectedUsers.TryRemove(Context.User.GetId(), out garbage);
            }
            return base.OnDisconnectedAsync(exception);
        }

    }
}
