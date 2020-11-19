let g_id = null;
let g_edita = false;

$(document).ready(function () {
    let params = new URLSearchParams(location.search);
    g_id = params.get('id');
    if (g_id != null) {
        g_edita = true;
        edita_r(g_id);
        $("#div_btn_modificar").css("display", "block");
        $("#div_btn_guardar").css("display", "none");
    } else {
        return;
    }
});

$(document).ready(function () {
    debugger;
    $('.js-example-responsive').select2();
});

var g_contratos = [];
var g_contrato = new Object();
var g_contacto = new Object();
var g_proyecto = new Object();
var g_cliente = new Object();
var g_servicios = [];
var g_contactos = [];
var g_proyectos = [];
var g_correos = [];

var g_reporte = new Object();

var g_detalles_reporte = [];

function resetear_campos() {
    $("#total_horas").val(0);
    $("#total_horas").prop('disabled', false);
    //---------------------
    $("#horas_disponibles").val(0);
    $("#horas_disponibles").prop('disabled', false);
    //---------------------
    $("#cantidad_disponible").val(0);
    $("#cantidad_disponible").prop('disabled', false);
    //---------------------
    $("#horas_consumidas").val(0);
    $("#horas_consumidas").prop('disabled', false);
    //---------------------
    $("#div_monto_total").css("display", "none");
}

$(document).ready(function () {
    $("input[name=grupo_tipo]").change(function () {
        $("#div_tipo_r").css("display", "none");

        resetear_campos();

        g_proyectos = [];
        g_contratos = [];

        limpia_tabla_Servicios();
        $("#row_servicios").css("display", "none");

        var val_select = $('input:radio[name=grupo_tipo]:checked').val();

        var cliente = $('#cliente').val();
        var arrelgo_cliente = cliente.split("-");

        $("#total_horas").val(0);
        $("#horas_disponibles").val(0);
        $("#horas_consumidas").val(0);

        if (val_select == "contrato" && cliente != "") {
            $("#div_t_servicios").css("display", "block");
            buscar_contratos(arrelgo_cliente[0]);
        }
        else if (val_select == "proyecto" && cliente != "") {
            $("#div_t_servicios").css("display", "none");
            buscar_proyecto(arrelgo_cliente[0]);
        }
        else if ((val_select == "facturado" || val_select == "garantia") && ($("#div_tipo_r").css('display') == 'none')) {
            $("#div_tipo_r").css("display", "inline-block");
            var val_r_select = $('input:radio[name=grupo_r]:checked').val();

            if (val_r_select == "contrato" && (cliente != "")) {
                $("#div_t_servicios").css("display", "block");
                buscar_contratos(arrelgo_cliente[0]);
            } else if (val_r_select == "proyecto" && (cliente != "")) {
                $("#div_t_servicios").css("display", "none");
                buscar_proyecto(arrelgo_cliente[0]);
            }
        }
    });
})

$(document).ready(function () {
    $("input[name=grupo_r]").change(function () {
        var cliente = $('#cliente').val();
        resetear_campos();

        if (cliente != "") {
            g_proyectos = [];
            g_contratos = [];
            limpia_tabla_Servicios();
            $("#row_servicios").css("display", "none");

            var arrelgo_cliente = cliente.split("-");
            var val_select = $('input:radio[name=grupo_tipo]:checked').val();
            var val_r_select = $('input:radio[name=grupo_r]:checked').val();

            if (val_select == "facturado" || val_select == "garantia") {
                if (val_r_select == "contrato") {
                    $("#div_t_servicios").css("display", "block");
                    buscar_contratos(arrelgo_cliente[0]);
                } else if (val_r_select == "proyecto") {
                    $("#div_t_servicios").css("display", "none");
                    buscar_proyecto(arrelgo_cliente[0]);
                }
            }

            buscar_datos_contacto(arrelgo_cliente[0]);
        }

    });
})

$(document).ready(function () {
    $('#cliente').change(function () {

        g_contratos = [];
        g_proyectos = [];
        g_contactos = [];
        g_correos = [];
        $("#email").val("");
        limpia_tabla_Servicios();
        $("#row_servicios").css("display", "none");

        resetear_campos();

        var cliente = $('#cliente').val();
        if (cliente != "") {
            var arrelgo_cliente = cliente.split("-");
            var val_select = $('input:radio[name=grupo_tipo]:checked').val();
            var val_r_select = $('input:radio[name=grupo_r]:checked').val();

            if (val_select == "contrato") {
                buscar_contratos(arrelgo_cliente[0]);
            }
            else if (val_select == "proyecto") {
                buscar_proyecto(arrelgo_cliente[0]);
            } else if ((val_select == "facturado" || val_select == "garantia") && (cliente != "")) {
                if (val_r_select == "contrato") {
                    buscar_contratos(arrelgo_cliente[0]);
                } else if (val_r_select == "proyecto") {
                    buscar_proyecto(arrelgo_cliente[0]);
                }
            }
            var id_cliente = $('select[id=cliente]').val();
            $("#contacto_encargado").empty().append('<option value="nulo" disabled>Seleccione una opci\xf3n...</option>');
            $("#correo_encargado").empty().append('<option value="nulo" disabled>Seleccione una opci\xf3n...</option>');
            buscar_datos_contacto(id_cliente);
        }
    });
});

function buscar_datos_contacto(id) {
    $.ajax({
        type: "POST",
        url: "/Reporte/buscar_datos_contacto",
        data: JSON.stringify({
            id: id,
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: function () {
        },
        success: function (response) { //una vez que el archivo recibe el request lo procesa y lo devuelve
            response.forEach(pinta_contactos);
            var val_select = $('select[id=contacto_encargado]').val();
            $("#email").val(g_contactos[0].CORREO + ";");
            g_correos.push(g_contactos[0].CORREO);
            for (let i = 0; i < g_contactos.length; i++) {
                if (g_contactos[i].ID_CONTACTO == val_select) {
                    g_contacto = g_contactos[i];
                    return;
                }
            }


            //$("#encargado").val(response.ENCARGADO);
            //$("#email").val(response.CORREO);
            //g_contacto = response;
        },
        failure: function (response) {
            alert("failure");
            alert(response.responseText);
        },
        error: function (response) {
            alert("Error");
            alert(response.responseText);
        }
    });
}

function buscar_contratos(id) {

    var select = $('input:radio[name=grupo_tipo]:checked').val();
    vaciar_options();
    g_contratos = [];

    if (select == "contrato" || select == "facturado") {
        $.ajax({
            type: "POST",
            url: "/Reporte/listar_contrato_cliente",
            data: JSON.stringify({
                id: id,
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            beforeSend: function () {
            },
            success: function (response) { //una vez que el archivo recibe el request lo procesa y lo devuelve
                response.forEach(pinta_contrato);
            },
            failure: function (response) {
                alert("failure");
                alert(response.responseText);
            },
            error: function (response) {
                alert("Error");
                alert(response.responseText);
            }
        });
    } else if (select == "garantia") {
        $.ajax({
            type: "POST",
            url: "/Reporte/listar_contrato_cliente_garantia",
            data: JSON.stringify({
                id: id,
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            beforeSend: function () {
            },
            success: function (response) { //una vez que el archivo recibe el request lo procesa y lo devuelve
                response.forEach(pinta_contrato);
            },
            failure: function (response) {
                alert("failure");
                alert(response.responseText);
            },
            error: function (response) {
                alert("Error");
                alert(response.responseText);
            }
        });
    }
}

function buscar_proyecto(id) {

    var select = $('input:radio[name=grupo_tipo]:checked').val();
    vaciar_options();
    g_proyectos = [];

    if (select == "proyecto" || select == "facturado") {
        $.ajax({
            type: "POST",
            url: "/Reporte/listar_proyecto_cliente",
            data: JSON.stringify({
                id: id,
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            beforeSend: function () {
            },
            success: function (response) { //una vez que el archivo recibe el request lo procesa y lo devuelve
                response.forEach(pinta_proyecto);
            },
            failure: function (response) {
                alert("failure");
                alert(response.responseText);
            },
            error: function (response) {
                alert("Error");
                alert(response.responseText);
            }
        });
    } else {
        $.ajax({
            type: "POST",
            url: "/Reporte/listar_proyecto_cliente_garantia",
            data: JSON.stringify({
                id: id,
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            beforeSend: function () {
            },
            success: function (response) { //una vez que el archivo recibe el request lo procesa y lo devuelve
                response.forEach(pinta_proyecto);
            },
            failure: function (response) {
                alert("failure");
                alert(response.responseText);
            },
            error: function (response) {
                alert("Error");
                alert(response.responseText);
            }
        });
    }
}

function pinta_contrato(data) {
    g_contratos.push(data);
    $('#tipo').prepend("<option value='" + data.ID_CONTRATO + "' >" + data.NOMBRE_CONTRATO + "</option>");
}

function pinta_proyecto(data) {
    g_proyectos.push(data);
    $('#tipo').prepend("<option value='" + data.ID_PROYECTO + "' >" + data.NOMBRE + "</option>");
}

function vaciar_options() {
    var option = $('<option></option>').attr("value", "option value").text("Seleccione");
    $("#tipo").empty().append(option);

    //$('#tipo option:gt(0)').remove();
    //$('#tipo').prepend("<option value='' disabled>Seleccione</option>");
}

$(document).ready(function () {
    $('#tipo').change(function () {
        datos_tipo();
    });
});

function datos_tipo() {

    $('#div_btn_agregar').css('display', 'block');

    limpia_tabla_Servicios();
    $("#row_servicios").css("display", "none");

    var cliente = $('#cliente').val();
    var arrelgo_cliente = cliente.split("-");
    var val_select = $('input:radio[name=grupo_tipo]:checked').val();
    var val_Select_elemento = $("#tipo").val();

    g_contrato = new Object();
    g_proyecto = new Object();

    if (val_select == "contrato" && cliente != "") {
        for (let i = 0; i < g_contratos.length; i++) {
            if (g_contratos[i].ID_CONTRATO == val_Select_elemento) {
                g_contrato = g_contratos[i];
                prepara_campos(g_contrato);
                busca_servicios_contrato(g_contrato.ID_CONTRATO);
                return;
            }
        }
    }
    else if (val_select == "proyecto" && cliente != "") {
        for (let i = 0; i < g_proyectos.length; i++) {
            if (g_proyectos[i].ID_PROYECTO == val_Select_elemento) {
                g_proyecto = g_proyectos[i];
                prepara_campos_proyecto();
                return;
            }
        }
    }
    else if (val_select == "facturado" && cliente != "") {
        var val_r_select = $('input:radio[name=grupo_r]:checked').val();
        if (val_r_select == "contrato") {
            for (let i = 0; i < g_contratos.length; i++) {
                if (g_contratos[i].ID_CONTRATO == val_Select_elemento) {
                    g_contrato = g_contratos[i];
                    prepara_campos(g_contrato);
                    busca_servicios_contrato(g_contrato.ID_CONTRATO);
                    return;
                }
            }
        } else if (val_r_select == "proyecto") {
            for (let i = 0; i < g_proyectos.length; i++) {
                if (g_proyectos[i].ID_PROYECTO == val_Select_elemento) {
                    g_proyecto = g_proyectos[i];
                    prepara_campos_proyecto(g_proyecto);
                    return;
                }
            }
        }
    }
    else if (val_select == "garantia" && cliente != "") {
        var val_r_select = $('input:radio[name=grupo_r]:checked').val();
        if (val_r_select == "contrato") {
            for (let i = 0; i < g_contratos.length; i++) {
                if (g_contratos[i].ID_CONTRATO == val_Select_elemento) {
                    g_contrato = g_contratos[i];
                    prepara_campos(g_contrato);
                    busca_servicios_contrato(g_contrato.ID_CONTRATO);
                    return;
                }
            }
        }
        else if (val_r_select == "proyecto") {
            for (let i = 0; i < g_proyectos.length; i++) {
                if (g_proyectos[i].ID_PROYECTO == val_Select_elemento) {
                    g_proyecto = g_proyectos[i];
                    prepara_campos_proyecto(g_proyecto);
                    return;
                }
            }
        }
    }
}

function prepara_campos(data) {
    var select = $('input:radio[name=grupo_tipo]:checked').val();
    if (select != "garantia") {
        if (data.HORAS != -1) {
            $("#total_horas").val(data.HORAS);
            $("#horas_disponibles").val(data.HORAS_POR_CONSUMIR);
            $("#cantidad_disponible").val(data.HORAS_POR_CONSUMIR);
            $("#horas_consumidas").val(0);

            $('#label_total').text("Total de Horas");
            $('#label_consumido').text("Horas Consumidas");
            $('#label_disponible').text("Horas Disponibles");

            $("#div_monto_total").css("display", "block");

        }
        if (data.MONTO != -1) {
            $("#div_monto_total").css("display", "none");

            $("#total_horas").val(data.MONTO);
            $("#horas_disponibles").val(data.MONTO);
            $("#horas_consumidas").val(0);

            $('#label_total').text("Monto total");
            $('#label_consumido').text("Monto consumido");
            $('#label_disponible').text("Monto disponible");
        }
        if (data.RANGO != -1) {

        }
    }
    else if (select == "garantia") {
        $("#total_horas").val(0);
        $("#total_horas").prop('disabled', true);
        //---------------------
        $("#horas_disponibles").val(0);
        $("#horas_disponibles").prop('disabled', true);
        //---------------------
        $("#cantidad_disponible").val(0);
        $("#cantidad_disponible").prop('disabled', true);
        //---------------------
        $("#horas_consumidas").val(0);
        $("#horas_consumidas").prop('disabled', true);
        //---------------------
        $("#div_monto_total").css("display", "none");
    }

}

function prepara_campos_proyecto() {
    var select = $('input:radio[name=grupo_tipo]:checked').val();

    if (select != "garantia") {
        $("#div_monto_total").css("display", "none");
        $("#observacion_reporte").val(g_proyecto.DESCRIPCION);

        $('#label_total').text("Monto total");
        $('#label_consumido').text("Monto consumido");
        $('#label_disponible').text("Monto disponible");

        $("#total_horas").val(g_proyecto.PRECIO);
        $("#horas_disponibles").val(g_proyecto.PRECIO);
        $("#horas_consumidas").val(0);
    } else if (select == "garantia") {
        $("#total_horas").val(0);
        $("#total_horas").prop('disabled', true);
        //---------------------
        $("#horas_disponibles").val(0);
        $("#horas_disponibles").prop('disabled', true);
        //---------------------
        $("#cantidad_disponible").val(0);
        $("#cantidad_disponible").prop('disabled', true);
        //---------------------
        $("#horas_consumidas").val(0);
        $("#horas_consumidas").prop('disabled', true);
        //---------------------
        $("#div_monto_total").css("display", "none");
    }
}

function busca_servicios_contrato(id) {
    limpia_tabla_Servicios();
    g_servicios = [];
    $("#row_servicios").css("display", "block");

    $.ajax({
        type: "POST",
        url: "/Contrato/listar_servicios_contrato",
        data: JSON.stringify({
            id: id,
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: function () {
        },
        success: function (response) { //una vez que el archivo recibe el request lo procesa y lo devuelve
            response.forEach(pinta_servicios);

            if (g_id != null && g_edita == true) {

                $.ajax({
                    type: "POST",
                    url: "/Reporte/devuelve_servicios",
                    data: {},
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    beforeSend: function () {
                    },
                    success: function (response) { //una vez que el archivo recibe el request lo procesa y lo devuelve
                        response.forEach(busca_nuevos_servicios);

                        g_servicios.forEach(quita_servicios);

                        g_edita = false;
                        let c = false;
                        let l_id = 0;
                        if (g_reporte.ID_CONTRATO != null) {
                            c = true;
                        }

                        if (c == true) {

                            g_detalles_reporte.sort(function (a, b) {
                                if (a.ID_SERVICIO > b.ID_SERVICIO) {
                                    return 1;
                                }
                                if (a.ID_SERVICIO < b.ID_SERVICIO) {
                                    return -1;
                                }
                                // a must be equal to b
                                return 0;
                            });

                            g_servicios.sort(function (a, b) {
                                if (a.ID_SERVICIO > b.ID_SERVICIO) {
                                    return 1;
                                }
                                if (a.ID_SERVICIO < b.ID_SERVICIO) {
                                    return -1;
                                }
                                // a must be equal to b
                                return 0;
                            });

                            g_contrato.HORAS_POR_CONSUMIR = g_contrato.HORAS;

                            for (let i = 0; i < g_detalles_reporte.length; i++) {
                                g_servicios[i].HORAS = g_detalles_reporte[i].HORAS;
                                g_servicios[i].MONTO = g_detalles_reporte[i].TARIFA;

                                //1$('input:text[id=' + g_detalles_reporte[i].ID_SERVICIO + ']').val(g_detalles_reporte[i].HORAS);
                                $("#m" + g_detalles_reporte[i].ID_SERVICIO).val(g_detalles_reporte[i].TARIFA);
                                $("#ob" + g_detalles_reporte[i].ID_SERVICIO).val(g_detalles_reporte[i].OBSERVACION);
                                //$("#ph" + g_detalles_reporte[i].ID_SERVICIO).val(g_detalles_reporte[i].TARIFA / g_detalles_reporte[i].HORAS);

                                //$("#horas_disponibles").val(g_contrato.HORAS);
                                if (g_detalles_reporte[i].HORAS === 0) {
                                    $("#ph" + g_detalles_reporte[i].ID_SERVICIO).val(0).trigger('change');
                                } else {
                                    $("#ph" + g_detalles_reporte[i].ID_SERVICIO).val(g_detalles_reporte[i].TARIFA / g_detalles_reporte[i].HORAS).trigger('change');
                                }

                                $('input:text[id=' + g_detalles_reporte[i].ID_SERVICIO + ']').val(g_detalles_reporte[i].HORAS).trigger('change');

                            }
                        }

                    },
                    failure: function (response) {
                        alert("failure");
                        alert(response.responseText);
                    },
                    error: function (response) {
                        alert("Error");
                        alert(response.responseText);
                    }
                });
            }
        },
        failure: function (response) {
            alert("failure");
            alert(response.responseText);
        },
        error: function (response) {
            alert("Error");
            alert(response.responseText);
        }
    });
}

function busca_nuevos_servicios(data) {
    var encuentra = g_detalles_reporte.filter(servicio => (servicio.ID_SERVICIO === data.ID_SERVICIO));
    if (encuentra.length > 0) {
        var encuentra_servicio = g_servicios.filter(servicio => (servicio.ID_SERVICIO === data.ID_SERVICIO));
        if (encuentra_servicio.length === 0) {
            pinta_servicios(data);
        }
    }
}

function quita_servicios(data) {
    var encuentra = g_detalles_reporte.filter(servicio => (servicio.ID_SERVICIO === data.ID_SERVICIO));
    if (encuentra.length === 0) {
        g_servicios = g_servicios.filter(function (servicio) {
            return servicio.ID_SERVICIO !== data.ID_SERVICIO;
        });
        elimina(data.ID_SERVICIO);
    }
}

function pinta_servicios(data) {

    let monto;
    let rango;

    if (g_contrato.MONTO > 0) {
        monto = g_contrato.MONTO;
    } else {
        monto = "";
        data.TARIFA = 0;
        data.MONTO = 0;
        data.HORAS = 0;
    }
    if (g_contrato.RANGO > 0) {
        rango = g_contrato.RANGO;
    } else {
        rango = "";
    }
    data.HORAS = 0;
    data.MONTO = 0;
    g_servicios.push(data);

    var select = $('input:radio[name=grupo_tipo]:checked').val();

    var htmlTags = '<tr id=' + data.ID_SERVICIO + ' class="txt2">' +
        '<td><input class="form-control" type="text" id="desc' + data.ID_SERVICIO + '" name="" value="' + data.DESCRIPCION + '" readonly></td>' +
        '<td><input class="form-control" type="text" id="ob' + data.ID_SERVICIO + '" name="" value=""></td>';
    if (select == "garantia") {
        htmlTags = htmlTags + ' <td><input class="form-control" type="text" id="m' + data.ID_SERVICIO + '" name="" value="0" readonly></td>' +
            '<td><input class="form-control" type="text" id="' + data.ID_SERVICIO + '" name="" value="0" readonly></td>' +
            '<td><input class="form-control" type="text" id="ph' + data.ID_SERVICIO + '" name="" value="0" readonly></td>' +
            '<td style="text-align: center;"><a onclick="elimina(' + data.ID_SERVICIO + ');"><i class="fas fa-trash color-icono" aria-hidden="true" readonly></td>' +
            '</tr>';
    }
    else {

        if (monto == "") {
            htmlTags = htmlTags + ' <td><input class="form-control" type="text" id="m' + data.ID_SERVICIO + '" name="" value="' + monto + '" readonly></td>' +
                '<td><input class="form-control" type="text" id="' + data.ID_SERVICIO + '" name="" value="0" onchange="actualiza(' + data.ID_SERVICIO + ');"></td>';
        } else {
            htmlTags = htmlTags + ' <td><input class="form-control" type="text" id="m' + data.ID_SERVICIO + '"  name="" value="0" onchange=actualiza_monto(' + data.ID_SERVICIO + ');></td>' +
                '<td><input class="form-control" type="text" id="' + data.ID_SERVICIO + '" name="" value="0" onchange="actualiza_hora_monto(' + data.ID_SERVICIO + ');"></td>';
        }
        //htmlTags = htmlTags + '<td><input class="form-control" type="text" id="' + data.ID_SERVICIO + '" name="" value="" onchange="actualiza(' + data.ID_SERVICIO + ');"></td>';
        if (monto == "") {
            htmlTags = htmlTags + '<td><input class="form-control" type="text" id="ph' + data.ID_SERVICIO + '" name="" value="0" onchange="precios_por_hora(' + data.ID_SERVICIO + ');"></td>';
        } else {
            htmlTags = htmlTags + '<td><input class="form-control" type="text" id="ph' + data.ID_SERVICIO + '" name="" value="0" onchange="precios(' + data.ID_SERVICIO + ');"></td>';
        }
        htmlTags = htmlTags + '<td style="text-align: center;"><a onclick="elimina(' + data.ID_SERVICIO + ');"><i class="fas fa-trash color-icono" aria-hidden="true"></td>' +
            '</tr>';
    }
    $('#t_servicios tbody').append(htmlTags);

}

function actualiza(id) {

    if ($('input:text[id=' + id + ']').val() >= 0) {
        if ($('input:text[id=' + id + ']').val() == "") {
            $('input:text[id=' + id + ']').val(0)
        }
        var resta;
        for (var i = 0; i < g_servicios.length; i++) {
            if (g_servicios[i].ID_SERVICIO == id) {
                var horas = $('input:text[id=' + id + ']').val();
                g_servicios[i].HORAS = (parseInt(horas));
                suma_total();
                //if (g_contrato.MONTO > 0) {
                precios_por_hora(id);
                //}
                return;
            }
        }

    }
}

function suma_total() {
    var suma = 0;
    for (var i = 0; i < g_servicios.length; i++) {
        suma += g_servicios[i].HORAS;
    }
    let disponible = parseInt(g_contrato.HORAS_POR_CONSUMIR);
    $("#horas_consumidas").val(suma);

    var horas_disponibles = (parseInt($("#total_horas").val()) - parseInt($("#horas_consumidas").val()));
    $("#horas_disponibles").val(disponible - suma);

}

function limpia_tabla_Servicios() {
    g_servicios = [];
    $('#t_servicios tbody').empty();
}

function elimina(id) {
    $("#" + id).remove();
    for (let i = 0; i < g_servicios.length; i++) {
        if (g_servicios[i].ID_SERVICIO == id) {
            if (i == 0) {
                g_servicios.shift();
            } else {
                g_servicios.splice(i, 1);
            }
        }
    }
    if (g_contrato.HORAS !== -1) {
        suma_total();
        suma_monto_por_hora();
    } else if (g_contrato.MONTO !== -1) {
        suma_total_monto();
    }

}

function precios(id) {

    if ($("#ph" + id).val() == "") {
        $("#ph" + id).val(0);
    }

    let horas = 0;
    let monto = 0;

    monto = $("#m" + id).val();
    costo_hora = $("#ph" + id).val();

    if (costo_hora == 0) {
        $('input:text[id=' + id + ']').val(0);
    } else if (costo_hora > 0) {
        horas = (monto / costo_hora);
        $("#" + String(id)).val(horas);
        $('input:text[id=' + id + ']').val(horas);
    }

}

function actualiza_monto(id) {
    if ($('input:text[id=m' + id + ']').val() >= 0) {
        if ($('input:text[id=m' + id + ']').val() == "") {
            $('input:text[id=m' + id + ']').val(0);
        }

        var resta;
        for (var i = 0; i < g_servicios.length; i++) {
            if (g_servicios[i].ID_SERVICIO == id) {
                var monto = $('input:text[id=m' + id + ']').val();
                g_servicios[i].MONTO = (parseInt(monto));
                suma_total_monto();

                var horas = $('input:text[id=' + id + ']').val();
                g_servicios[i].HORAS = (parseInt(horas));

                return;
            }
        }

    }
}

function suma_total_monto() {
    let suma = 0;
    for (let i = 0; i < g_servicios.length; i++) {
        suma += g_servicios[i].MONTO;
    }
    $("#horas_consumidas").val(suma);

    let horas_disponibles = (parseInt($("#total_horas").val()) - parseInt($("#horas_consumidas").val()));
    $("#horas_disponibles").val(horas_disponibles);
}

function actualiza_hora_monto(id) {

    if ($('input:text[id=' + id + ']').val() == "") {
        $('input:text[id=' + id + ']').val(0);
    }

    let monto_servicio = 0;
    let horas_servicio = 0;

    for (let i = 0; i < g_servicios.length; i++) {
        if (g_servicios[i].ID_SERVICIO == id) {
            g_servicios[i].HORAS = parseInt($('input:text[id=' + id + ']').val());
        }
    }

    monto_servicio = parseInt($("#m" + id).val());
    horas_servicio = parseInt($('input:text[id=' + id + ']').val());
    if (horas_servicio == 0) {
        $("#ph" + id).val(0);
    } else if (horas_servicio > 0) {
        $("#ph" + id).val(monto_servicio / horas_servicio);
    }

}

function precios_por_hora(id) {

    if ($('input:text[id=ph' + id + ']').val() == "") {
        $('input:text[id=ph' + id + ']').val(0);
    }

    let horas_servicio = 0;
    let monto = 0;

    //monto = $("#m" + id).val();
    costo_hora = parseInt($("#ph" + id).val());

    horas_servicio = parseInt($('input:text[id=' + id + ']').val());
    //horas = (monto / costo_hora);

    for (let i = 0; i < g_servicios.length; i++) {
        if (g_servicios[i].ID_SERVICIO == id) {
            g_servicios[i].TARIFA = costo_hora;
            g_servicios[i].MONTO = (costo_hora * horas_servicio);
            $("#m" + id).val(g_servicios[i].MONTO);
            suma_monto_por_hora();
        }
    }

    $("#" + String(id)).val(horas_servicio);
    $('input:text[id=' + id + ']').val(horas_servicio);
}

function suma_monto_por_hora() {
    let suma = 0;

    for (let i = 0; i < g_servicios.length; i++) {
        suma += g_servicios[i].TARIFA * g_servicios[i].HORAS;
    }
    $("#monto_final").val(suma);
}

//Funcion que guarda los datos generados en la tabla de reporte y detalle del reporte
function guardar(opc) {
    var Reporte = new Object();
    g_detalles_reporte = [];
    var val_select = $('input:radio[name=grupo_tipo]:checked').val();
    var cliente = $('#cliente').val();
    var horas_disponibles = $("#horas_disponibles").val();

    var val_r_select = $('input:radio[name=grupo_r]:checked').val();

    if (val_select == "contrato" || (val_r_select == "contrato" && (val_select == "facturado" || val_select == "garantia")) && cliente != "") {
        if (g_contrato != null) {
            if (g_contrato.HORAS != -1) {
                Reporte.CANTIDAD_HORAS = $("#horas_consumidas").val();
            } else {
                let h_total = 0;
                for (let i = 0; i < g_servicios.length; i++) {
                    h_total += g_servicios[i].HORAS;
                }
                Reporte.CANTIDAD_HORAS = h_total;
            }

            Reporte.OBSERVACION = $("#observacion_reporte").val();

            var arreglo_fecha = ($('#fecha').text()).split(": ");

            Reporte.FECHA = arreglo_fecha[1];
            Reporte.FK_ID_CONTACTO = g_contacto.ID_CONTACTO;
            Reporte.ID_CONTRATO = g_contrato.ID_CONTRATO;
            if (val_select == "contrato") {
                Reporte.TIPO_DOCUMENTO = "Reporte Contrato";
            } else if (val_select == "facturado") {
                Reporte.TIPO_DOCUMENTO = "Reporte Contrato Facturado";
            }
            else if (val_select == "garantia") {
                Reporte.TIPO_DOCUMENTO = "Reporte Contrato Garantía";
            }

            //**--------Detalle de reporte correspondiente a los servicios del contrato-----------**//

            for (let i = 0; i < g_servicios.length; i++) {
                var Detalle_Reporte = new Object();
                Detalle_Reporte.HORAS = $('input:text[id=' + g_servicios[i].ID_SERVICIO + ']').val();

                Detalle_Reporte.TARIFA = g_servicios[i].MONTO;

                var arreglo_id_reporte = ($('#n_reporte').text()).split(": ");
                Detalle_Reporte.FK_ID_REPORTE = arreglo_id_reporte[1];

                Detalle_Reporte.OBSERVACION = $("#ob" + g_servicios[i].ID_SERVICIO).val();

                Detalle_Reporte.ID_SERVICIO = g_servicios[i].ID_SERVICIO;

                g_detalles_reporte.push(Detalle_Reporte);
            }
            
            if (Reporte != null) {

                if (g_contrato.HORAS == "-1") {
                    horas_disponibles = "f"
                }
                var url = "";
                if (opc == 1) {
                    url = "/Reporte/agregar_reporte";
                } else if (opc == 2) {
                    url = "/Reporte/actualizar_reporte_contrato";
                    Reporte.PK_ID_REPORTE = g_id;
                }

                $.ajax({
                    type: "POST",
                    url: url,
                    data: JSON.stringify({
                        reporte: Reporte,
                        detalles_reporte: g_detalles_reporte,
                        horas_disponibles: horas_disponibles
                    }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        swal({
                            title: "Hecho",
                            text: "Se ha registrado el reporte correctamente",
                            type: "success",
                            showConfirmButton: false
                        })

                        setTimeout('location.reload()', 2000);

                        servicios = [];
                        if (opc == 2) {
                            location.href = "Cierre_Mes.aspx";
                        }
                    },
                    failure: function (response) {
                        alert(response.responseText);
                    },
                    error: function (response) {
                        alert(response.responseText);
                    }
                });
            }
        }
    }
    else if ((val_select == "proyecto" || (val_r_select == "proyecto" && (val_select == "facturado" || val_select == "garantia"))) && cliente != "") {
        if (g_proyecto != null) {
            Reporte.OBSERVACION = $("#observacion_reporte").val();
            var arreglo_fecha = ($('#fecha').text()).split(": ");

            Reporte.FECHA = arreglo_fecha[1];
            Reporte.FK_ID_CONTACTO = g_contacto.ID_CONTACTO;
            Reporte.ID_PROYECTO = g_proyecto.ID_PROYECTO;

            if (val_select == "proyecto") {
                Reporte.TIPO_DOCUMENTO = "Reporte Proyecto";
            } else if (val_select == "facturado") {
                Reporte.TIPO_DOCUMENTO = "Reporte Proyecto Facturado";
            } else if (val_select == "garantia") {
                Reporte.TIPO_DOCUMENTO = "Reporte Proyecto Garantía";
            }

            /**CREACION DETALLE REPORTE**/
            var Detalle_Reporte = new Object();
            Detalle_Reporte.TARIFA = parseFloat($("#horas_consumidas").val());

            var arreglo_id_reporte = ($('#n_reporte').text()).split(": ");
            Detalle_Reporte.FK_ID_REPORTE = arreglo_id_reporte[1];
            Detalle_Reporte.OBSERVACION = $("#observacion_reporte").val();

            var url = "";
            if (opc == 1) {
                url = "/Reporte/agregar_reporte_proyecto";
            } else if (opc == 2) {
                url = "/Reporte/actualizar_reporte_proyecto";
                Reporte.PK_ID_REPORTE = g_id;
            }

            /**PETICION AJAX**/
            $.ajax({
                type: "POST",
                url: url,
                data: JSON.stringify({
                    reporte: Reporte,
                    detalle_reporte: Detalle_Reporte
                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    swal({
                        title: "Hecho",
                        text: "Se ha registrado el reporte correctamente",
                        type: "success",
                        showConfirmButton: false
                    })

                    setTimeout('location.reload()', 2000);

                    servicios = [];

                    if (opc == 2) {
                        location.href = "Cierre_Mes.aspx";
                    }
                },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                }
            });

        }
    }
}

function monto_consumido() {
    var val_select = $('input:radio[name=grupo_tipo]:checked').val();
    var val_r_select = $('input:radio[name=grupo_r]:checked').val();

    if ((val_select == "proyecto") || ((val_select == "facturado" || val_select == "garantia") && val_r_select == "proyecto")) {
        let consumido = $("#horas_consumidas").val();
        let total = $("#total_horas").val();
        $("#horas_disponibles").val(total - consumido);
    }
}

function pinta_contactos(data) {
    data.USO = 0;
    g_contactos.push(data);
    var x = document.getElementById("contacto_encargado");
    var option = document.createElement("option");
    option.text = data.ENCARGADO;
    option.value = data.ID_CONTACTO;
    x.add(option, x[0]);

    var x = document.getElementById("correo_encargado");
    var option = document.createElement("option");
    option.text = data.ENCARGADO;
    option.value = data.ID_CONTACTO;
    x.add(option, x[0]);
}



$(document).ready(function () {
    $('#contacto_encargado').change(function () {
        var val_select = $('select[id=contacto_encargado]').val();
        for (let i = 0; i < g_contactos.length; i++) {
            if (g_contactos[i].ID_CONTACTO == val_select) {
                g_contacto = g_contactos[i];
                return;
            }
        }
    });
});

$(document).ready(function () {
    $('#correo_encargado').change(function () {
        var val_select = $('select[id=correo_encargado]').val();
        for (let i = 0; i < g_contactos.length; i++) {
            if (g_contactos[i].ID_CONTACTO == val_select) {
                var correo_t = $("#email").val();
                if (g_correos.includes(g_contactos[i].CORREO)) {
                    swal({
                        title: "Error",
                        text: "El correo ya se encuentra agregado",
                        type: "error",
                        showConfirmButton: true
                    });
                    return;
                } else {
                    $("#email").val(correo_t + g_contactos[i].CORREO + ";");
                    g_contacto = g_contactos[i];
                    g_correos.push(g_contactos[i].CORREO);
                    return;
                }
            }
        }
    });
});

$(document).ready(function () {
    $('#servicios_l').change(function () {
        var val_select = $('#servicios_l').val();
        if (val_select == "") {
            return;
        } else {

            var arreglo_servicio = val_select.split('-');

            for (let i = 0; i < g_servicios.length; i++) {
                if (g_servicios[i].ID_SERVICIO == arreglo_servicio[0]) {
                    swal({
                        title: "Error",
                        text: "El servicio ya se encuentra agregado",
                        type: "error",
                        showConfirmButton: true
                    });
                    $('#servicios_l').val("");
                    return;
                }
            }
            var g_servicio = new Object();
            g_servicio.ID_SERVICIO = arreglo_servicio[0];
            g_servicio.DESCRIPCION = arreglo_servicio[1];
            g_servicio.HORAS = 0;
            //g_servicios.push(g_servicio);
            pinta_servicios(g_servicio);

            $('#servicios_l').val("");
        }
    });
});

function edita_r(id) {

    $("#div_btn_agregar").css("display", "none");
    $("#div_btn_modificar").css("display", "block");
    document.getElementById("n_reporte").innerHTML = "Reporte: " + id;

    $.ajax({
        type: "POST",
        url: "/Reporte/devuelve_reporte",
        data: JSON.stringify({
            id: id,
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: function () {
        },
        success: function (response) { //una vez que el archivo recibe el request lo procesa y lo devuelve
            g_reporte = response;
            //-----------------------------//
            if (g_reporte.TIPO_DOCUMENTO == "Reporte Contrato") {
                $("#Contrato").attr('checked', true).trigger('click');
            } else if (g_reporte.TIPO_DOCUMENTO == "Reporte Proyecto") {
                $("#Proyecto").attr('checked', true).trigger('click');
            } else if (g_reporte.TIPO_DOCUMENTO == "Reporte Contrato Facturado") {
                $("#div_tipo_r").css("display", "block");
                $("#Facturado").attr('checked', true).trigger('click');
                $("#R_Contrato").attr('checked', true).trigger('click');
            } else if (g_reporte.TIPO_DOCUMENTO == "Reporte Proyecto Facturado") {                
                $("#div_tipo_r").css("display", "block");
                $("#Facturado").attr('checked', true).trigger('click');
                $("#R_Proyecto").attr('checked', true).trigger('click');
            } else if (g_reporte.TIPO_DOCUMENTO == "Reporte Contrato Garantía") {
                $("#div_tipo_r").css("display", "block");
                $("#Garantia").attr('checked', true).trigger('click');
                $("#R_Contrato").attr('checked', true).trigger('click');
            } else if (g_reporte.TIPO_DOCUMENTO == "Reporte Proyecto Garantía") {
                $("#div_tipo_r").css("display", "block");
                $("#Garantia").attr('checked', true).trigger('click');
                $("#R_Proyecto").attr('checked', true).trigger('click');
            }

            //------------------------------------//
            let opc = 2;
            let l_id = 0;
            if (response.ID_CONTRATO != 0) {
                devuelve_cliente_r(g_reporte.ID_CONTRATO, 1);
                l_id = g_reporte.ID_CONTRATO;
                opc = 1;
            } else if (response.ID_PROYECTO != 0) {
                devuelve_cliente_r(g_reporte.ID_PROYECTO, 2);
                l_id = g_reporte.ID_PROYECTO;
            }

            $.ajax({
                type: "POST",
                url: "Reporte/activa_contrato_proyecto",
                data: JSON.stringify({
                    id: l_id,
                    opc: opc,
                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                beforeSend: function () {
                },
                success: function (response) { //una vez que el archivo recibe el request lo procesa y lo devuelve
                    
                },
                failure: function (response) {
                    alert("failure");
                    alert(response.responseText);
                },
                error: function (response) {
                    alert("Error");
                    alert(response.responseText);
                }
            });

        },
        failure: function (response) {
            alert("failure");
            alert(response.responseText);
        },
        error: function (response) {
            alert("Error");
            alert(response.responseText);
        }
    });
}

function devuelve_cliente_r(id, opc) {
    $.ajax({
        type: "POST",
        url: "Reporte/devuelve_cliente",
        data: JSON.stringify({
            id: id,
            opc: opc,
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: function () {
        },
        success: function (response) { //una vez que el archivo recibe el request lo procesa y lo devuelve
            $("#cliente option[value='nulo'").attr("selected", false);
            $("#cliente option[value=" + response + "]").attr("selected", true);
            $('#cliente').val(response).trigger('change');

            $("#observacion_reporte").val(g_reporte.OBSERVACION);
            $("#horas_consumidas").val(g_reporte.CANTIDAD_HORAS);
            document.getElementById("fecha").innerHTML = "Fecha: " + g_reporte.FECHA_CREACION;
            //-----------------------------//
            let l_id = 0;
            if (g_reporte.ID_CONTRATO != 0) {
                l_id = g_reporte.ID_CONTRATO
            } else if (g_reporte.ID_PROYECTO != 0) {
                l_id = g_reporte.ID_PROYECTO
            }

            $("#tipo option[value='nulo'").attr("selected", false);
            $("#tipo option[value=" + l_id + "]").attr("selected", true);
            $('#tipo').val(l_id).trigger('change');

            buscar_detalle_reporte();
        },
        failure: function (response) {
            alert("failure");
            alert(response.responseText);
        },
        error: function (response) {
            alert("Error");
            alert(response.responseText);
        }
    });
}


function buscar_detalle_reporte() {
    let opc = 0;
    if (g_reporte.ID_CONTRATO != 0) {
        opc = 1
    } else if (g_reporte.ID_PROYECTO != 0) {
        opc = 2
    }
    if (g_reporte.PK_ID_REPORTE != null) {
        $.ajax({
            type: "POST",
            url: "Reporte/buscar_detalle_reporte",
            data: JSON.stringify({
                id: g_reporte.PK_ID_REPORTE,
                opc: opc,
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            beforeSend: function () {
            },
            success: function (response) { //una vez que el archivo recibe el request lo procesa y lo devuelve
                //response.forEach(pinta_servicios);
                g_detalles_reporte = response;

                let c = false;
                let l_id = 0;
                if (g_reporte.ID_CONTRATO != 0) {
                    l_id = g_reporte.ID_CONTRATO
                    c = true;
                } else if (g_reporte.ID_PROYECTO != 0) {
                    l_id = g_reporte.ID_PROYECTO;
                }

                $("#tipo option[value='nulo'").attr("selected", false);
                $("#tipo option[value=" + l_id + "]").attr("selected", true);
                $('#tipo').val(l_id).trigger('change');

                if (g_reporte.ID_PROYECTO != 0) {
                    if (g_reporte.TIPO_DOCUMENTO == "Reporte Proyecto" || g_reporte.TIPO_DOCUMENTO == "Reporte Proyecto Facturado") {
                        $("#horas_consumidas").val(g_detalles_reporte[0].TARIFA).trigger('change');
                    } else if (g_reporte.TIPO_DOCUMENTO == "Reporte Proyecto Garantía") {
                        $("#horas_consumidas").val(0).trigger('change');
                    }
                    
                }

            },
            failure: function (response) {
                alert("failure");
                alert(response.responseText);
            },
            error: function (response) {
                alert("Error");
                alert(response.responseText);
            }
        });
    }

}