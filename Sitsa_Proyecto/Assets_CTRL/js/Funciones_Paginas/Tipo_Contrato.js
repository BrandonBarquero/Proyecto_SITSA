$(document).ready(function () {
    $('#tabla-mant').DataTable();
});

function estado(dato_id) {

    var id_tipo_contrato = dato_id;

    $("#" + id_tipo_contrato).on('change', function () {
        if ($(this).is(':checked')) {
            $.ajax({
                type: "post",
                url: "/TipoContrato/actualizar_estado_Habilitar_Tipo_Contrato",
                data: {
                    id_tipo_contrato: id_tipo_contrato,
                },
                success: function (result) {
                    if (result == "fail") {

                    }
                    else {
                        swal({
                            title: "Hecho",
                            text: "Estado Habilitado",
                            type: "success",
                            showConfirmButton: true
                        })
                    }
                }
            })

        } else {
            $.ajax({
                type: "post",
                url: "/TipoContrato/actualizar_estado_deshabilitar_Tipo_Contrato",
                data: {
                    id_tipo_contrato: id_tipo_contrato,
                },
                success: function (result) {
                    if (result == "fail") {

                    }
                    else {
                        swal({
                            title: "Hecho",
                            text: "Estado Deshabilitado",
                            type: "error",
                            showConfirmButton: true
                        })
                    }
                }
            })

        }
    });
};

function edita(id, nombre, horas, rango_documentos, monto, aceptacion) {
    $("#d_tipo_contrato").val(id);
    $("#d_nombre_tipo_contrato").val(nombre);

    if (horas == "True") {
        $("#d_horas").prop('checked', true);
    }
    if (rango_documentos == "True") {
        $("#d_rango_documentos").prop('checked', true);
    }
    if (monto == "True") {
        $("#d_monto").prop('checked', true);
    }
    if (aceptacion == "True") {
        $("#d_aceptacion").prop('checked', true);
    }

}

function Agregar_Tipo_Contrato() {

    var tipo_contrato = new Object();
    tipo_contrato.nombre = $("#nombre_tipo_contrato").val();
    tipo_contrato.horas = $("#horas").is(":checked");
    tipo_contrato.rango_documentos = $("#rango_documentos").is(":checked");
    tipo_contrato.monto = $("#monto").is(":checked");
    tipo_contrato.aceptacion = $("#aceptacion").is(":checked");

    swal({
        title: "\u00BFAgregar Tipo de Contrato?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#34495E",
        confirmButtonText: "Si, agregar",
        cancelButtonText: "Cancelar",
        closeOnConfirm: false
    },
        function (isConfirm) {


            if (isConfirm) {

    if (tipo_contrato != null) {
        $.ajax({
            type: "POST",
            url: "/TipoContrato/agregar_tipo_contrato",
            data: JSON.stringify(tipo_contrato),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                swal({
                    title: "Hecho",
                    text: "Se ha agregado correctamente",
                    type: "success",
                    showConfirmButton: false
                })

                setTimeout('location.reload()', 2000);
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    }
            } else {


                swal({
                    title: "Error",
                    text: "Se ha producido un problema",
                    type: "error",
                    showConfirmButton: false
                })
            }
        })
}

function Modificar_Tipo_Contrato(id, nombre, horas, rango_documentos, monto, aceptacion) {

    $("#consecutivo_tipo_contrato").val(id);
    $("#nombre_tipo_contrato").val(nombre);

    if (horas == "True") {
        $("#horas").prop('checked', true);
    }
    if (rango_documentos == "True") {
        $("#rango_documentos").prop('checked', true);
    }
    if (monto == "True") {
        $("#monto").prop('checked', true);
    }
    if (aceptacion == "True") {
        $("#aceptacion").prop('checked', true);
    }

    $("#boton_enviar").css("display", "none");
    $("#botones").css("display", "block");
    $("#consecutivo").css("display", "block");

    $('#boton_multiple').text("Modificar Tipo de Contrato");
    $('#parrafo_servicio').text("Modificar tipo de contrato actual");
}

function Actualizar_Tipo_Contrato() {
    var tipo_contrato = {
        'id_tipo_contrato': $("#consecutivo_tipo_contrato").val(),
        'nombre': $("#nombre_tipo_contrato").val(),
        'horas': $("#horas").is(":checked"),
        'rango_documentos': $("#rango_documentos").is(":checked"),
        'monto': $("#monto").is(":checked"),
        'aceptacion': $("#aceptacion").is(":checked")


    }

    swal({
        title: "\u00BFEst\u00E1 seguro de realizar los cambios?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, modificar",
        cancelButtonText: "Cancelar",
        closeOnConfirm: false
    },
        function (isConfirm) {
            if (isConfirm) {

    if (tipo_contrato != null) {
        $.ajax({
            type: "POST",
            url: "/TipoContrato/modificar_tipo_contrato",
            data: JSON.stringify(tipo_contrato),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                swal({
                    title: "Hecho",
                    text: "Se ha modificado correctamente",
                    type: "success",
                    showConfirmButton: false
                })

                setTimeout('location.reload()', 2000);
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    }
            } else {
                swal({
                    title: "Error",
                    text: "Se ha producido un problema",
                    type: "error",
                    showConfirmButton: false
                })
            }
        })
}

$(document).ready(function () {
    $('#select_tipo').change(function () {
        var val_select = $('#select_tipo').val();
        var url = window.location.href;
        var nuevaUrl = url.substring(0, url.indexOf('?'));
        window.location.href = nuevaUrl + "?Estado=" + val_select;

    });
});

var ShowPopup = function () {
    alert("No tiene permisos");
}

function Validar_Campo() {

    if (document.getElementById("nombre_tipo_contrato").value.trim() == "") {

        document.getElementById("boton_agregar").disabled = true;
        document.getElementById("boton_modificar").disabled = true;
        document.getElementById("error_campos_vacios").style.display = "block";
        return false;
    } else {
        document.getElementById("boton_agregar").disabled = false;
        document.getElementById("boton_modificar").disabled = false;
        document.getElementById("error_campos_vacios").style.display = "none";
        return true;
    }
}