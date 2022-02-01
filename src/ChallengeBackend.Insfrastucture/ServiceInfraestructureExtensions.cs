using ChallengeBackend.Application.Contracts.Persistence;
using ChallengeBackend.Insfrastucture.Persistence;
using ChallengeBackend.Insfrastucture.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeBackend.Insfrastucture
{
    public static class ServiceInfraestructureExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ChallengeSQLConnection"))
            );

            services.AddScoped<IUserRepository, UserRepository>();
           
            return services;
        }
    }
}
