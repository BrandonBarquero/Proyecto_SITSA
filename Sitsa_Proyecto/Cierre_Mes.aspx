<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Maestra.Master" AutoEventWireup="true" CodeBehind="Cierre_Mes.aspx.cs" Inherits="WebApplication2.Cierre_Mes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="styles" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="Assets_CTRL/js/Funciones_Paginas/Cierre_Mes.js"></script>

    <div class="container-repo">

        <!-- Page Header -->
        <div style="margin-right: auto;">
            <h3 class="text-left">
                <i class="far fa-file color-icono"></i>&nbsp; Cierre de mes
            </h3>
            <p class="text-justify txt5">
           Manejo y control de registro de reportes por facturar y facturados.
                </p>
        </div>

        <!-- Contenido -->
        <div class="container txt2">

            <div class="row">

                <div class="col-md-3 mb-3">
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

                <div class="col-md-3 mb-3">
                    <label for="firstName">Reporte</label>

                    <div class="input-group">
                        <input required type="text" class="form-control" placeholder="Reporte" id="reporte" name="reporte">
                        <div class="input-group-append">
                          
                        </div>
                    </div>

                </div>

                <div class="col-md-3 mb-3">
                    <label for="firstName">Fecha inicial</label>

                    <div class="input-group">
                        <input type="date" class="form-control" id="horas_convertidas" name="horas_convertidas">
                    </div>

                </div>

                <div class="col-md-3 mb-3">
                    <label for="firstName">Fecha final</label>

                    <div class="input-group">
                        <input type="date" class="form-control" id="horas_convertidas2" name="horas_convertidas">
                        <div class="input-group-append" > <button type="button" onclick="Buscar()" class="cliente-btn-search">Buscar</button></div>
                    </div>
                    
                </div>


            </div>

            <ul class="nav nav-tabs md-tabs" id="myTabMD" role="tablist">
                <li class="nav-item">
                    <a onclick="Generales()" class="nav-link active" id="home-tab-md" data-toggle="tab" href="#home-md" role="tab" aria-controls="home-md"
                        aria-selected="true">Reportes sin facturar</a>
                </li>
                <li class="nav-item">
                    <a onclick="Facturados()" class="nav-link" id="profile-tab-md" data-toggle="tab" href="#profile-md" role="tab" aria-controls="profile-md"
                        aria-selected="false">Reportes facturados</a>
                </li>
            </ul>

            <!-- Tabla -->
            <table id="tabla-mant" class="table table-striped table-bordered" style="width: 100%;">
                <!--Tabla-->

                <thead class="estilo-thead">
                    <tr>
                        <th>Doumento</th>
                        <th>Cantidad horas</th>
                        <th>Tipo de documento</th>
                        <th id="aprobar1">Aprobación</th>

                        <th id="reenvio1">Reenviar</th>
                        <th >Detalle</th>
                    </tr>
                </thead>

                <tbody>
                </tbody>

                <tfoot class="estilo-thead">
                    <tr>
                        <th>Documento</th>
                        <th>Cantidad horas</th>
                        <th>Tipo de documento</th>
                        <th  id="aprobar2">Aprobación</th>

                        <th id="reenvio2" >Reenviar</th>
                        <th>Detalle</th>
                    </tr>
                </tfoot>

            </table>
            <!--Fin Tabla-->



        </div>
        <!--Container-->


            <!--Popup Reenvio-->
     <div id="cambio_contrasenna" class="modal fade" role="dialog">
      <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content" style="background-color: #EBEBEB">

          <div class="modal-header popup-estilo-head">
            <button type="button" class="close" data-dismiss="modal">&times;</button>
          </div>

          <div class="modal-body popup-estilo">

              <p>Reenvío de reporte</p>


                  <div class="col-md-12 mb-12">
                        <label for="pk_reporte">ID Reporte</label>
                        <input readonly type="text" class="form-control" id="pk_reporte">
                    </div>
              <br />
                        <div class="col-md-12 mb-12">
                              <label>Contáctos</label>
                       <%--<%--     <label for="address">Añadir Correo</label>
                            <%--<input type="text" class="form-control" id="encargado" name="encargado" placeholder="Encargado" required>--%>
                           <select <%--onchange="actualizarRespuesta()" onblur="Validar_Campo()"--%> onchange="devuelve_correo()" id="correo" class="js-example-responsive"  lang="es" style="width: 100%;" name="state">
                            <option selected value="nulo" disabled></option>

                         
                        </select>
   
                    </div>
                    <br>
                    <div class="col-md-12 mb-12">
                        <label for="email">Correos</label>
                        <input type="email" class="form-control" id="email" name="email" placeholder="Correo Electrónico">
                    </div>

              
                                
              <br /><br />
              
              <div style="text-align: center">
              <button type="button" onclick="reenvio_reporte()" id="reenvio"  class="popup-btn">Reenviar</button>

              </div>

          </div>
        </div>
      </div>
    </div>
    <!--Fin Popup -->


    </div>
    <!--Container-->


    <script>
      


    </script>


</asp:Content>

