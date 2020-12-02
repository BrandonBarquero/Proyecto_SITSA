using Biblioteca_Clases.DAO;
using Biblioteca_Clases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Clases.Modelos
{
   public class Tabla_ConfiguracionModelo
    {
        Tabla_ConfiguracionDAO dao_tbl = new Tabla_ConfiguracionDAO();

        public string agregar_tabla_configuracion(Tabla_Configuracion cont, string user)
        {
            var t = cont;
            string validacion = "fail";
            Fecha fecha = new Fecha();

            Tabla_Configuracion tbl_config = new Tabla_Configuracion();
            tbl_config.ESTADO = t.ESTADO;
            tbl_config.CONSECUTIVO = t.CONSECUTIVO;
            tbl_config.DESCRIPCION = t.DESCRIPCION;
            tbl_config.OBSERVACION = t.OBSERVACION;
            tbl_config.LLAVE01 = t.LLAVE01;
            tbl_config.LLAVE02 = t.LLAVE02;
            tbl_config.LLAVE03 = t.LLAVE03;
            tbl_config.LLAVE04 = t.LLAVE04;
            tbl_config.LLAVE05 = t.LLAVE05;
            tbl_config.LLAVE06 = t.LLAVE06;
            tbl_config.VALOR = t.VALOR;
            tbl_config.FK_LLAVE_FORANEA = t.FK_LLAVE_FORANEA;
            tbl_config.ESTRUCTURA = t.ESTRUCTURA;
            tbl_config.GUI_RELACION = t.GUI_RELACION;
            tbl_config.FECHA_CREACION = fecha.fecha();
            tbl_config.USUARIO_CREACION = user;

            int result = dao_tbl.AgregarTabla_Configuracion(tbl_config);

            if (result == 1)
            {
                validacion = "sucess";
            }
            return validacion;
        }

        public string modificar_tabla_configuracion(Tabla_Configuracion tbl_config, string user)
        {
            var t = tbl_config;
            string validacion = "fail";
            Fecha fecha = new Fecha();

            Tabla_Configuracion tbl = new Tabla_Configuracion();
            tbl.ESTADO = t.ESTADO;
            tbl.CONSECUTIVO = t.CONSECUTIVO;
            tbl.DESCRIPCION = t.DESCRIPCION;
            tbl.OBSERVACION = t.OBSERVACION;
            tbl.LLAVE01 = t.LLAVE01;
            tbl.LLAVE02 = t.LLAVE02;
            tbl.LLAVE03 = t.LLAVE03;
            tbl.LLAVE04 = t.LLAVE04;
            tbl.LLAVE05 = t.LLAVE05;
            tbl.LLAVE06 = t.LLAVE06;
            tbl.VALOR = t.VALOR;
            tbl.FK_LLAVE_FORANEA = t.FK_LLAVE_FORANEA;
            tbl.ESTRUCTURA = t.ESTRUCTURA;
            tbl.GUI_RELACION = t.GUI_RELACION;
            tbl.PK_TBL_CONFIG = t.PK_TBL_CONFIG;
            tbl.USUARIO_MODIFICACION = user;
            tbl.FECHA_MODIFICACION = fecha.fecha();


            int result = dao_tbl.ActualizarTabla_Configuracion(tbl);

            if (result == 1)
            {
                validacion = "sucess";
            }
            return validacion;
        }

        public int Eliminar_Tabla(int id)
        {

            int result = dao_tbl.EliminarTabla(id);

            return result;

        }
    }
}
