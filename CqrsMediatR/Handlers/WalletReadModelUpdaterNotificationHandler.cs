using CqrsMediatR.Data;
using CqrsMediatR.Notifications;
using MediatR;

namespace CqrsMediatR.Handlers
{
    public class WalletReadModelUpdaterNotificationHandler : INotificationHandler<WalletChangedNotification>
    {
        private readonly ISampleDataStore _sampleDataStore;
        public WalletReadModelUpdaterNotificationHandler(ISampleDataStore sampleDataStore) => _sampleDataStore = sampleDataStore;

        public async Task Handle(WalletChangedNotification notification, CancellationToken cancellationToken)
        {
            await _sampleDataStore.UpdateWalletReadModel(notification.walletWriteModel);
        }
    }
}
