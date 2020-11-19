using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Clases.Models
{
    public class Reporte
    {
        public int PK_ID_REPORTE { set; get; }
        public string TIPO_DOCUMENTO { set; get; }
        public bool FACTURADO { set; get; }
        public double CANTIDAD_HORAS { set; get; }
        public string OBSERVACION { set; get; }
        public string FECHA { set; get; }
        public bool APROBACION { set; get; }
        public string FECHA_APROBACION { set; get; }
        public string FECHA_FACTURADO { set; get; }
        public string FECHA_CREACION { set; get; }
        public string USUARIO_CREACION { set; get; }
        public string FECHA_MODIFICACION { set; get; }
        public string USUARIO_MODIFICACION { set; get; }
        public int FK_ID_CONTACTO { set; get; }
        public int ID_CONTRATO{ set; get; }
        public int ID_PROYECTO { set; get; }

        public Reporte() { 
        
        }

    }
}
