using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace HomePropertySystem.Data
{
    public static class DbContextConfiguration
    {
        public static void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext<HomesDbContext>(options => options.UseSqlServer(DbContextConstants.GetConnectionString()));
        }

        public static void AddIdentity(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<HomesDbContext>()
            .AddDefaultTokenProviders();
        }

        public static void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                HomesDbContext dbContext = serviceScope.ServiceProvider.GetRequiredService<HomesDbContext>();
                dbContext.Database.Migrate();

                // TODO: Use dbContext if you want to do seeding etc.
            }
        }
    }
}
