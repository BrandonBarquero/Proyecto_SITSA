<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Maestra.Master" AutoEventWireup="true" CodeBehind="Man_Tipo_Contrato.aspx.cs" Inherits="WebApplication2.Man_Tipo_Contrato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="styles" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <script src="Assets_CTRL/js/Funciones_Paginas/Tipo_Contrato.js"></script>

    <div class="container-mant">


        <div style="margin-right: auto;">
            <!--Cabecera-->
            <h3 class="text-left">
                <i class="fas fa-file-alt color-icono" aria-hidden="true"></i>&nbsp; Tipo de Contratos
            </h3>
            <p class="text-justify txt5">
             Mantenimiento para el manejo y control de los tipos de contrato.
     </p>
        </div>
        <!--Fin Cabecera-->

        <br>

        <!-- Contenido -->
        <div class="container">

            <div class="form-group container">
                <select class="form-control select_selecionar_proyecto" id="select_tipo">
                    <option selected disabled="disabled">Seleccione el estado:</option>
                    <option value="Activo">Activo</option>
                    <option value="Inactivo">Inactivo</option>
                     <option value="General">Todos</option>
                </select>
            </div>

            <% if (Permisos.CREAR == false)
                {

            %>

            <div style="display: none;" id="divvalida">
                <%  }%>

                <p>
                    <button id="boton_multiple" class="btn btn-dark txt2" value="" type="button" data-toggle="collapse" data-target="#collapseServicios" aria-expanded="false" aria-controls="collapseServicios">
                        Agregar tipo de contrato
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

                    <p>Agregar tipo de contrato</p>

                    <div class="form-group" style="display: none" id="consecutivo">
                        <label>Consecutivo:</label>
                        <input type="text" class="form-control" id="consecutivo_tipo_contrato" name="consecutivo_tipo_contrato" readonly="">
                    </div>

                    <div class="form-group">
                        <label>Nombre del tipo de contrato:</label>
                        <input onchange="actualizarRespuesta()" maxlength="50" onblur="Validar_Campo()" type="text" class="form-control" id="nombre_tipo_contrato" name="nombre_tipo_contrato">
                    </div>

                    <div class="form-group">
                        <label>Opciones del tipo de contrato:</label>

                        <div class="custom-control custom-checkbox">
                            <input onchange="actualizarRespuesta()" type="checkbox" class="custom-control-input" id="horas" name="horas">
                            <label class="custom-control-label" for="horas">Horas</label>
                        </div>
                        <div class="custom-control custom-checkbox">
                            <input onchange="actualizarRespuesta()" type="checkbox" class="custom-control-input" id="rango_documentos" name="rango_documentos">
                            <label class="custom-control-label" for="rango_documentos">Rango de documentos</label>
                        </div>
                        <div class="custom-control custom-checkbox">
                            <input onchange="actualizarRespuesta()" type="checkbox" class="custom-control-input" id="monto" name="monto">
                            <label class="custom-control-label" for="monto">Monto</label>
                        </div>
                        <div class="custom-control custom-checkbox">
                            <input onchange="actualizarRespuesta()" type="checkbox" class="custom-control-input" id="aceptacion" name="aceptacion">
                            <label class="custom-control-label" for="aceptacion">Aceptación</label>
                        </div>

                    </div>

                    <div id="boton_enviar" style="display: block; text-align: center">
                        <button disabled type="button" class="popup-btn" onclick="Agregar_Tipo_Contrato()" id="boton_agregar">Agregar</button>
                         <button id="boton_cancelar_2" type="submit" class="popup-btn">Cancelar</button>
                    </div>

                    <div id="botones" style="display: none; text-align: center;">
                        <div style="display: none"  id="boton_modificar2">
                          <button disabled type="button" class="popup-btn" onclick="Actualizar_Tipo_Contrato()" id="boton_modificar">Modificar</button>
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
                        <th>Consecutivo</th>
                        <th>Nombre del Tipo de Contrato</th>
                        <%if (Permisos.EDTIAR == true)
                            { %>
                        <th>Modificar</th>
                        <th>Estado</th>
                        <%}%>
                    </tr>
                </thead>

                <tbody id="cuerpo">

                    <%
                        List<Biblioteca_Clases.Models.Tipo_Contrato> list = new List<Biblioteca_Clases.Models.Tipo_Contrato>();

                        string valor = Convert.ToString(Request.QueryString["Estado"]);
                        list = ListaTipo_Contrato(valor);

                        int autoincrement = 0;
                        foreach (var dato in list)
                        {
                            autoincrement = autoincrement + 1;
                    %>

                    <tr class="txt2">
                        <td><%=dato.ID_TIPO_CONTRATO%></td>
                        <td><%=dato.NOMBRE%></td>
                        <%if (Permisos.EDTIAR == true)
                            { %>
                        <td style="text-align: center;"><a href="#" onclick="Modificar_Tipo_Contrato(<%=dato.ID_TIPO_CONTRATO%>,'<%=dato.NOMBRE%>','<%=dato.HORAS%>','<%=dato.RANGO_DOCUMENTOS%>','<%=dato.MONTO%>','<%=dato.ACEPTACION%>');" data-toggle="collapse" data-target="#collapseServicios" aria-expanded="false" aria-controls="collapseServicios" /><i class="fa fa-edit color-icono" aria-hidden="true"/></td>
                        <td style="text-align: center;"><a href="#"/>
                            <div class="custom-control custom-switch">
                                <% if (dato.ESTADO == 1)
                                    {
                                %>
                                <input onclick="estado(<%=dato.ID_TIPO_CONTRATO%>)" type="checkbox" checked class="custom-control-input" id="<%=dato.ID_TIPO_CONTRATO%>">
                                <%}
                                    else if (dato.ESTADO == 0)
                                    {
                                %>
                                <input onclick="estado(<%=dato.ID_TIPO_CONTRATO%>)" type="checkbox" class="custom-control-input" id="<%=dato.ID_TIPO_CONTRATO%>">
                                <%}%>
                                <label class="custom-control-label" for="<%=dato.ID_TIPO_CONTRATO%>" />
                            </div></td>
                        <%}%>
                    </tr>

                    <%}%>
                </tbody>

                <tfoot class="estilo-thead">
                    <tr>
                        <th>Consecutivo</th>
                        <th>Nombre del Tipo de Contrato</th>
                        <%if (Permisos.EDTIAR == true)
                            { %>
                        <th>Modificar</th>
                        <th>Estado</th>
                        <%}%>
                    </tr>
                </tfoot>

            </table>
            <!--Fin Tabla-->

        </div>
        <!--Container-->

    </div>
    <!--Container mant-->

    <!--Script Tabla-->
    <script type="text/javascript">

        function actualizarRespuesta() {
            $("#boton_modificar2").css("display", "block");
            $("#boton_cancelar2").css("display", "block");
            document.getElementById("boton_modificar").disabled = false;
        }
   
        $('#nombre_tipo_contrato').on('input', function (e) {
            if (!/^[ a-z0-9áéíóúüñ]*$/i.test(this.value)) {
                this.value = this.value.replace(/[^ a-z0-9áéíóúüñ]+/ig, "");
            }
        });


    </script>
</asp:Content>
