<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Maestra.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="WebApplication2.Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="styles" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="Assets_CTRL/js/Funciones_Paginas/Reporte.js"></script>

    <div class="container-repo">

        <!-- Page Header -->
        <div style="margin-right: auto;">
            <h3 class="text-left">
                <i class="far fa-file color-icono"></i>&nbsp; Generar Reporte
            </h3>
            <p class="text-justify txt5">
             Generación y envió de los reportes de contrato y proyecto para los clientes.
            </p>
        </div>



        <!-- Contenido -->
        <div class="container txt2">

            <div class="row">
                <div class="col-md-4 order-md-2 mb-4">
                    <%
                        string numero = Numero_Reporte();

                    %>
                    <h5 class="mb-3" id="n_reporte">Reporte:   <%=numero %></h5>


                    <!-- Seleccion de tipo de reporte -->
                    <!-- Group option 1 -->
                    <div class="custom-control custom-radio">
                        <input type="radio" class="custom-control-input" id="Contrato" name="grupo_tipo" value="contrato" checked>
                        <label class="custom-control-label" for="Contrato">Contrato</label>
                    </div>

                    <!-- Group option 2 -->
                    <div class="custom-control custom-radio">
                        <input type="radio" class="custom-control-input" id="Proyecto" name="grupo_tipo" value="proyecto">
                        <label class="custom-control-label" for="Proyecto">Proyecto</label>
                    </div>

                    <!-- Group option 3 -->
                    <div class="custom-control custom-radio">
                        <input type="radio" class="custom-control-input" id="Facturado" name="grupo_tipo" value="facturado">
                        <label class="custom-control-label" for="Facturado">Facturado</label>
                    </div>

                    <!-- Group option 4 -->
                    <div class="custom-control custom-radio">
                        <input type="radio" class="custom-control-input" id="Garantia" name="grupo_tipo" value="garantia">
                        <label class="custom-control-label" for="Garantia">Garantía</label>
                    </div>
                    <!-- Fin seleccion de tipo de reporte -->
                    <br>
                    <!-- Tipo de garantía -->
                    <div <%--class="custom-control"--%> style="display: none;" id="div_tipo_r">
                        <div class="custom-control custom-radio custom-control-inline">
                            <input type="radio" class="custom-control-input" id="R_Contrato" name="grupo_r" value="contrato" checked>
                            <label class="custom-control-label" for="R_Contrato">Contrato</label>
                        </div>

                        <div class="custom-control custom-radio custom-control-inline">
                            <input type="radio" class="custom-control-input" id="R_Proyecto" name="grupo_r" value="proyecto">
                            <label class="custom-control-label" for="R_Proyecto">Proyecto</label>
                        </div>
                    </div>
                    <!-- Fin tipo de garantía -->
                    <br>
                    <br>
                    <div <%--class="custom-control"--%> id="div_select">
                        <select class="custom-select d-block w-100 js-example-responsive" id="tipo" name="tipo" required style="width: 100%;">
                            <option value="" disabled>Seleccione</option>

                        </select>
                    </div>


                    <hr class="mb-4 hr-estilo-linea">

                    <label for="zip" id="label_total">Total de Horas</label>
                    <input type="text" class="form-control" id="total_horas" name="total_horas" placeholder="" required>
                    <br>
                    <label for="zip" id="label_consumido">Horas Consumidas</label>
                    <input type="text" class="form-control" id="horas_consumidas" name="horas_consumidas" placeholder="" onchange="monto_consumido()" required>
                    <br>
                    <label for="zip" id="label_disponible">Horas Disponibles</label>
                    <input type="text" class="form-control" id="horas_disponibles" name="horas_disponibles" placeholder="" required>
                    <br>
                    <div style="display: none" id="div_monto_total">
                        <label for="zip" id="label_monto">Monto Total</label>
                        <input type="text" class="form-control" id="monto_final" name="monto" placeholder="" required>
                    </div>
                </div>

                <div class="container">
                    <div class="py-1 text-center">
                    </div>
                </div>


                <div class="col-md-8 order-md-1">
                    <%
                        string date = Fecha();
                    %>
                    <h5 class="mb-3" id="fecha">Fecha: <%=date %> </h5>

                    <div class="row">

                        <div class="col-md-12 mb-12">
                            <label for="firstName">Cliente</label>
                            <div class="input-group">
                                <select <%--onchange="actualizarRespuesta()" onblur="Validar_Campo()"--%> id="cliente" lang="es" class="js-example-responsive" style="width: 100%;" name="state">
                                    <option selected value="nulo" disabled></option>
                                    <%
                                        List<Biblioteca_Clases.Models.Cliente> list_clientes = Lista_Clientes();

                                        foreach (var dato in list_clientes)
                                        {
                                    %>
                                    <option value="<%=dato.ID_CLIENTE%>"><%=dato.NOMBRE%></option>

                                    <%}%>
                                </select>

                            </div>
                        </div>
                    </div>
                    <br>
                    <div class="row">
                        <div class="col-md-12 mb-12">
                            <label for="address">Encargado</label>
                            <%--<input type="text" class="form-control" id="encargado" name="encargado" placeholder="Encargado" required>--%>
                            <select id="contacto_encargado" lang="es" class="js-example-responsive" style="width: 100%;" name="state">
                                <option selected value="nulo" disabled></option>

                            </select>
                        </div>
                    </div>
                    <br>
                    <div class="row">
                        <div class="col-md-12 mb-12">
                            <label for="address">Añadir Correo</label>
                            <%--<input type="text" class="form-control" id="encargado" name="encargado" placeholder="Encargado" required>--%>
                            <select id="correo_encargado" lang="es" class="js-example-responsive" style="width: 100%;" name="state">
                                <option selected value="nulo" disabled></option>

                            </select>
                        </div>
                    </div>
                    <br>
                    <div class="mb-3 ">
                        <label for="email">Correos</label>
                        <input type="email" class="form-control" id="email" name="email" placeholder="Correo Electrónico">
                    </div>
                    <%--<div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="firstName">Cantidad Disponible</label>
                            <div class="input-group">
                                <input type="text" id="cantidad_disponible" name="cantidad_disponible" class="form-control" placeholder="###">
                            </div>
                        </div>
                    </div>--%>
                    <div class="mb-3 form-group">
                        <label>Observación:</label>
                        <textarea maxlength="100" id="observacion_reporte" class="md-textarea form-control" rows="3"></textarea>
                    </div>

                    <div class="row" id="row_servicios" style="display: none;">
                        <div class="col-12 col-md-6">

                            <br>
                            <label>Seleccionar servicio:</label>
                            <input class="form-control" id="servicios_l" list="lista_servicios">
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
                    </div>

                </div>
                <!--Primera Parte-->
            </div>
            <!--Row Contenido-->

            <hr class="mb-4 hr-estilo-linea">

            <div id="div_t_servicios">

                <h5 class="mb-3">Servicios:</h5>


                <table id="t_servicios" class="table table-striped table-bordered" style="width: 100%;">
                    <!--Tabla-->

                    <thead class="estilo-thead">
                        <tr>
                            <th>Servicio</th>
                            <th>Descripción</th>
                            <th>Monto</th>
                            <th>Horas</th>
                            <th>Costo por Hora</th>
                            <th>Eliminar</th>
                        </tr>
                    </thead>

                    <tbody>
                    </tbody>

                    <tfoot class="estilo-thead">
                        <tr>
                            <th>Servicio</th>
                            <th>Descripción</th>
                            <th>Monto</th>
                            <th>Horas</th>
                            <th>Costo por Hora</th>
                            <th>Eliminar</th>
                        </tr>
                    </tfoot>

                </table>
            </div>
            <!--Fin Tabla-->

            <br>

                      <%if (Permisos.CREAR == true)
                          { %>
            <div class="col text-center" style="display: none" id="div_btn_agregar">
                <button type="button" class="guardar-btn-reporte" onclick="guardar(1);">Guardar</button>
            </div>
            <br>
            <div class="col text-center" style="display: none" id="div_btn_modificar">
                <button type="button" class="guardar-btn-reporte" onclick="guardar(2);">Modificar</button>
            </div>
              <%} %>
            <br>
            <br>
        </div>
        <!--Container-->
    </div>
    <!--Container Repo-->

    <script type="text/javascript">

        

    </script>

</asp:Content>
