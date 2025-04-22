using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutostoreProject.DBEntities;
using AutostoreProject.Model;
using AutostoreProject.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AutostoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private Ilogin _ilogin;
        private ISignUp _iSignUp;
        private ICommonFunction _commonFunction;
        public LoginController(Ilogin ilogin,ISignUp iSignUp,ICommonFunction commonFunction)
        {
            // Initialize the services here or use dependency injection
            // For example, if you have a constructor for your service, you can inject it here
            this._ilogin=ilogin;
            this._iSignUp=iSignUp;
            this._commonFunction=commonFunction;
        }
    
    [HttpPost("LoginByEmailAndPassword")]
    // [ValidateAntiForgeryToken]
    public async Task<IActionResult> LoginByEmailAndPassword([FromBody] UserLogin userLogin)
    {
        try
        {
            Debugger.Break();
            if (userLogin == null || string.IsNullOrEmpty(userLogin.UserNameOrEmail) || string.IsNullOrEmpty(userLogin.Password))
            {
                return BadRequest(new { message = "Invalid login request" });
            }
             
            var user =_ilogin.Login(userLogin.UserNameOrEmail, userLogin.Password);
            if (user == null)
            {
                    var token = _commonFunction.GenerateJwtToken(userLogin.UserNameOrEmail);
                    return Ok(new { token = token, User = user });
            }

                return Unauthorized(new { message = "Invalid credentials" });

                // return Ok($"Token: {  token }");
         }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
            // return Unauthorized(new { message = "Invalid credentials" });
            
        }

        
    }

        [HttpPost("SignUpByEmailAndPassword")]
        public IActionResult SignUpByEmailAndPassword([FromBody]UserLogin userLogin)
        {
            try{
                AUser user = new AUser();
                user= _iSignUp.UserForSignUp(userLogin);
                if(user!=null)
                {
                _commonFunction.SendSecurityEmailAsync(userLogin.UserNameOrEmail, userLogin.UserNameOrEmail, "SignUp", "https://localhost:5001/api/Login/VerifyEmail?email="+userLogin.UserNameOrEmail).Wait();
                return Ok(ApiResponse<AUser>.SuccessResponse(user, "User Created Successfully"));
                }
                else
                {
                    return BadRequest(new { message = "Invalid SignUp request" });
                }
                   
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        
    }
}
