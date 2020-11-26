using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
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

        // GET: Reporte
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult listar_contrato_cliente(String id)
        {
            List<Contrato> contratos = new List<Contrato>();
            contratos = dao_contrato.listaContratosCliente(id,1);

            return Json(contratos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listar_contrato_cliente_garantia(String id)
        {
            List<Contrato> contratos = new List<Contrato>();
            contratos = dao_contrato.listaContratosCliente(id,2);

            return Json(contratos, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult listar_proyecto_cliente(int id)
        {
            List<Proyecto> proyectos = new List<Proyecto>();
            proyectos = dao_proyecto.listaProyectos_cliente(id,1);

            return Json(proyectos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listar_proyecto_cliente_garantia(int id)
        {
            List<Proyecto> proyectos = new List<Proyecto>();
            proyectos = dao_proyecto.listaProyectos_cliente(id,2);

            return Json(proyectos, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult buscar_datos_contacto(int id) {
            List<Contacto> contactos = new List<Contacto>();
            contactos = dao_contacto.BuscarDatosContacto(id);

            return Json(contactos, JsonRequestBehavior.AllowGet);
        }



        public JsonResult agregar_reporte(Reporte reporte, List<Detalle_Reporte> detalles_reporte, string horas_disponibles, string correos) {
            int result = 0;

            string[] vector_correo = correos.Split(',');           

            Fecha fecha = new Fecha();
            string fecha_asignar = fecha.fecha();

            reporte.FECHA_CREACION = fecha_asignar;
            reporte.USUARIO_CREACION = (string)(Session["User"]);

            int id = dao_reporte.AgregarReporte(reporte);

            string nombre_cliente = dao_reporte.ObtenerNombreCliente2(id);
                        
            if (detalles_reporte != null){
                for (int i = 0; i < detalles_reporte.Count; i++){
                    detalles_reporte[i].USUARIO_CREACION = (string)(Session["User"]);
                    detalles_reporte[i].FECHA_CREACION = fecha_asignar;
                    detalles_reporte[i].FK_ID_REPORTE = id;
                }

                result = dao_reporte.AgregarDetallesReporte(detalles_reporte);
            }
            
            if (horas_disponibles != "f" && reporte.TIPO_DOCUMENTO != "Reporte Contrato Garantía")
            {
                double hor = Double.Parse(horas_disponibles);
                dao_contrato.RebajarHorasContrato(reporte.ID_CONTRATO, hor, (string)(Session["User"]), fecha_asignar);

                if (hor == 0)
                {
                    dao_reporte.CambiarEstadoReporteContrato(reporte.ID_CONTRATO, (string)(Session["User"]), fecha_asignar);
                }
            }
            else {
                dao_reporte.CambiarEstadoReporteContrato(reporte.ID_CONTRATO, (string)(Session["User"]), fecha_asignar);
            }

            //mail.Enviar_Resporte_Correo(encryption.Encrypt(id.ToString()), reporte, detalles_reporte, nombre_cliente, vector_correo);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult agregar_reporte_proyecto(Reporte reporte, Detalle_Reporte detalle_Reporte, string correos)
        {
            int result = 0;

            string[] vector_correo = correos.Split(',');

            Fecha fecha = new Fecha();
            string fecha_asignar = fecha.fecha();

            reporte.FECHA_CREACION = fecha_asignar;
            reporte.USUARIO_CREACION = (string)(Session["User"]);

            int id = dao_reporte.AgregarReporteProyecto(reporte);

            detalle_Reporte.USUARIO_CREACION = (string)(Session["User"]);
            detalle_Reporte.FECHA_CREACION = fecha_asignar;
            detalle_Reporte.FK_ID_REPORTE = id;

            dao_reporte.CambiarEstadoReporteProyecto(reporte.ID_PROYECTO, (string)(Session["User"]), fecha_asignar);

           string nombre_cliente =  dao_reporte.ObtenerNombreCliente2(reporte.ID_PROYECTO);

            result = dao_reporte.AgregarDetalleReporteProyecto(detalle_Reporte);

            mail.Enviar_Resporte_Correo_Proyecto(encryption.Encrypt(id.ToString()), reporte, detalle_Reporte, nombre_cliente, vector_correo);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult devuelve_reporte(int id) {
            Reporte reporte = new Reporte();
            reporte = dao_reporte.devuelve_reporte(id);

            return Json(reporte, JsonRequestBehavior.AllowGet);
        }

        public JsonResult devuelve_cliente(int id, int opc) {
            int cliente_id = dao_cliente.DevuelveCliente(id, opc);
            return Json(cliente_id, JsonRequestBehavior.AllowGet);
        }

        public JsonResult buscar_detalle_reporte(int id, int opc)
        {
            List<Detalle_Reporte> detalles_Reporte = dao_reporte.BuscaDetallesReporte(id, opc);
            return Json(detalles_Reporte, JsonRequestBehavior.AllowGet);
        }

        public JsonResult actualizar_reporte_proyecto(Reporte reporte, Detalle_Reporte detalle_Reporte) {
            int result = 0;

            Fecha fecha = new Fecha();
            string fecha_asignar = fecha.fecha();

            reporte.FECHA_CREACION = fecha_asignar;
            reporte.USUARIO_CREACION = (string)(Session["User"]);

            int id = dao_reporte.ModificarReporteProyecto(reporte);

            detalle_Reporte.USUARIO_CREACION = (string)(Session["User"]);
            detalle_Reporte.FECHA_CREACION = fecha_asignar;
            detalle_Reporte.FK_ID_REPORTE = reporte.PK_ID_REPORTE;

            dao_reporte.CambiarEstadoReporteProyecto(reporte.ID_PROYECTO, (string)(Session["User"]), fecha_asignar);

            dao_reporte.EliminarDetallesReporte(reporte.PK_ID_REPORTE);

            result = dao_reporte.AgregarDetalleReporteProyecto(detalle_Reporte);

            // mail.Enviar_Resporte_Correo(encryption.Encrypt(id.ToString()));

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public JsonResult actualizar_reporte_contrato(Reporte reporte, List<Detalle_Reporte> detalles_reporte, string horas_disponibles)
        {
            int result = 0;

            Fecha fecha = new Fecha();
            string fecha_asignar = fecha.fecha();

            reporte.FECHA_CREACION = fecha_asignar;
            reporte.USUARIO_CREACION = (string)(Session["User"]);

            int id = dao_reporte.ModificarReporteContrato(reporte);

            dao_reporte.EliminarDetallesReporte(reporte.PK_ID_REPORTE);

            for (int i = 0; i < detalles_reporte.Count; i++)
            {
                detalles_reporte[i].USUARIO_CREACION = (string)(Session["User"]);
                detalles_reporte[i].FECHA_CREACION = fecha_asignar;
                detalles_reporte[i].FK_ID_REPORTE = reporte.PK_ID_REPORTE;
            }

            result = dao_reporte.AgregarDetallesReporte(detalles_reporte);

            if (horas_disponibles != "f" && reporte.TIPO_DOCUMENTO != "Reporte Contrato Garantía")
            {
                double hor = Double.Parse(horas_disponibles);
                dao_contrato.RebajarHorasContrato(reporte.ID_CONTRATO, hor, (string)(Session["User"]), fecha_asignar);

                if (hor == 0)
                {
                    dao_reporte.CambiarEstadoReporteContrato(reporte.ID_CONTRATO, (string)(Session["User"]), fecha_asignar);
                }
            }
            else
            {
                dao_reporte.CambiarEstadoReporteContrato(reporte.ID_CONTRATO, (string)(Session["User"]), fecha_asignar);
            }

            string nombre_cliente = dao_reporte.ObtenerNombreCliente2(reporte.ID_PROYECTO);

         //   mail.Enviar_Resporte_Correo(encryption.Encrypt(id.ToString()), reporte, detalles_reporte, nombre_cliente);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult activa_contrato_proyecto(int id, int opc) {
            int result = dao_reporte.ActivarContratoProyecto(id, opc);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult devuelve_servicios() {
            List<Servicio> servicios = dao_servicio.listaServicios();
            return Json(servicios, JsonRequestBehavior.AllowGet);
        }

    }
}