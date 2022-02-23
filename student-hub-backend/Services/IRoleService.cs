using student_hub_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_hub_backend.Services
{
    public interface IRoleService
    {
        /// <summary>
        /// get list of all employees
        /// </summary>
        /// <returns></returns>
        List<Roles> GetRolesList();

        /// <summary>
        /// get employee details by employee id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Roles GetRoleDetailsById(int roleId);

        /// <summary>
        ///  add edit employee
        /// </summary>
        /// <param name="roleModel"></param>
        /// <returns></returns>
        ResponseModel SaveRole(Roles roleModel);


        /// <summary>
        /// delete employees
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        ResponseModel DeleteRole(int roleId);
    }
}
