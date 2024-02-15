
namespace Model.DTOs.Account
{
    public class CustomerDto
    {
    }

    public class CustomerInputDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } = string.Empty;
        public string Phone { get; set; }
        public string Address { get; set; }
    }

    public class CustomerOutputDto : CustomerInputDto
    {
        public int Id { get; set; }
    }
}
