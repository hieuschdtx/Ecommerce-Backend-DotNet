using Microsoft.AspNetCore.SignalR;

namespace shopecommerce.Domain.Commons
{
    public class DataHub : Hub
    {
        public async Task SendDataChangeNotification()
        {
            await Clients.All.SendAsync("RELOAD_DATA_CHANGE");
            await Task.Delay(5000);
        }
    }
}
