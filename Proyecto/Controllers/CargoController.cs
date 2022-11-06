using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.permisos;

namespace WebApplication1.Controllers
{
    [ValidateSession]
    public class cargoController : Controller
    {

        private readonly string _url = "https://apiclinica.azurewebsites.net/api/Cargo";
        public async Task<ActionResult> Index()

        {
           

            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_url);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var listadoCargos = JsonConvert.DeserializeObject<List<TblCargo>>(responseString);
                return View(listadoCargos);
            }



        }
        public ActionResult newCargo()
        {
            return View();
        }
        //agregar a el json
        [HttpPost]
        //siempre debe ser un model

        public async Task<ActionResult>AgregarCargo(TblCargo model)

        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            using (var http = new HttpClient())
            {
                var CargoSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(CargoSerializada, Encoding.UTF8, "application/json");
                var response = await http.PostAsync(_url, content);
                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
                return RedirectToAction("Index");
            }

        }


        public async Task<ActionResult> modificarCargo(int id)
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_url + "/" + id);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var cargo = JsonConvert.DeserializeObject<TblCargo>(responseString);
                return View(cargo);
            }
            
        }

        //modifica los datos de la bd
        [HttpPost]
        public async Task<ActionResult> modificarCargo(TblCargo model)
        {
            using (var http = new HttpClient())
            {
                var cargoSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(cargoSerializada, Encoding.UTF8, "application/json");
                var response = await http.PutAsync(_url + "/" + model.IdCargo, content);
                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
                return RedirectToAction("Index");
            }

        }

        public async Task<string> eliminarCargo(int id)
        {
            using (var http = new HttpClient())
            {
                var response = await http.DeleteAsync(_url + "/" + id);
                if (!response.IsSuccessStatusCode)
                {
                    return "Error";
                }
                return "Exito";
            }
        }

    }
}
