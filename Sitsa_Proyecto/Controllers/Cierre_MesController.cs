using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
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
        Fecha fecha = new Fecha();
        ReporteDAO daoreporte = new ReporteDAO();
        // GET: Cierre_Mes
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Filtrar_Cliente(string dato)
        {
            List<Reporte> list = daoreporte.listaCliente(dato);


            string sJSONResponse = JsonConvert.SerializeObject(list, Formatting.Indented);
            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Filtrar_Clientefacturado(string dato)
        {
            List<Reporte> list = daoreporte.listaClienteFacturado(dato);


            string sJSONResponse = JsonConvert.SerializeObject(list, Formatting.Indented);
            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Filtrar_Reporte(string dato)
        {
            List<Reporte> list = daoreporte.listaReporte(dato);


            string sJSONResponse = JsonConvert.SerializeObject(list, Formatting.Indented);
            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Filtrar_Reporte_Facturados(string dato)
        {
            List<Reporte> list = daoreporte.listaReportefacturados(dato);


            string sJSONResponse = JsonConvert.SerializeObject(list, Formatting.Indented);
            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Filtrar_Fechas(string dato, string dato1)
        {
            



            List<Reporte> list = daoreporte.listaFechas(dato, dato1);


            string sJSONResponse = JsonConvert.SerializeObject(list, Formatting.Indented);
            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Filtrar_Fechas_Facturado(string dato, string dato1)
        {

            List<Reporte> list = daoreporte.listaFechasfacturado(dato, dato1);


            string sJSONResponse = JsonConvert.SerializeObject(list, Formatting.Indented);
            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AceptarReporte(string dato)
        {
            string user = (string)(Session["User"]);

          int result = daoreporte.aceptarreporte(dato, user, fecha.fecha());


           
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult RechazarReporte(string dato)
        {
            string user = (string)(Session["User"]);

            int result = daoreporte.RechazarReporte(dato, user, fecha.fecha());



            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Facturados()
        {

            List<Reporte> list = daoreporte.listarfacturados();


            string sJSONResponse = JsonConvert.SerializeObject(list, Formatting.Indented);
            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);


          
        }

        public JsonResult Generales()
        {

            List<Reporte> list = daoreporte.listar();


            string sJSONResponse = JsonConvert.SerializeObject(list, Formatting.Indented);
            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);



        }
    }
}