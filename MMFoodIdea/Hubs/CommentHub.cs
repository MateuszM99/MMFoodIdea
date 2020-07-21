using Microsoft.AspNetCore.SignalR;
using MMFI_Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMFoodIdea.Hubs
{
    public class CommentHub : Hub
    {
        public async Task PostComment(Comment comment)
        {
            await Clients.All.SendAsync("reciveComment", comment);
        }
    }
}
