using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EntityModel.Payment
{
    [Table("Receipts")]
    public class ReceiptModel : BaseEntity<int>
    {
        public string ReceiptNo { get; set; }
        public int FkInvoiceId { get; set; }
        [ForeignKey(nameof(FkInvoiceId))]
        public InvoiceModel Invoice { get; set; }
        public string TransactionId { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
