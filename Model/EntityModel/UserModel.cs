using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EntityModel
{
    public class UserModel : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } = string.Empty;
        public string Phone { get; set; }
        public string Address { get; set; }
        public int? FkRoleId { get; set; }
        [ForeignKey(nameof(FkRoleId))]
        public RoleModel Role { get; set; }
    }
}
