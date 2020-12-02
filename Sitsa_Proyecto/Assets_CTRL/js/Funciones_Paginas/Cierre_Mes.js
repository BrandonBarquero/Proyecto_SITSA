let Tipo = "General";

let val = 0;
let val2 = 0;








$(document).ready(function () {


    $.ajax({
        type: "post",
        url: "/Cierre_Mes/Permisos",
        async: false,
        success: function (result) {

            val = result;

        }

    })


    $.ajax({
        type: "post",
        async: false,
        url: "/Cierre_Mes/Permisos_Reenvio",
        success: function (result) {

            val2 = result;

        }

    })


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



                let td_tabla;

                if (val == 1) {
                    td_tabla = `<td style="text-align: center;"><a onclick="Aceptar(${json_obj6[i].PK_ID_REPORTE},${i})"><i class="fa fa-check-square color-icono" aria-hidden="true"> </td>`;


                } if (val == 0) {
                    $("#aprobar2").hide();
                    $("#aprobar1").hide();
                    td_tabla = "";

                }

                let td_tabla2;

                if (val2 == 1) {
                    td_tabla2 = `<td style="text-align: center;"><a data-toggle="modal" data-target="#cambio_contrasenna"  onclick="Reenviar(${json_obj6[i].PK_ID_REPORTE})"><i class="fa fa-file-import color-icono" aria-hidden="true"> </td>
`;


                } if (val2 == 0) {
                    $("#reenvio2").hide();
                    $("#reenvio1").hide();
                    td_tabla2 = "";
                }

                var htmlTags6 = `
                        <tr id=${i} class="txt2">
                        <td>${json_obj6[i].PK_ID_REPORTE}</td>
                        <td>${json_obj6[i].OBSERVACION}</td>
                        <td>${json_obj6[i].TIPO_DOCUMENTO}</td>
                        ${td_tabla} 
                        ${td_tabla2} 
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
            data: { Reporte: Reporte, cliente: cliente, horas_convertidas: horas_convertidas, horas_convertidas2: horas_convertidas2 },
            success: function (result) {
                var json_obj6 = $.parseJSON(result);
                var cantidadDeClaves6 = Object.keys(json_obj6).length;

                $("#tabla-mant > tbody").empty();

                for (var i = 0; i < cantidadDeClaves6; i++) {

                    servicios2.push($('#tabla-mant').val());
                    let td_tabla;

                    if (val == 1) {
                        td_tabla = `<td style="text-align: center;"><a onclick="Aceptar(${json_obj6[i].PK_ID_REPORTE},${i})"><i class="fa fa-check-square color-icono" aria-hidden="true"> </td>`;


                    } if (val == 0) {
                        td_tabla = "";
                    }

                    let td_tabla2;

                    if (val2 == 1) {
                        td_tabla2 = `<td style="text-align: center;"><a data-toggle="modal" data-target="#cambio_contrasenna"  onclick="Reenviar(${json_obj6[i].PK_ID_REPORTE})"><i class="fa fa-file-import color-icono" aria-hidden="true"> </td>
`;


                    } if (val2 == 0) {
                        td_tabla2 = "";
                    }
                    var htmlTags6 = `
                        <tr id=${i} class="txt2">
                        <td>${json_obj6[i].PK_ID_REPORTE}</td>
                        <td>${json_obj6[i].OBSERVACION}</td>
                        <td>${json_obj6[i].TIPO_DOCUMENTO}</td>
                        ${td_tabla} 
                        ${td_tabla2} 
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
                    let td_tabla;

                    if (val == 1) {
                        td_tabla = `<td style="text-align: center;"><a onclick="Rechazar(${json_obj6[i].PK_ID_REPORTE},${i})"><i class="fas fa-times color-icono" aria-hidden="true"> </td>`;


                    } if (val == 0) {
                        td_tabla = "";
                    }

                    let td_tabla2;

                    if (val2 == 1) {
                        td_tabla2 = `<td style="text-align: center;"><a data-toggle="modal" data-target="#cambio_contrasenna"  onclick="Reenviar(${json_obj6[i].PK_ID_REPORTE})"><i class="fa fa-file-import color-icono" aria-hidden="true"> </td>
`;


                    } if (val2 == 0) {
                        td_tabla2 = "";
                    }
                    var htmlTags6 = `
                        <tr id=${i} class="txt2">
                        <td>${json_obj6[i].PK_ID_REPORTE}</td>
                        <td>${json_obj6[i].OBSERVACION}</td>
                        <td>${json_obj6[i].TIPO_DOCUMENTO}</td>
                        ${td_tabla} 
                        ${td_tabla2} 
                        <td style="text-align: center;"><a onclick="detalla(${json_obj6[i].PK_ID_REPORTE});" data-toggle="modal" data-target="#modificar_contrato" href="#"><i class="fa fa-edit color-icono" aria-hidden="true">    </td>
                        </tr>`;

                    $('#tabla-mant tbody').append(htmlTags6);
                }



            }
        })
    }

}


function Aceptar(dato, dato2) {

    $.ajax({
        type: "post",
        url: "/Cierre_Mes/AceptarReporte",
        data: { dato: dato },
        success: function (result) {

            $("#" + dato2).remove();
            swal({
                title: "Hecho",
                text: "Reporte aprobado exitosamente",
                type: "success",
                showConfirmButton: true
            });

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
            swal({
                title: "Rechazado",
                text: "Reporte rechazado exitosamente",
                type: "error",
                showConfirmButton: true
            });

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


            let x = document.getElementById("correo");

            var option2 = document.createElement("option");
            option2.text = "";
            option2.value = "";
            x.add(option2, x[0]);

            for (var i = 0; i < cantidadDeClaves6; i++) {

                var option = document.createElement("option");
                option.text = json_obj6[i].ENCARGADO;
                option.value = json_obj6[i].CORREO;
                x.add(option, x[0]);

                //$("#correo option[value='nulo']").attr("selected", true);
                //$('#correo').val('nulo').trigger('change');
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
                let td_tabla;

                if (val == 1) {
                    td_tabla = `<td style="text-align: center;"><a onclick="Rechazar(${json_obj6[i].PK_ID_REPORTE},${i})"><i class="fas fa-times color-icono" aria-hidden="true"> </td>`;


                } if (val == 0) {
                    td_tabla = "";
                }

                let td_tabla2;

                if (val2 == 1) {
                    td_tabla2 = `<td style="text-align: center;"><a data-toggle="modal" data-target="#cambio_contrasenna"  onclick="Reenviar(${json_obj6[i].PK_ID_REPORTE})"><i class="fa fa-file-import color-icono" aria-hidden="true"> </td>
`;


                } if (val2 == 0) {
                    td_tabla2 = "";
                }
                var htmlTags6 = `
                        <tr id=${i} class="txt2">
                        <td>${json_obj6[i].PK_ID_REPORTE}</td>
                        <td>${json_obj6[i].OBSERVACION}</td>
                        <td>${json_obj6[i].TIPO_DOCUMENTO}</td>
                         ${td_tabla} 
                        ${td_tabla2} 
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
                let td_tabla;

                if (val == 1) {
                    td_tabla = `<td style="text-align: center;"><a onclick="Aceptar(${json_obj6[i].PK_ID_REPORTE},${i})"><i class="fa fa-check-square color-icono" aria-hidden="true"> </td>`;


                } if (val == 0) {
                    td_tabla = "";
                }

                let td_tabla2;

                if (val2 == 1) {
                    td_tabla2 = `<td style="text-align: center;"><a data-toggle="modal" data-target="#cambio_contrasenna"  onclick="Reenviar(${json_obj6[i].PK_ID_REPORTE})"><i class="fa fa-file-import color-icono" aria-hidden="true"> </td>
`;


                } if (val2 == 0) {
                    td_tabla2 = "";
                }
                var htmlTags6 = `
                        <tr id=${i} class="txt2">
                        <td>${json_obj6[i].PK_ID_REPORTE}</td>
                        <td>${json_obj6[i].OBSERVACION}</td>
                        <td>${json_obj6[i].TIPO_DOCUMENTO}</td>
                        ${td_tabla} 
                        ${td_tabla2} 
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

    var ultimoCaracter = correos.charAt(correos.length - 1);

    if (ultimoCaracter != ";") {
        correos = correos + ";";
    }

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
                title: "Reenv\u00EDo de reporte",
                text: "Reporte reenviado exitosamente",
                type: "success",
                showConfirmButton: true
            });

        }
    })



}