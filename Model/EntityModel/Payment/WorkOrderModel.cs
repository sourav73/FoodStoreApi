using Model.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EntityModel.Payment
{
    [Table("WorkOrders")]
    public class WorkOrderModel : BaseEntity<int>
    {
        public string WorkOrderNo { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int FkCustomerId { get; set; }
        [ForeignKey(nameof(FkCustomerId))]
        public CustomerModel Customer { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
