using WebApi.Entities;

namespace KiproshBirthdayCelebration.BuisnessLogic.Abstract
{
    public interface IAuthenticateService
    {
        string GenerateJSONWebToken(Associate request);
        Associate AuthenticateUser(string userName,string pwd);
    }
}