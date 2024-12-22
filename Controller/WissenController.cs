using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class WissenController:ControllerBase
{
    public IActionResult Get(){
       // geriye product döndürelim 
        var products = new[]
        {
            new { Id =1, Name = "Kalem"},

            new { Id =2, Name = "Kağıt"},

            new { Id =3, Name = "Silgi"},

            new { Id =4, Name = "Masa"},

            new { Id =5, Name = "Bilgisayar"},

            new { Id =6, Name = "Mouse"},
        };
        return Ok(products);
    }
}