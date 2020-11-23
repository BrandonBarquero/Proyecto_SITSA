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
        public JsonResult Buscar(string reporte, string cliente, string horas_convertidas, string horas_convertidas2)
        {

            if (horas_convertidas.Equals("") && horas_convertidas2.Equals("")) {
                horas_convertidas = "1999-10-10";
                horas_convertidas2 = "2040-10-10";
            }
            if ( horas_convertidas2.Equals(""))
            {
                horas_convertidas = "1999-10-10";
                horas_convertidas2 = "2040-10-10";
            }
            if (horas_convertidas.Equals(""))
            {
                horas_convertidas = "1999-10-10";
                horas_convertidas2 = "2040-10-10";
            }




            List<Reporte> list = daoreporte.listaReporte(reporte, cliente, horas_convertidas, horas_convertidas2);


            string sJSONResponse = JsonConvert.SerializeObject(list, Formatting.Indented);

            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);

        }
        public JsonResult Buscar_Facturados(string reporte, string cliente, string horas_convertidas, string horas_convertidas2)
        {

            if (horas_convertidas.Equals("") && horas_convertidas2.Equals(""))
            {
                horas_convertidas = "1999-10-10";
                horas_convertidas2 = "2040-10-10";
            }
            if (horas_convertidas2.Equals(""))
            {
                horas_convertidas = "1999-10-10";
                horas_convertidas2 = "2040-10-10";
            }
            if (horas_convertidas.Equals(""))
            {
                horas_convertidas = "1999-10-10";
                horas_convertidas2 = "2040-10-10";
            }




            List<Reporte> list = daoreporte.listaReportefacturados(reporte, cliente, horas_convertidas, horas_convertidas2);


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