using student_hub_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_hub_backend
{
    public interface IUserService
    {
        /// <summary>
        /// get list of all users
        /// </summary>
        /// <returns></returns>
        List<Users> GetUsersList();

        /// <summary>
        /// get user details by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Users GetUserDetailsById(int userId);

        /// <summary>
        ///  add edit user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        ResponseModel SaveUser(Users userModel);


        /// <summary>
        /// delete users
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ResponseModel DeleteUser(int userId);
    }
}
