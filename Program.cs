//Uygulama olu�turma
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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


