<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Maestra.Master" AutoEventWireup="true" CodeBehind="Man_Contacto.aspx.cs" Inherits="WebApplication2.Man_Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="styles" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="Assets_CTRL/js/Funciones_Paginas/Contacto.js"></script>

    <div class="container-mant">


        <div style="margin-right: auto;">
            <!--Cabecera-->
            <h3 class="text-left">
                <i class="fas fa-id-card color-icono" aria-hidden="true"></i>&nbsp; Contactos
            </h3>
            <p class="text-justify txt5">
            Mantenimiento para el manejo y control de los contactos.
            </p>
        </div>
        <!--Fin Cabecera-->

        <br>

        <!-- Contenido -->
        <div class="container">

         <% if (Permisos.CREAR == false)
             { 

            %>

            <div style="display: none;" id="divvalida">
                <%  }%>
            <p>

                <button class="btn btn-dark txt2" id="boton_multiple" value="" type="button" data-toggle="collapse" data-target="#collapseServicios" aria-expanded="false" aria-controls="collapseServicios">
                    Agregar Contacto
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

                    <p id="parrafo_servicio">Ingresar un nuevo contacto</p>

                    <div id="id_contacto_input" style="display: none" class="form-group">
                        <label>ID Contacto:</label>
                        <input type="text" class="form-control" id="id_contacto" name="id_contacto" readonly="">
                    </div>

                    <div class="form-group">
                        <label>Encargado:</label>
                        <input onchange="actualizarRespuesta()"  maxlength="50" onblur="Validar_Campo()" type="text" class="form-control" id="encargado" name="encargado" required>
                    </div>

                    <div class="form-group">
                        <label>Teléfono:</label>
                        <input onchange="actualizarRespuesta()"  maxlength="11" onblur="Validar_Campo()" type="text" class="form-control" id="telefono" name="telefono">
                    </div>

                    <div class="form-group">
                        <label>Correo:</label>
                        <input onchange="actualizarRespuesta()"  maxlength="100" onblur="Validar_Campo()" type="email" class="form-control" id="correo" name="correo">
                    </div>

                    <div class="form-group">
                        <label>Tipo de encargado:</label>
                        <input onchange="actualizarRespuesta()"  maxlength="50" onblur="Validar_Campo()" type="text" class="form-control" id="tipo_encargado" name="tipo_encargado">
                    </div>

                    <div id="boton_agregar" style="display: block; text-align: center">

                       <button disabled id="boton_agregar_contacto" onclick="Agrega_Contacto()" type="button" class="popup-btn">Agregar</button>

                    </div>

                    <div id="botones" style="display: none; text-align: center;">

                        <div style="display: none"  id="boton_modificar2">
                            <button disabled type="button" id="boton_modificar" onclick="Actualizar_Contacto()" class="popup-btn">Modificar</button>
                        </div>
                        <br/>
                         <div style="display: block"  id="boton_cancelar2">
                            <button id="boton_cancelar" type="submit" class="popup-btn">Cancelar</button>
                        </div>
                        
                      
                    </div>

                    <br>
                </div>
            </div>

            <br>

            <table id="tabla-mant" class="table table-striped table-bordered" style="width: 100%;">
                <!--Tabla-->

                <thead class="estilo-thead">
                    <tr>
                        <th>ID Contacto</th>
                        <th>Encargado</th>
                             <%if (Permisos.EDTIAR == true)
                                 { %>
                        <th>Modificar</th>
                        <th>Eliminar</th>
                        <%} %>
                    </tr>
                </thead>

                <tbody>

                    <%
                        List<Biblioteca_Clases.Models.Contacto> list = new List<Biblioteca_Clases.Models.Contacto>();
                        list = ListaContacto();

                        int autoincrement = 0;
                        foreach (var dato in list)
                        {
                            autoincrement = autoincrement + 1;
                    %>

                    <tr class="txt2">
                        <td><%=dato.ID_CONTACTO%></td>
                        <td><%=dato.ENCARGADO%></td>
                            <%if (Permisos.EDTIAR == true)
                                 { %>
                        <td style="text-align: center;"><a data-toggle="collapse" data-target="#collapseServicios" aria-expanded="false" aria-controls="collapseServicios" onclick="editar('<%=dato.ID_CONTACTO%>','<%=dato.ENCARGADO%>','<%=dato.TELEFONO%>','<%=dato.CORREO%>','<%=dato.TIPO_ENCARGADO%>');" href="#"><i class="fa fa-edit color-icono" aria-hidden="true"></td>
                        <td style="text-align: center;"><a onclick="Eliminar_Contacto(<%=dato.ID_CONTACTO%>)" href="#"><i class="fas fa-trash color-icono" aria-hidden="true"></td>
                        <%} %>
                    </tr>

                    <%}%>
                </tbody>

                <tfoot class="estilo-thead">
                    <tr>
                        <th>ID Contacto</th>
                        <th>Encargado</th>
                             <%if (Permisos.EDTIAR == true)
                                 { %>
                        <th>Modificar</th>
                        <th>Eliminar</th>
                        <%} %>
                    </tr>
                </tfoot>

            </table>
            <!--Fin Tabla-->

    </div>
    <!--Container-->

    </div>
    <!--Container mant-->

      <script type="text/javascript">

          function actualizarRespuesta() {
              $("#boton_modificar2").css("display", "block");
              $("#boton_cancelar2").css("display", "block");
          }

          /*Validaciones*/

          $('#encargado').on('input', function (e) {
              if (!/^[ a-z0-9áéíóúüñ]*$/i.test(this.value)) {
                  this.value = this.value.replace(/[^ a-z0-9áéíóúüñ]+/ig, "");
              }
          });

          $('#telefono').on('input', function (e) {
              if (!/^[ 0-9]*$/i.test(this.value)) {
                  this.value = this.value.replace(/[^ 0-9]+/ig, "");
              }
          });

          $('#correo').on('input', function (e) {
              if (!/^[ a-z0-9áéíóúüñ@._]*$/i.test(this.value)) {
                  this.value = this.value.replace(/[^ a-z0-9áéíóúüñ@._]+/ig, "");
              }
          });

          $('#tipo_encargado').on('input', function (e) {
              if (!/^[ a-z0-9áéíóúüñ]*$/i.test(this.value)) {
                  this.value = this.value.replace(/[^ a-z0-9áéíóúüñ]+/ig, "");
              }
          });
      </script>

</asp:Content>
