namespace Model.DTOs.Category
{
    public class CategoryOutputDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int ParentId { get; set; }
        public List<CategoryOutputDto> SubCategories { get; set; } = [];
    }

    public class CategoryDDLOutputDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int Level { get; set; }
    }
}
