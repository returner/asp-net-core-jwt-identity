namespace CqrsMediatR.Contracts
{
    public class GetWalletReadModelRequest
    {
        public int? UserId { get; set; }
        public int? MoneyType { get; set; }
    }
}
