using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Clases.Modelos
{
   public class ContactoModelo
    {
        ContactoDAO dao_contacto = new ContactoDAO();

        public string agregar_contacto(Contacto cont, string user)
        {
            var t = cont;
            string validacion = "fail";
            Fecha fecha = new Fecha();

            Contacto contacto = new Contacto();
            contacto.ENCARGADO = t.ENCARGADO;
            contacto.TELEFONO = t.TELEFONO;
            contacto.CORREO = t.CORREO;
            contacto.TIPO_ENCARGADO = t.TIPO_ENCARGADO;
            contacto.FECHA_CREACION = fecha.fecha();
            contacto.USUARIO_CREACION = user;

            int result = dao_contacto.AgregarContacto(contacto);

            if (result == 1)
            {
                validacion = "sucess";
            }
            return validacion;

        }

        public string modificar_contacto(Contacto contac, string user)
        {
            var t = contac;
            string validacion = "fail";
            Fecha fecha = new Fecha();

            Contacto contacto = new Contacto();
            contacto.ID_CONTACTO = t.ID_CONTACTO;
            contacto.ENCARGADO = t.ENCARGADO;
            contacto.TELEFONO = t.TELEFONO;
            contacto.CORREO = t.CORREO;
            contacto.TIPO_ENCARGADO = t.TIPO_ENCARGADO;
            contacto.USUARIO_MODIFICACION = user;
            contacto.FECHA_MODIFICACION = fecha.fecha();


            int result = dao_contacto.ActualizarContacto(contacto);

            if (result == 1)
            {
                validacion = "sucess";
            }
            return validacion;
        }

        public string eliminar_contacto(Contacto contac)
        {
            var t = contac;
            string validacion = "fail";
            Fecha fecha = new Fecha();

            Contacto contacto = new Contacto();
            contacto.ID_CONTACTO = t.ID_CONTACTO;

            int result = dao_contacto.EliminarContacto(contacto);

            if (result == 1)
            {
                validacion = "sucess";
            }

            if (result == 2)
            {
                validacion = "ErrorCont";
            }

            return validacion;
        }

        public string eliminar_contacto_cliente(string dato)
        {

            string validacion = "fail";


            int result = dao_contacto.EliminarClienteContacto(dato);

            if (result == 1)
            {
                validacion = "sucess";
            }
            return validacion;
        }
    }
}
