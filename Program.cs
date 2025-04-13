//Uygulama oluþturma
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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


