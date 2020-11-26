<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Maestra.Master" AutoEventWireup="true" CodeBehind="Man_Contrato.aspx.cs" Inherits="WebApplication2.Man_Contrato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="styles" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="Assets_CTRL/js/Funciones_Paginas/Contrato.js"></script>

    <div class="container-mant">


        <div style="margin-right: auto;">
            <!--Cabecera-->
            <h3 class="text-left">
                <i class="fas fa-file-alt color-icono" aria-hidden="true"></i>&nbsp; Contratos
            </h3>
            <p class="text-justify txt5">
           Mantenimiento para el manejo y control de los contratos.

            </p>
        </div>
        <!--Fin Cabecera-->

        <br>

        <!-- Contenido -->
        <div class="container">

            <div class="form-group container">
                <select class="form-control select_selecionar_proyecto" id="select_tipo">
                    <option selected="true" disabled="disabled">Seleccione el estado:</option>
                    <option value="Activo">Activo</option>
                    <option value="Inactivo">Inactivo</option>
                    <option value="General">Todos</option>
                </select>
            </div>

            <!--Panel agregar contrato-->
            <% if (Permisos.CREAR == false)
                {

            %>

            <div style="display: none;" id="divvalida">
                <%  }%>
                <p>
                    <button class="btn btn-dark txt2" id="boton_multiple" value="" type="button" data-toggle="collapse" data-target="#collapseServicios" aria-expanded="false" aria-controls="collapseServicios">
                        Agregar Contrato
                    </button>
                </p>
                <% if (Permisos.CREAR == false)
                    {

                %>
            </div>
            <%  }%>

            <div class="collapse" id="collapseServicios">
                <div class="card card-body txt2">

                    <div id="div_agregar_contrato">

                        <div style="display: none; text-align: center;" id="error_campos_vacios" class="alert alert-warning">
                            <strong>¡Cuidado!</strong> Campos sin completar en el contrato.
                        </div>

                        <div style="display: none; text-align: center;" id="error_campos_vacios2" class="alert alert-warning">
                            <strong>¡Cuidado!</strong> Campos sin completar en los servicios.
                        </div>
                        <div style="display: none; text-align: center;" id="error_fechas" class="alert alert-warning">
                            <strong>¡Cuidado!</strong> La fecha de vencimiento es menor a la fecha de inicio.
                        </div>

                        <p>Ingresar un nuevo contrato</p>

                        <div class="row">

                            <div class="form-group col-12 col-md-6" style="display: none" id="consecutivo">
                                <label>Consecutivo del contrato:</label>
                                <input type="text" class="form-control" id="consecutivo_contrato" name="consecutivo_contrato" readonly="">
                            </div>

                            <div class="form-group col-12 col-md-6" style="display: none;" id="aux">
                            </div>

                            <div class="col-12 col-md-6">
                                <label>Seleccionar cliente:</label>


                                <select <%--onchange="actualizarRespuesta()" onblur="Validar_Campo()"--%> onchange="actualizaContacto();" id="cliente_contrato" lang="es" class="js-example-responsive" style="width: 100%;" name="state">
                                    <option selected value="nulo" disabled></option>
                                    <%
                                        List<Biblioteca_Clases.Models.Cliente> list_clientes = Lista_Clientes();

                                        foreach (var dato in list_clientes)
                                        {
                                    %>
                                    <option value="<%=dato.ID_CLIENTE%>"><%=dato.NOMBRE%></option>

                                    <%}%>
                                </select>

                                <br>
                            </div>

                            <div class="col-12 col-md-6">
                                <div class="form-group">
                                    <label>Nombre del contrato:</label>
                                    <input onchange="actualizarRespuesta()" maxlength="25" onblur="Validar_Campo()" type="text" class="form-control" id="nombre_contrato" name="nombre_contrato">
                                </div>
                            </div>

                            <div class="col-12 col-md-6">

                                <div class="form-group">
                                    <label>Descripción:</label>
                                    <textarea onchange="actualizarRespuesta()" maxlength="100" onblur="Validar_Campo()" id="descripcion_contrato" class="md-textarea form-control" rows="3"></textarea>
                                </div>
                            </div>

                            <div class="col-12 col-md-6">
                                <label>Seleccionar contacto:</label>
                                <select onchange="actualizarRespuesta()" id="contacto_contrato" lang="es" class="js-example-responsive" style="width: 100%;" name="state">
                                    <option selected value="nulo" disabled></option>

                                </select>

                                <br>
                            </div>

                            <div class="col-12 col-md-6">
                                <div class="form-group">
                                    <label>Fecha de inicio:</label>
                                    <input onchange="Validar_Fechas();actualizarRespuesta()" onblur="Validar_Campo()" type="date" class="form-control" id="fecha_inicio" name="fecha_inicio">
                                </div>
                            </div>

                            <div class="col-12 col-md-6">

                                <div class="form-group">
                                    <label>Fecha de vencimiento:</label>
                                    <input onchange="Validar_Fechas();actualizarRespuesta()" onblur="Validar_Campo()" type="date" class="form-control" id="fecha_vencimiento" name="fecha_vencimiento">
                                </div>
                            </div>

                            <div class="col-12 col-md-6">

                                <label>Seleccionar tipo de contrato:</label>
                                <!--Dependiendo lo que se seleccione se agregar los campos de hora, rango, etc-->
                                <%--<input onchange="actualizarRespuesta()" onblur="Validar_Campo()" class="form-control" id="tipo_contrato" list="lista_tipo_contrato">
                                <datalist id="lista_tipo_contrato">
                                    <%
                                        List<Biblioteca_Clases.Models.Tipo_Contrato> list_tipo_contrato = Lista_Tipo_Contratos();

                                        foreach (var tipo in list_tipo_contrato)
                                        {
                                            string horas = "Contrato sin horas";
                                            string monto = "Contrato sin monto";
                                            string rango = "Contrato sin rango de documentos";

                                            if (tipo.HORAS == true)
                                            {
                                                horas = "Por horas";
                                            }
                                            if (tipo.MONTO == true)
                                            {
                                                monto = "Por monto";
                                            }
                                            if (tipo.RANGO_DOCUMENTOS == true)
                                            {
                                                rango = "Por rango de documentos";
                                            }
                                    %>
                                    <option value="<%=tipo.ID_TIPO_CONTRATO%>,<%=horas%>,<%=rango%>,<%=monto%>,<%=tipo.NOMBRE %>"><%=tipo.ID_TIPO_CONTRATO %>-<%=tipo.NOMBRE%></option>

                                    <%}%>
                                </datalist>--%>

                                <select <%--onchange="actualizarRespuesta()" onblur="Validar_Campo()"--%> id="tipo_contrato" lang="es" class="js-example-responsive" style="width: 100%;" name="state">
                                    <option selected value="nulo" disabled></option>
                                    <%
                                        List<Biblioteca_Clases.Models.Tipo_Contrato> list_tipo_contrato = Lista_Tipo_Contratos();

                                        foreach (var tipo in list_tipo_contrato)
                                        {
                                            string horas = "Contrato sin horas";
                                            string monto = "Contrato sin monto";
                                            string rango = "Contrato sin rango de documentos";

                                            if (tipo.HORAS == true)
                                            {
                                                horas = "Por horas";
                                            }
                                            if (tipo.MONTO == true)
                                            {
                                                monto = "Por monto";
                                            }
                                            if (tipo.RANGO_DOCUMENTOS == true)
                                            {
                                                rango = "Por rango de documentos";
                                            }
                                    %>
                                    <option value="<%=tipo.ID_TIPO_CONTRATO%>,<%=horas%>,<%=rango%>,<%=monto%>,<%=tipo.NOMBRE %>"><%=tipo.NOMBRE%></option>

                                    <%}%>
                                </select>
                            </div>

                            <div class="col-12 col-md-6" id="padre_horas">
                                <div class="form-group" id="div_horas" style="display: none">
                                    <label>Horas: </label>
                                    <input onchange="actualizarRespuesta()" maxlength="25" id="horas_contrato" type="text" class="form-control">
                                </div>
                            </div>

                            <div class="col-12 col-md-6" id="padre_monto" style="display: block">
                                <br>
                                <div class="form-group" id="div_monto" style="display: none">
                                    <label>Monto: </label>
                                    <input onchange="actualizarRespuesta()" maxlength="25" id="monto_contrato" type="text" class="form-control">
                                </div>
                            </div>

                            <div class="col-12 col-md-6" id="padre_rango" style="display: block">
                                <br>
                                <div class="form-group" id="div_rango" style="display: none">
                                    <label>Rango: </label>
                                    <input onchange="actualizarRespuesta()" maxlength="25" id="rango_contrato" type="text" class="form-control">
                                </div>
                            </div>

                            <div class="col-12 col-md-6">

                                <br>
                                <label>Seleccionar servicio:</label>
                                <input onchange="actualizarRespuesta()" onblur="Validar_Campo2()" class="form-control" id="servicio_contrato" list="lista_servicios">
                                <datalist id="lista_servicios">
                                    <%
                                        List<Biblioteca_Clases.Models.Servicio> list_servicios = Lista_Servicios();

                                        foreach (var servicio in list_servicios)
                                        {
                                    %>
                                    <option value="<%=servicio.ID_SERVICIO%>-<%=servicio.DESCRIPCION%>"><%=servicio.DESCRIPCION%></option>

                                    <%}%>
                                </datalist>

                                <br>
                            </div>

                            <div class="col-12 col-md-6">
                                <br>
                                <div class="form-group">
                                    <label>Descripción del servicio:</label>
                                    <input onchange="actualizarRespuesta()" maxlength="100" onblur="Validar_Campo2()" type="text" class="form-control" id="descripcion_servicio" name="desc_contrato">
                                </div>
                            </div>

                            <div class="col-12 col-md-6">
                                <br>
                                <div class="form-group">
                                    <button disabled onclick="Agregar_Servicio()" id="boton_agrega_servicio" type="button" class="popup-btn">Agregar servicio</button>
                                </div>
                            </div>

                        </div>

                        <p>Servicios del contrato</p>
                        <table id="t_servicios" class="table table-striped table-bordered" style="width: 100%;">
                            <!--Tabla-->

                            <thead class="estilo-thead">
                                <tr>
                                    <th>ID</th>
                                    <th>Descripción</th>
                                    <th>Eliminar</th>
                                </tr>
                            </thead>

                            <tbody>
                            </tbody>

                        </table>
                        <!--Fin Tabla-->

                        <div id="boton_enviar" style="display: block; text-align: center">
                            <button disabled onclick="Agregar_Contrato()" id="boton_agregar" type="button" class="popup-btn">Agregar</button>
                            <button id="boton_cancelar1" type="submit" class="popup-btn">Cancelar</button>
                        </div>


                        <div id="botones" style="display: none; text-align: center;">

                            <div style="display: none" id="boton_modificar2">
                                <button disabled onclick="Actualizar_Contrato();" type="button" id="boton_modificar" class="popup-btn">Modificar</button>
                            </div>
                            <br />
                            <div style="display: block" id="boton_cancelar2">
                                <button id="boton_cancelar" type="submit" class="popup-btn">Cancelar</button>
                            </div>

                        </div>

                        <br>
                    </div>
                </div>


            </div>

            <br>


            <table id="tabla-mant" class="table table-striped table-bordered" style="width: 100%;">
                <!--Tabla-->

                <thead class="estilo-thead">
                    <tr>
                        <th>Consecutivo</th>
                        <th>Nombre de Contrato</th>
                        <!--<th>Ver Detalles</th>-->
                        <%if (Permisos.EDTIAR == true)
                            { %>
                        <th>Modificar</th>
                        <th>Estado</th>
                        <%}%>
                    </tr>
                </thead>

                <tbody>


                    <%
                        List<Biblioteca_Clases.Models.Contrato> lista = new List<Biblioteca_Clases.Models.Contrato>();

                        string seleccion = Convert.ToString(Request.QueryString["Estado"]);
                        lista = Lista_Contrato(seleccion);

                        foreach (var dato in lista)
                        {
                    %>


                    <tr class="txt2">
                        <td><%=dato.ID_CONTRATO%></td>
                        <td><%=dato.NOMBRE_CONTRATO%></td>
                        <%--<td style="text-align: center;"><a data-toggle="modal" data-target="#detalles_contrato" onclick="detalla(<%=dato.ID_CONTRATO%>,<%=dato.CLIENTE%>,'<%=dato.NOMBRE_CONTRATO%>','<%=dato.DESCRIPCION%>',<%=dato.CONTACTO%>,'<%=dato.FECHA_INICIO%>','<%=dato.FECHA_VENCE%>',<%=dato.TIPO_CONTRATO%>, <%=dato.HORAS%>, <%=dato.MONTO%>, <%=dato.RANGO%>);" /><i class="fa fa-list color-icono" aria-hidden="true" /></td>--%>
                        <%if (Permisos.EDTIAR == true)
                            { %>
                        <td style="text-align: center;"><a onclick="editar(<%=dato.ID_CONTRATO%>,<%=dato.CLIENTE%>,'<%=dato.NOMBRE_CONTRATO%>','<%=dato.DESCRIPCION%>',<%=dato.CONTACTO%>,'<%=dato.FECHA_INICIO%>','<%=dato.FECHA_VENCE%>',<%=dato.TIPO_CONTRATO%>, <%=dato.HORAS%>, <%=dato.MONTO%>, <%=dato.RANGO%>);" href="#" data-toggle="collapse" data-target="#collapseServicios" aria-expanded="false" aria-controls="collapseServicios" /><i class="fa fa-edit color-icono" aria-hidden="true" /></td>
                        <td style="text-align: center;"><a href="#" />
                            <div class="custom-control custom-switch">
                                <% if (dato.ESTADO == 1)
                                    {
                                %>
                                <input onclick="estado(<%=dato.ID_CONTRATO%>);" type="checkbox" checked class="custom-control-input" id="<%=dato.ID_CONTRATO%>">
                                <%}
                                    else if (dato.ESTADO == 0)
                                    {
                                %>
                                <input onclick="estado(<%=dato.ID_CONTRATO%>);" type="checkbox" class="custom-control-input" id="<%=dato.ID_CONTRATO%>">
                                <%}%>
                                <label class="custom-control-label" for="<%=dato.ID_CONTRATO%>" />
                            </div>
                        </td>
                        <%}%>
                    </tr>

                    <%}

                    %>
                </tbody>

                <tfoot class="estilo-thead">
                    <tr>
                        <th>Consecutivo</th>
                        <th>Nombre de Proyecto</th>
                        <!--<th>Ver Detalles</th>-->
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

        /*Validaciones*/

        $('#rango_contrato').on('input', function (e) {
            if (!/^[ a-záéíóúüñ]*$/i.test(this.value)) {
                this.value = this.value.replace(/[^ 0-9]+/ig, "");
            }
        });

        $('#horas_contrato').on('input', function (e) {
            if (!/^[ 0-9]*$/i.test(this.value)) {
                this.value = this.value.replace(/[^ 0-9]+/ig, "");
            }
        });

        $('#monto_contrato').on('input', function (e) {
            if (!/^[ 0-9]*$/i.test(this.value)) {
                this.value = this.value.replace(/[^ 0-9]+/ig, "");
            }
        });


        $('#cliente_contrato').on('input', function (e) {
            if (!/^[ a-z0-9áéíóúüñ-]*$/i.test(this.value)) {
                this.value = this.value.replace(/[^ a-z0-9áéíóúüñ-]+/ig, "");
            }
        });

        $('#nombre_contrato').on('input', function (e) {
            if (!/^[ a-z0-9áéíóúüñ]*$/i.test(this.value)) {
                this.value = this.value.replace(/[^ a-z0-9áéíóúüñ]+/ig, "");
            }
        });

        $('#descripcion_contrato').on('input', function (e) {
            if (!/^[ a-z0-9áéíóúüñ]*$/i.test(this.value)) {
                this.value = this.value.replace(/[^ a-z0-9áéíóúüñ]+/ig, "");
            }
        });

        $('#contacto_contrato').on('input', function (e) {
            if (!/^[ a-z0-9áéíóúüñ]*$/i.test(this.value)) {
                this.value = this.value.replace(/[^ a-z0-9áéíóúüñ]+/ig, "");
            }
        });

        $('#descripcion_servicio').on('input', function (e) {
            if (!/^[ a-z0-9áéíóúüñ]*$/i.test(this.value)) {
                this.value = this.value.replace(/[^ a-z0-9áéíóúüñ]+/ig, "");
            }
        });

    </script>
</asp:Content>

