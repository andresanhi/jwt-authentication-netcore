using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Jwt.Authentication.Manager.Api.Config
{
    public static class Injections
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
        }
    }
}
