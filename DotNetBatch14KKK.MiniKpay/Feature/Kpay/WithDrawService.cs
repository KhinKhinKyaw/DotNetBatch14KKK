using Microsoft.EntityFrameworkCore;


namespace DotNetBatch14KKK.MiniKpay.Feature.Kpay
{
    public class WithDrawService
    {
        public AppDbContext db = new AppDbContext();

        public ResponseModel WidthDraw(string MobileNo, decimal Amount, int password)
        {
            UserModel userData = GetUserData(MobileNo);
            ResponseModel model = new ResponseModel();
            if (userData is null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = $"Invalid Mobile Number"
                };
            }
            if (userData.Password != password)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = "Invalid password"
                };
            }
            if (Amount > userData.Balance)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = "The balance is insufficient"
                };
            }
            userData.Balance -= Amount;

            db.Users.Entry(userData).State = EntityState.Modified;
            int result = db.SaveChanges();

            string message = result > 0 ? "Update success" : "Update fail";
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
    }
}

