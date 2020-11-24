using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Clases.Models
{
   public class Cierre_Mes
    {
        public int FK_ID_REPORTE { set; get; }
        public string FECHA_CREACION { set; get; }
        public string USUARIO_CREACION { set; get; }

        public Cierre_Mes()
        {
        }
    }
}
