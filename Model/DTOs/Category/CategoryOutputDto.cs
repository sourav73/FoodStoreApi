namespace Model.DTOs.Category
{
    public class CategoryOutputDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<SubCategoriesOutputDto> SubCategories { get; set; } = [];
    }

    public class SubCategoriesOutputDto : CategoryInputDto
    {
        public int Id { get; set; }
        public List<SubCategoriesOutputDto> SubCategories { get; set; } = [];
    }
}
