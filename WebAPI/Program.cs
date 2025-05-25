using Business;
using Core.Exceptions.Extensions;
using Core.Security.Encryption;
using Core.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRepositoriesServices(builder.Configuration);

builder.Services.AddBusinessServices(); 

//AddScoped => //Her http request icin bir kez olusturulur

//AddSingleton => Uygulama baslad�g�nda bir kez olusturulur. Cok s�k kullan�lan ve degismeyen yap�lar icin. Cache islemleri,Config islemleri
//AddTransiet => Her kullan�mda yeni bir nesne olusturur. �ok hafif objeler veya ba��ms�z i� yapan k���k servisler i�in tercih edilir.=> EmailSenderService


builder.Services.AddControllers();   //Controller servislerini tan�mlar.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


TokenOptions? tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
        ClockSkew = TimeSpan.Zero
    };
});


//uygulamay� yap�land�r�r
var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureCustomExceptionMiddleware();
}

if (app.Environment.IsProduction())
{
    app.ConfigureCustomExceptionMiddleware();
}


app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();  //Http isteklerini controller'lara y�nlendirir.
app.Run();

