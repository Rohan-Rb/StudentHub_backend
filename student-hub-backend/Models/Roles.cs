using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace student_hub_backend.Models
{
    public class Roles
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleTitle { get; set; }

    }
}
