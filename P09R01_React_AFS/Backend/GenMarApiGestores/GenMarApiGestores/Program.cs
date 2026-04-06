using Microsoft.EntityFrameworkCore;
using GenMarApiGestores.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

//Vamos a configurar CORS para que React se conecte por la api
//vamos a llevar esta configuraciones para hacer la conexion puente entre nuestro bakend api y fronend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
    {
        //Puestos comunes de React - Vite
        policy.WithOrigins("http://localhost:3000", "http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
    });
});





builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowReact");

app.UseAuthorization();

app.MapControllers();

app.Run();
