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
        private readonly AppDbContext _context;
        public AssociateService(AppDbContext context)
        {
            _context = context;
        }
        public List<Associate> GetAllAssociates()
        {
            return _context.Associates
                .Select(x =>
                new Associate
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DateofBirth = x.DOB,
                    Role = x.Role
                }).ToList();
        }

        public Associate GetAssociateById(int id)
        {
            return _context.Associates
                .Where(x => x.Id == id)
                .Select(x =>
                new Associate
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DateofBirth = x.DOB,
                    Role = x.Role
                }).FirstOrDefault();
        }

        public List<UpcomingBirthdayModel> GetUpcomingBirthdays()
        {
            var theDate = DateTimeOffset.Now.AddDays(1).Date;
            return _context.Associates
                 .Where(x => (x.DOB.Month >= theDate.Month) && (x.DOB.Day >= theDate.Day))
                 .OrderBy(x => x.DOB)
                 .Select(x => new UpcomingBirthdayModel
                 {
                     AssoicateId = x.Id,
                     AssociateName = $"{x.FirstName} {x.LastName}",
                     DOB = x.DOB
                 })
                 .ToList();
        }

        public List<UpcomingBirthdayModel> GetCurrentBirthdays()
        {
            var theDate = DateTimeOffset.Now.AddDays(1).Date;
            return _context.Associates
                .Where(x => (x.DOB.Month == theDate.Month) && (x.DOB.Day == theDate.Day))
                .OrderBy(x => x.DOB)
                .Select(x => new UpcomingBirthdayModel
                {
                    AssoicateId = x.Id,
                    AssociateName = $"{x.FirstName} {x.LastName}",
                    DOB = x.DOB,
                })
                .ToList();
        }
    }
}
