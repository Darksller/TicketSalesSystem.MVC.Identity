using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketSalesSystem.DAL.Data;
using TicketSalesSystem.DAL.Interfaces;
using TicketSalesSystem.DAL.Repositories;

namespace TicketSalesSystem.DAL.Configurations
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                    options.EnableSensitiveDataLogging(true)
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

            services.AddScoped<IAirplaneRepository, AirplaneRepository>()
                .AddScoped<IFlightRepository, FlightRepository>()
                .AddScoped<IFlightStatusRepository, FlightStatusRepository>()
                .AddScoped<IRouteRepository, RouteRepository>()
                .AddScoped<ISeatTypeRepository, SeatTypeRepository>()
                .AddScoped<ITicketRepository, TicketRepository>()
                .AddScoped<IAirlineRepository, AirlineRepository>();


            return services;
        }
    }
}
