using KiproshBirthdayCelebration.BuisnessLogic.Abstract;
using KiproshBirthdayCelebration.DataAccess;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;

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
    }
}
