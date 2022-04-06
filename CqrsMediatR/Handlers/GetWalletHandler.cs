using CqrsMediatR.Data;
using CqrsMediatR.Model;
using CqrsMediatR.Queries;
using MediatR;

namespace CqrsMediatR.Handlers
{
    public class GetWalletHandler : IRequestHandler<GetWalletQuery, List<WalletReadModel>>
    {
        private readonly ISampleDataStore _sampleDataStore;

        public GetWalletHandler (ISampleDataStore sampleDataStore) => _sampleDataStore = sampleDataStore;

        public async Task<List<WalletReadModel>> Handle (GetWalletQuery request, CancellationToken cancellationToken)
        {
            return await _sampleDataStore.GetWalletReadModels(request.getWalletReadModelRequest);
        }
    }
}
