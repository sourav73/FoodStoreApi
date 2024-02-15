namespace Model.EntityModel
{
    public class CustomerModel : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } = string.Empty;
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
