using CqrsMediatR.Command;
using CqrsMediatR.Data;
using CqrsMediatR.Model;
using MediatR;

namespace CqrsMediatR.Handlers
{
    public class AddWalletHandler : IRequestHandler<AddWalletCommand, WalletWriteModel>
    {
        private readonly ISampleDataStore _sampleDataStore;

        public AddWalletHandler(ISampleDataStore sampleDataStore)
        {
            _sampleDataStore = sampleDataStore;
        }

        public async Task<WalletWriteModel> Handle(AddWalletCommand request, CancellationToken cancellationToken)
        {
            return await _sampleDataStore.AddWallet(request.walletWriteModel);
        }
    }
}
