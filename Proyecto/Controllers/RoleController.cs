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

namespace WebApplication1.Controllers
{
    [ValidateSession]
    public class RoleController : Controller
    {
        private readonly string _urlRoles = "https://apiclinica.azurewebsites.net/api/Roles";
        // GET: RoleI
        public async Task<ActionResult> Index()
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_urlRoles);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var listadoRol = JsonConvert.DeserializeObject<List<TblRole>>(responseString);
                return View(listadoRol);
            }
        }
        public ActionResult agregarRole()
        {
            return View();
        }
            //agregar a el json
            [HttpPost]
        //siempre debe ser un model
        public async Task<ActionResult> agregarRole(TblRole model)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            using (var http = new HttpClient())
            {
                var RoleSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(RoleSerializada, Encoding.UTF8, "application/json");
                var response = await http.PostAsync(_urlRoles, content);
                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
                return RedirectToAction("Index");
            }

        }


        public async Task<ActionResult> modificarRole(int id)
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_urlRoles + "/" + id);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var Role = JsonConvert.DeserializeObject<TblRole>(responseString);
                return View(Role);
            }

        }

        //modifica los datos de la bd
        [HttpPost]
        public async Task<ActionResult> modificarRole(TblRole model)
        {
            using (var http = new HttpClient())
            {
                var RoleSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(RoleSerializada, Encoding.UTF8, "application/json");
                var response = await http.PutAsync(_urlRoles + "/" + model.IdRol, content);
                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
                return RedirectToAction("Index");
            }

        }
        //elimina los datos de la bd

        public async Task<string> eliminarRole(int id)
        {
            using (var http = new HttpClient())
            {
                var response = await http.DeleteAsync(_urlRoles + "/" + id);
                if (!response.IsSuccessStatusCode)
                {
                    return "Error";
                }
                return "Exito";
            }
        }


    }
}




