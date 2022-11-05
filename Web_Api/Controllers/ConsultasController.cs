using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Web_Api.Models;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public ConsultasController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/Consultas
        [HttpGet]
        public async Task<ActionResult> GetTblConsultas()
        {
            var listado = _context.TblConsultas.ToList().Join(_context.TblPacientes,
                consulta => consulta.IdPaciente,
                paciente => paciente.IdPaciente,
                (consulta, paciente) => new
                {
                    IdConsulta = consulta.IdConsulta,
                    IdPaciente = consulta.IdPaciente,
                    IdEmpleado = consulta.IdEmpleado,
                    IdClinica = consulta.IdClinica,
                    IdDiagnostico = consulta.IdDiagnostico,
                    IdReceta = consulta.IdReceta,
                    Paciente = paciente.Nombre
                }).ToList().Join(_context.TblEmpleados,
                consulta => consulta.IdEmpleado,
                empleado => empleado.IdEmpleado,
                (consulta, empleado) => new
                {
                    IdConsulta = consulta.IdConsulta,
                    IdPaciente = consulta.IdPaciente,
                    IdEmpleado = consulta.IdEmpleado,
                    IdClinica = consulta.IdClinica,
                    IdDiagnostico = consulta.IdDiagnostico,
                    IdReceta = consulta.IdReceta,
                    Paciente = consulta.Paciente,
                    Empleado = empleado.Nombre
                }).ToList().Join(_context.TblClinicas,
                consulta => consulta.IdClinica,
                clinica => clinica.IdClinica,
                (consulta, clinica) => new
                {
                    IdConsulta = consulta.IdConsulta,
                    IdPaciente = consulta.IdPaciente,
                    IdEmpleado = consulta.IdEmpleado,
                    IdClinica = consulta.IdClinica,
                    IdDiagnostico = consulta.IdDiagnostico,
                    IdReceta = consulta.IdReceta,
                    Paciente = consulta.Paciente,
                    Empleado = consulta.Empleado,
                    Clinica = clinica.Nombre
                }).ToList().Join(_context.TblDiagnosticos,
                consulta => consulta.IdDiagnostico,
                diagnosticos => diagnosticos.IdDiagnostico,
                (consulta, diagnosticos) => new
                {
                    IdConsulta = consulta.IdConsulta,
                    IdPaciente = consulta.IdPaciente,
                    IdEmpleado = consulta.IdEmpleado,
                    IdClinica = consulta.IdClinica,
                    IdDiagnostico = consulta.IdDiagnostico,
                    IdReceta = consulta.IdReceta,
                    Paciente = consulta.Paciente,
                    Empleado = consulta.Empleado,
                    Clinica = consulta.Clinica,
                    Diagnostico = diagnosticos.Titulo
                }).ToList().Join(_context.TblRecetas,
                consulta => consulta.IdReceta,
                recetas => recetas.IdReceta,
                (consulta, recetas) => new
                {
                    IdConsulta = consulta.IdConsulta,
                    IdPaciente = consulta.IdPaciente,
                    IdEmpleado = consulta.IdEmpleado,
                    IdClinica = consulta.IdClinica,
                    IdDiagnostico = consulta.IdDiagnostico,
                    IdReceta = consulta.IdReceta,
                    Paciente = consulta.Paciente,
                    Empleado = consulta.Empleado,
                    Clinica = consulta.Clinica,
                    Diagnostico = consulta.Diagnostico,
                    Receta = recetas.Serie
                }).ToList();


            return Ok(listado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblConsulta>> GetTblConsultas(int id)
        {
            var listado = _context.TblConsultas.ToList()
                .Where(x=>x.IdPaciente==id)
                .Join(_context.TblPacientes,
                consulta => consulta.IdPaciente,
                paciente => paciente.IdPaciente,
                (consulta, paciente) => new
                {
                    IdConsulta = consulta.IdConsulta,
                    IdPaciente = consulta.IdPaciente,
                    IdEmpleado = consulta.IdEmpleado,
                    IdClinica = consulta.IdClinica,
                    IdDiagnostico = consulta.IdDiagnostico,
                    IdReceta = consulta.IdReceta,
                    Paciente = paciente.Nombre
                }).ToList().Join(_context.TblEmpleados,
                consulta => consulta.IdEmpleado,
                empleado => empleado.IdEmpleado,
                (consulta, empleado) => new
                {
                    IdConsulta = consulta.IdConsulta,
                    IdPaciente = consulta.IdPaciente,
                    IdEmpleado = consulta.IdEmpleado,
                    IdClinica = consulta.IdClinica,
                    IdDiagnostico = consulta.IdDiagnostico,
                    IdReceta = consulta.IdReceta,
                    Paciente = consulta.Paciente,
                    Empleado = empleado.Nombre
                }).ToList().Join(_context.TblClinicas,
                consulta => consulta.IdClinica,
                clinica => clinica.IdClinica,
                (consulta, clinica) => new
                {
                    IdConsulta = consulta.IdConsulta,
                    IdPaciente = consulta.IdPaciente,
                    IdEmpleado = consulta.IdEmpleado,
                    IdClinica = consulta.IdClinica,
                    IdDiagnostico = consulta.IdDiagnostico,
                    IdReceta = consulta.IdReceta,
                    Paciente = consulta.Paciente,
                    Empleado = consulta.Empleado,
                    Clinica = clinica.Nombre
                }).ToList().Join(_context.TblDiagnosticos,
                consulta => consulta.IdDiagnostico,
                diagnosticos => diagnosticos.IdDiagnostico,
                (consulta, diagnosticos) => new
                {
                    IdConsulta = consulta.IdConsulta,
                    IdPaciente = consulta.IdPaciente,
                    IdEmpleado = consulta.IdEmpleado,
                    IdClinica = consulta.IdClinica,
                    IdDiagnostico = consulta.IdDiagnostico,
                    IdReceta = consulta.IdReceta,
                    Paciente = consulta.Paciente,
                    Empleado = consulta.Empleado,
                    Clinica = consulta.Clinica,
                    Diagnostico = diagnosticos.Titulo
                }).ToList().Join(_context.TblRecetas,
                consulta => consulta.IdReceta,
                recetas => recetas.IdReceta,
                (consulta, recetas) => new
                {
                    IdConsulta = consulta.IdConsulta,
                    IdPaciente = consulta.IdPaciente,
                    IdEmpleado = consulta.IdEmpleado,
                    IdClinica = consulta.IdClinica,
                    IdDiagnostico = consulta.IdDiagnostico,
                    IdReceta = consulta.IdReceta,
                    Paciente = consulta.Paciente,
                    Empleado = consulta.Empleado,
                    Clinica = consulta.Clinica,
                    Diagnostico = consulta.Diagnostico,
                    Receta = recetas.Serie
                }).ToList();

            if (listado == null)
            {
                return NotFound();
            }

            return Ok(listado);
        }




        [HttpGet]
        [Route("Details/{id}")]
        public async Task<ActionResult<TblConsulta>> GetTblConsultasDetails(int id)
        {
            var listado = _context.TblConsultas.ToList()
                .Where(x => x.IdConsulta == id)
                .Join(_context.TblPacientes,
                consulta => consulta.IdPaciente,
                paciente => paciente.IdPaciente,
                (consulta, paciente) => new
                {
                    IdConsulta = consulta.IdConsulta,
                    IdPaciente = consulta.IdPaciente,
                    IdEmpleado = consulta.IdEmpleado,
                    IdClinica = consulta.IdClinica,
                    IdDiagnostico = consulta.IdDiagnostico,
                    IdReceta = consulta.IdReceta,
                    Paciente = paciente.Nombre
                }).ToList().Join(_context.TblEmpleados,
                consulta => consulta.IdEmpleado,
                empleado => empleado.IdEmpleado,
                (consulta, empleado) => new
                {
                    IdConsulta = consulta.IdConsulta,
                    IdPaciente = consulta.IdPaciente,
                    IdEmpleado = consulta.IdEmpleado,
                    IdClinica = consulta.IdClinica,
                    IdDiagnostico = consulta.IdDiagnostico,
                    IdReceta = consulta.IdReceta,
                    Paciente = consulta.Paciente,
                    Empleado = empleado.Nombre
                }).ToList().Join(_context.TblClinicas,
                consulta => consulta.IdClinica,
                clinica => clinica.IdClinica,
                (consulta, clinica) => new
                {
                    IdConsulta = consulta.IdConsulta,
                    IdPaciente = consulta.IdPaciente,
                    IdEmpleado = consulta.IdEmpleado,
                    IdClinica = consulta.IdClinica,
                    IdDiagnostico = consulta.IdDiagnostico,
                    IdReceta = consulta.IdReceta,
                    Paciente = consulta.Paciente,
                    Empleado = consulta.Empleado,
                    Clinica = clinica.Nombre
                }).ToList().Join(_context.TblDiagnosticos,
                consulta => consulta.IdDiagnostico,
                diagnosticos => diagnosticos.IdDiagnostico,
                (consulta, diagnosticos) => new
                {
                    IdConsulta = consulta.IdConsulta,
                    IdPaciente = consulta.IdPaciente,
                    IdEmpleado = consulta.IdEmpleado,
                    IdClinica = consulta.IdClinica,
                    IdDiagnostico = consulta.IdDiagnostico,
                    IdReceta = consulta.IdReceta,
                    Paciente = consulta.Paciente,
                    Empleado = consulta.Empleado,
                    Clinica = consulta.Clinica,
                    Diagnostico = diagnosticos.Titulo
                }).ToList().Join(_context.TblRecetas,
                consulta => consulta.IdReceta,
                recetas => recetas.IdReceta,
                (consulta, recetas) => new
                {
                    IdConsulta = consulta.IdConsulta,
                    IdPaciente = consulta.IdPaciente,
                    IdEmpleado = consulta.IdEmpleado,
                    IdClinica = consulta.IdClinica,
                    IdDiagnostico = consulta.IdDiagnostico,
                    IdReceta = consulta.IdReceta,
                    Paciente = consulta.Paciente,
                    Empleado = consulta.Empleado,
                    Clinica = consulta.Clinica,
                    Diagnostico = consulta.Diagnostico,
                    Receta = recetas.Serie,
                    Examenes=(_context.TblExamenesConsultas.Where(x=>x.IdConsulta==id).Join(_context.TblExamenes,
                    c=>c.IdExamen,
                    e=>e.IdExamen,
                    (c, e) => new
                    {
                        IdExamen=c.IdExamen,
                        Nombre=e.Nombre,
                        Descripcion=e.Descripcion,
                        Precio=e.Precio
                    }).ToList())
                }).ToList();

            if (listado == null)
            {
                return NotFound();
            }

            return Ok(listado);
        }



        // PUT: api/Consultas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblConsulta(int id, TblConsulta tblConsulta)
        {
            if (id != tblConsulta.IdConsulta)
            {
                return BadRequest("El id no coincide");
            }

            _context.Entry(tblConsulta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblConsultaExists(id))
                {
                    return NotFound("No existe el registro");
                }
                else
                {
                    throw;
                }
            }

            return Ok(tblConsulta);
        }

        // POST: api/Consultas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblConsulta>> PostTblConsulta(TblConsulta tblConsulta)
        {
            try
            {
                _context.TblConsultas.Add(tblConsulta);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(tblConsulta);
        }

        // DELETE: api/Consultas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblConsulta(int id)
        {
            var tblConsulta = await _context.TblConsultas.FindAsync(id);
            if (tblConsulta == null)
            {
                return NotFound("No existe el registro");
            }

            _context.TblConsultas.Remove(tblConsulta);
            await _context.SaveChangesAsync();

            return Ok("Registro eliminado");
        }

        private bool TblConsultaExists(int id)
        {
            return _context.TblConsultas.Any(e => e.IdConsulta == id);
        }
    }
}
