namespace HomePropertySystem.IoC
{
    using HomePropertySystem.Data.Repositories;
    using HomePropertySystem.ServiceInterfaces;
    using HomePropertySystem.Services;
    using Microsoft.Extensions.DependencyInjection;

    public static class IoCContainer
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            #region " DbContext/UowData/Repositories "

            services.AddScoped<IUowData, UowData>();

            #endregion

            #region " Services "

            services.AddTransient<IUserService, UserService>();
            #endregion
        }
    }
}
