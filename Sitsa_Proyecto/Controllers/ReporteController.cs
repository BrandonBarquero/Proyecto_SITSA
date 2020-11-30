using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using Biblioteca_Clases.Modelos;
using Biblioteca_Clases.Seguridad;
namespace Sitsa_Proyecto.Controllers
{
    public class ReporteController : Controller
    {
        ContratoDAO dao_contrato = new ContratoDAO();
        ProyectoDAO dao_proyecto = new ProyectoDAO();
        ContactoDAO dao_contacto = new ContactoDAO();
        ReporteDAO dao_reporte = new ReporteDAO();
        ClienteDAO dao_cliente = new ClienteDAO();
        ServicioDAO dao_servicio = new ServicioDAO();

        Mail mail = new Mail();
        Encryption encryption = new Encryption();
        Contacto contacto = new Contacto();

        ReporteModelo ReporteModelo = new ReporteModelo();

        // GET: Reporte
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult listar_contrato_cliente(String id)
        {
            List<Contrato> contratos = new List<Contrato>();
            contratos = ReporteModelo.listar_contrato_cliente(id,1);

            return Json(contratos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listar_contrato_cliente_garantia(String id)
        {
            List<Contrato> contratos = new List<Contrato>();
            contratos = ReporteModelo.listar_contrato_cliente_garantia(id,2);

            return Json(contratos, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult listar_proyecto_cliente(int id)
        {
            List<Proyecto> proyectos = new List<Proyecto>();
            proyectos = ReporteModelo.listar_proyecto_cliente(id,1);

            return Json(proyectos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listar_proyecto_cliente_garantia(int id)
        {
            List<Proyecto> proyectos = new List<Proyecto>();
            proyectos = ReporteModelo.listar_proyecto_cliente_garantia(id,2);

            return Json(proyectos, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult buscar_datos_contacto(int id) {
            List<Contacto> contactos = new List<Contacto>();
            contactos = ReporteModelo.buscar_datos_contacto(id);

            return Json(contactos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult agregar_reporte(Reporte reporte, List<Detalle_Reporte> detalles_reporte, List<Detalle_Reporte> detalles_reporte_extra, string horas_disponibles, string correos) {
            int result = ReporteModelo.agregar_reporte(reporte, detalles_reporte, detalles_reporte_extra, horas_disponibles, correos, (string)(Session["User"]));

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult agregar_reporte_proyecto(Reporte reporte, Detalle_Reporte detalle_Reporte, string correos)
        {
            int result = ReporteModelo.agregar_reporte_proyecto(reporte, detalle_Reporte, correos, (string)(Session["User"])); ;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult devuelve_reporte(int id) {
            Reporte reporte = new Reporte();
            reporte = ReporteModelo.devuelve_reporte(id);

            return Json(reporte, JsonRequestBehavior.AllowGet);
        }

        public JsonResult devuelve_cliente(int id, int opc) {
            int cliente_id = ReporteModelo.devuelve_cliente(id, opc);
            return Json(cliente_id, JsonRequestBehavior.AllowGet);
        }

        public JsonResult buscar_detalle_reporte(int id, int opc)
        {
            List<Detalle_Reporte> detalles_Reporte = ReporteModelo.buscar_detalle_reporte(id, opc);
            return Json(detalles_Reporte, JsonRequestBehavior.AllowGet);
        }

        //-----------inicio
        public JsonResult actualizar_reporte_proyecto(Reporte reporte, Detalle_Reporte detalle_Reporte) {
            int result = ReporteModelo.actualizar_reporte_proyecto(reporte, detalle_Reporte, (string)(Session["User"]));

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult actualizar_reporte_contrato(Reporte reporte, List<Detalle_Reporte> detalles_reporte, List<Detalle_Reporte> detalles_reporte_extra, string horas_disponibles)
        {
            int result = ReporteModelo.actualizar_reporte_contrato(reporte, detalles_reporte, detalles_reporte_extra, horas_disponibles, (string)(Session["User"]));

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult activa_contrato_proyecto(int id, int opc) {
            int result = ReporteModelo.activa_contrato_proyecto(id, opc);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult devuelve_servicios() {
            List<Servicio> servicios = ReporteModelo.devuelve_servicios();
            return Json(servicios, JsonRequestBehavior.AllowGet);
        }
        //--fin
    }
}