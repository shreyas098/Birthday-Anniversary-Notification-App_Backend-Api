using WebApi.Entities;

namespace KiproshBirthdayCelebration.BuisnessLogic.Abstract
{
    public interface IAuthenticateService
    {
        string GetAccessToken(AssociateViewModel request);
        AssociateViewModel AuthenticateUser(string userName,string pwd);
    }
}