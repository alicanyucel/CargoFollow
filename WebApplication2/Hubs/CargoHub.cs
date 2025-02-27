using Microsoft.AspNetCore.SignalR;

namespace WebApplication2.Hubs
{
    public class CargoHub : Hub
    {
        
        public async Task UpdateCargoStatus(string cargoId, string status)
        {
            await Clients.All.SendAsync("ReceiveCargoStatus", cargoId, status);
        }
    }
}
