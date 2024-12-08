using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DotNetBatch14KKK.MiniKpay.Feature.Kpay
{
    [Table("tbl_user")]
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? MobileNo { get; set; }
        public decimal? Balance { get; set; }
        public int? Password { get; set; }
    }
}
