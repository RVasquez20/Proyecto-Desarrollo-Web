using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api.Models;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public PacientesController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/Pacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPaciente>>> GetTblPacientes()
        {
            return Ok(await _context.TblPacientes.ToListAsync());
        }

        // PUT: api/Pacientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPaciente(int id, TblPaciente tblPaciente)
        {
            if (id != tblPaciente.IdPaciente)
            {
                return BadRequest("El id no coincide");
            }

            _context.Entry(tblPaciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPacienteExists(id))
                {
                    return NotFound("No se encontro la clinica");
                }
                else
                {
                    throw;
                }
            }

            return Ok(tblPaciente);
        }

        // POST: api/Pacientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblPaciente>> PostTblPaciente(TblPaciente tblPaciente)
        {
            _context.TblPacientes.Add(tblPaciente);
            await _context.SaveChangesAsync();
            
            return Ok(tblPaciente);
        }

        // DELETE: api/Pacientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblPaciente(int id)
        {
            var tblPaciente = await _context.TblPacientes.FindAsync(id);
            if (tblPaciente == null)
            {
                return NotFound("No se encontro el paciente");
            }

            _context.TblPacientes.Remove(tblPaciente);
            await _context.SaveChangesAsync();

            return Ok("Paciente eliminado");
        }

        private bool TblPacienteExists(int id)
        {
            return _context.TblPacientes.Any(e => e.IdPaciente == id);
        }

        //Filtros 
        //Diagnosticos por paciente
        [HttpGet("Diagnosticos/{id}")]
        public async Task<ActionResult> GetDiagnosticos(int id)
        {
            var diagnosticos = _context.TblPacientes.ToList()
                .Where(x=>x.IdPaciente==id)
                .Join(_context.TblConsultas,
                paciente => paciente.IdPaciente,
                consulta => consulta.IdPaciente,
                (paciente, consulta) => new {
                    IdPaciente=paciente.IdPaciente,
                    Nombre = paciente.Nombre,
                    NoAfiliacion = paciente.NoAfiliacion,
                    NoConsulta = consulta.IdConsulta,
                    IdDiagnostico=consulta.IdDiagnostico
                }).ToList().Join(_context.TblDiagnosticos,
                consulta=>consulta.IdDiagnostico,
                diagnosticos => diagnosticos.IdDiagnostico,
                (consulta, diagnosticos) => new
                {
                    IdPaciente = consulta.IdPaciente,
                    Nombre = consulta.Nombre,
                    NoAfiliacion = consulta.NoAfiliacion,
                    NoConsulta = consulta.NoConsulta,
                    IdDiagnostico = consulta.IdDiagnostico,
                    Titulo=diagnosticos.Titulo,
                    Descripcion=diagnosticos.Descripcion
                }).ToList();
            if (diagnosticos == null)
            {
                return NotFound("No se encontraron diagnosticos");
            }
            return Ok(diagnosticos);
        }

        //Recetas por paciente
        [HttpGet("Recetas/{id}")]
        public async Task<ActionResult> GetRecetas(int id)
        {
            var recetas = _context.TblPacientes.ToList()
                .Where(x => x.IdPaciente == id)
                .Join(_context.TblConsultas,
                paciente => paciente.IdPaciente,
                consulta => consulta.IdPaciente,
                (paciente, consulta) => new {
                    IdPaciente = paciente.IdPaciente,
                    Nombre = paciente.Nombre,
                    NoAfiliacion = paciente.NoAfiliacion,
                    NoConsulta = consulta.IdConsulta,
                    IdRecetas = consulta.IdReceta
                }).ToList().Join(_context.TblRecetas,
                consulta => consulta.IdRecetas,
                recetas => recetas.IdReceta,
                (consulta, recetas) => new
                {
                    IdPaciente = consulta.IdPaciente,
                    Nombre = consulta.Nombre,
                    NoAfiliacion = consulta.NoAfiliacion,
                    NoConsulta = consulta.NoConsulta,
                    IdRecetas = consulta.IdRecetas,
                    Serie = recetas.Serie,
                    FechaEmision = recetas.FechaEmision
                }).ToList();
            if (recetas == null)
            {
                return NotFound("No se encontraron recetas");
            }
            return Ok(recetas);
        }

        //Examenes por paciente
        [HttpGet("Examenes/{id}")]
        public async Task<ActionResult> GetExamen(int id)
        {
            var diagnosticos = _context.TblPacientes.ToList()
                .Where(x => x.IdPaciente == id)
                .Join(_context.TblConsultas,
                paciente => paciente.IdPaciente,
                consulta => consulta.IdPaciente,
                (paciente, consulta) => new {
                    IdPaciente = paciente.IdPaciente,
                    Nombre = paciente.Nombre,
                    NoAfiliacion = paciente.NoAfiliacion,
                    NoConsulta = consulta.IdConsulta,
                    Idconsulta = consulta.IdConsulta
                }).ToList().Join(_context.TblExamenesConsultas,
                consulta => consulta.Idconsulta,
                ExamenConsulta => ExamenConsulta.IdConsulta,
                (consulta, ExamenConsulta) => new
                {
                    IdPaciente = consulta.IdPaciente,
                    Nombre = consulta.Nombre,
                    NoAfiliacion = consulta.NoAfiliacion,
                    NoConsulta = consulta.NoConsulta,
                    Idconsulta = consulta.Idconsulta,
                    IdExamen = ExamenConsulta.IdExamen

                }).ToList().Join(_context.TblExamenes,
                consulta => consulta.IdExamen,
                Examenes => Examenes.IdExamen,
                (consulta, Examenes) => new
                {
                    IdPaciente = consulta.IdPaciente,
                    Nombre = consulta.Nombre,
                    NoAfiliacion = consulta.NoAfiliacion,
                    NoConsulta = consulta.NoConsulta,
                    Idconsulta = consulta.Idconsulta,
                    IdExamen = consulta.IdExamen,
                    nombre = Examenes.Nombre,
                    descripcion = Examenes.Descripcion,
                    precio = Examenes.Precio
                }).ToList();
            if (diagnosticos == null)
            {
                return NotFound("No se encontraron diagnosticos");
            }
            return Ok(diagnosticos);
        }


    }
}
