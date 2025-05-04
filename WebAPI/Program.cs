using Business;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRepositoriesServices(builder.Configuration);

builder.Services.AddBusinessServices(); 





//AddScoped => //Her http request icin bir kez olusturulur

//AddSingleton => Uygulama basladýgýnda bir kez olusturulur. Cok sýk kullanýlan ve degismeyen yapýlar icin. Cache islemleri,Config islemleri
//AddTransiet => Her kullanýmda yeni bir nesne olusturur. çok hafif objeler veya baðýmsýz iþ yapan küçük servisler için tercih edilir.=> EmailSenderService


builder.Services.AddControllers();   //Controller servislerini tanýmlar.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//uygulamayý yapýlandýrýr
var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}





app.MapControllers();  //Http isteklerini controller'lara yönlendirir.
app.Run();

