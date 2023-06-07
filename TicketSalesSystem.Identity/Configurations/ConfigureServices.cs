using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketSalesSystem.Identity.Data;
namespace TicketSalesSystem.DAL.Configurations
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddIdentityConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)))
                .AddIdentity<IdentityUser, IdentityRole>(opt =>
                {
                    opt.SignIn.RequireConfirmedAccount = false;
                    opt.User.RequireUniqueEmail = true;
                })
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            
            return services;
        }
    }
}
