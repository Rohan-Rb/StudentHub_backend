using Microsoft.EntityFrameworkCore;
using student_hub_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_hub_backend.Services
{
    public class UserService: IUserService
    {
        private MyDBContext _context;
        public UserService(MyDBContext context)
        {
            _context = context;
        }

        public List<Users> GetUsersList()
        {
            List<Users> userList;
            try
            {
                /*userList = _context.Set<Users>().ToList();*/
                userList = _context.Users.Include(x => x.Roles).ToList();




            }
            catch (Exception)
            {
                throw;
            }
            return userList;
        }

        public Users GetUserDetailsById(int userId)
        {
            Users users;
            try
            {
                users = _context.Find<Users>(userId);
                users = _context.Users.Include(x => x.Roles).Where(user => user.UserID == userId).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return users;
        }

        public ResponseModel SaveUser(Users userModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Users _temp = GetUserDetailsById(userModel.UserID);
                if (_temp != null)
                {
                    _temp.FirstName = userModel.FirstName;
                    _temp.LastName = userModel.LastName;
                    _temp.UserName = userModel.UserName;
                    _temp.PrimaryPhone = userModel.PrimaryPhone;
                    _temp.SecondaryPhone = userModel.SecondaryPhone;
                    _temp.Email = userModel.Email;
                    _temp.State = userModel.State;
                    _temp.City = userModel.City;
                    _temp.Street = userModel.Street;
                    _temp.PasswordHash = userModel.PasswordHash;
                    _temp.RegisteredDate = userModel.RegisteredDate;
                    _temp.ProfileURL = userModel.ProfileURL;
                    _temp.RoleID = userModel.RoleID;

                    _context.Update<Users>(_temp);
                    model.Messsage = "user Update Successfully";
                }
                else
                {
                    _context.Add<Users>(userModel);
                    model.Messsage = "Users Inserted Successfully";
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public ResponseModel DeleteUser(int userId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Users _temp = GetUserDetailsById(userId);
                if (_temp != null)
                {
                    _context.Remove<Users>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "user Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "user Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
    }
}
