using KiproshBirthdayCelebration.BuisnessLogic;
using KiproshBirthdayCelebration.BuisnessLogic.Abstract;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddBirthdayIdeaServices(this IServiceCollection services)
        {
            services.AddScoped<IAssociateService, AssociateService>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            return services;
        }
    }
}
