using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace student_hub_backend.DTO
{
    public class JobDto
    {
        public string College { get; set; }
        public string JobTitle { get; set; }
        public string JobBanner { get; set; }
        public string JobLevel { get; set; }
        public int Vacancy { get; set; }
        public string Type { get; set; }
        public int Salary { get; set; }
        public string Deadline { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public string JobDescription { get; set; }
        public string ApplyingProcedure { get; set; }

        public string OtherSpecification { get; set; }
        [NotMapped]
        public string FileName { get; set; }
        [NotMapped]
        public IFormFile FormFile { get; set; }
        public int UserID { get; set; }
    }
}
