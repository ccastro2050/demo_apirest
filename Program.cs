using demo_apirest.Modelos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(); // Agregar esta línea

builder.Services.AddDbContext<BaseDeDatosContexto>(opciones =>
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConexionBd"))
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers(); // Esta línea reemplaza el MapGet anterior

app.Run();
// Este es el punto de entrada principal para la aplicación ASP.NET Core.
// Configura los servicios necesarios, incluyendo Swagger para la documentación de la API y el contexto de la base de datos.