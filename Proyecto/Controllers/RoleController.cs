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
        private readonly string _urlAccesos = "https://apiclinica.azurewebsites.net/api/Access";
        private readonly string _urlAccesosRoles = "https://apiclinica.azurewebsites.net/api/AccessRoles";
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
        public async Task<ActionResult> agregarRole()
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_urlAccesos);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var listPermisos = JsonConvert.DeserializeObject<List<TblAccess>>(responseString);
                var listadoPermisos = listPermisos.ConvertAll(r =>
                {
                    return new SelectListItem()
                    {
                        Text = r.Name,
                        Value = r.IdAccess.ToString(),
                        Selected = false
                    };
                });
                ViewBag.listadoPermisos = listadoPermisos;
                return View();
            }
        }
        
        [HttpPost]
        public async Task<JsonResult> agregarRole(TblRole model)
        {
            if (!ModelState.IsValid)
            {
                return Json(null);
            }
            /*   using (var http = new HttpClient())
               {
                   var RoleSerializada = JsonConvert.SerializeObject(model);
                   var content = new StringContent(RoleSerializada, Encoding.UTF8, "application/json");
                   var response = await http.PostAsync(_urlRoles, content);
                   if (!response.IsSuccessStatusCode)
                   {
                       return Json(null);
                   }
                   var responseString = await response.Content.ReadAsStringAsync();
                   var role = JsonConvert.DeserializeObject<TblRole>(responseString);
                   return Json(role);
               }*/
            model.IdRol = 5;
            return Json(model);
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




