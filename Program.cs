using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

var JwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(option =>
{

    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = JwtSettings["Issuer"],
        ValidAudience = JwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings["Key"]))
    };


});


builder.Services.AddAuthorization();

// Cors'u açalım 

// Cors tarayıcı tarafından, web apilere yapılan istekleri engellemek için, web apilerde olan bir güvenlik katmanıdır

// tarayıcılar, cors açık değilken asla bir web sitesine yada apisine istek yapamazlar!!



// Cors restcharp ile yapılan isteklere takılmaz, çünkü restsharp ile yapılan istekler, tarayıcıdan gönderilemiştir
// kesinlik bir backend kodu vardır!!
// Taracıyıda çalışan tüm teknolojiler (JavaScript,Query,React, Vue, Angular) vb tüm tarayıcı da çalışan proglamlama dilleri cors'a takılır!!


// Cors'u aşmak için illaki apiden cors ayarını açmakmı gerekir, 

// 1. evet açmak gerekir
// 2. proxy sunucusu kullanarak cors aşılabilir. Proxy sunucular, aslında siz taracıyıdan istek yapsanızda, kendisi backend'den istek yaparak apiden veriyi çeker ve size verir.
//Proxy sunucusu ve sizin aranızda cors olmaması için, proxy sunucusu corsu kendisinde açmıştır!!
// 


// 
builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(policy =>
    {
        policy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseCors();
app.UseRouting();
app.MapControllers();
app.UseHttpsRedirection();


app.Run();

