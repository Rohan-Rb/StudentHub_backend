using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace student_hub_backend.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PrimaryPhone { get; set; }
        public string? SecondaryPhone { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PasswordHash { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string ProfileURL { get; set; }

        [Display(Name = "Role")]
        public virtual int RoleID { get; set; }

        [ForeignKey("RoleID")]
        public virtual Roles Roles { get; set; }

    }
}
