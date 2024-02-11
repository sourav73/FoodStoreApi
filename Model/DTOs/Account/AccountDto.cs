namespace Model.DTOs.Account
{
    public class AccountInputDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }

    public class AccountOutputDto : AccountInputDto
    {
        public int Id { get; set; }
    }
}
