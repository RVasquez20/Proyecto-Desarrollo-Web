using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.permisos;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ValidateSession]
    public class UsuarioController : Controller
    {
        private readonly string _urlUsuario = "https://apiclinica.azurewebsites.net/api/Usuarios";
        private readonly string _urlEmpleados = "https://apiclinica.azurewebsites.net/api/Empleados";
        private readonly string _urlRoles = "https://apiclinica.azurewebsites.net/api/Roles";
        public async Task<ActionResult> Index()

        {

            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_urlUsuario);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var listadoUsuario = JsonConvert.DeserializeObject<List<UsuariosViewModel>>(responseString);
                return View(listadoUsuario);
            }



        }
        public async Task<ActionResult> newUser()
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_urlEmpleados);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var listadoEmpleados = JsonConvert.DeserializeObject<List<EmpleadosViewModel>>(responseString);
                var listadoEmpleado = listadoEmpleados.ConvertAll(r =>
                {
                    return new SelectListItem()
                    {
                        Text = (r.Nombre + " " + r.Apellido),
                        Value = r.IdEmpleado.ToString(),
                        Selected = false
                    };
                });

                var responseRoles = await http.GetAsync(_urlRoles);
                if (responseRoles.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseStringRole = await responseRoles.Content.ReadAsStringAsync();
                var listadoRoles = JsonConvert.DeserializeObject<List<TblRole>>(responseStringRole);
                var listadoRol = listadoRoles.ConvertAll(r =>
                {
                    return new SelectListItem()
                    {
                        Text = r.Rol,
                        Value = r.IdRol.ToString(),
                        Selected = false
                    };
                });
                ViewBag.listadoEmpleados = listadoEmpleado;
                ViewBag.listadoRoles = listadoRol;

                return View();
            }

        }


        //agregar a el json
        [HttpPost]
        //siempre debe ser un model
        public async Task<ActionResult> AgregarUser(TblUsuario model)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            using (var http = new HttpClient())
            {
                var oUser = new TblUsuario();
                oUser.IdEmpleado = model.IdEmpleado;
                oUser.IdRol = model.IdRol;
                oUser.Username = model.Username;
                oUser.Password = Encrypt.GetHash(model.Password);
                
                var UserSerializada = JsonConvert.SerializeObject(oUser);
                var content = new StringContent(UserSerializada, Encoding.UTF8, "application/json");
                var response = await http.PostAsync(_urlUsuario, content);
                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
                return RedirectToAction("Index");
            }

        }

        //trae la vista con los datos cargados

        public async Task<ActionResult> modificarUsuario(int id)
        {
            using (var http = new HttpClient())
            {
                var responseUser = await http.GetAsync(_urlUsuario + "/" + id);
                if (responseUser.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var response = await http.GetAsync(_urlEmpleados);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var listadoEmpleados = JsonConvert.DeserializeObject<List<EmpleadosViewModel>>(responseString);
                var listadoEmpleado = listadoEmpleados.ConvertAll(r =>
                {
                    return new SelectListItem()
                    {
                        Text = (r.Nombre+" "+r.Apellido),
                        Value = r.IdEmpleado.ToString(),
                        Selected = false
                    };
                });

                var responseRoles = await http.GetAsync(_urlRoles);
                if (responseRoles.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseStringRole = await responseRoles.Content.ReadAsStringAsync();
                var listadoRoles = JsonConvert.DeserializeObject<List<TblRole>>(responseStringRole);
                var listadoRol = listadoRoles.ConvertAll(r =>
                {
                    return new SelectListItem()
                    {
                        Text = r.Rol,
                        Value = r.IdRol.ToString(),
                        Selected = false
                    };
                });
                ViewBag.listadoEmpleados = listadoEmpleado;
                ViewBag.listadoRoles = listadoRol;

                var responseStringUser = await responseUser.Content.ReadAsStringAsync();
                var User = JsonConvert.DeserializeObject<TblUsuario>(responseStringUser);
                return View(User);
            }

        }

        //modifica los datos de la bd
        [HttpPost]
        public async Task<ActionResult> modificarUsuario(TblUsuario model)
        {
            using (var http = new HttpClient())
            {
                var responseUser = await http.GetAsync(_urlUsuario + "/" + model.IdUsuario);
                if (responseUser.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseStringUser = await responseUser.Content.ReadAsStringAsync();
                var User = JsonConvert.DeserializeObject<TblUsuario>(responseStringUser);
                User.IdEmpleado = model.IdEmpleado;
                User.IdRol = model.IdRol;
                User.Username = model.Username;
                User.Password = Encrypt.GetHash(model.Password);
                var usuarioSerializada = JsonConvert.SerializeObject(User);
                var content = new StringContent(usuarioSerializada, Encoding.UTF8, "application/json");
                var response = await http.PutAsync(_urlUsuario + "/" + model.IdUsuario, content);
                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
                return RedirectToAction("Index");
            }

        }
        //elimina los datos de la bd

        public async Task<string> eliminarUsuario(int id)
        {
            using (var http = new HttpClient())
            {
                var response = await http.DeleteAsync(_urlUsuario + "/" + id);
                if (!response.IsSuccessStatusCode)
                {
                    return "Error";
                }
                return "Exito";
            }
        }

    }
}