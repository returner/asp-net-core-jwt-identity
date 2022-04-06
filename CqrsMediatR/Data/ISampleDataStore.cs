using CqrsMediatR.Model;

namespace CqrsMediatR.Data
{
    public interface ISampleDataStore
    {
        Task<WalletWriteModel> AddWallet(WalletWriteModel walletWriteModel);
        Task<List<WalletReadModel>> GetWalletReadModels(GetWalletReadModelRequest getWalletReadModelRequest);
        Task SetPublishedEvent(WalletWriteModel walletWriteModel, string eventName);
        Task UpdateWalletReadModel(WalletWriteModel walletWriteModel);
    }
}
