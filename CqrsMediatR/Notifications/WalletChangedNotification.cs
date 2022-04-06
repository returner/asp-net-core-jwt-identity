using CqrsMediatR.Model;
using MediatR;

namespace CqrsMediatR.Notifications
{
    public record WalletChangedNotification(WalletWriteModel walletWriteModel) : INotification;
}
