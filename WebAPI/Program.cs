using Business.Abstracts;
using Business.Concretes;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstracts;
using Repositories.Concretes.EntityFramework;
using Repositories.Concretes.EntityFramework.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BaseDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("BaseDb")));


builder.Services.AddScoped<IBrandService, BrandManager>();          //Her http request icin bir kez olusturulur
builder.Services.AddScoped<IBrandRepository, BrandRepository>();

//AddSingleton => Uygulama baslad�g�nda bir kez olusturulur. Cok s�k kullan�lan ve degismeyen yap�lar icin. Cache islemleri,Config islemleri
//AddTransiet => Her kullan�mda yeni bir nesne olusturur. �ok hafif objeler veya ba��ms�z i� yapan k���k servisler i�in tercih edilir.=> EmailSenderService


builder.Services.AddControllers();   //Controller servislerini tan�mlar.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//uygulamay� yap�land�r�r
var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}





app.MapControllers();  //Http isteklerini controller'lara y�nlendirir.
app.Run();

