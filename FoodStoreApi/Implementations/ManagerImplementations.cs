using Manager.Manager.BaseManager;
using Manager.Manager.Implementation;

namespace FoodStoreApi.Implementations
{
    public class ManagerImplementations
    {
        public static void ImplementManagers(IServiceCollection services)
        {
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IAccountManager, AccountManager>();
        }
    }
}
