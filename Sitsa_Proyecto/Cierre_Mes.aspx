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
        <div class="#">
            <h3 class="text-left">
                <i class="far fa-file color-icono"></i>&nbsp; Cierre de mes
            </h3>
            <p class="text-justify txt5">
                Lorem ipsum dolor sit amet, consectetur adipisicing elit. Suscipit nostrum rerum animi natus beatae ex. Culpa blanditiis tempore amet alias placeat, obcaecati quaerat ullam, sunt est, odio aut veniam ratione.
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
                        <input type="text" class="form-control" placeholder="Reporte" id="reporte" name="reporte">
                        <div class="input-group-append">
                            <button type="button" onclick="Flitrar_Reporte()" class="cliente-btn-search">Buscar</button>
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
                        <div class="input-group-append" > <button type="button" onclick="Flitrar_Fechas()" class="cliente-btn-search">Buscar</button></div>
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
                        <td style="text-align: center;"><a onclick="Reenviar(${json_obj6[i].PK_ID_REPORTE})"><i class="fa fa-file-import color-icono" aria-hidden="true"> </td>
                        <td style="text-align: center;"><a onclick="detalla(${json_obj6[i].PK_ID_REPORTE});" data-toggle="modal" data-target="#modificar_contrato" href="#"><i class="fa fa-edit color-icono" aria-hidden="true">    </td>
                        </tr>`;

                        $('#tabla-mant tbody').append(htmlTags6);
                    }



                }
            })

        });



        var servicios = [];
        var servicios2 = [];
        function Flitrar_Fechas() {

            let dato = $("#horas_convertidas").val();
            let dato1 = $("#horas_convertidas2").val();
            alert(dato);


            if (Tipo == "General") {
                $.ajax({
                    type: "post",
                    url: "/Cierre_Mes/Filtrar_Fechas",
                    data: { dato: dato, dato1: dato1 },
                    success: function (result) {
                        var json_obj6 = $.parseJSON(result);
                        var cantidadDeClaves6 = Object.keys(json_obj6).length;

                        $("#tabla-mant > tbody").empty();

                        for (var i = 0; i < cantidadDeClaves6; i++) {

                            servicios.push($('#tabla-mant').val());

                            var htmlTags6 = `
                        <tr id=${i} class="txt2">
                        <td>${json_obj6[i].PK_ID_REPORTE}</td>
                        <td>${json_obj6[i].CANTIDAD_HORAS}</td>
                        <td>${json_obj6[i].TIPO_DOCUMENTO}</td>
                        <td style="text-align: center;"><a onclick="Aceptar(${json_obj6[i].PK_ID_REPORTE},${i})"><i class="fa fa-check-square color-icono" aria-hidden="true"> </td>
                        <td style="text-align: center;"><a onclick="Reenviar(${json_obj6[i].PK_ID_REPORTE})"><i class="fa fa-file-import color-icono" aria-hidden="true"> </td>
                        <td style="text-align: center;"><a onclick="detalla(${json_obj6[i].PK_ID_REPORTE});" data-toggle="modal" data-target="#modificar_contrato" href="#"><i class="fa fa-edit color-icono" aria-hidden="true">    </td>
                        </tr>`;

                            $('#tabla-mant tbody').append(htmlTags6);
                        }



                    }
                })
            }
            if (Tipo == "Facturados") {

                $.ajax({
                    type: "post",
                    url: "/Cierre_Mes/Filtrar_Fechas_Facturado",
                    data: { dato: dato, dato1: dato1 },
                    success: function (result) {
                        var json_obj6 = $.parseJSON(result);
                        var cantidadDeClaves6 = Object.keys(json_obj6).length;

                        $("#tabla-mant > tbody").empty();

                        for (var i = 0; i < cantidadDeClaves6; i++) {

                            servicios.push($('#tabla-mant').val());

                            var htmlTags6 = `
                        <tr id=${i} class="txt2">
                        <td>${json_obj6[i].PK_ID_REPORTE}</td>
                        <td>${json_obj6[i].CANTIDAD_HORAS}</td>
                        <td>${json_obj6[i].TIPO_DOCUMENTO}</td>
                        <td style="text-align: center;"><a onclick="Rechazar(${json_obj6[i].PK_ID_REPORTE},${i})"><i class="fa fa-check-square color-icono" aria-hidden="true"> </td>
                        <td style="text-align: center;"><a onclick="Reenviar(${json_obj6[i].PK_ID_REPORTE})"><i class="fa fa-file-import color-icono" aria-hidden="true"> </td>
                        <td style="text-align: center;"><a onclick="detalla(${json_obj6[i].PK_ID_REPORTE});" data-toggle="modal" data-target="#modificar_contrato" href="#"><i class="fa fa-edit color-icono" aria-hidden="true">    </td>
                        </tr>`;

                            $('#tabla-mant tbody').append(htmlTags6);
                        }



                    }
                })



            }

        }
        function Flitrar_Reporte() {

            let dato = $("#reporte").val();

            if (Tipo == "General") {
                $.ajax({
                    type: "post",
                    url: "/Cierre_Mes/Filtrar_Reporte",
                    data: { dato: dato },
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
                        <td style="text-align: center;"><a onclick="Reenviar(${json_obj6[i].PK_ID_REPORTE})"><i class="fa fa-file-import color-icono" aria-hidden="true"> </td>
                        <td style="text-align: center;"><a onclick="detalla(${json_obj6[i].PK_ID_REPORTE});" data-toggle="modal" data-target="#modificar_contrato" href="#"><i class="fa fa-edit color-icono" aria-hidden="true">    </td>
                        </tr>`;

                            $('#tabla-mant tbody').append(htmlTags6);
                        }



                    }
                })
            }
            if (Tipo == "Facturados") {
                $.ajax({
                    type: "post",
                    url: "/Cierre_Mes/Filtrar_Reporte_Facturados",
                    data: { dato: dato },
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
                        <td style="text-align: center;"><a onclick="Reenviar(${json_obj6[i].PK_ID_REPORTE})"><i class="fa fa-file-import color-icono" aria-hidden="true"> </td>
                        <td style="text-align: center;"><a onclick="detalla(${json_obj6[i].PK_ID_REPORTE});" data-toggle="modal" data-target="#modificar_contrato" href="#"><i class="fa fa-edit color-icono" aria-hidden="true">    </td>
                        </tr>`;

                            $('#tabla-mant tbody').append(htmlTags6);
                        }



                    }
                })


            }


        }
        $(document).ready(function () {
            $('#cliente').change(function () {
                var dato = $('#cliente').val();
                alert(dato);
                if (Tipo == "General") {
                    $.ajax({
                        type: "post",
                        url: "/Cierre_Mes/Filtrar_Cliente",
                        data: { dato: dato },
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
                        <td style="text-align: center;"><a onclick="Reenviar(${json_obj6[i].PK_ID_REPORTE})"><i class="fa fa-file-import color-icono" aria-hidden="true"> </td>
                        <td style="text-align: center;"><a onclick="detalla(${json_obj6[i].PK_ID_REPORTE});" data-toggle="modal" data-target="#modificar_contrato" href="#"><i class="fa fa-edit color-icono" aria-hidden="true">    </td>
                        </tr>`;

                                $('#tabla-mant tbody').append(htmlTags6);
                            }



                        }
                    })
                }
                if (Tipo == "Facturados") {
                    $.ajax({
                        type: "post",
                        url: "/Cierre_Mes/Filtrar_Clientefacturado",
                        data: { dato: dato },
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
                        <td style="text-align: center;"><a onclick="Reenviar(${json_obj6[i].PK_ID_REPORTE})"><i class="fa fa-file-import color-icono" aria-hidden="true"> </td>
                        <td style="text-align: center;"><a onclick="detalla(${json_obj6[i].PK_ID_REPORTE});" data-toggle="modal" data-target="#modificar_contrato" href="#"><i class="fa fa-edit color-icono" aria-hidden="true">    </td>
                        </tr>`;

                                $('#tabla-mant tbody').append(htmlTags6);
                            }



                        }
                    })

                }

            });
        });


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

            $.ajax({
                type: "post",
                url: "/Cierre_Mes/ReenviarCorreo",
                data: { dato: dato },
                success: function (result) {


                    alert("reenviado");

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
                        <td style="text-align: center;"><a onclick="Reenviar(${json_obj6[i].PK_ID_REPORTE})"><i class="fa fa-file-import color-icono" aria-hidden="true"> </td>
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
                        <td style="text-align: center;"><a onclick="Reenviar(${json_obj6[i].PK_ID_REPORTE})"><i class="fa fa-file-import color-icono" aria-hidden="true"> </td>
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
    </script>


</asp:Content>

