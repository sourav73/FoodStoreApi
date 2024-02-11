namespace Model.DTOs.Account
{
    public class RoleInputDto
    {
        public string RoleName { get; set; }
    }

    public class RoleOutputDto : RoleInputDto
    {
        public int Id { get; set; }
    }
}
