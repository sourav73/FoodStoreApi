using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EntityModel.Payment
{
    [Table("WorkOrderDetails")]
    public class WorkOrderDetailsModel : BaseEntity<int>
    {
        public int FkWorkOrderId { get; set; }
        [ForeignKey(nameof(FkWorkOrderId))]
        public WorkOrderModel WorkOrder { get; set; }
        public int FkProductId { get; set; }
        [ForeignKey(nameof(FkProductId))]
        public ProductModel Product { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountedPrice { get; set; }
    }
}
