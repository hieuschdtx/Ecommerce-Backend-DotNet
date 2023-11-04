using MediatR;
using Microsoft.AspNetCore.SignalR;
using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Behaviors
{
    public class DataChangeNotification : INotification
    {
    }
    public class DataChangeNotificationHandler : INotificationHandler<DataChangeNotification>
    {
        private readonly IHubContext<DataHub> _hubContext;

        public DataChangeNotificationHandler(IHubContext<DataHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task Handle(DataChangeNotification notification, CancellationToken cancellationToken)
        {
            await _hubContext.Clients.All.SendAsync("RELOAD_DATA_CHANGE", cancellationToken);
        }
    }
}
