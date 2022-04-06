using CqrsMediatR.Model;
using MediatR;

namespace CqrsMediatR.Queries
{
    public record GetWalletQuery(GetWalletReadModelRequest getWalletReadModelRequest) : IRequest<List<WalletReadModel>>;
}
