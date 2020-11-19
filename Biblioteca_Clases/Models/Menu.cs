namespace Biblioteca_Clases.Models
{
    public class Menu
    {
        public int PK_ID_MENU { set; get; }
        public string CODIGO_PADRE { set; get; }
        public string ICONO { set; get; }
        public string URL { set; get; }
        public string DESCRIPCION { set; get; }
        public bool ESTADO_MENU { set; get; }
        public bool CREAR_MENU { set; get; }
        public bool VER_MENU { set; get; }
        public bool EDITAR_MENU { set; get; }
        public bool ESTADO_PERMISO { set; get; }
        public bool EDITAR_PERMISO { set; get; }
        public bool VER_PERMISO { set; get; }
        public bool CREAR_PERMISO { set; get; }
        public Menu()
        {

        }
        public Menu(int pK_ID_MENU, string cODIGO_PADRE, string iCONO, string uRL, string dESCRIPCION, bool cREAR_MENU, bool vER_MENU, bool eDITAR_MENU, bool eSTADO_PERMISO, bool eDITAR_PERMISO, bool vER_PERMISO, bool cREAR_PERMISO)
        {
            PK_ID_MENU = pK_ID_MENU;
            CODIGO_PADRE = cODIGO_PADRE;
            ICONO = iCONO;
            URL = uRL;
            DESCRIPCION = dESCRIPCION;
            CREAR_MENU = cREAR_MENU;
            VER_MENU = vER_MENU;
            EDITAR_MENU = eDITAR_MENU;
            ESTADO_PERMISO = eSTADO_PERMISO;
            EDITAR_PERMISO = eDITAR_PERMISO;
            VER_PERMISO = vER_PERMISO;
            CREAR_PERMISO = cREAR_PERMISO;
        }

        public Menu(int pK_ID_MENU, string cODIGO_PADRE)
        {
            PK_ID_MENU = pK_ID_MENU;
            CODIGO_PADRE = cODIGO_PADRE;

        }

    }
}
