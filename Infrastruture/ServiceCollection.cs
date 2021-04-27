using KiproshBirthdayCelebration.BuisnessLogic;
using KiproshBirthdayCelebration.BuisnessLogic.Abstract;
using KiproshBirthdayCelebration.SecurityExtensions;
using KiproshBirthdayCelebration.SecurityExtensions.Abstract;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddBirthdayIdeaServices(this IServiceCollection services)
        {
            services.AddScoped<IAssociateService, AssociateService>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddScoped<IGreetingService, GreetingService>();
            services.AddScoped<ILoggedInAssociateService, LoggedInUserServices>();
            services.AddScoped<IAuthProviderService, AuthProviderService>();
            services.AddHttpContextAccessor();
            services.AddTransient<ClaimsPrincipal>(
                s => s.GetService<IHttpContextAccessor>().HttpContext.User);
            return services;
        }
    }
}
