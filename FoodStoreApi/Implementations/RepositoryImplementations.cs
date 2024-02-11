using Repository.Repository.BaseRepository;
using Repository.Repository.Implementation;

namespace FoodStoreApi.Implementations
{
    public class RepositoryImplementations
    {
        public static void ImplementRepositories(IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
        }
    }
}
