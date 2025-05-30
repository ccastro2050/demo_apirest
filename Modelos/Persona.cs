namespace demo_apirest.Modelos
{
    // Representa una persona en el sistema
    public class Persona
    {
        public int Id { get; set; }              // Identificador único (clave primaria)

        public string? Nombre { get; set; }      // Nombre de la persona (puede ser nulo)
        
        public int Edad { get; set; }            // Edad de la persona

        public string? Correo { get; set; }      // Correo electrónico (puede ser nulo)
    }
}

// Esta clase define la estructura de una persona con propiedades básicas como Id, Nombre, Edad y Correo.
// Se utiliza para mapear los datos de la persona a la base de datos y facilitar su manipulación en la aplicación.
// La propiedad Id es la clave primaria y se generará automáticamente al crear una nueva persona.
// Se utiliza en conjunto con Entity Framework Core para realizar operaciones CRUD en la base de datos.
// La propiedad Id es la clave primaria y se generará automáticamente al crear una nueva persona.
