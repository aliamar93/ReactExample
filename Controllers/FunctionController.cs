using AutostoreProject.Model;
using AutostoreProject.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutostoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunctionController : ControllerBase
    {
        private readonly ICommonFunction _IcommonFunction;
        public FunctionController(ICommonFunction IcommonFunction)
        {
            this._IcommonFunction=IcommonFunction;
        }
        [HttpGet("[action]")]
        // [Authorize]  // Protects the route for authenticated users only
        public IActionResult GetEncrypt(string value)
        {

            return Ok($"Encrypted value: {_IcommonFunction.Encryption(value)}");
        }

        [HttpGet("GetDecrypt")]
        // [Authorize]  // Protects the route for authenticated users only
        public IActionResult GetDecrypt(string value)
        {
            return Ok($"Received value: {_IcommonFunction.Decryption(value)}");
        }


// // This method can only be accessed by authenticated users with the "Admin" role
//     [HttpGet("admin-data")]
//     [Authorize(Roles = "Admin")]  // Protects the route for users with "Admin" role
    [HttpGet("GetPublicData")]
    [Authorize]  // Protects the route for authenticated users only
    public IActionResult GetPublicData()
    {
        return Ok(new { message = "This is public data accessible by all authenticated users." });
    }
    }
}
