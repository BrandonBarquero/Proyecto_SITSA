using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;


namespace Biblioteca_Clases.Modelos
{
    public class TipoContratoModelo
    {
        Tipo_ContratoDAO dao_tipo_contrato = new Tipo_ContratoDAO();

        public Tipo_Contrato listar_tipo_contrato(int id)
        {
            Tipo_ContratoDAO dao_tipo_contrato = new Tipo_ContratoDAO();
            Tipo_Contrato tipo_Contrato = dao_tipo_contrato.listar_TipoContrato(id);

            return tipo_Contrato;
        }

        public string actualizar_estado_Habilitar_Tipo_Contrato(int id_tipo_contrato, string user)
        {
            string validacion = "fail";

            string Usuario_Edita = user;
            Fecha fecha = new Fecha();
            string dato = fecha.fecha();

            Tipo_Contrato tipo_Contrato = new Tipo_Contrato(id_tipo_contrato, dato, Usuario_Edita);

            int result = dao_tipo_contrato.ActualizarEstadoHabilitarTipoContrato(tipo_Contrato);

            if (result == 1)
            {
                validacion = "sucess";
            }
            return validacion;
        }

        public String actualizar_estado_deshabilitar_Tipo_Contrato(int id_tipo_contrato, string user)
        {
            string validacion = "fail";

            string Usuario_Edita = user;
            Fecha fecha = new Fecha();
            string dato = fecha.fecha();

            Tipo_Contrato tipo_Contrato = new Tipo_Contrato(id_tipo_contrato, dato, Usuario_Edita);


            int result = dao_tipo_contrato.ActualizarEstadoDeshabilitarTipoContrato(tipo_Contrato);


            if (result == 1)
            {
                validacion = "sucess";
            }
            return validacion;
        }

        public string agregar_tipo_contrato(Tipo_Contrato tipo, string user)
        {
            string validacion = "fail";
            Fecha fecha = new Fecha();

            tipo.FECHA_CREACION = fecha.fecha();
            tipo.USUARIO_CREACION = user;

            int result = dao_tipo_contrato.AgregarTipoContrato(tipo);

            if (result == 1)
            {
                validacion = "sucess";
            }
            return validacion;
        }

        public string modificar_tipo_contrato(Tipo_Contrato tipo, string user)
        {
            string validacion = "fail";
            Fecha fecha = new Fecha();

            tipo.FECHA_MODIFICACION = fecha.fecha();
            tipo.USUARIO_MODIFICACION = user;

            int result = dao_tipo_contrato.ModificarTipoContrato(tipo);

            if (result == 1)
            {
                validacion = "sucess";
            }
            return validacion;
        }

        public List<Tipo_Contrato> listar_activos()
        {
            List<Tipo_Contrato> lista = new List<Tipo_Contrato>();
            lista = dao_tipo_contrato.listaTipoContratos();

            return lista;
        }

        public List<Tipo_Contrato> listar_inactivos()
        {
            List<Tipo_Contrato> lista = new List<Tipo_Contrato>();
            lista = dao_tipo_contrato.listaTipoContratosInactivos();

            return lista;
        }
    }
}
