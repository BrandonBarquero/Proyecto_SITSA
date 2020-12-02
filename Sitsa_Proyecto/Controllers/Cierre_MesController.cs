using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Modelos;
using Biblioteca_Clases.Models;
using Biblioteca_Clases.Seguridad;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitsa_Proyecto.Controllers
{
    public class Cierre_MesController : Controller
    {
        PerfilDAO dao = new PerfilDAO();
        Fecha fecha = new Fecha();
        ReporteDAO daoreporte = new ReporteDAO();
        Cierre_MesDAO dao_cierre = new Cierre_MesDAO();
        Mail mail = new Mail();
        Encryption encryption = new Encryption();

        Cierre_MesModelo cierre_modelo = new Cierre_MesModelo();
        // GET: Cierre_Mes
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Permisos()
        {

            string perfil = (string)(Session["User"]);

            int permisos = cierre_modelo.Permisos(perfil);

            return Json(permisos, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Permisos_Reenvio()
        {

            string perfil = (string)(Session["User"]);

            int permisos = cierre_modelo.Permisos_Reenvio(perfil);

            return Json(permisos, JsonRequestBehavior.AllowGet);
        }


        public JsonResult AceptarReporte(string dato)
        {

            string user = (string)(Session["User"]);

            int result = cierre_modelo.AceptarReporte(dato, user);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult RechazarReporte(string dato)
        {

            string user = (string)(Session["User"]);

            int result = cierre_modelo.RechazarReporte(dato, user);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Facturados()
        {
            string sJSONResponse = cierre_modelo.Facturados();

            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Buscar(string reporte, string cliente, string horas_convertidas, string horas_convertidas2)
        {
            string sJSONResponse = cierre_modelo.Buscar(reporte, cliente, horas_convertidas, horas_convertidas2);

            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Buscar_Facturados(string reporte, string cliente, string horas_convertidas, string horas_convertidas2)
        {
            string sJSONResponse = cierre_modelo.Buscar_Facturados(reporte, cliente, horas_convertidas, horas_convertidas2);

            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Generales()
        {
            string sJSONResponse = cierre_modelo.Generales();

            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Reenviar_Correo(string dato)
        {
            string sJSONResponse = cierre_modelo.Reenviar_Correo(dato);

            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Cambiar_Estado_Reporte(string ID_Reporte, string correos)
        {
            int result = cierre_modelo.Cambiar_Estado_Reporte(ID_Reporte, correos);

            return Json(result, JsonRequestBehavior.AllowGet);

        }
    }
}