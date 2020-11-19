using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class ContratoController : Controller
    {
        ContratoDAO dao_contrato = new ContratoDAO();
        ClienteDAO dao_cliente = new ClienteDAO();
        Tipo_ContratoDAO dao_tipo_contrato = new Tipo_ContratoDAO();
        ContactoDAO dao_contacto = new ContactoDAO();

        // GET: Contrato
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult actualizar_estado_Habilitar_Contrato(int id_contrato)
        {
            string validacion = "fail";

            string Usuario_Edita = (string)(Session["User"]);
            Fecha fecha = new Fecha();
            string dato = fecha.fecha();

            Contrato contrato = new Contrato(id_contrato, dato, Usuario_Edita);

            int result = dao_contrato.ActualizarEstadoHabilitarContrato(contrato);

            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult actualizar_estado_deshabilitar_Contrato(int id_contrato)
        {
            string validacion = "fail";

            string Usuario_Edita = (string)(Session["User"]);
            Fecha fecha = new Fecha();
            string dato = fecha.fecha();

            Contrato contrato = new Contrato(id_contrato, dato, Usuario_Edita);

            Servicio_Contrato servicio_Contrato = new Servicio_Contrato();

            int result = dao_contrato.ActualizarEstadoDeshabilitarContrato(contrato);


            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult agregar_contrato(Contrato contrato, List<string> servicios)
        {
            string validacion = "fail";
            Fecha fecha = new Fecha();
            string date = fecha.fecha();

            contrato.FECHA_CREACION = date;
            contrato.USUARIO_CREACION = (string)(Session["User"]);

            int id = dao_contrato.AgregarContrato(contrato);

            int result = 1;

            if (servicios != null)
            {
                List<Servicio_Contrato> servicios_Contrato = new List<Servicio_Contrato>();
                Servicio_Contrato servicio_Contrato;

                foreach (var dato in servicios)
                {
                    servicio_Contrato = new Servicio_Contrato();
                    servicio_Contrato.ID_CONTRATO = id;
                    servicio_Contrato.ID_SERVICIO = Int32.Parse(dato);
                    servicio_Contrato.FECHA_CREACION = date;
                    servicio_Contrato.USUARIO_CREACION = (string)(Session["User"]);
                    servicios_Contrato.Add(servicio_Contrato);
                }

                result = dao_contrato.AgregarServiciosContrato(servicios_Contrato);
            }

            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listar_servicios_contrato(string id)
        {

            List<Servicio> servicios = new List<Servicio>();
            servicios = dao_contrato.Listar_Servicios_Contrato(Int32.Parse(id));

            return Json(servicios, JsonRequestBehavior.AllowGet);
        }

        public JsonResult modificar_contrato(Contrato contrato, List<string> servicios)
        {
            string validacion = "fail";
            Fecha fecha = new Fecha();
            string fecha_asignar = fecha.fecha();

            contrato.FECHA_CREACION = fecha_asignar;
            contrato.USUARIO_CREACION = (string)(Session["User"]);

            int result = dao_contrato.ModificarContrato(contrato);

            if (servicios != null)
            {
                List<Servicio_Contrato> servicios_Contrato = new List<Servicio_Contrato>();
                Servicio_Contrato servicio_Contrato;

                foreach (var dato in servicios)
                {
                    servicio_Contrato = new Servicio_Contrato();
                    servicio_Contrato.ID_CONTRATO = contrato.ID_CONTRATO;
                    servicio_Contrato.ID_SERVICIO = Int32.Parse(dato);
                    servicio_Contrato.FECHA_CREACION = fecha_asignar;
                    servicio_Contrato.USUARIO_CREACION = (string)(Session["User"]);
                    servicios_Contrato.Add(servicio_Contrato);
                }

                result = dao_contrato.ModificarServiciosContrato(servicios_Contrato);
            }
            else
            {
                result = dao_contrato.QuitarServiciosContrato(contrato.ID_CONTRATO);
            }

            if (result == 1)
            {
                validacion = "sucess";
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult devuelve_cliente(int id)
        {

            Cliente cliente = new Cliente();

            cliente = dao_cliente.filtrar_cliente(id);

            return Json(cliente, JsonRequestBehavior.AllowGet);
        }

        public JsonResult devuelve_tipo_contrato(int id)
        {

            Tipo_Contrato tipo_Contrato = new Tipo_Contrato();

            tipo_Contrato = dao_tipo_contrato.listar_TipoContrato(id);

            return Json(tipo_Contrato, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listar_contactos_cliente(int id)
        {
            List<Contacto> contactos = new List<Contacto>();
            contactos = dao_contacto.BuscarDatosContacto(id);

            return Json(contactos, JsonRequestBehavior.AllowGet);
        }

    }
}