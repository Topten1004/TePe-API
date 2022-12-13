using Tepe.Brt.Business.Services;
using Tepe.Brt.Data.Repositories;

namespace Tepe.Brt.Api.Services
{
    public static class ApplicationServices
    {
        public static void AddServices(IServiceCollection services)
        {
            #region Services

            services.AddTransient<IGenericService, GenericService>();

            #endregion

            #region Repositories

            services.AddTransient<IGenericRepository, GenericRepository>();

            #endregion
        }
    }
}
