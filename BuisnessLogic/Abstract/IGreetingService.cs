using KiproshBirthdayCelebration.Entities;

namespace KiproshBirthdayCelebration.BuisnessLogic.Abstract
{
    public interface IGreetingService
    {
       void SubmitWishes(int currentUserId,GreetingSaveViewModel model);
    }
}