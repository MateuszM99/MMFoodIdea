using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMFoodIdea.Hubs
{
    public class CommentHub : Hub
    {
        public async Task PostComment(string message)
        {
            await Clients.All.SendAsync("Recive Comment", message);
        }
    }
}
