namespace KiproshBirthdayCelebration.SecurityExtensions.Abstract
{
    public interface ILoggedInAssociateService
    {
        int UserId { get; }
        bool IsInRole(string role);
    }
}
