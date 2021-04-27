using System.ComponentModel.DataAnnotations;

namespace KiproshBirthdayCelebration.Entities
{
    public class GreetingSaveViewModel
    {
        [Required]
        public int ReceiverAssociateId { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
