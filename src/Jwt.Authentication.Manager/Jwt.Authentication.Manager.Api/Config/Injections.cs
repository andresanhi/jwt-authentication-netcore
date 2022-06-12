using Jwt.Authentication.Manager.Domain.Config;
using Jwt.Authentication.Manager.Domain.Interfaces.Services;
using Jwt.Authentication.Manager.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;

namespace Jwt.Authentication.Manager.Api.Config
{
    public static class Injections
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Configuration
            Settings settings = configuration.Get<Settings>();
            services.Configure<Settings>(configuration);
            ConfigureJwt(services, settings.AppSettings);
            #endregion

            #region Services
            services.AddScoped<ISecurityService, SecurityService>();
            #endregion

            #region Automapper
            services.AddAutoMapper(typeof(MapperProfile).Assembly);
            #endregion
        }

        private static void ConfigureJwt(IServiceCollection services, AppSettings settings)
        {
            var key = Encoding.ASCII.GetBytes(settings.SecretKey);
            services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}
