using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Chat.API.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendMessageToGroup(Response response)
        {
            await Clients.Group(response.Group).SendAsync("ReceiveMessage", response.User, response.Message);
        }

        public async Task AddToGroup(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
        }
    }

    public class Response
    {
        public string User { get; set; }
        public string Message { get; set; }
        public string Group { get; set; }
    }
}
