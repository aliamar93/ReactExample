using AutostoreProject.DBEntities;
using AutostoreProject.Model;
using AutostoreProject.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutostoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        // Constructor for UserController
        // This constructor can be used to inject dependencies or services if needed
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            // Initialize any services or dependencies here if needed
            _userService = userService;
        }
        // This method is responsible for handling user login requests
        [Authorize]
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        { try
            {
                var users = await _userService.GetAllUsers();
                return Ok(users);  // Ensure that users is a simple, serializable collection (e.g., List<AUser>)
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [Authorize]
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] AUser user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("User cannot be null.");
                }
                await _userService.AddUser(user);
                return Ok();  // Ensure that result is a simple, serializable object
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
