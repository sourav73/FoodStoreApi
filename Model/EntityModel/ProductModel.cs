using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EntityModel
{
    [Table("Products")]
    public class ProductModel : BaseEntity<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int FkCategoryId { get; set; }
        [ForeignKey(nameof(FkCategoryId))]
        public CategoryModel Category { get; set; }
        public string? ImagePath { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Discount { get; set; }
    }
}
