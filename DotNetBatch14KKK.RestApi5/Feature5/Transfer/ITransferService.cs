
namespace DotNetBatch14KKK.RestApi5.Feature5.Transfer
{
    public interface ITransferService
    {
        TransferResponseModel CreateTransaction(TransactionModel requestTransactionModel, int Password);
        TransferResponseModel CreateUser(UserModel user);
        List<TransactionModel> GetTransaction(string MobileNo);
        UserModel GetUserData(string MobileNo);
    }
}