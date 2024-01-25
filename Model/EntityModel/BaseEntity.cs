using System.ComponentModel.DataAnnotations;

namespace Model.EntityModel
{
    public class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }
        [Required]
        public int RStatus { get; set; }
    }
}
