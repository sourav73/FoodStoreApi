using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EntityModel
{
    [Table("Categories")]
    public class CategoryModel : BaseEntity<int>
    {
        [Required(ErrorMessage = "Name is required")]
        public string CategoryName { get; set; }
        public int ParentId { get; set; }
    }
}
