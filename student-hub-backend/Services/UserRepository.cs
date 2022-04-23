using student_hub_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_hub_backend.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDBContext _context;
        public UserRepository(MyDBContext context)
        {
            _context = context;
        }
        public Users Create(Users user)
        {
            _context.Users.Add(user);
            user.UserID =_context.SaveChanges();

            return user; 
        }

        public Users GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public Users GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserID == id);
        }

    }
}
