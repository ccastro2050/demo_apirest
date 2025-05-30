using demo_apirest.Modelos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios de Swagger y controladores
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Registrar el contexto de base de datos
builder.Services.AddDbContext<BaseDeDatosContexto>(opciones =>
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConexionBd"))
);

// Habilitar CORS con múltiples orígenes permitidos
builder.Services.AddCors(opciones =>
{
    opciones.AddPolicy("PermitirClienteBlazor", politica =>
    {
        politica.WithOrigins(
            "http://localhost:5116", // Desarrollo local
            "https://cliente.runasp.net" // Producción (ajustar si el dominio cambia)
        )
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Habilitar Swagger para todos los entornos (o solo en desarrollo si se desea)
app.UseSwagger();
app.UseSwaggerUI();

// Activar CORS antes del HTTPS
app.UseCors("PermitirClienteBlazor");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
