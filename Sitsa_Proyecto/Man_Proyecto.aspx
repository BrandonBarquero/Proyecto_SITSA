<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Maestra.Master" AutoEventWireup="true" CodeBehind="Man_Proyecto.aspx.cs" Inherits="WebApplication2.Man_Proyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="styles" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="Assets_CTRL/js/Funciones_Paginas/Proyecto.js"></script>

    <div class="container-mant">


        <div style="margin-right: auto;">
            <!--Cabecera-->
            <h3 class="text-left">
                <i class="fas fa-project-diagram color-icono" aria-hidden="true"></i>&nbsp; Proyectos
            </h3>
            <p class="text-justify txt5">
           Mantenimiento para el manejo y control de proyectos.
                </p>
        </div>
        <!--Fin Cabecera-->

        <br>

        <!-- Contenido -->
        <div class="container">

            <div class="form-group container">

                <select class="form-control select_selecionar_proyecto" id="select_proyect">
                    <option selected="" disabled="disabled">Seleccione el estado:</option>
                    <option value="Activo_Servicio">Proyectos en Curso</option>
                    <option value="Inactivo_Servicio">Proyectos Terminados</option>
                    <option value="Todos_Servicio">Todos los proyectos</option>
                </select>
            </div>

            <% if (Permisos.CREAR == false)
                {

            %>

            <div style="display: none;" id="divvalida">
                <%  }%>

                <p>
                    <button class="btn btn-dark txt2" id="boton_multiple" value="" type="button" data-toggle="collapse" data-target="#collapseProyectos" aria-expanded="false" aria-controls="collapseProyectos">
                        Agregar Proyecto
                    </button>
                </p>

                <% if (Permisos.CREAR == false)
                    {

                %>
            </div>
            <%  }%>



            <div class="collapse" id="collapseProyectos">
                <div class="card card-body txt2">

                    <div id="div_agregar_proyecto">

                        <div style="display: none; text-align: center;" id="error_campos_vacios" class="alert alert-warning">
                            <strong>¡Cuidado!</strong> Campos sin completar en proyecto.
                        </div>

                        <div style="display: none; text-align: center;" id="error_campos_vacios2" class="alert alert-warning">
                            <strong>¡Cuidado!</strong> Campos sin completar en fases.
                        </div>


                        <p id="parrafo_proyecto">Agregar nuevo proyecto</p>

                        <div id="consecutivo_proyecto_div" class="form-group" style="display: none">
                            <label>Consecutivo:</label>
                            <input id="consecutivo_proyecto" type="text" class="form-control">
                        </div>

                        <div class="form-group">
                            <label>Seleccionar cliente:</label>
                           <%-- <input onchange="actualizarRespuesta()" onblur="Validar_Campo()" id="cliente_proyecto" class="form-control" list="lista_clientes">


                            <datalist id="lista_clientes">
                                <%
                                    Biblioteca_Clases.DAO.ClienteDAO cliente_dao = new Biblioteca_Clases.DAO.ClienteDAO();
                                    List<Biblioteca_Clases.Models.Cliente> list_clientes = cliente_dao.listaClientes();


                                    int autoincrement_cliente = 0;

                                    foreach (var dato in list_clientes)
                                    {
                                        autoincrement_cliente = autoincrement_cliente + 1;
                                %>
                                <option value="<%=dato.ID_CLIENTE%>"><%=dato.NOMBRE%></option>

                                <%}%>
                            </datalist>
                            <br>--%>

                                    <select onchange="actualizarRespuesta()" onblur="Validar_Campo()" id="cliente_proyecto"  lang="es" class="js-example-responsive" style="width:100%;"  name="state">
                                         <option selected value="nulo" disabled >  </option>
                                 <%
                                    Biblioteca_Clases.DAO.ClienteDAO cliente_dao = new Biblioteca_Clases.DAO.ClienteDAO();
                                    List<Biblioteca_Clases.Models.Cliente> list_clientes = cliente_dao.listaClientes();


                                    int autoincrement_cliente = 0;

                                    foreach (var dato in list_clientes)
                                    {
                                        autoincrement_cliente = autoincrement_cliente + 1;
                                %>

                                <option value="<%=dato.ID_CLIENTE%>"><%=dato.NOMBRE%></option>
   
                                <%} %>
                    </select>


                        </div>

                  
                        <div class="form-group">
                            <label>Nombre del proyecto:</label>
                            <input onchange="actualizarRespuesta()" maxlength="50" onblur="Validar_Campo()" type="text" class="form-control" id="nombre_proyecto" name="nombre_proyecto">
                        </div>

                        <div class="form-group">
                            <label>Descripción:</label>
                            <textarea onchange="actualizarRespuesta()" maxlength="100" onblur="Validar_Campo()" id="desc_proyecto" class="md-textarea form-control" rows="3"></textarea>
                        </div>

                        <div class="form-group">
                            <label>Precio:</label>
                            <input onchange="actualizarRespuesta()" onblur="Validar_Campo()" maxlength="25" type="text" class="form-control" id="precio" name="precio">
                        </div>





                    </div>

                    <div style="display: block" id="div_fase_tiempo">

                        <p>Fases del proyecto</p>


                        <div class="form-group">
                            <label>Descripción:</label>
                            <input onchange="actualizarRespuesta()" onblur="Validar_Campo2()" maxlength="100" type="text" class="form-control" id="descripcion_fase">
                        </div>

                        <div class="form-group">
                            <label>Tiempo:</label>
                            <input onchange="actualizarRespuesta()" onblur="Validar_Campo2()" maxlength="10" type="text" class="form-control" id="tiempo_proyecto">
                        </div>



                        <div style="text-align: center;">
                            <button disabled id="agregar_fases" onclick="Agregar_Fase()" type="button" class="popup-btn">Agregar Fase</button>
                        </div>




                        <hr class="mb-4 hr-estilo-linea">


                        <table id="t_fase" class="table table-striped table-bordered" style="width: 100%;">
                            <!--Tabla-->

                            <thead class="estilo-thead">
                                <tr>
                                    <th>Tiempo</th>
                                    <th>Descripción</th>
                                    <th>Eliminar</th>
                                </tr>
                            </thead>

                            <tbody>
                            </tbody>
                        </table>
                        <!--Fin Tabla-->

                    </div>


                    <div id="boton_agregar" style="text-align: center">

                        <button disabled id="boton_agregar_proyecto" onclick="Agregar_Proyecto()" type="button" class="popup-btn">Agregar</button>
                         <button id="boton_cancelar_2" type="submit" class="popup-btn">Cancelar</button>
                    </div>

                    <div id="botones" style="display: none; text-align: center;">
                         <div style="display: none"  id="boton_modificar2">
                          <button disabled onclick="Actualizar_Proyecto()" type="button" id="boton_modificar" class="popup-btn">Modificar</button>
                        </div>
                        <br/>
                       <div style="display: block"  id="boton_cancelar2">
                         <button id="boton_cancelar" type="submit" class="popup-btn">Cancelar</button>
                        </div>
                                       
                    </div>


                </div>
            </div>

            <br>


            <table id="tabla-mant" class="table table-striped table-bordered" style="width: 100%;">
                <!--Tabla-->

                <thead class="estilo-thead">
                    <tr>
                        <th>Consecutivo</th>
                        <th>Nombre de Proyecto</th>
               
                        <%if (Permisos.EDTIAR == true)
                            { %>
                   
                        <th>Modificar</th>
                        <th>Estado</th>
                        <%}%>
                    </tr>
                </thead>

                <tbody>

                    <%
                        List<Biblioteca_Clases.Models.Proyecto> list = new List<Biblioteca_Clases.Models.Proyecto>();
                        string valor = Convert.ToString(Request.QueryString["Estado"]);
                        list = ListaProyectos(valor);
                        int autoincrement = 0;

                        foreach (var dato in list)
                        {
                            autoincrement = autoincrement + 1;
                    %>

                    <tr class="txt2">
                        <td><%=dato.ID_PROYECTO%></td>
                        <td><%=dato.NOMBRE%></td>
                        <% if (Permisos.EDTIAR == true)
                            { %>
                        <td style="text-align: center;"><a data-toggle="collapse" data-target="#collapseProyectos" aria-expanded="false" aria-controls="collapseServicios" onclick="editar('<%=dato.ID_PROYECTO%>','<%=dato.NOMBRE%>','<%=dato.DESCRIPCION%>','<%=dato.PRECIO%>','<%=dato.FK_ID_CLIENTE%>');" href="#"><i class="fa fa-edit color-icono" aria-hidden="true"></td>
                        <td style="text-align: center;"><a href="#">
                            <div class="custom-control custom-switch">
                                <% if (dato.ESTADO == 1)
                                    {


                                %>
                                <input onclick="estado(<%=dato.ID_PROYECTO%>)" type="checkbox" checked class="custom-control-input" id="<%=dato.ID_PROYECTO%>">
                                <%}

                                    else if (dato.ESTADO == 0)
                                    {
                                %>
                                <input onclick="estado(<%=dato.ID_PROYECTO%>)" type="checkbox" class="custom-control-input" id="<%=dato.ID_PROYECTO%>">

                                <%}%>

                                <label class="custom-control-label" for="<%=dato.ID_PROYECTO%>" />

                            </div></td>
                        <%}%>
                    </tr>

                    <%}

                    %>
                </tbody>
                
                <tfoot class="estilo-thead">
                    <tr>
                        <th>Consecutivo</th>
                        <th>Nombre de Proyecto</th>
                      
                        <%      if (Permisos.EDTIAR == true)
                            {%>
                     
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

  


    <script type="text/javascript">

        function actualizarRespuesta() {
            $("#boton_modificar2").css("display", "block");
            $("#boton_cancelar2").css("display", "block");
            document.getElementById("boton_modificar").disabled = false;
        }

        /*Validaciones*/

        $('#precio').on('input', function (e) {
            if (!/^[ 0-9]*$/i.test(this.value)) {
                this.value = this.value.replace(/[^ 0-9]+/ig, "");
            }
        });

        $('#cliente_proyecto').on('input', function (e) {
            if (!/^[ 0-9]*$/i.test(this.value)) {
                this.value = this.value.replace(/[^ 0-9]+/ig, "");
            }
        });

        $('#nombre_proyecto').on('input', function (e) {
            if (!/^[ a-z0-9áéíóúüñ@._]*$/i.test(this.value)) {
                this.value = this.value.replace(/[^ a-z0-9áéíóúüñ@._]+/ig, "");
            }
        });

        $('#desc_proyecto').on('input', function (e) {
            if (!/^[ a-z0-9áéíóúüñ@._]*$/i.test(this.value)) {
                this.value = this.value.replace(/[^ a-z0-9áéíóúüñ@._]+/ig, "");
            }
        });

        $('#tiempo_proyecto').on('input', function (e) {
            if (!/^[ 0-9]*$/i.test(this.value)) {
                this.value = this.value.replace(/[^ 0-9]+/ig, "");
            }
        });
        $('#descripcion_fase').on('input', function (e) {
            if (!/^[ a-z0-9áéíóúüñ@._]*$/i.test(this.value)) {
                this.value = this.value.replace(/[^ a-z0-9áéíóúüñ@._]+/ig, "");
            }
        });

    </script>



</asp:Content>
