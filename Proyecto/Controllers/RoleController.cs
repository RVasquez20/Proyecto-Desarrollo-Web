using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    }
}




