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
                if (users == null)
                {
                    return NotFound();
                }

                var getUserDto = users.Select(u => new GetUserDto 
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    UserName = $"{u.FirstName} {u.LastName}",
                    PrimaryPhone = u.PrimaryPhone,
                    SecondaryPhone = u.SecondaryPhone,
                    Email = u.Email,
                    /*City = u.City,
                    State = u.State,
                    Street = u.Street,*/
                    FullAddress = $"{u.Street} {u.City} {u.State}",
                    PasswordHash = u.PasswordHash,
                    ProfileURL = u.ProfileURL,
                    RoleID = u.RoleID,
                    RoleTitle = u.Roles.RoleTitle
                });
                /*var getUserDto = from u in users
                                 select new GetUserDto


                                 {
                                     FirstName = u.FirstName,
                                     LastName = u.LastName,
                                     UserName = $"{u.FirstName} {u.LastName}",
                                     PrimaryPhone = u.PrimaryPhone,
                                     SecondaryPhone = u.SecondaryPhone,
                                     Email = u.Email,
                                     *//*City = u.City,
                                     State = u.State,
                                     Street = u.Street,*//*
                                     FullAddress = $"{u.Street} {u.City} {u.State}",
                                     PasswordHash = u.PasswordHash,
                                     ProfileURL = u.ProfileURL,
                                     RoleID = u.RoleID,
                                 };*/
                /*var getUserDto = new GetUserDto
                {
                    FirstName = users[1].FirstName,
                    LastName = users[1].LastName,
                    UserName = $"{users[1].FirstName} {users[1].LastName}",
                    PrimaryPhone = users[1].PrimaryPhone,
                    SecondaryPhone = users[1].SecondaryPhone,
                    Email = users[1].Email,
                    *//*City = users.City,
                    State = users.State,
                    Street = users.Street,*//*
                    FullAddress = $"{users[1].Street} {users[1].City} {users[1].State}",
                    PasswordHash = users[1].PasswordHash,
                    *//*FullName = $"{users.FirstName} {users.LastName}",*//*
                    ProfileURL = users[1].ProfileURL,
                    RoleID = users[1].RoleID,
                    *//*RoleTitle = users[1].Roles.RoleTitle,*/


                    /*RoleTitle = users.Roles.RoleTitle,
                    City = users.City,
                    Email = users.Email*//*
                };*/

                return Ok(getUserDto);
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
                    FirstName = users.FirstName,
                    LastName = users.LastName,
                    UserName = $"{users.FirstName} {users.LastName}",
                    PrimaryPhone = users.PrimaryPhone,
                    SecondaryPhone = users.SecondaryPhone,
                    Email = users.Email,
                    /*City = users.City,
                    State = users.State,
                    Street = users.Street,*/
                    FullAddress = $"{users.Street} {users.City} {users.State}",
                    PasswordHash = users.PasswordHash,
                    /*FullName = $"{users.FirstName} {users.LastName}",*/
                    ProfileURL = users.ProfileURL,
                    RoleID = users.RoleID,
                    RoleTitle = users.Roles.RoleTitle,


                    /*RoleTitle = users.Roles.RoleTitle,*/
                    /*City = users.City,*/
                    /*Email = users.Email*/
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
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    UserName = $"{userDto.FirstName} {userDto.LastName}",
                    PrimaryPhone = userDto.PrimaryPhone,
                    SecondaryPhone = userDto.SecondaryPhone,
                    Email = userDto.Email,
                    City = userDto.City,
                    State = userDto.State,
                    Street = userDto.Street,
                    PasswordHash = userDto.PasswordHash,
                    /*FullName = $"{userDto.FirstName} {userDto.LastName}",*/
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
