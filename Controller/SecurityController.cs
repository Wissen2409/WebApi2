
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

// Bu controllerdaki hiç bir action'da header'dan token gönderilmeden girilemez!!!
[Authorize]
public class SecurityController:ControllerBase
{
    public IActionResult Get()
    {
        return Ok("token tarafından korunan veriye erişildi");
    }
}