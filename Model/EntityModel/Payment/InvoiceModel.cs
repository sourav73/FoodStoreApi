using Model.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EntityModel.Payment
{
    [Table("Invoices")]
    public class InvoiceModel : BaseEntity<int>
    {
        public string InvoiceNo { get; set; }
        public int FkWorkOrderId { get; set; }
        [ForeignKey(nameof(FkWorkOrderId))]
        public WorkOrderModel WorkOrder { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string DeliveryAddress { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
    }
}
