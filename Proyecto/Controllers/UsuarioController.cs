﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.permisos;

namespace WebApplication1.Controllers
{
    [ValidateSession]
    public class UsuarioController : Controller
    {
        // GET: UsuarioI
        public ActionResult Index()
        {
            //get para obtener listado de usuarios
            var dataUsers = new List<Usuarios>()
            {
                
                new Usuarios()
                {
                    id_usuario=1,
                    nombre="juana",
                    username="Juana22",
                    pass="1234",
                    id_rol=1
                },
                 new Usuarios()
                {
                    id_usuario=2,
                    nombre="juan",
                    username="Juan22",
                    pass="1234",
                    id_rol=2
                },
                  new Usuarios()
                {
                    id_usuario=3,
                    nombre="juana",
                    username="Juana22",
                    pass="1234",
                    id_rol=1
                }
            };
            //peticion get para obtener listado de roles
            var dataRoles = new List<Roles>()
            {
                new Roles()
                {
                    id_rol=1,
                    ROL="admin"
                },
                new Roles()
                {
                    id_rol=2,
                    ROL="Medico"
                }
            };

            var dataUsuariosViewModel = (from u in dataUsers
                                         join r in dataRoles
                                         on u.id_rol equals r.id_rol
                                         select new UsuariosViewModel
                                         {
                                             id_usuario=u.id_usuario,
                                             nombre=u.nombre,
                                             username=u.username,
                                             pass=u.pass,
                                             id_rol=r.id_rol,
                                             nombreRol=r.ROL
                                         }).ToList();

            return View(dataUsuariosViewModel);
        }

        public ActionResult newUser()
        {
            var dataRoles = new List<Roles>()
            {
                new Roles()
                {
                    id_rol=1,
                    ROL="admin"
                },
                new Roles()
                {
                    id_rol=2,
                    ROL="Medico"
                }
            };
            var listadoRoles = dataRoles.ConvertAll(r=>
            {
                return new SelectListItem()
                {
                    Text = r.ROL,
                    Value = r.id_rol.ToString(),
                    Selected = false
                };
            });
            ViewBag.listadoRoles=listadoRoles;
            return View();
        }
    }
}