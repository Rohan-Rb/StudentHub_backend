using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace student_hub_backend.Models
{
    public class JobDTO
    {
        [Column(TypeName = "varchar(200)")]
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string OtherSpecification { get; set; }
    }
}
