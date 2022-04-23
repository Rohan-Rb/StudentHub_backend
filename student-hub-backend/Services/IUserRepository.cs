using student_hub_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_hub_backend.Services
{
    public interface IUserRepository
    {
        Users Create(Users user);
        Users GetByEmail(string email);
        Users GetById(int id);
    }
}
