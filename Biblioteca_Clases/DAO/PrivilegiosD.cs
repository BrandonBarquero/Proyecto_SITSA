using Biblioteca_Clases.Models;

using System;
using System.Data.SqlClient;

namespace Biblioteca_Clases.DAO
{
    public class PrivilegiosD
    {
        public SqlConnection conexion;
        public SqlTransaction transaction;
        public PrivilegiosD()
        {
            this.conexion = Conexion.getConexion();
        }
        #region METODOS DE MANTENIMIENTO 
        public string InsertarPermisos(PrivilegiosE privilegios)
        {

            try
            {
                string valor = "";
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = "execute PA_MAN_TBL_CTRL_SEG_PERMISOS @OPCION,@USUARIO,@FK_ID_PERFIL,@LISTA_MENUS,@LISTA_PERMISOS";
                comando.Parameters.AddWithValue("@OPCION ", privilegios.OPCION);
                comando.Parameters.AddWithValue("@USUARIO", privilegios.USUARIO);
                comando.Parameters.AddWithValue("@FK_ID_PERFIL", privilegios.FK_TBL_CRM_SEG_PERFIL);
                comando.Parameters.AddWithValue("@LISTA_MENUS", privilegios.LISTA_MENU);
                comando.Parameters.AddWithValue("@LISTA_PERMISOS", privilegios.LISTA_PERMISOS);

                comando.ExecuteNonQuery();



                comando.Dispose();

                if (!string.IsNullOrEmpty(valor))
                {
                    return valor;
                }
                return "Datos Guardados Correctamente";
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error en Base de Datos al ingresar los permisos \n" + ex.Message);
            }
        }
        #endregion METODOS DE MANTENIMIENTO 
    }




}
