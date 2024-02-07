namespace Model.DTOs.Product
{
    public class ProductInputOutputDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int FkCategoryId { get; set; }
        public string? ImagePath { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Discount { get; set; }
    }
}
