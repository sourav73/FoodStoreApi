using Model.DTOs.Account;

namespace Manager.Manager.BaseManager
{
    public interface IAccountManager
    {
        Task<bool> CreateAccount(AccountInputDto account);
        Task<List<AccountOutputDto>> GetAccounts();
        Task<bool> UpdateAccount(int id, AccountInputDto account);
        Task<bool> DeleteAccount(int id);
        Task<bool> CreateRole(RoleInputDto role);
        Task<List<RoleOutputDto>> GetRoles();
        Task<bool> UpdateRole(int id, RoleInputDto role);
        Task<bool> DeleteRole(int id);
    }
}
