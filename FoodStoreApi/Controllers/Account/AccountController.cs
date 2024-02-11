using Manager.Manager.BaseManager;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs.Account;
using Model.DTOs.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodStoreApi.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("A collection of Account APIs")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountManager _accountManager;
        public AccountController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all accounts")]
        public async Task<ListResponse<AccountOutputDto>> GetAccounts()
        {
            List<AccountOutputDto> accounts = await _accountManager.GetAccounts();
            return new ListResponse<AccountOutputDto> { Data = accounts, Message = "Data found" };
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create account")]
        public async Task<ObjectResponse<bool>> CreateAccount(AccountInputDto account)
        {
            bool isCreated = await _accountManager.CreateAccount(account);
            return new ObjectResponse<bool> { Data = isCreated, Message = isCreated ? "Account created" : "Account creating failed" };
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update account")]
        public async Task<ObjectResponse<bool>> UpdateAccount(int id, AccountInputDto account)
        {
            bool isUpdated = await _accountManager.UpdateAccount(id, account);
            return new ObjectResponse<bool> { Data = isUpdated, Message = isUpdated ? "Account updated" : "Account updating failed" };
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete account")]
        public async Task<ObjectResponse<bool>> DeleteAccount(int id)
        {
            bool isDeleted = await _accountManager.DeleteAccount(id);
            return new ObjectResponse<bool> { Data = isDeleted, Message = isDeleted ? "Account deleted" : "Account deleting failed" };
        }

        #region Role apis

        [HttpGet("/api/role")]
        [SwaggerOperation(Summary = "Get all roles")]
        public async Task<ListResponse<RoleOutputDto>> GetRoles()
        {
            List<RoleOutputDto> roles = await _accountManager.GetRoles();
            return new ListResponse<RoleOutputDto> { Data = roles, Message = "Data found" };
        }

        [HttpPost("/api/role")]
        [SwaggerOperation(Summary = "Create role")]
        public async Task<ObjectResponse<bool>> CreateRole(RoleInputDto role)
        {
            bool isCreated = await _accountManager.CreateRole(role);
            return new ObjectResponse<bool> { Data = isCreated, Message = isCreated ? "Role created" : "Role creating failed" };
        }

        [HttpPut("/api/role/{id}")]
        [SwaggerOperation(Summary = "Update role")]
        public async Task<ObjectResponse<bool>> UpdateRole(int id, RoleInputDto role)
        {
            bool isUpdated = await _accountManager.UpdateRole(id, role);
            return new ObjectResponse<bool> { Data = isUpdated, Message = isUpdated ? "Role updated" : "Role updating failed" };
        }

        [HttpDelete("/api/role/{id}")]
        [SwaggerOperation(Summary = "Delete role")]
        public async Task<ObjectResponse<bool>> DeleteRole(int id)
        {
            bool isDeleted = await _accountManager.DeleteRole(id);
            return new ObjectResponse<bool> { Data = isDeleted, Message = isDeleted ? "Role deleted" : "Role deleting failed" };
        }

        #endregion
    }
}
