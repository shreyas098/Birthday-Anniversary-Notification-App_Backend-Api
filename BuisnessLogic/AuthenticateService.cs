using KiproshBirthdayCelebration.BuisnessLogic.Abstract;
using KiproshBirthdayCelebration.DataAccess;
using KiproshBirthdayCelebration.SecurityExtensions.Abstract;
using System.Linq;
using WebApi.Entities;
using BC = BCrypt.Net.BCrypt;

namespace KiproshBirthdayCelebration.BuisnessLogic
{
    public class AuthenticateService : IAuthenticateService
    {
        private IAuthProviderService AuthService;
        private readonly AppDbContext DbContext;
        public AuthenticateService(
            IAuthProviderService authService,
            AppDbContext dbContext)
        {
            DbContext = dbContext;
            AuthService = authService;
        }

        public Associate AuthenticateUser(string userName, string pwd)
        {
            //$2a$11$s2zIFxyIzlv/YCBgPZRKHeIp8BgpaGmoJ7LDoibQxruR1Fz4i9SFe (Kiprosh@123)
            var account = DbContext.Associates.SingleOrDefault(x => x.UserName == userName);
            if (account != null && BC.Verify(pwd, account.Password))
            {
                return new Associate()
                {
                    Id = account.Id,
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    Role = account.Role
                };
            }
            else
            {
                return null;
            }
        }
        public string GetAccessToken(Associate request)
        {
            return AuthService.GenerateJSONWebToken(request);
        }
    }
}
