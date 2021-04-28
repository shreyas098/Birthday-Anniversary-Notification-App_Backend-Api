using WebApi.Entities;

namespace KiproshBirthdayCelebration.SecurityExtensions.Abstract
{
    public interface IAuthProviderService
    {
        string GenerateJSONWebToken(AssociateViewModel request);
    }
}
