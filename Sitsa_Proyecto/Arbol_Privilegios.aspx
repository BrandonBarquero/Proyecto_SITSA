<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Maestra.Master" AutoEventWireup="true" CodeBehind="Arbol_Privilegios.aspx.cs" Inherits="Control_Visitas.Arbol_Provilegios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="styles" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     
 <div class="container-home">
      
  <div class="container pt-4 pb-4">
    <div class="row ml-1 mr-1 panel-theme">
      <div class="col-lg-12">

        <asp:UpdatePanel ID="UpdatePanel24" runat="server">
          <ContentTemplate>
            <div class=" row pt-4 pb-4" runat="server" id="mensajePermiso" visible="false">
              <div class="alert alert-danger col-lg-10 col-md-10 col-sm-10 col-xs-10 text-center offset-1 " role="alert">
                <i class="fa fa-info-circle"></i>&nbsp;
                  <asp:Label ID="lblMensajePermisos" runat="server"></asp:Label>
              </div>
            </div>
          </ContentTemplate>
        </asp:UpdatePanel>

           <div margin-right: auto;> <!--Cabecera-->
          <h3 class="text-left">
           <i class="fas fa-lock color-icono" aria-hidden="true"></i>&nbsp; Permisos
         </h3>
         <p class="text-justify txt5">
       Manejo y control de permisos para los distintos perfiles del Sistema de Control de Visitas.
             </p>
      </div><!--Fin Cabecera-->
        <asp:UpdatePanel ID="upNum4" runat="server">
          <ContentTemplate>
            <div class="row">
              <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6  pt-4 pb-3">
                <div class="form-group" style="margin-right: 2rem;">
                  <asp:Label ID="lblPerfil" CssClass="col-lg-3 col-md-6 col-sm-6 col-xs-6 lead text-right" runat="server" Text="Perfiles:"></asp:Label>
                  <div class="col-lg-7 col-md-6 col-sm-6 col-xs-6 pl-lg-0">
                    <div class="input-group">

                      <asp:DropDownList ID="ddlPerfiles" OnSelectedIndexChanged="ddlPerfiles_SelectedIndexChanged"
                        CssClass="chosen-select form-control mb-0" runat="server" AutoPostBack="true">
                      </asp:DropDownList>
                    </div>
                  </div>
                </div>
              </div>

            </div>

          </ContentTemplate>
        </asp:UpdatePanel>


        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
            <div class="table-responsive col-lg-6 col-md-6 col-sm-6 col-xs-6  pt-4 pb-4">
              <asp:TreeView ID="tvPermisos" runat="server" OnTreeNodeCheckChanged="tvPermisos_TreeNodeCheckChanged"
                Class="TreeView ">
              </asp:TreeView>
            </div>


            <div class="col-md-12 text-center pb-4 pt-4" style="padding-left: 5px;">
              <asp:Button ID="btnAceptarPermisos" CssClass="popup-btn" runat="server" Text="Aceptar" OnClick="btnAceptarPermisos_Click" />
              <asp:Button ID="btnLimpiarPermisos" CssClass="popup-btn" runat="server" Text="Limpiar" OnClick="btnLimpiarPermisos_Click" />

              <div style="display: none">
                <asp:Button ID="btnPostBack" runat="server" Text="Button" />
              </div>
            </div>

          </ContentTemplate>
        </asp:UpdatePanel>


      </div>
    </div>
  </div>

     </div> <!--Fin contenedor Home-->

  <!--MODAL EXITO-->
  <div class="modal fade " id="modalInfoExitosa" style="display: none;" role="dialog" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header ModalNormal">
          <div class="hgroup title pull-left">
            <h3>11111</h3>
          </div>
          <input type="button" class="close pull-right CerrarModal" value="&times;" data-dismiss="modal" />
          <%--<a href="#" data-dismiss="modal" style="text-decoration: none;" class="close pull-right" onclick="cerrarModalError();">&times;</a>--%>
        </div>
        <div class="modal-body">
          <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
              <div class="text-center pb-4 ">
                <asp:Label ID="lblMensajeExito" CssClass="lead" runat="server" Text="Se ha actualizado correctamente."></asp:Label>
              </div>
            </ContentTemplate>
          </asp:UpdatePanel>
        </div>
        <div class="modal-footer">
          <div class="buttons">
            <div class="pull-right">
              <input type="button" class="btn btn-primary btn-sm" value="Aceptar" data-dismiss="modal" />
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

  <!--MODAL ERROR-->
  <div class="modal fade" id="modalErroInformacion" role="dialog" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
      <!-- Modal content-->
      <div class="modal-content">
        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
          <ContentTemplate>
            <div class="modal-header ModalError" runat="server" id="modalError">
              <div class="hgroup title pull-left">
                <h3>1111</h3>
              </div>
              <input type="button" class="close pull-right CerrarModal" value="&times;" data-dismiss="modal" />
              <%--<a href="#" data-dismiss="modal" style="text-decoration: none;" class="close pull-right" onclick="cerrarModalError();">&times;</a>--%>
            </div>
          </ContentTemplate>
        </asp:UpdatePanel>

        <div class="modal-body modal-body-error ">
          <div class="row">
            <asp:UpdatePanel ID="upNum5" runat="server">
              <ContentTemplate>
                <asp:Label ID="lblMensajeD" runat="server" Text="" CssClass="lead"></asp:Label>
              </ContentTemplate>
            </asp:UpdatePanel>
          </div>
        </div>
        <div class="modal-footer">
          <div class="buttons">
            <div class="text-center">
              <input type="button" class="btn btn-secundary btn-sm" value="Cerrar" data-dismiss="modal" />
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
    


  <script>
      jQuery(document).ready(function () {
          chosenSelect();
          AsignarPaginacion();
          FuncionesGenerales();
          quitarEventoSobreTextoTreeViewNode();
      });
      //On UpdatePanel Refresh
      var prm = Sys.WebForms.PageRequestManager.getInstance();
      var interval;

      if (prm != null) {
          prm.add_beginRequest(function (sender, e) {
              var loading = $("#haceLoading").val();
              if (loading == "NO") {
                  $(".loading-panel").attr("style", "display:none");
              } else {
                  $(".loading-panel").attr("style", "display:block");
              }
              chosenSelect();
              AsignarPaginacion();
              FuncionesGenerales();
              quitarEventoSobreTextoTreeViewNode();
          });

          //AjaxFileUpload_change_text();
          prm.add_endRequest(function (sender, e) {
              chosenSelect();
              $(".loading-panel").attr("style", "display:none");
              $("#haceLoading").val("");
              AsignarPaginacion();
              FuncionesGenerales();
              quitarEventoSobreTextoTreeViewNode();
          });
      }

      function AlertaExito() {

          swal({
              title: "Hecho",
              text: "Se ha modificado correctamente",
              type: "success",
              showConfirmButton: false
          })

          setTimeout('location.reload()', 2000);
      }

      function AlertaFallo() {

          swal({
              title: "Error",
              text: "Se ha producido un problema",
              type: "error",
              showConfirmButton: false
          })

          setTimeout('location.reload()', 2000);
      }



      function chosenSelect() {
          $(".chosen-select").chosen();
          $('.chosen-select-deselect').chosen({ allow_single_deselect: true });
      }

      function ClearContent(sender) {
          $(sender._element).find('input').val('');
      }

      function UploadError(sender, args) {
          $(sender._element).find('input').val('');
      }

      function OnSuccess(response, userContext, methodName) {
          alert(response);
      }


      window.onerror = function (error) {
          if (error.includes("PageRequest")) {

              alert("Ha Ocurrido un error de Conexión, será redireccionado al Inicio... Error: " + error);
              window.location.replace("Inicio.aspx");
          }
      };


      /*FUNCIONAMIENTO PARA EL TREEVIEW */
      function postBackByObject() {
          $("#haceLoading").val("NO");
          $(".loading-panel").attr("style", "display:none");
          var o = window.event.srcElement; // obteniendo el elemento clickeado
          if (o.tagName == "INPUT" && o.type == "checkbox") // verificando si se trata del checkbox
          {
              __doPostBack('<%= tvPermisos.ClientID %>', ''); // haciendo un postback al treeview para que entre al evento tvPermisos_TreeNodeCheckChanged
          }

      }

      function quitarEventoSobreTextoTreeViewNode() {
          $("[id *= 'tvPermisos'] table a[id *= tvPermisost]").removeAttr("onclick");
          $("[id *= 'tvPermisos'] table a[id *= tvPermisost]").removeAttr("href");
          $("[id *= 'tvPermisos'] table a[id *= tvPermisost]").css("color", "#555555");
          $("[id *= 'tvPermisos'] table a[id *= tvPermisost]").css("text-decoration", "none");
          $("[id *= 'tvPermisos'] table a[id *= tvPermisost]").css("font-size", "1.2em");
      }

  </script>
</asp:Content>