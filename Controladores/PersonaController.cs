using Microsoft.AspNetCore.Mvc;
using demo_apirest.Modelos;
using Microsoft.EntityFrameworkCore;

namespace demo_apirest.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly BaseDeDatosContexto _contexto;

        public PersonaController(BaseDeDatosContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> ObtenerPersonas()
        {
            return await _contexto.Personas.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Persona>> InsertarPersona(Persona persona)
        {
            _contexto.Personas.Add(persona);
            await _contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(ObtenerPersonas), new { id = persona.Id }, persona);
        }
    }
}

// Este controlador maneja las operaciones CRUD para la entidad Persona en una API RESTful.
// Utiliza Entity Framework Core para interactuar con la base de datos y proporciona métodos para obtener una lista de personas y para insertar una nueva persona.
// El controlador está decorado con [ApiController] y [Route] para definir la ruta base de la API.