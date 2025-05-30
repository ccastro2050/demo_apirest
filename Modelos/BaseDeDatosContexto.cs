using Microsoft.EntityFrameworkCore;

namespace demo_apirest.Modelos
{
    // Representa el contexto de la base de datos local
    public class BaseDeDatosContexto : DbContext
    {
        // Constructor que permite recibir las opciones de configuración desde el sistema
        public BaseDeDatosContexto(DbContextOptions<BaseDeDatosContexto> opciones) : base(opciones)
        {
        }

        // Representa la tabla de personas
        public DbSet<Persona> Personas { get; set; }
    }
}
// Esta clase define el contexto de la base de datos utilizando Entity Framework Core.
// Permite interactuar con la base de datos y define las tablas que se utilizarán en la aplicación.