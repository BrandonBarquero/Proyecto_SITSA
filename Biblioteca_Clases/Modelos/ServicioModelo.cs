using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Clases.Modelos
{
   public class ServicioModelo
    {


        ServicioDAO dao_servicio = new ServicioDAO();

        public string agregar_servicio(string desc, string user)
        {
            string validacion = "fail";

            string descripcion = desc;
            string Usuario_Edita = user;
            Fecha fecha = new Fecha();
            string dato = fecha.fecha();

            Servicio serv = new Servicio(descripcion, dato, Usuario_Edita);


            int result = dao_servicio.AgregarServicio(serv);


            if (result == 1)
            {
                validacion = "sucess";
            }
            return validacion;
        }

        public string actualizar_servicio(int id_servicio, string descripcion, string user)
        {
            string validacion = "fail";

            string Usuario_Edita = user;
            Fecha fecha = new Fecha();
            string dato = fecha.fecha();

            Servicio serv = new Servicio(id_servicio, descripcion, dato, Usuario_Edita);


            int result = dao_servicio.ActualizarServicio(serv);


            if (result == 1)
            {
                validacion = "sucess";
            }
            return validacion;
        }

        public string actualizar_estado_deshabilitar_servicio(int id_servicio, string user)
        {
            string validacion = "fail";

            string Usuario_Edita = user;
            Fecha fecha = new Fecha();
            string dato = fecha.fecha();

            Servicio serv = new Servicio(id_servicio, dato, Usuario_Edita);


            int result = dao_servicio.ActualizarEstadoDeshabilitarServicio(serv);


            if (result == 1)
            {
                validacion = "sucess";
            }
            return validacion;
        }

        public string actualizar_estado_Habilitar_servicio(int id_servicio, string user)
        {
            string validacion = "fail";

            string Usuario_Edita = user;
            Fecha fecha = new Fecha();
            string dato = fecha.fecha();

            Servicio serv = new Servicio(id_servicio, dato, Usuario_Edita);


            int result = dao_servicio.ActualizarEstadoHabilitarServicio(serv);


            if (result == 1)
            {
                validacion = "sucess";
            }
            return validacion;
        }

        public string eliminar_servicio_cliente(string dato)
        {

            string validacion = "fail";


            int result = dao_servicio.EliminarServicioContacto(dato);

            if (result == 1)
            {
                validacion = "sucess";
            }
            return validacion;
        }

    }
}
