using System;

namespace Biblioteca_Clases.Models
{
    public class PrivilegiosE
    {
        public int PK_TBL_CRM_SEG_PERMISOS { set; get; }
        public int FK_TBL_CRM_SEG_PERFIL { set; get; }
        public int FK_TBL_CRM_SEG_MENU { set; get; }
        public string DESCRIPCION { set; get; }
        public bool ESTADO_PERMISO { set; get; }
        public bool CREAR_PERMISO { set; get; }
        public bool EDITAR_PERMISO { set; get; }
        public bool VER_PERMISO { set; get; }
        public string LISTA_MENU { set; get; }
        public string LISTA_PERMISOS { set; get; }
        public DateTime FECHA_CREACION { set; get; }
        public string USUARIO_CREACION { set; get; }
        public DateTime FECHA_MODIFICACION { set; get; }
        public string USUARIO_MODIFICACION { set; get; }
        public int OPCION { set; get; }
        public string USUARIO { set; get; }
    }
}
