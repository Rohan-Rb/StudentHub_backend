using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_hub_backend.DTO
{
    public class GetUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PrimaryPhone { get; set; }
        public string? SecondaryPhone { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string FullAddress { get; set; }
        public string PasswordHash { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string ProfileURL { get; set; }
        public int RoleID { get; set; }
        public string RoleTitle { get; set; }
    }
}
