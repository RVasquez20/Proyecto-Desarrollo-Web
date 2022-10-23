using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.permisos;

namespace WebApplication1.Controllers
{
    [ValidateSession]
    public class ConsultaController : Controller
    {
        // GET: Consulta
        public ActionResult Consulta()
        {
            var lista = new List<ConsultaViewModel>()
            {
                new ConsultaViewModel()
                {
                    idConsulta = 1,
                    nombre = "Consulta 1",
                    idPaciente = 2,
                    Paciente = "Juan",
                    idEmpleado = 1,
                    Empleado = "Pepito",
                    idClinica = 1,
                    Clinica = "Clinica 1",
                    idDiagnostico = 1,
                    Diagnostico = "Diagnostico 1",
                    idReceta = 1,
                    Receta = "Receta 1"
                },
                new ConsultaViewModel()
                {
                    idConsulta = 2,
                    nombre = "Consulta 2",
                    idPaciente = 1,
                    Paciente = "Dayana",
                    idEmpleado = 1,
                    Empleado = "Pepito",
                    idClinica = 2,
                    Clinica = "Clinica 2",
                    idDiagnostico = 1,
                    Diagnostico = "Diagnostico 2",
                    idReceta = 2,
                    Receta = "Receta 2"
                }
            };
            return View();
        }

        public ActionResult newConsulta()
        {
            var dataPaciente = new List<Pacientes>()
            {
                new Pacientes()
                {
                    idPaciente = 1,
                    no_afiliado = "2541254789654",
                    nombre = "Dayana",
                    direccion = "Ecuador",
                    telefono = 12345678
                },
                new Pacientes()
                {
                    idPaciente = 2,
                    no_afiliado = "547896541254",
                    nombre = "Juan",
                    direccion = "Perez",
                    telefono = 87654321
                }
            };
            var listadoPaciente = dataPaciente.ConvertAll(r =>
            {
                return new SelectListItem()
                {
                    Text = r.no_afiliado + "," + r.nombre,
                    Value = r.idPaciente.ToString(),
                    Selected = false
                };
            });
            ViewBag.listadoPaciente = listadoPaciente;

            var dataEmpleado = new List<EmpleadosViewModel>()
            {
                new EmpleadosViewModel()
                {
                    idEmpleado=1,
                    Nombre="Pepito",
                    Apellido="Perez",
                    IdCargo=1,
                    Cargo="Medico"
                },
                new EmpleadosViewModel()
                {
                    idEmpleado=2,
                    Nombre="Pepito2",
                    Apellido="Perez2",
                    IdCargo=2,
                    Cargo="Administrador"
                }
            };
            var listadoEmpleado = dataEmpleado.ConvertAll(r =>
            {
                return new SelectListItem()
                {
                    Text = r.Nombre + "," + r.Apellido,
                    Value = r.idEmpleado.ToString(),
                    Selected = false
                };
            });
            ViewBag.listadoEmpleado = listadoEmpleado;

            var dataClinica = new List<ClinicaViewModel>()
            {
                new ClinicaViewModel()
                {
                    idClinica = 1,
                    nombre = "Clinica 1",
                    direccion = "Direccion 1"
                },
                new ClinicaViewModel()
                {
                    idClinica = 2,
                    nombre = "Clinica 2",
                    direccion = "Direccion 2"
                }
            };
            var listadoClinica = dataClinica.ConvertAll(r =>
            {
                return new SelectListItem()
                {
                    Text = r.nombre + "," + r.direccion,
                    Value = r.idClinica.ToString(),
                    Selected = false
                };
            });
            ViewBag.listadoClinica = listadoClinica;

            var dataDiagnostico = new List<Diagnosticos>()
            {
                new Diagnosticos()
                {
                    idDiagnostico = 1,
                    titulo = "General",
                    descripcion = "General"
                },
                new Diagnosticos()
                {
                    idDiagnostico = 2,
                    titulo = "Interno",
                    descripcion = "Interno"
                }
            };
            var listadoDiagnostico = dataDiagnostico.ConvertAll(r =>
            {
                return new SelectListItem()
                {
                    Text = r.titulo,
                    Value = r.idDiagnostico.ToString(),
                    Selected = false
                };
            });
            ViewBag.listadoDiagnostico = listadoDiagnostico;

            var dataReceta = new List<Receta>()
            {
                new Receta()
                {
                    idReceta = 1,
                    serie_receta = "Juana Maria",
                    fecha_emision = DateTime.Now
                },
                new Receta()
                {
                    idReceta = 2,
                    serie_receta = "",
                    fecha_emision = DateTime.Now
                }
            };
            var listadoReceta = dataReceta.ConvertAll(r =>
            {
                return new SelectListItem()
                {
                    Text = r.serie_receta + "," + r.fecha_emision,
                    Value = r.idReceta.ToString(),
                    Selected = false
                };
            });
            return View();
        }
    }
}