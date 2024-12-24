using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class HeaderController : ControllerBase
{

    [HttpPost]
    [Authorize]
    public IActionResult Post(string model)
    {

        // Web apiler iki bölümden oluşur,
        // 1 : Body kısmı : body kısmında gönderilen veriler bulunmaktadır!! (mesaj gövdesidir!!)
        // 2 : Header kısmı : Header, üst bilgi olarak gönderilecek verileri taşır
        // peki üst bilgiler neler olabilir : 

        // Apide, eğer authentication var ise, authentication bilgilerini taşır!!
        // İstek yapılan kaynağın ip numarasını taşır!
        // istek yapılan kaynağın browser bilgilerini taşır!!
        // Yapılan isteğin, veri tipini taşır!!

        // yapılan istekte header bilgisine ulaşmak için 

        string authorization = HttpContext.Request.Headers["Authorization"].ToString();
        string userAgent = HttpContext.Request.Headers["User-Agent"].ToString();

        return Ok(true);
    }

}