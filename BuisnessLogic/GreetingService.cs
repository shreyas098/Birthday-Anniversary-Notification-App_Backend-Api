using KiproshBirthdayCelebration.BuisnessLogic.Abstract;
using KiproshBirthdayCelebration.DataAccess;
using KiproshBirthdayCelebration.Entities;
using System;
using System.Linq;

namespace KiproshBirthdayCelebration.BuisnessLogic
{
    public class GreetingService : IGreetingService
    {
        private readonly AppDbContext DbContext;
        public GreetingService(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void SubmitWishes(int currentUserId, GreetingSaveViewModel model)
        {
            if (currentUserId > 0 && model.ReceiverAssociateId > 0)
            {
                DbContext.Associate_Birthday_Wishes_Inputs
                     .RemoveRange(DbContext.Associate_Birthday_Wishes_Inputs
                     .Where(b => b.BirthdayPersonId == model.ReceiverAssociateId
                     && b.AssociateId == currentUserId).ToList());

                var message = new Associate_Birthday_Wishes_Inputs
                {
                    AssociateId = currentUserId,
                    BirthdayPersonId = model.ReceiverAssociateId,
                    AddedDate = DateTimeOffset.UtcNow,
                    BirthdayMessage = model.Message
                };

                DbContext.Add(message);
                DbContext.SaveChanges();
            }
        }
    }
}
