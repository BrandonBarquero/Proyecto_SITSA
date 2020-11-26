<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Maestra.Master" AutoEventWireup="true" CodeBehind="Man_Usuario.aspx.cs" Inherits="WebApplication2.Man_Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="styles" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="Assets_CTRL/js/Funciones_Paginas/Usuario.js"></script>

     <div class="container-mant">

    <div style="margin-right: auto;"> <!--Cabecera-->
      <h3 class="text-left">
       <i class="fas fa-user color-icono" aria-hidden="true"></i>&nbsp; Usuarios
     </h3>
     <p class="text-justify txt5">
     Mantenimiento para el manejo y control de los usuarios.
            </p>
  </div><!--Fin Cabecera-->

  <br>

<!-- Contenido -->
  <div class="container">

              <div class="form-group container">
    <select class="form-control select_selecionar_proyecto" id="select_usuario">
        <option selected="true" disabled="disabled">Seleccione el estado:</option>
           <option value="Activo_Usuario">Activo</option>
           <option value="Inactivo_Usuario">Inactivo</option>
           <option value="Todos_Usuario">Todos</option>
    </select>
  </div>

   <% if (Permisos.CREAR == false)
        {
           
               %>
      
      <div style="display: none;" id="divvalida">
                 <%  }%>
   <p>
  <button id="boton_multiple" class="btn btn-dark txt2" type="button" data-toggle="collapse" data-target="#collapseServicios" aria-expanded="false" aria-controls="collapseServicios">
    Agregar usuario
  </button>
</p>
    
        <% if (Permisos.CREAR == false)
        {
           
               %>
      
      </div>
                 <%  }%>
      

<div class="collapse" id="collapseServicios">



  <div class="card card-body txt2">

      <div style="display: none; text-align: center;" id="error_campos_vacios" class="alert alert-warning">
                 <strong>¡Cuidado!</strong> Campos sin completar.
                      </div>
 

                <p id="parrafo_servicio">Ingresar un nuevo usuario</p>

       <div  class="form-group">
            <label> Seleccionar Perfil:</label>

                        <select onchange="actualizarRespuesta()" onblur="Validar_Campo()" id="perfil"  lang="es" class="js-example-responsive" style="width:100%;"  name="state">
                                         <option selected value="nulo" disabled >  </option>
                                 <%
                   List<Biblioteca_Clases.Models.Perfil> list2 = lista_perfiles();

                    int autoincrement2 = 0;

                    foreach (var dato in list2)
                    {
                        autoincrement2 = autoincrement2 + 1;

                 %>  

                                <option value="<%=dato.Pk_ID_PERFIL%>"><%=dato.DESCRIPCION%></option>
   
                                <%} %>
                    </select>

          </div>


              <div class="form-group">
                <label> Cédula:</label>
                <input   onblur="Validar_Campo()" maxlength="10" type="text" class="form-control" id="cedula">
              </div>
                <div style="display: none;" id="error_contrasenna" class="alert alert-danger">
              
                 <strong>¡Error!</strong> La cédula ya existe en el sistema.
                      </div>
               
              <div class="form-group">
                <label> Nombre:</label>
                <input onchange="actualizarRespuesta()" onblur="Validar_Campo()" maxlength="50" type="text" class="form-control" id="nombre">
              </div>

              <div class="form-group">
                <label> Correo:</label>
                <input onchange="actualizarRespuesta()" onblur="Validar_Campo()" maxlength="100" type="email" class="form-control" id="email">
              </div>
                <div style="display: none;" id="error_email" class="alert alert-danger">
              
                 <strong>¡Error!</strong>Correo ya utilizado.
                      </div>
            
                         <div id="boton_enviar" style="text-align: center">

                        <button disabled onclick="Agregar_Usuario()" id="agregar_usuario" type="button" class="popup-btn">Agregar</button>
                              <button  id="boton_cancelar_2" type="submit" class="popup-btn">Cancelar</button>
                    </div>

                  <div id="botones" style="display: none; text-align: center;">
                        <div style="display: none"  id="modificar_usuario2">
                             <button disabled onclick="Actualizar_Usuario()" type="button" id="modificar_usuario" class="popup-btn">Modificar</button>
                       
                        </div>

                        <br>

                        <div id="boton_cancelar2" style="display: block">
                                  <button  id="boton_cancelar" type="submit" class="popup-btn">Cancelar</button>
                  
                        </div>
                    </div>


        <br>
      </div>
    </div>
      <br>

       <table id="tabla-mant" class="table table-striped table-bordered" style="width:100%;"><!--Tabla-->

        <thead class="estilo-thead">
          <tr>
            <th>Cédula</th>
            <th>Nombre</th>
              <%if (Permisos.EDTIAR == true) { %>
            <th>Modificar</th>
            <th>Estado</th>
              <%}%>
          </tr>
        </thead>

        <tbody>
            
             <%List<Biblioteca_Clases.Models.Usuario> list = lista1();

                   string valor = Convert.ToString(Request.QueryString["Estado"]);
                        list = ListaUsuarios(valor);

                 int autoincrement = 0;

                 foreach(var dato in list)
                 {
                     autoincrement = autoincrement + 1;
                         %>
		    <tr class="txt2">
            <td><%=dato.CEDULA%></td>
            <td><%=dato.NOMBRE%></td>
             <% if (Permisos.EDTIAR == true) { %>
              <td style="text-align: center;"><a data-toggle="collapse" data-target="#collapseServicios" aria-expanded="false" aria-controls="collapseServicios" onclick="Modificar_Usuario(<%=dato.CEDULA%>,'<%=dato.NOMBRE%>','<%=dato.CORREO%>','<%=dato.FK_PERFIL%>');" data-toggle="collapse" data-target="#collapseServicios" aria-expanded="false" aria-controls="collapseServicios"><i class="fa fa-edit color-icono" aria-hidden="true"> </td
              <td style="text-align: center;">
              <input type="checkbox" class="custom-control-input" id="" >
             
                  </td>


                <td style="text-align: center;"><a href="#">
                            <div class="custom-control custom-switch">
                                <% if (dato.ESTADO == true)
                                    {
                                %>
                                <input onclick="estado(<%=dato.ID_USUARIO%>, <%=dato.CEDULA%>)" type="checkbox" checked class="custom-control-input" id="<%=dato.CEDULA%>">
                                <%}
                                    else if (dato.ESTADO == false)
                                    {
                                %>
                                <input onclick="estado(<%=dato.ID_USUARIO%>, <%=dato.CEDULA%> )" type="checkbox" class="custom-control-input" id="<%=dato.CEDULA%>">
                                <%}%>
                                <label class="custom-control-label" for="<%=dato.CEDULA%>" />
                            </div></td>
		    </tr>
            <%}%>
	<%}%>

                     </tbody>

                     <tfoot class="estilo-thead">
                      <tr>
                       <th>Cédula</th>
                       <th>Nombre</th>
                         <%      if (Permisos.EDTIAR == true){%>
                       <th>Modificar</th>
                       <th>Estado</th>
                         <%}%>
                     </tr>
                   </tfoot>

                 </table><!--Fin Tabla-->

               </div> <!--Container-->

             </div>  <!--Container mant-->


        


    
  <script>

      function actualizarRespuesta() {
          $("#modificar_usuario2").css("display", "block");
          $("#boton_cancelar2").css("display", "block");
      }
      /*Validaciones*/

      $('#cedula').on('input', function (e) {
          if (!/^[ 0-9]*$/i.test(this.value)) {
              this.value = this.value.replace(/[^ 0-9]+/ig, "");
          }
      });

      $('#nombre').on('input', function (e) {
          if (!/^[ a-z0-9áéíóúüñ]*$/i.test(this.value)) {
              this.value = this.value.replace(/[^ a-z0-9áéíóúüñ]+/ig, "");
          }
      });

      $('#email').on('input', function (e) {
          if (!/^[ a-z0-9áéíóúüñ@._]*$/i.test(this.value)) {
              this.value = this.value.replace(/[^ a-z0-9áéíóúüñ@._]+/ig, "");
          }
      });

      $('#perfil').on('input', function (e) {
          if (!/^[ 0-9]*$/i.test(this.value)) {
              this.value = this.value.replace(/[^ 0-9]+/ig, "");
          }
      });
  </script>
</asp:Content>

