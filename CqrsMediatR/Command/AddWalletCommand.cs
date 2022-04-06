using CqrsMediatR.Model;
using MediatR;

namespace CqrsMediatR.Command
{
    public record AddWalletCommand(WalletWriteModel walletWriteModel) : IRequest<WalletWriteModel>;
}
