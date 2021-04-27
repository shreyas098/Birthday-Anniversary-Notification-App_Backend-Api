using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KiproshBirthdayCelebration.DataAccess
{
    [Table("Associates")]
    public class Associates
    {
        [Column("AssociateID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Column("AssociateFirstName")]
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Column("AssociateLastName")]
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Column("AssociateUserName")]
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Column("Password")]
        [Required]
        public string Password { get; set; }

        [Column("BirthDate")]
        [Required]
        [StringLength(100)]
        public DateTimeOffset DOB { get; set; }

        [Column("Role")]
        [Required]
        [StringLength(100)]
        public string Role { get; set; }
    }
}
