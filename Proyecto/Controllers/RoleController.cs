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
    public class RoleController : Controller
    {
        // GET: RoleI
        public ActionResult Index()
        {
            var dataRoles = new List<RolesViewModel>()
            {
                new RolesViewModel()
                {
                    id_rol=1,
                    ROL="admin"
                },
                new RolesViewModel()
                {
                    id_rol=2,
                    ROL="Medico"
                }
            };
            return View(dataRoles);  
        }
    }
}




