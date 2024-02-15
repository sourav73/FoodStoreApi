using Model.DTOs.Account;

namespace Manager.Manager.BaseManager
{
    public interface ICustomerManager
    {
        Task<bool> CreateCustomer(CustomerInputDto customer);
    }
}
