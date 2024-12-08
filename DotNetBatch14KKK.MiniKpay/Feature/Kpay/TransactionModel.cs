using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DotNetBatch14KKK.MiniKpay.Feature.Kpay
{
    [Table("tbl_transaction")]
    public class TransactionModel
    {
        [Key]
        public int TransactionId { get; set; }
        public string? FromMobileNo { get; set; }
        public string? ToMobileNo { get; set; }
        public decimal Amount { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string Notes { get; set; }
    }
}
