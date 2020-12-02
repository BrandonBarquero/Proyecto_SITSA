using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;
namespace WebApplication2.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        ContratoDAO dao = new ContratoDAO();
        Cliente_ServicioDAO dao_cliente = new Cliente_ServicioDAO();
        Cliente_ContactoDAO dao_contrato = new Cliente_ContactoDAO();
        ServicioDAO daoservicio = new ServicioDAO();
        ContactoDAO dao1 = new ContactoDAO();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult agrega(Cliente_Servicio cont)
        {
            var t = cont;
            string validacion = "fail";
            Fecha fecha = new Fecha();

            Cliente_Servicio cliente_Servicio = new Cliente_Servicio();
            cliente_Servicio.TARIFA_HORA = t.TARIFA_HORA;
            cliente_Servicio.ESTADO = 1;
            cliente_Servicio.USUARIO_CREACION = (string)(Session["User"]);
            cliente_Servicio.FECHA_CREACION = fecha.fecha();
            cliente_Servicio.FK_ID_CLIENTE = t.FK_ID_CLIENTE;
            cliente_Servicio.FK_ID_SERVICIO = t.FK_ID_SERVICIO;


            int result = dao_cliente.AgregarCliente_Servicio(cliente_Servicio);



            string sJSONResponse = JsonConvert.SerializeObject(result, Formatting.Indented);
            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult agrega_contactos(Contacto cont)
        {

            var t = cont;



            string validacion = "fail";
            Fecha fecha = new Fecha();
            Cliente_Contacto entidad = new Cliente_Contacto();
            entidad.ESTADO = 1;
            entidad.FECHA_CREACION = fecha.fecha();
            entidad.USUARIO_CREACION = (string)(Session["User"]);
            entidad.FK_ID_CLIENTE = int.Parse(t.ENCARGADO);
            entidad.FK_ID_CONTACTO = t.ID_CONTACTO;


            int result = dao_contrato.AgregarCliente_Contacto(entidad);

            if (result == 1)
            {

                List<Contacto> list = dao1.listaContactoscliente(int.Parse(t.ENCARGADO));

                string sJSONResponse = JsonConvert.SerializeObject(list, Formatting.Indented);
                return Json(sJSONResponse, JsonRequestBehavior.AllowGet);
            }
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult agregar_fases(int id_proyecto/*List<Fase_Tiempo> fases*/)
        {

            string validacion = "fail";
            int d = id_proyecto;
            //int result = 0; 

            //foreach (Fase_Tiempo dato in fases)
            //{
            //     result = dao_fase.AgregarFase_Tiempo(dato, id_proyecto_result, (string)(Session["User"]));
            //}

            //if (result == 1)
            //{
            //    validacion = "sucess";
            //}
            return Json(validacion, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SesionCLeinte(string dato1)
        {
            List<Contrato> list = dao.listaContratosCliente(dato1, 1);


            string sJSONResponse = JsonConvert.SerializeObject(list, Formatting.Indented);
            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult ServiciosCliente(string dato1)
        {
            List<Cliente_Servicio> list = dao_cliente.Listar_servicio_cliente_filtrado(dato1);


            string sJSONResponse = JsonConvert.SerializeObject(list, Formatting.Indented);
            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult ContactosCliente(int dato)
        {
            List<Contacto> list = dao1.listaContactoscliente(dato);


            string sJSONResponse = JsonConvert.SerializeObject(list, Formatting.Indented);
            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public JsonResult ProyectosCliente(string dato1)
        {
            List<Proyecto> list = dao_cliente.Listar_servicio_cliente_filtrado_contrato(dato1);


            string sJSONResponse = JsonConvert.SerializeObject(list, Formatting.Indented);
            return Json(sJSONResponse, JsonRequestBehavior.AllowGet);
        }



    }
}