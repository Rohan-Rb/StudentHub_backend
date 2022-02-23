using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_hub_backend.Models;
using student_hub_backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_hub_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRoleService _roleService;
        public RoleController(IRoleService service)
        {
            _roleService = service;
        }

        /*Get List Of All Roles Method*/
        /// <summary>
        /// get all roles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllRoles()
        {
            try
            {
                var roles = _roleService.GetRolesList();
                if (roles == null) return NotFound();
                return Ok(roles);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /*Get Roles Details By Id Method*/
        /// <summary>
        /// get role details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetRolesById(int id)
        {
            try
            {
                var roles = _roleService.GetRoleDetailsById(id);
                if (roles == null) return NotFound();
                return Ok(roles);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /*Save Roles Method*/
        /// <summary>
        /// save Role
        /// </summary>
        /// <param name="roleModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveRoles(Roles roleModel)
        {
            try
            {
                var model = _roleService.SaveRole(roleModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /*Delete role Method*/
        /// <summary>
        /// delete role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteRole(int id)
        {
            try
            {
                var model = _roleService.DeleteRole(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}

