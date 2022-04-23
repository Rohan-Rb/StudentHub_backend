using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_hub_backend.DTO;
using student_hub_backend.Helpers;
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
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;

        public AuthController(IUserRepository repository, JwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = new Users
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserName = $"{dto.FirstName} {dto.LastName}",
                PrimaryPhone = dto.PrimaryPhone,
                SecondaryPhone = dto.SecondaryPhone,
                Email = dto.Email,
                State = dto.State,
                City = dto.City,
                Street = dto.Street,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.PasswordHash),
                RegisteredDate = dto.RegisteredDate,
                ProfileURL = dto.ProfileURL,
                RoleID = dto.RoleID
            };
            return Created("Success", _repository.Create(user));
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _repository.GetByEmail(dto.Email);

            if (user == null) return BadRequest(new { message = "Invalid Credentials" });

            if (!BCrypt.Net.BCrypt.Verify(dto.PasswordHash, user.PasswordHash))
            {
                return BadRequest(new { message = "Invalid Credentials" });
            }

            var jwt = _jwtService.Generate(user.UserID);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None

            }) ;

            return Ok(new
            {
                message = "Success."
            });
        }

        [HttpGet("user")]
        public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = _repository.GetById(userId);

                return Ok(user);
            }
            catch (Exception _)
            {
                return Unauthorized();
            }
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            /*Response.Cookies.Delete("jwt");*/
           var test = Request.Cookies["jwt"];
            Response.Cookies.Delete("jwt");
            var test1 = Request.Cookies["jwt"];
            var test2 = Response.Cookies.ToString();
       

            /*Response.Cookies.Delete("jwt", new CookieOptions()
            {
                Secure = true,
            });*/
            /*HttpCookie currentUserCookie = HttpContext.Current.Request.Cookies["currentUser"];
            HttpContext.Current.Response.Cookies.Remove("currentUser");
            currentUserCookie.Expires = DateTime.Now.AddDays(-10);
            currentUserCookie.Value = null;
            HttpContext.Current.Response.SetCookie(currentUserCookie);*/


            return Ok(new { 
                message = "Success"
            });
        }
    }
}
 