using Microsoft.AspNetCore.SignalR;

namespace ChartsSignalRAndBlazor.Server.Hubs;

public class SatisHub : Hub
{
    public async Task SendMessageAsync()
    {
        await Clients.All.SendAsync("receiveMessage", "Merhaba");
    }
}
