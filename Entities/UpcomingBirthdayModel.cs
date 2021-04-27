using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KiproshBirthdayCelebration.Entities
{
    public class UpcomingBirthdayModel
    {
        public int AssoicateId { get; set; }
        public string AssociateName { get; set; }
        public DateTimeOffset DOB { get; set; }
        public bool CanSendMessage { get; internal set; }
    }
}
