using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KiproshBirthdayCelebration.Entities
{

    public class UpcomingBirthdayViewModel
    {
        public int AssoicateId { get; set; }
        public string AssociateName { get; set; }
        public string Designation { get; set; }
        public DateTimeOffset DOB { get; set; }
        public string ImageUrl { get; internal set; }
    }
}
