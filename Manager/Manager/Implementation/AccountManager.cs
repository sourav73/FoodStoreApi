using Manager.Manager.BaseManager;
using Microsoft.EntityFrameworkCore;
using Model.DTOs.Account;
using Model.EntityModel;
using Model.Enum;
using Repository.Repository.BaseRepository;
using Utilities.Exceptions;

namespace Manager.Manager.Implementation
{
    public class AccountManager : IAccountManager
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IRoleRepository _roleRepository;
        public AccountManager(IAccountRepository accountRepository, IRoleRepository roleRepository)
        {
            _accountRepository = accountRepository;
            _roleRepository = roleRepository;
        }

        public async Task<bool> CreateAccount(AccountInputDto account)
        {
            UserModel user = new UserModel
            {
                Name = account.Name,
                Email = account.Email,
                Phone = account.Phone,
                Address = account.Address,
                FkRoleId = account.FkRoleId
            };
            _accountRepository.Create(user);
            return await _accountRepository.SaveAsync();
        }

        public async Task<List<AccountOutputDto>> GetAccounts()
        {
            List<AccountOutputDto> accounts = await _accountRepository.FindByCondition(a =>
                    a.RStatus == (int)EnumRStatus.Active)
                .Select(a => new AccountOutputDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Email = a.Email,
                    Phone = a.Phone,
                    Address = a.Address,
                    FkRoleId = a.FkRoleId
                }).ToListAsync();
            return accounts;
        }

        public async Task<bool> UpdateAccount(int id, AccountInputDto account)
        {
            UserModel? user = _accountRepository.FindByCondition(a => a.Id == id).FirstOrDefault();
            if (user == null)
            {
                throw new BadRequestException("User not found");
            }

            user.Name = account.Name;
            user.Email = account.Email;
            user.Phone = account.Phone;
            user.Address = account.Address;
            user.FkRoleId = account.FkRoleId;
            return await _accountRepository.SaveAsync();
        }

        public async Task<bool> DeleteAccount(int id)
        {
            UserModel? user = _accountRepository.FindByCondition(a => a.Id == id).FirstOrDefault();
            if (user == null)
            {
                throw new BadRequestException("User not found");
            }

            _accountRepository.Delete(user);
            return await _accountRepository.SaveAsync();
        }

        #region Role methods
        public async Task<bool> CreateRole(RoleInputDto role)
        {
            RoleModel newRole = new RoleModel
            {
                RoleName = role.RoleName
            };

            _roleRepository.Create(newRole);
            return await _roleRepository.SaveAsync();
        }

        public async Task<List<RoleOutputDto>> GetRoles()
        {
            List<RoleOutputDto> roles = await _roleRepository.FindByCondition(r =>
                    r.RStatus == (int)EnumRStatus.Active
                ).Select(r => new RoleOutputDto
                {
                    Id = r.Id,
                    RoleName = r.RoleName
                }).ToListAsync();
            return roles;
        }

        public async Task<bool> UpdateRole(int id, RoleInputDto role)
        {
            RoleModel? existingRole = _roleRepository.FindByCondition(r => r.Id == id).FirstOrDefault();
            if (existingRole == null)
            {
                throw new BadRequestException("Role not found");
            }

            existingRole.RoleName = role.RoleName;
            return await _roleRepository.SaveAsync();
        }

        public async Task<bool> DeleteRole(int id)
        {
            RoleModel? role = _roleRepository.FindByCondition(r => r.Id == id).FirstOrDefault();
            if (role == null)
            {
                throw new BadRequestException("Role not found");
            }

            _roleRepository.Delete(role);
            return await _roleRepository.SaveAsync();
        }
        #endregion
    }
}
