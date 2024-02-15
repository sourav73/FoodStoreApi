using Manager.Manager.BaseManager;
using Model.DTOs.Account;
using Model.EntityModel;
using Repository.Repository.BaseRepository;

namespace Manager.Manager.Implementation
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> CreateCustomer(CustomerInputDto customer)
        {
            CustomerModel newCustomer = new()
            {
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address,
                Password = customer.Password
            };

            _customerRepository.Create(newCustomer);
            return await _customerRepository.SaveAsync();
        }
    }
}
