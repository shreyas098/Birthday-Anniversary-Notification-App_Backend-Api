using KiproshBirthdayCelebration.SecurityExtensions.Abstract;
using System.Security.Claims;

namespace KiproshBirthdayCelebration.SecurityExtensions
{
    public class LoggedInUserServices : ILoggedInAssociateService
    {
        private readonly ClaimsPrincipal _Caller;
        public LoggedInUserServices(ClaimsPrincipal caller)
        {
            _Caller = caller;
        }
        public int UserId
        {
            get
            {
                var userId = 0;
                if (_Caller.Identity.IsAuthenticated)
                {
                    userId = int.Parse(_Caller.Identity.Name);
                }
                return userId;
            }
        }

        public bool IsInRole(string role)
        {
            if (_Caller.Identity.IsAuthenticated)
            {
                return _Caller.IsInRole(role);
            }
            return false;
        }
    }
}
