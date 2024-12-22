using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class WissenController : ControllerBase
{


    // Kaynaktaki veriyi tamamen oluşturmak yada güncellemek istersen put kullanılır!!
    //Eğer kaynak mevcut değilse, oluşturmak
    //Eğer kaynak mevcut ise, tamamını güncellemek (override) için kullanılır,!!
    // Örnek : Bir öğrenci nesnesi var, ve bu öğrenci nesnesi yeni öğrenci nesnesi ile değiştirmek için kullanılır

    [HttpPut]
    public IActionResult Put(){
        return Ok(true);
    }

    // Bir veri kaynağındaki veriyi, kısmi güncellemek isterseniz kullanılmaktadır!!

    // Örnek : Bir öğrenci nesnesinin sadece property'lerini   güncellemek için kullanılır!!
    [HttpPatch]
    public IActionResult Patch(){

        return Ok(true);
    }

    // bir veri kaynağındaki veriyi silmek için kullanılır!!
    // Örnek  : Id değerine göre öğrenci nesnesini silebilirsiniz!!!
    [HttpDelete]
    public IActionResult x(){

        return Ok(true);
    }

    //Bu metot, header bilgilerini almak için kullanılır!!
    // Header alanında istenilen verilerin olup olmadığını, varsa bu veriyi almak ve kullanmak için vardır!!
    [HttpHead]
    public IActionResult Head(){

        return Ok(true);
    }

    // Api'nin, hangi HTTPMetotlarına izin verdiğini veren metotdur!
    // kullanım amacıi apinin izin verdiği metotlar öğrenmek için kullanılır!

    [HttpOptions]
    public IActionResult Options(){
        return Ok(true);
    }
    public IActionResult Get()
    {
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