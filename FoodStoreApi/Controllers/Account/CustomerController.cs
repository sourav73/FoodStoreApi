using Manager.Manager.BaseManager;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs.Account;
using Model.DTOs.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodStoreApi.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("A collection of Customer APIs")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager _customerManager;
        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create customer")]
        public async Task<ObjectResponse<bool>> CreateAccount(CustomerInputDto customer)
        {
            bool isCreated = await _customerManager.CreateCustomer(customer);
            return new ObjectResponse<bool> { Data = isCreated, Message = isCreated ? "Customer created" : "Customer creating failed" };
        }
    }
}
