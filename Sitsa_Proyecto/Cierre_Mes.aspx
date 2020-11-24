<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Maestra.Master" AutoEventWireup="true" CodeBehind="Cierre_Mes.aspx.cs" Inherits="WebApplication2.Cierre_Mes" %>

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

                <div class="col-md-2.7 mb-3">
                    <label for="firstName">Fecha inicial</label>

                    <div class="input-group">
                        <input type="date" class="form-control" id="horas_convertidas" name="horas_convertidas">
                    </div>

                </div>

                <div class="col-md-3.3 mb-3">
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
                        <th id="estado2">Aprobar</th>

                        <th>Reenviar</th>
                        <th>Detalle</th>
                    </tr>
                </thead>

                <tbody>
                </tbody>

                <tfoot class="estilo-thead">
                    <tr>
                        <th>Documento</th>
                        <th>Cantidad horas</th>
                        <th>Tipo de documento</th>
                        <th id="estado">Aprobar</th>

                        <th>Reenviar</th>
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
        let Tipo = "General";

        

        $(document).ready(function () {

            $('.js-example-responsive').select2();

            $.ajax({
                type: "post",
                url: "/Cierre_Mes/Generales",

                success: function (result) {
                    var json_obj6 = $.parseJSON(result);
                    var cantidadDeClaves6 = Object.keys(json_obj6).length;

                    $("#tabla-mant > tbody").empty();

                    for (var i = 0; i < cantidadDeClaves6; i++) {

                        servicios2.push($('#tabla-mant').val());

                        var htmlTags6 = `
                        <tr id=${i} class="txt2">
                        <td>${json_obj6[i].PK_ID_REPORTE}</td>
                        <td>${json_obj6[i].CANTIDAD_HORAS}</td>
                        <td>${json_obj6[i].TIPO_DOCUMENTO}</td>
                        <td style="text-align: center;"><a onclick="Aceptar(${json_obj6[i].PK_ID_REPORTE},${i})"><i class="fa fa-check-square color-icono" aria-hidden="true"> </td>
                        <td style="text-align: center;"><a data-toggle="modal" data-target="#cambio_contrasenna"  onclick="Reenviar(${json_obj6[i].PK_ID_REPORTE})"><i class="fa fa-file-import color-icono" aria-hidden="true"> </td>
                        <td style="text-align: center;"><a onclick="detalla(${json_obj6[i].PK_ID_REPORTE});" data-toggle="modal" data-target="#modificar_contrato" href="#"><i class="fa fa-edit color-icono" aria-hidden="true">    </td>
                        </tr>`;

                        $('#tabla-mant tbody').append(htmlTags6);
                    }



                }
            })

        });



        var servicios = [];
        var servicios2 = [];
        var Array_Correos = []; 
       
        function Buscar() {

            let Reporte = $("#reporte").val();
            let cliente = $("#cliente").val();
            let horas_convertidas = $("#horas_convertidas").val();
            let horas_convertidas2 = $("#horas_convertidas2").val();

            if (Tipo == "General") { 
            $.ajax({
                type: "post",
                url: "/Cierre_Mes/Buscar",
                data: { Reporte: Reporte, cliente: cliente, horas_convertidas: horas_convertidas, horas_convertidas2: horas_convertidas2},
                success: function (result) {
                    var json_obj6 = $.parseJSON(result);
                    var cantidadDeClaves6 = Object.keys(json_obj6).length;

                    $("#tabla-mant > tbody").empty();

                    for (var i = 0; i < cantidadDeClaves6; i++) {

                        servicios2.push($('#tabla-mant').val());

                        var htmlTags6 = `
                        <tr id=${i} class="txt2">
                        <td>${json_obj6[i].PK_ID_REPORTE}</td>
                        <td>${json_obj6[i].CANTIDAD_HORAS}</td>
                        <td>${json_obj6[i].TIPO_DOCUMENTO}</td>
                        <td style="text-align: center;"><a onclick="Rechazar(${json_obj6[i].PK_ID_REPORTE},${i})"><i class="fa fa-check-square color-icono" aria-hidden="true"> </td>
                        <td style="text-align: center;"><a data-toggle="modal" data-target="#cambio_contrasenna" onclick="Reenviar(${json_obj6[i].PK_ID_REPORTE})"><i class="fa fa-file-import color-icono" aria-hidden="true"> </td>
                        <td style="text-align: center;"><a  onclick="detalla(${json_obj6[i].PK_ID_REPORTE});" data-toggle="modal" data-target="#modificar_contrato" href="#"><i class="fa fa-edit color-icono" aria-hidden="true">    </td>
                        </tr>`;

                        $('#tabla-mant tbody').append(htmlTags6);
                    }



                }
            })
            }

            if (Tipo == "Facturados") {
                $.ajax({
                    type: "post",
                    url: "/Cierre_Mes/Buscar_Facturados",
                    data: { Reporte: Reporte, cliente: cliente, horas_convertidas: horas_convertidas, horas_convertidas2: horas_convertidas2 },
                    success: function (result) {
                        var json_obj6 = $.parseJSON(result);
                        var cantidadDeClaves6 = Object.keys(json_obj6).length;

                        $("#tabla-mant > tbody").empty();

                        for (var i = 0; i < cantidadDeClaves6; i++) {

                            servicios2.push($('#tabla-mant').val());

                            var htmlTags6 = `
                        <tr id=${i} class="txt2">
                        <td>${json_obj6[i].PK_ID_REPORTE}</td>
                        <td>${json_obj6[i].CANTIDAD_HORAS}</td>
                        <td>${json_obj6[i].TIPO_DOCUMENTO}</td>
                        <td style="text-align: center;"><a onclick="Rechazar(${json_obj6[i].PK_ID_REPORTE},${i})"><i class="fa fa-check-square color-icono" aria-hidden="true"> </td>
                        <td style="text-align: center;"><a data-toggle="modal" data-target="#cambio_contrasenna" onclick="Reenviar(${json_obj6[i].PK_ID_REPORTE})"><i class="fa fa-file-import color-icono" aria-hidden="true"> </td>
                        <td style="text-align: center;"><a onclick="detalla(${json_obj6[i].PK_ID_REPORTE});" data-toggle="modal" data-target="#modificar_contrato" href="#"><i class="fa fa-edit color-icono" aria-hidden="true">    </td>
                        </tr>`;

                            $('#tabla-mant tbody').append(htmlTags6);
                        }



                    }
                })}

        }


        function Aceptar(dato, dato2) {

            $.ajax({
                type: "post",
                url: "/Cierre_Mes/AceptarReporte",
                data: { dato: dato },
                success: function (result) {

                    $("#" + dato2).remove();
                    alert("exito");

                }
            })


        }
        function Rechazar(dato, dato2) {

            $.ajax({
                type: "post",
                url: "/Cierre_Mes/RechazarReporte",
                data: { dato: dato },
                success: function (result) {

                    $("#" + dato2).remove();
                    alert("eliminado");

                }
            })


        }



        function Reenviar(dato) {

            $("#pk_reporte").val(dato);
            $("#correo").empty();
            $("#email").val("");
            Array_Correos.length = 0;





            $.ajax({
                type: "post",
                url: "/Cierre_Mes/Reenviar_Correo",
                data: { dato: dato },
                success: function (result) {

                    var json_obj6 = $.parseJSON(result);
                    var cantidadDeClaves6 = Object.keys(json_obj6).length;

           


                    for (var i = 0; i < cantidadDeClaves6; i++) {

                        let x = document.getElementById("correo");
                        var option = document.createElement("option");
                        option.text = json_obj6[i].ENCARGADO;
                        option.value = json_obj6[i].CORREO;
                        x.add(option, x[0]);

                    }
                }
            })


        }



        function Facturados() {
            Tipo = "Facturados";

            $("#estado").text("Desaprobar");
            $("#estado2").text("Desaprobar");

            $.ajax({
                type: "post",
                url: "/Cierre_Mes/Facturados",

                success: function (result) {
                    var json_obj6 = $.parseJSON(result);
                    var cantidadDeClaves6 = Object.keys(json_obj6).length;

                    $("#tabla-mant > tbody").empty();

                    for (var i = 0; i < cantidadDeClaves6; i++) {

                        servicios2.push($('#tabla-mant').val());

                        var htmlTags6 = `
                        <tr id=${i} class="txt2">
                        <td>${json_obj6[i].PK_ID_REPORTE}</td>
                        <td>${json_obj6[i].CANTIDAD_HORAS}</td>
                        <td>${json_obj6[i].TIPO_DOCUMENTO}</td>
                        <td style="text-align: center;"><a onclick="Rechazar(${json_obj6[i].PK_ID_REPORTE},${i})"><i class="fa fa-check-square color-icono" aria-hidden="true"> </td>
                        <td style="text-align: center;"><a data-toggle="modal" data-target="#cambio_contrasenna"  onclick="Reenviar(${json_obj6[i].PK_ID_REPORTE})"><i class="fa fa-file-import color-icono" aria-hidden="true"> </td>
                        <td style="text-align: center;"><a onclick="detalla(${json_obj6[i].PK_ID_REPORTE});" data-toggle="modal" data-target="#modificar_contrato" href="#"><i class="fa fa-edit color-icono" aria-hidden="true">    </td>
                        </tr>`;

                        $('#tabla-mant tbody').append(htmlTags6);
                    }



                }
            })


        }








        function Generales() {
            Tipo = "General";
            $("#estado").text("Aprobar");
            $("#estado2").text("Aprobar");

            $.ajax({
                type: "post",
                url: "/Cierre_Mes/Generales",

                success: function (result) {
                    var json_obj6 = $.parseJSON(result);
                    var cantidadDeClaves6 = Object.keys(json_obj6).length;

                    $("#tabla-mant > tbody").empty();

                    for (var i = 0; i < cantidadDeClaves6; i++) {

                        servicios2.push($('#tabla-mant').val());

                        var htmlTags6 = `
                        <tr id=${i} class="txt2">
                        <td>${json_obj6[i].PK_ID_REPORTE}</td>
                        <td>${json_obj6[i].CANTIDAD_HORAS}</td>
                        <td>${json_obj6[i].TIPO_DOCUMENTO}</td>
                        <td style="text-align: center;"><a onclick="Aceptar(${json_obj6[i].PK_ID_REPORTE},${i})"><i class="fa fa-check-square color-icono" aria-hidden="true"> </td>
                        <td style="text-align: center;"><a data-toggle="modal" data-target="#cambio_contrasenna" onclick="Reenviar(${json_obj6[i].PK_ID_REPORTE})"><i class="fa fa-file-import color-icono" aria-hidden="true"> </td>
                        <td style="text-align: center;"><a onclick="detalla(${json_obj6[i].PK_ID_REPORTE});" data-toggle="modal" data-target="#modificar_contrato" href="#"><i class="fa fa-edit color-icono" aria-hidden="true">    </td>
                        </tr>`;

                        $('#tabla-mant tbody').append(htmlTags6);
                    }

                }
            })


        }

     

        function detalla(id) {
            location.href = "Reportes.aspx?id=" + id;
        }

        function devuelve_correo() {

            

            var contacto = document.getElementById("correo").value; //los correos

            for (let i = 0; i <= Array_Correos.length; i++) {
                if (Array_Correos[i] == contacto) {
                    swal({
                        title: "Error",
                        text: "El correo ya se encuentra agregado",
                        type: "error",
                        showConfirmButton: true
                    });
                    return;
                }

                
            }
            Array_Correos.push(contacto);

            
            
            let contactos_correos = $("#email").val() + contacto + ";"; 

            $("#email").val(contactos_correos);



        }

        function reenvio_reporte() {


            var correos = $("#email").val();

            var g_correos2 = [];

            g_correos2 = correos.split(";");

            var correo_final = g_correos2.toString();



           let ID_Reporte = $("#pk_reporte").val();

            $.ajax({
                type: "POST",
                url: "/Cierre_Mes/Cambiar_Estado_Reporte",
                data: JSON.stringify({
                    ID_Reporte: ID_Reporte,
                    correos: correo_final
                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {

                    swal({
                        title: "Reenvío de reporte",
                        text: "Reporte reenviado exitosamente",
                        type: "success",
                        showConfirmButton: true
                    });

                }
            })



        }


    </script>


</asp:Content>

