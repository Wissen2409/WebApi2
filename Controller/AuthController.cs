using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private const string USERNAME = "root";
    private const string PASSWORD = "1010";
    public IConfiguration Configuration { get; }
    public AuthController(IConfiguration configuration)
    {
        this.Configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult Login(AuthModel model)
    {
        if (model.Username != USERNAME || model.Password != PASSWORD)
        {
            return Unauthorized("Geçersiz kullanıcı adı ve şifre");
        }
        // bu satırsa kullanıcı adı ve şifrenin doğru olduğunu kabul ediyoruz!!
        // Gelen kullanıcı ve şifreye göre JWT token üretelim!!
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Configuration["JwtSettings:Key"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {

            Subject = new System.Security.Claims.ClaimsIdentity(new[]{

                 new Claim(ClaimTypes.Name, model.Username),
                 new Claim(ClaimTypes.Role, "Admin")


            }),
            Expires = DateTime.UtcNow.AddHours(1),
            Issuer = Configuration["JwtSettings:Issuer"],
            Audience = Configuration["JwtSettings:Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);
        return Ok(tokenString);
    }


}