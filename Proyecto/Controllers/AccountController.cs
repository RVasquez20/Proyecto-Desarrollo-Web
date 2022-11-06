using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using WebApplication1.Models;
using WebApplication1.Services;
using static System.Net.WebRequestMethods;

namespace WebApplication1.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly string _url = "https://apiclinica.azurewebsites.net/api/Usuarios";

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }


        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session["User"] = null;
            Session["Empleado"] = null;
            Session["NClinica"] = null;
            Session["IDClinica"] = null;
            var accesos = (List<TblAccess>)Session["Accesos"];
            foreach (var acceso in accesos)
            {
                Session[acceso.Name] = null;
            }
            return RedirectToAction("Login", "Account");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var _http = new HttpClient())
            {
                var oUser = new TblUsuario();
                oUser.Username = model.User;
                oUser.Password = Encrypt.GetHash(model.Password);
                var userSerializer = JsonConvert.SerializeObject(oUser);
                var content = new StringContent(userSerializer, Encoding.UTF8, "application/json");
                var response = await _http.PostAsync(_url + "/Login", content);
                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("", "El Username o Password Ingresado es Incorrecto.");
                    return View(model);
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var oUsuario = JsonConvert.DeserializeObject<UsuarioViewModel>(responseString);
                Session["User"] = oUsuario.Username;
                Session["Empleado"] = oUsuario.IdEmpleado;
                Session["IDClinica"] = oUsuario.IdClinica;
                Session["NClinica"] = oUsuario.Clinica;
                var accesos =await getMenu(oUsuario.IdUsuario);
                Session["Accesos"] = accesos;
                foreach (var acceso in accesos)
                {
                    Session[acceso.Name] = acceso.Url;
                }
                return RedirectToAction("Index", "Home");

            }
        }
               

        public async Task<List<TblAccess>> getMenu(int idUser)
        {
            using (var _http = new HttpClient())
            {
                var response = await _http.GetAsync(_url + "/ListaAccesos/"+ idUser.ToString());
                if (!response.IsSuccessStatusCode)
                {
                    return new List<TblAccess>();
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var oAccess = JsonConvert.DeserializeObject<List<TblAccess>>(responseString);
                return oAccess;
            }
        }
    }
}