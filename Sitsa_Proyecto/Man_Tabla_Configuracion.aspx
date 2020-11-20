<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Maestra.Master" AutoEventWireup="true" CodeBehind="Man_Tabla_Configuracion.aspx.cs" Inherits="Sitsa_Proyecto.Man_Tabla_Configuracion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="styles" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <script src="Assets_CTRL/js/Funciones_Paginas/Tabla_Configuracion.js"></script>

    <div class="container-mant">


        <div style="margin-right: auto;">
            <!--Cabecera-->
            <h3 class="text-left">
                <i class="fas fa-database color-icono" aria-hidden="true"></i>&nbsp; Tabla Configuración
            </h3>
            <p class="text-justify txt5">
            Mantenimiento para el manejo de los valores correspondientes a la Tabla Configuración del Sistema Control de Visitas. 
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
                    Agregar nuevo valor
                </button>
            </p>

                               <% if (Permisos.CREAR == false)
                                   {

                %>
            </div>
            <%  }%>
            <div class="collapse" id="collapseServicios">
                <div class="card card-body txt2">

                    <p id="parrafo_configuracion">Ingresar un nuevo valor</p>

                    <div class="row">
            
                        <input hidden maxlength="25"  type="text" class="form-control" id="pk_tbl_config" name="pk_tbl_config">
                  
                         <div class="col-12 col-md-6">

                    <div  class="form-group">
                        <label>Estado:</label>
                        <input onchange="actualizarRespuesta()"  maxlength="25" value=" " type="text" class="form-control" id="estado" name="estado">
                    </div>

                             </div>

                        <div class="col-12 col-md-6">

                    <div class="form-group">
                        <label>Consecutivo:</label>
                        <input onchange="actualizarRespuesta()" value=" "  maxlength="25" type="text" class="form-control" id="consecutivo" name="consecutivo">
                    </div>

                            </div>

                        <div class="col-12 col-md-12">

                    <div class="form-group">
                        <label>Descripción:</label>
                        <input onchange="actualizarRespuesta()" value=" "  maxlength="100" type="text" class="form-control" id="descripcion" name="descripcion">
                    </div>

                            </div>

                        <div class="col-12 col-md-12">

                    <div class="form-group">
                        <label>Observación:</label>
                        <input onchange="actualizarRespuesta()" value=" "  maxlength="100" type="text" class="form-control" id="observacion" name="observacion">
                    </div>

                            </div>

                     <div class="col-12 col-md-6">

                    <div class="form-group">
                        <label>Llave 01:</label>
                        <input onchange="actualizarRespuesta()" value=" "  maxlength="50" type="text" class="form-control" id="llave01" name="llave01">
                    </div>

                         </div>

                      <div class="col-12 col-md-6">

                    <div class="form-group">
                        <label>Llave 02:</label>  
                        <input onchange="actualizarRespuesta()" value=" " maxlength="50" type="text" class="form-control" id="llave02" name="llave02">
                    </div>

                           </div>

                         <div class="col-12 col-md-6">

                    <div class="form-group">
                        <label>Llave 03:</label>
                        <input onchange="actualizarRespuesta()" value=" "  maxlength="50" type="text" class="form-control" id="llave03" name="llave03">
                    </div>

                             </div>

                         <div class="col-12 col-md-6">

                    <div class="form-group">
                        <label>Llave 04:</label>
                        <input onchange="actualizarRespuesta()" value=" "  maxlength="50" type="text" class="form-control" id="llave04" name="llave04">
                    </div>

                             </div>

                         <div class="col-12 col-md-6">

                    <div class="form-group">
                        <label>Llave 05:</label>
                        <input onchange="actualizarRespuesta()" value=" "  maxlength="50" type="text" class="form-control" id="llave05" name="llave05">
                    </div>

                             </div>

                         <div class="col-12 col-md-6">

                    <div class="form-group">
                        <label>Llave 06:</label>
                        <input onchange="actualizarRespuesta()" value=" " maxlength="50" type="text" class="form-control" id="llave06" name="llave06">
                    </div>

                             </div>

                        <div class="col-12 col-md-12">

                      <div class="form-group">
                        <label>Valor:</label>
                        <input onchange="actualizarRespuesta()" value=" " maxlength="100" type="text" class="form-control" id="valor" name="valor">
                    </div>

                            </div>

                        <div class="col-12 col-md-6">

                     <div class="form-group">
                        <label>FK llave foránea:</label>
                        <input onchange="actualizarRespuesta()" value=" " maxlength="25" type="text" class="form-control" id="fk_llave_foranea" name="fk_llave_foranea">
                    </div>

                            </div>

                        <div class="col-12 col-md-6">

                     <div class="form-group">
                        <label>Estructura:</label>
                        <input onchange="actualizarRespuesta()" value=" " maxlength="25" type="text" class="form-control" id="estructura" name="estructura">
                    </div>

                            </div>

                        <div class="col-12 col-md-12">

                     <div class="form-group">
                        <label>Gui Relación:</label>
                        <input onchange="actualizarRespuesta()" value=" " maxlength="25" type="text" class="form-control" id="gui_relacion" name="gui_relacion">
                    </div>

                            </div>

                        </div>

                    <div id="boton_agregar" style="display: block; text-align: center">

                       <button id="boton_agregar_tbl_config" onclick="Agrega_Tabla_Configuracion()" type="button" class="popup-btn">Agregar</button>

                    </div>

                    <div id="botones" style="display: none; text-align: center;">

                        <div style="display: none"  id="boton_modificar2">
                            <button  type="button" id="boton_modificar" onclick="Actualizar_Tabla_Configuracion()" class="popup-btn">Modificar</button>
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
                        <th>Descripción</th>
                        <th>Valor</th>
                             <%if (Permisos.EDTIAR == true)
                                 { %>
                        <th>Modificar</th>
                         <th>Eliminar</th>
                        <%} %>
                    </tr>
                </thead>

                <tbody>

                    <%
                        List<Biblioteca_Clases.Models.Tabla_Configuracion> list = new List<Biblioteca_Clases.Models.Tabla_Configuracion>();
                        list = ListaConfiguracion();

                        int autoincrement = 0;
                        foreach (var dato in list)
                        {
                            autoincrement = autoincrement + 1;
                    %>

                    <tr class="txt2">
                        <td><%=dato.DESCRIPCION%></td>
                        <td><%=dato.VALOR%></td>
                            <%if (Permisos.EDTIAR == true)
                                 { %>
                        <td style="text-align: center;"><a data-toggle="collapse" data-target="#collapseServicios" aria-expanded="false" aria-controls="collapseServicios" onclick="editar('<%=dato.ESTADO%>','<%=dato.CONSECUTIVO%>','<%=dato.DESCRIPCION%>','<%=dato.OBSERVACION%>','<%=dato.LLAVE01%>','<%=dato.LLAVE02%>','<%=dato.LLAVE03%>','<%=dato.LLAVE04%>','<%=dato.LLAVE05%>','<%=dato.LLAVE06%>','<%=dato.VALOR%>','<%=dato.FK_LLAVE_FORANEA%>','<%=dato.ESTRUCTURA%>','<%=dato.GUI_RELACION%>', '<%=dato.PK_TBL_CONFIG%>');" href="#"><i class="fa fa-edit color-icono" aria-hidden="true"></td>
                         <td style="text-align: center;"><a onclick="Eliminar_Tabla_Configuracion('<%=dato.PK_TBL_CONFIG%>')"><i class="fas fa-trash color-icono" aria-hidden="true"></td>
                        <%} %>
                    </tr>

                    <%}%>
                </tbody>

                <tfoot class="estilo-thead">
                    <tr>
                        <th>Descripción</th>
                        <th>Valor</th>
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

          $('#descripcion').on('input', function (e) {
              if (!/^[ a-z0-9áéíóúüñ]*$/i.test(this.value)) {
                  this.value = this.value.replace(/[^ a-z0-9áéíóúüñ]+/ig, "");
              }
          });

          $('#observacion').on('input', function (e) {
              if (!/^[ a-z0-9áéíóúüñ]*$/i.test(this.value)) {
                  this.value = this.value.replace(/[^ a-z0-9áéíóúüñ]+/ig, "");
              }
          });

          $('#llave01').on('input', function (e) {
              if (!/^[ a-z0-9áéíóúüñ]*$/i.test(this.value)) {
                  this.value = this.value.replace(/[^ a-z0-9áéíóúüñ]+/ig, "");
              }
          });

          $('#llave02').on('input', function (e) {
              if (!/^[ a-z0-9áéíóúüñ]*$/i.test(this.value)) {
                  this.value = this.value.replace(/[^ a-z0-9áéíóúüñ]+/ig, "");
              }
          });

          $('#llave03').on('input', function (e) {
              if (!/^[ a-z0-9áéíóúüñ]*$/i.test(this.value)) {
                  this.value = this.value.replace(/[^ a-z0-9áéíóúüñ]+/ig, "");
              }
          });


          $('#llave04').on('input', function (e) {
              if (!/^[ a-z0-9áéíóúüñ]*$/i.test(this.value)) {
                  this.value = this.value.replace(/[^ a-z0-9áéíóúüñ]+/ig, "");
              }
          });


          $('#llave05').on('input', function (e) {
              if (!/^[ a-z0-9áéíóúüñ]*$/i.test(this.value)) {
                  this.value = this.value.replace(/[^ a-z0-9áéíóúüñ]+/ig, "");
              }
          });


          $('#llave06').on('input', function (e) {
              if (!/^[ a-z0-9áéíóúüñ]*$/i.test(this.value)) {
                  this.value = this.value.replace(/[^ a-z0-9áéíóúüñ]+/ig, "");
              }
          });

          $('#valor').on('input', function (e) {
              if (!/^[ a-z0-9áéíóúüñ]*$/i.test(this.value)) {
                  this.value = this.value.replace(/[^ a-z0-9áéíóúüñ]+/ig, "");
              }
          });

          $('#estructura').on('input', function (e) {
              if (!/^[ a-z0-9áéíóúüñ]*$/i.test(this.value)) {
                  this.value = this.value.replace(/[^ a-z0-9áéíóúüñ]+/ig, "");
              }
          });

          $('#gui_relacion').on('input', function (e) {
              if (!/^[ a-z0-9áéíóúüñ]*$/i.test(this.value)) {
                  this.value = this.value.replace(/[^ a-z0-9áéíóúüñ]+/ig, "");
              }
          });

          $('#fk_llave_foranea').on('input', function (e) {
              if (!/^[ 0-9]*$/i.test(this.value)) {
                  this.value = this.value.replace(/[^ 0-9]+/ig, "");
              }
          });

          $('#estado').on('input', function (e) {
              if (!/^[ 0-9]*$/i.test(this.value)) {
                  this.value = this.value.replace(/[^ 0-9]+/ig, "");
              }
          });

          $('#consecutivo').on('input', function (e) {
              if (!/^[ 0-9]*$/i.test(this.value)) {
                  this.value = this.value.replace(/[^ 0-9]+/ig, "");
              }
          });





      </script>

</asp:Content>
