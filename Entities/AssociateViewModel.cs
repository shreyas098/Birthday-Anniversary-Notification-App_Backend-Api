using System;

namespace WebApi.Entities
{
    public class AssociateViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateofBirth { get; set; }
        public string Role { get; set; }
        public string ImageUrl { get; set; }
    }
}