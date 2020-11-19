using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Clases.Models
{
    public class Detalle_Reporte
    {
        public int PK_ID_DETALLE_REPORTE { set; get; }
        public double HORAS { set; get; }
        public double TARIFA { set; get; }
        public int FK_ID_REPORTE { set; get; }
        public string FECHA_CREACION { set; get; }
        public string USUARIO_CREACION { set; get; }
        public string FECHA_MODIFICACION { set; get; }
        public string USUARIO_MODIFICACION { set; get; }
        public string OBSERVACION { set; get; }
        public int ID_SERVICIO { set; get; }

        public Detalle_Reporte() { 

        }
    }
}
