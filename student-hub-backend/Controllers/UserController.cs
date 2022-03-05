using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_hub_backend.DTO;
using student_hub_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_hub_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService service)
        {
            _userService = service;
        }

        /*Get List Of All Users Method*/
        /// <summary>
        /// get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _userService.GetUsersList();
                if (users == null) return NotFound();
                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /*Get Users Details By Id Method*/
        /// <summary>
        /// get user details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetUsersById(int id)
        {
            try
            {
                var users = _userService.GetUserDetailsById(id);
                if (users == null)
                {
                    return NotFound();
                }

                var getUserDto = new GetUserDto
                {
                    FullAddress = $"{users.Street} {users.City} {users.State}",
                    RoleTitle = users.Roles.RoleTitle,
                    City = users.City,
                    Email = users.Email
                };
                
                return Ok(getUserDto);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /*Save Users Method*/
        /// <summary>
        /// save User
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/save")]
        public IActionResult SaveUsers([FromBody]UserDto userDto)
        {
            try
            {
                var userModel = new Users
                {
                    City = userDto.City,
                    State = userDto.State,
                    Street = userDto.Street,
                    Email = userDto.Email,
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    FullName = $"{userDto.FirstName} {userDto.LastName}",
                    PrimaryPhone = userDto.PrimaryPhone,
                    ProfileURL = userDto.ProfileURL,
                    RoleID = userDto.RoleID
                 };

                var model = _userService.SaveUser(userModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /*Delete user Method*/
        /// <summary>
        /// delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var model = _userService.DeleteUser(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
