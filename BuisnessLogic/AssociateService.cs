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
            var output = default(List<UpcomingBirthdayModel>);
            var theDate = DateTimeOffset.Now.AddDays(1).Date;
            var query = _context.Associates
                .Where(x => x.DOB > theDate)
                .OrderByDescending(x => x.DOB)
                .Select(x => x)
                .ToList();

            if (query.Count > 0)
            {
                output = new List<UpcomingBirthdayModel>();
                query.ForEach(o =>
                {
                    output.Add(
                    new UpcomingBirthdayModel
                    {
                        AssoicateId = o.Id,
                        AssociateName = $"{o.FirstName} {o.LastName}",
                        DOB = o.DOB,
                        CanSendMessage = (o.DOB.Date == theDate)
                    });
                });
            }
            return output;
        }
    }
}
