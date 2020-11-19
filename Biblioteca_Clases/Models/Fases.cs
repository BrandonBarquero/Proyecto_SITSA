using System;

namespace Biblioteca_Clases.Models
{
    public class Fases
    {

        public string DESCRIPCION { set; get; }
        public Double TIEMPO { set; get; }

        public Fases()
        {
        }

        public Fases(string dESCRIPCION, double tIEMPO)
        {
            DESCRIPCION = dESCRIPCION;
            TIEMPO = tIEMPO;
        }
    }
}
