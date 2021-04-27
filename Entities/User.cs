using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class Associate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateofBirth { get; set; }
        public string Role { get; set; }
    }
}