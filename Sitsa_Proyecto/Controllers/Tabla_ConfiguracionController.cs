using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Modelos;
using Biblioteca_Clases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitsa_Proyecto.Controllers
{
    public class Tabla_ConfiguracionController : Controller
    {
        // GET: Tabla_Configuracion

        Tabla_ConfiguracionModelo tabla_configuracion_modelo = new Tabla_ConfiguracionModelo();


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult agregar_tabla_configuracion(Tabla_Configuracion cont)
        {
            var t = cont;
            string validacion = tabla_configuracion_modelo.agregar_tabla_configuracion(cont, (string)(Session["User"]));
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult modificar_tabla_configuracion(Tabla_Configuracion tbl_config)
        {
            var t = tbl_config;
            string validacion = tabla_configuracion_modelo.modificar_tabla_configuracion(tbl_config, (string)(Session["User"]));
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Eliminar_Tabla(int id)
        {

            int result = tabla_configuracion_modelo.Eliminar_Tabla(id);

            return Json(result, JsonRequestBehavior.AllowGet);

        }
    }
}