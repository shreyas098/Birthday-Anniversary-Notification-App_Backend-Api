using System.ComponentModel.DataAnnotations;

namespace KiproshBirthdayCelebration.Entities
{
    public class AuthenticateRequestViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
