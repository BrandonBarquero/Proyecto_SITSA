using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Clases.Modelos
{
   public class ClienteModelo
    {

        ContratoDAO dao = new ContratoDAO();
        Cliente_ServicioDAO dao_cliente = new Cliente_ServicioDAO();
        Cliente_ContactoDAO dao_contrato = new Cliente_ContactoDAO();
        ServicioDAO daoservicio = new ServicioDAO();
        ContactoDAO dao1 = new ContactoDAO();

        public string agrega(Cliente_Servicio cont, string user)
        {
            var t = cont;
            Fecha fecha = new Fecha();

            Cliente_Servicio cliente_Servicio = new Cliente_Servicio();
            cliente_Servicio.TARIFA_HORA = t.TARIFA_HORA;
            cliente_Servicio.ESTADO = 1;
            cliente_Servicio.USUARIO_CREACION = user;
            cliente_Servicio.FECHA_CREACION = fecha.fecha();
            cliente_Servicio.FK_ID_CLIENTE = t.FK_ID_CLIENTE;
            cliente_Servicio.FK_ID_SERVICIO = t.FK_ID_SERVICIO;

            int result = dao_cliente.AgregarCliente_Servicio(cliente_Servicio);

            string sJSONResponse = JsonConvert.SerializeObject(result, Formatting.Indented);
            return sJSONResponse;

        }

        public string agrega_contactos(Contacto cont, string user)
        {

            var t = cont;

            string validacion = "fail";
            Fecha fecha = new Fecha();
            Cliente_Contacto entidad = new Cliente_Contacto();
            entidad.ESTADO = 1;
            entidad.FECHA_CREACION = fecha.fecha();
            entidad.USUARIO_CREACION = (user);
            entidad.FK_ID_CLIENTE = int.Parse(t.ENCARGADO);
            entidad.FK_ID_CONTACTO = t.ID_CONTACTO;


            int result = dao_contrato.AgregarCliente_Contacto(entidad);

            if (result == 1)
            {

                List<Contacto> list = dao1.listaContactoscliente(int.Parse(t.ENCARGADO));

                string sJSONResponse = JsonConvert.SerializeObject(list, Formatting.Indented);
                return sJSONResponse;
            }
            return validacion;
        }

        public string SesionCLeinte(string dato1)
        {
            List<Contrato> list = dao.listaContratosCliente(dato1, 1);


            string sJSONResponse = JsonConvert.SerializeObject(list, Formatting.Indented);
            return sJSONResponse;
        }

        public string ServiciosCliente(string dato1)
        {
            List<Cliente_Servicio> list = dao_cliente.Listar_servicio_cliente_filtrado(dato1);

            string sJSONResponse = JsonConvert.SerializeObject(list, Formatting.Indented);

            return sJSONResponse;
        }

        public string ContactosCliente(int dato)
        {
            List<Contacto> list = dao1.listaContactoscliente(dato);


            string sJSONResponse = JsonConvert.SerializeObject(list, Formatting.Indented);
            return sJSONResponse;
        }

        public string ProyectosCliente(string dato1)
        {
            List<Proyecto> list = dao_cliente.Listar_servicio_cliente_filtrado_contrato(dato1);

            string sJSONResponse = JsonConvert.SerializeObject(list, Formatting.Indented);

            return sJSONResponse;
        }

    }
}
