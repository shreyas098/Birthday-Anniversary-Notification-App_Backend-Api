using KiproshBirthdayCelebration.BuisnessLogic.Abstract;
using KiproshBirthdayCelebration.DataAccess;
using KiproshBirthdayCelebration.Entities;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using System;

namespace KiproshBirthdayCelebration.BuisnessLogic
{
    public class AssociateService : IAssociateService
    {
        private readonly AppDbContext DbContext;
        public AssociateService(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public List<Associate> GetAllAssociates()
        {
            return DbContext.Associates
                .Select(x =>
                new Associate
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DateofBirth = x.DOB,
                    ImageUrl = x.ImageUrl,
                    Role = x.Role
                }).ToList();
        }

        public Associate GetAssociateById(int id)
        {
            return DbContext.Associates
                .Where(x => x.Id == id)
                .Select(x =>
                new Associate
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DateofBirth = x.DOB,
                    ImageUrl = x.ImageUrl,
                    Role = x.Role
                }).FirstOrDefault();
        }

        public List<UpcomingBirthdayViewModel> GetUpcomingBirthdays()
        {
            var theDate = DateTimeOffset.Now.AddDays(1).Date;
            return DbContext.Associates
                 .Where(x => (x.DOB.Month >= theDate.Month) && (x.DOB.Day >= theDate.Day))
                 .OrderBy(x => x.DOB)
                 .Select(x => new UpcomingBirthdayViewModel
                 {
                     AssoicateId = x.Id,
                     AssociateName = $"{x.FirstName} {x.LastName}",
                     ImageUrl = x.ImageUrl,
                     DOB = x.DOB
                 })
                 .ToList();
        }

        public List<UpcomingBirthdayViewModel> GetCurrentBirthdays()
        {
            var theDate = DateTimeOffset.Now.AddDays(1).Date;
            return DbContext.Associates
                .Where(x => (x.DOB.Month == theDate.Month) && (x.DOB.Day == theDate.Day))
                .OrderBy(x => x.DOB)
                .Select(x => new UpcomingBirthdayViewModel
                {
                    AssoicateId = x.Id,
                    AssociateName = $"{x.FirstName} {x.LastName}",
                    ImageUrl = x.ImageUrl,
                    DOB = x.DOB,
                })
                .ToList();
        }
    }
}
