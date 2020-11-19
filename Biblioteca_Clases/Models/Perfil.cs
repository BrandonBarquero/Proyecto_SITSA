namespace Biblioteca_Clases.Models
{
    public class Perfil
    {

        public string Pk_ID_PERFIL { set; get; }
        public string DESCRIPCION { set; get; }
        public string ESTADO { set; get; }
        public Perfil()
        {
        }

        public Perfil(string pk_ID_PERFIL, string dESCRIPCION, string eSTADO)
        {
            Pk_ID_PERFIL = pk_ID_PERFIL;
            DESCRIPCION = dESCRIPCION;
            ESTADO = eSTADO;
        }
    }
}
