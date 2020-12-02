using Biblioteca_Clases.DAO;
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
        // GET: Cierre_Mes
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Permisos()
        {

            string perfil = (string)(Session["User"]);

            bool permiso = dao.PERMISO_APROBAR(perfil);
            int permisos = 0;
            if (permiso == true)
            {
                permisos = 1;
            }


            return Json(permisos, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Permisos_Reenvio()
        {

            string perfil = (string)(Session["User"]);

            bool permiso = dao.PERMISO_APROBAR_R(perfil);
            int permisos = 0;
            if (permiso == true)
            {
                permisos = 1;
            }


            return Json(permisos, JsonRequestBehavior.AllowGet);
        }


        public JsonResult AceptarReporte(string dato)
        {

            int fk_id_reporte = int.Parse(dato);

            string user = (string)(Session["User"]);

            dao_cierre.AgregarCierreMes(fk_id_reporte, user, fecha.fecha());


            int result = daoreporte.aceptarreporte(dato, user, fecha.fecha());



            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult RechazarReporte(string dato)
        {
            int fk_id_reporte = int.Parse(dato);

            string user = (string)(Session["User"]);

            dao_cierre.Eliminar_Cierre_Mes(fk_id_reporte);

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

        public JsonResult Reenviar_Correo(string dato)
        {

            List<Contacto> list = dao_cierre.listaCorreos(dato);


            string sJSONResponse = JsonConvert.SerializeObject(list, Formatting.Indented);
            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);



        }

        public JsonResult Cambiar_Estado_Reporte(string ID_Reporte, string correos)
        {

            int ID_Reporte2 = int.Parse(ID_Reporte);

            string nombre_cliente = daoreporte.ObtenerNombreCliente2(ID_Reporte2);

            string[] vector_correo = correos.Split(',');

            int result = dao_cierre.Cambiar_Estado_Reenvio(ID_Reporte2);


            Reporte Reporte_Obj = new Reporte();

            Reporte_Obj = daoreporte.devuelve_reporte(ID_Reporte2);

            Detalle_Reporte Detalle_Obj2 = new Detalle_Reporte();

            int opc = 0;
            if (Reporte_Obj.ID_CONTRATO != 0)
            {
                opc = 1;
            }
            else if (Reporte_Obj.ID_PROYECTO != 0)
            {
                opc = 2;
            }



            List<Detalle_Reporte> Detalle_Obj = new List<Detalle_Reporte>();

            Detalle_Obj = daoreporte.BuscaDetallesReporte(ID_Reporte2, opc);


            if ((Reporte_Obj.TIPO_DOCUMENTO == "Reporte Contrato") || (Reporte_Obj.TIPO_DOCUMENTO == "Reporte Contrato Garantía") || (Reporte_Obj.TIPO_DOCUMENTO == "Reporte Contrato Facturado"))
            {
                mail.Enviar_Resporte_Correo(encryption.Encrypt(ID_Reporte2.ToString()), Reporte_Obj, Detalle_Obj, nombre_cliente, vector_correo);
            }
            else
            {
                mail.Enviar_Resporte_Correo_Proyecto(encryption.Encrypt(ID_Reporte2.ToString()), Reporte_Obj, Detalle_Obj2, nombre_cliente, vector_correo);
            }


            return Json(result, JsonRequestBehavior.AllowGet);

        }
    }
}