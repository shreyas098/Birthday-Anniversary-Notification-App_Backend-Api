using System.Collections.Generic;
using WebApi.Entities;

namespace KiproshBirthdayCelebration.BuisnessLogic.Abstract
{
    public interface IAssociateService
    {
        List<Associate> GetAllAssociates();
        Associate GetAssociateById(int id);
    }
}