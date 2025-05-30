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

// Habilitar CORS para permitir peticiones desde el cliente Blazor
builder.Services.AddCors(opciones =>
{
    opciones.AddPolicy("PermitirClienteBlazor", politica =>
    {
        politica.WithOrigins("http://localhost:5116")
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});

var app = builder.Build();

// Habilitar Swagger para todos los entornos
app.UseSwagger();
app.UseSwaggerUI();

// Activar CORS antes de redireccionar
app.UseCors("PermitirClienteBlazor");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
