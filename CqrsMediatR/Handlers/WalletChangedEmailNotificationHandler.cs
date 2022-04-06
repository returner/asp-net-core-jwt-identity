using CqrsMediatR.Notifications;
using MediatR;

namespace CqrsMediatR.Handlers
{
    public class WalletChangedEmailNotificationHandler : INotificationHandler<WalletChangedNotification>
    {
        public async Task Handle(WalletChangedNotification notification, CancellationToken cancellationToken)
        {
            // send email
            await Task.CompletedTask;
        }
    }
}
