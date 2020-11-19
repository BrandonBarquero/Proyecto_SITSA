using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Clases.Models
{
    public class Rechazo_Reporte
    {

        public int PK_ID_RECHAZO { set; get; }
        public string MOTIVO { set; get; }
        public string FECHA_CREACION { set; get; }
        public string USUARIO_CREACION { set; get; }
        public string FECHA_MODIFICACION { set; get; }
        public string USUARIO_MODIFICACION { set; get; }
        public int FK_ID_CONTRATO { set; get; }
        public int FK_ID_REPORTE { set; get; }

        public Rechazo_Reporte()
        {

        }

        public Rechazo_Reporte(string mOTIVO, int fK_ID_REPORTE)
        {
            MOTIVO = mOTIVO;
            FK_ID_REPORTE = fK_ID_REPORTE;
        }
    }

}



