using WebApi.Entities;

namespace KiproshBirthdayCelebration.BuisnessLogic.Abstract
{
    public interface IAuthenticateService
    {
        string GetAccessToken(Associate request);
        Associate AuthenticateUser(string userName,string pwd);
    }
}