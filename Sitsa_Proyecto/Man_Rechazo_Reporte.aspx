<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Maestra.Master" AutoEventWireup="true" CodeBehind="Man_Rechazo_Reporte.aspx.cs" Inherits="Sitsa_Proyecto.Man_Rechazo_Reporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="styles" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-mant">


        <div style="margin-right: auto;">
            <!--Cabecera-->
            <h3 class="text-left">
                <i class="fas fa-user-times color-icono" aria-hidden="true"></i>&nbsp; Reportes Rechazados
            </h3>
            <p class="text-justify txt5">
                    Mantenimiento para el manejo y control de los reportes rechazados.
      </p>
        </div>
        <!--Fin Cabecera-->

        <br>

        <!-- Contenido -->
        <div class="container">

            <table id="tabla-mant" class="table table-striped table-bordered" style="width: 100%;">
                <!--Tabla-->

                <thead class="estilo-thead">
                    <tr>
                        <th>Número de Reporte</th>
                        <th>Motivo de Rechazo</th>
                    </tr>
                </thead>

                <tbody>

                       <%

                 Biblioteca_Clases.DAO.Rechazo_ReporteDAO dao = new Biblioteca_Clases.DAO.Rechazo_ReporteDAO();

                 List<Biblioteca_Clases.Models.Rechazo_Reporte> list = dao.listaReportesRechazados();

                 int autoincrement = 0;

                 foreach (var dato in list)
                 {
                     autoincrement = autoincrement + 1;

                 %>

                    <tr class="txt2">
                          <td><%=dato.FK_ID_REPORTE%></td>
                          <td><%=dato.MOTIVO%></td>
                    </tr>

                      <%}%>

                </tbody>

                <tfoot class="estilo-thead">
                    <tr>
                        <th>Número de Reporte</th>
                        <th>Motivo de Rechazo</th>
                    </tr>
                </tfoot>

            </table>
            <!--Fin Tabla-->

    </div>
    <!--Container-->

    </div>
    <!--Container mant-->

      <script type="text/javascript">

          $(document).ready(function () {
              $('#tabla-mant').DataTable();


          });

      </script>
</asp:Content>
