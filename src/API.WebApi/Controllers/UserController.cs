using API.ApplicationCore.Exceptions;
using API.ApplicationCore.DTOs;
using API.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet()]
        public ActionResult<List<UserResponse>> GetUsers([FromQuery] Guid userId)
        {
            if (userId != new Guid())
            {
                try
                {
                    var user = this.userRepository.GetUserById(userId);
                    return Ok(user);
                }
                catch (NotFoundException)
                {
                    return NotFound();
                }
            }

            else
            {
                return Ok(this.userRepository.GetUsers());
            }
        }

        [HttpPost()]
        public ActionResult CreateUser([FromBody] CreateUserRequest request)
        {
            var user = this.userRepository.CreateUser(request);
            return Ok(user);
        }

        [HttpPut()]
        public ActionResult UpdateUser([FromQuery] Guid uid, [FromBody] UpdateUserRequest request) 
        { 
            try
            {
                var user = this.userRepository.UpdateUser(uid, request);
                return Ok(user);
            }
            catch (NotFoundException) 
            {
                return NotFound();
            }
        }

        [HttpDelete()]
        public ActionResult DeleteUser([FromQuery] Guid uid) 
        {
            try
            {
                this.userRepository.DeleteUserById(uid);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
