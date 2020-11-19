using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Clases.Models
{
   public class Tabla_Configuracion
    {
        public Int64 PK_TBL_CONFIG { set; get; }
        public Int32 FK_TBL_CTRL_REG_CONFIGURACION { set; get; }
        public string FECHA_CREACION { set; get; }
        public string USUARIO_CREACION { set; get; }
        public string FECHA_MODIFICACION { set; get; }
        public string USUARIO_MODIFICACION { set; get; }
        public Int16 ESTADO { set; get; }
        public Int16 CONSECUTIVO { set; get; }
        public string DESCRIPCION { set; get; }
        public string OBSERVACION { set; get; }
        public string LLAVE01 { set; get; }
        public string LLAVE02 { set; get; }
        public string LLAVE03 { set; get; }
        public string LLAVE04 { set; get; }
        public string LLAVE05 { set; get; }
        public string LLAVE06 { set; get; }
        public string VALOR { set; get; }
        public Int64 FK_LLAVE_FORANEA { set; get; }
        public string ESTRUCTURA { set; get; }
        public string GUI_RELACION { set; get; }

        public Tabla_Configuracion()
        {
        }
    }
}
