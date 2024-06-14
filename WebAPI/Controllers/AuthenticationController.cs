using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Data;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly DbContextClass _context;

        public AuthenticationController(DbContextClass context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login user)
        {
            var ulist = _context.User.ToList();
            var authUser = new User();
            authUser = ulist.Find(x => x.Username.Equals(user.UserName) &&
            x.Password.Equals(user.Password));


            if (user is null)
            {
                return BadRequest("Invalid user request!!!");
            }
            if(authUser is null)
            {
                return BadRequest("Invalid username and/or password.");
            }
            //if (user.UserName == "Jaydeep" && user.Password == "Pass@777")
            else
            {
                
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var c = new List<Claim>
                {
                    new Claim("user",authUser.Firstname + " " + authUser.Lastname),
                    new Claim("username", authUser.Username)
                };

 
                var tokeOptions = new JwtSecurityToken(
                    issuer: ConfigurationManager.AppSetting["JWT:ValidIssuer"],
                    audience: ConfigurationManager.AppSetting["JWT:ValidAudience"],
                    claims: c,//new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(6),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new JWTTokenResponse { Token = tokenString });
            }
            return Unauthorized();
        }
    }
}
