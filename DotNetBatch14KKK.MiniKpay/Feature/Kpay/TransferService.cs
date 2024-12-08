using DotNetBatch14KKK.MiniKpay.Feature.Kpay;
using Microsoft.EntityFrameworkCore;

namespace DotNetBatch14KKK.MiniKpay.Feature.Kpay
{
    public class TransferService
    {
        public AppDbContext db = new AppDbContext();
        public ResponseModel CreateTransaction(TransactionModel requestTransactionModel, int Password)
        {
            ResponseModel model = new ResponseModel();
            requestTransactionModel.TransactionDate = DateTime.Now;

            string toMobileNo = requestTransactionModel.ToMobileNo!;
            string fromMobileNo = requestTransactionModel.FromMobileNo!;
            decimal amount = requestTransactionModel.Amount;
            int password = Password;

            var SendUserData = GetUserData(fromMobileNo);
            if (SendUserData is null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = $"{fromMobileNo} doesn't create the bank account"
                };
            }
            if (SendUserData.Password != password)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = "Invalid password"
                };
            }
            if (amount > SendUserData.Balance)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = "The balance is insufficient"
                };
            }
            var ReceiveUserData = GetUserData(toMobileNo);
            if (ReceiveUserData is null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = $"{toMobileNo} doesn't create the bank account"
                };
            }
            SendUserData.Balance -= amount;
            ReceiveUserData.Balance += amount;

            db.Users.Entry(SendUserData).State = EntityState.Modified;
            db.Users.Entry(ReceiveUserData).State = EntityState.Modified;

            db.Transactions.Add(requestTransactionModel);
            int result = db.SaveChanges();

            string message = result > 0 ? "Create success" : "Create fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public UserModel GetUserData(string MobileNo)
        {
            string mobileNo = MobileNo.Trim();
            var UserData = db.Users.AsNoTracking().FirstOrDefault(x => x.MobileNo == mobileNo);
            return UserData!;
        }

        public List<TransactionModel> GetTransaction(string MobileNo)
        {
            var lst = db.Transactions.AsNoTracking().Where(x => x.ToMobileNo == MobileNo || x.FromMobileNo == MobileNo).ToList();
            return lst;
        }
    }
}

