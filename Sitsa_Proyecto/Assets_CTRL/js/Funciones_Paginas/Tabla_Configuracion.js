$(document).ready(function () {
    $('#tabla-mant').DataTable();


});



function editar(estado, consecutivo, descripcion, observacion, llave01, llave02, llave03, llave04, llave05, llave06, valor, fk_llave_foranea, estructura, gui_relacion, pk_tbl_config) {
    $("#estado").val(estado);
    $("#consecutivo").val(consecutivo);
    $("#descripcion").val(descripcion);
    $("#observacion").val(observacion);
    $("#llave01").val(llave01);
    $("#llave02").val(llave02);
    $("#llave03").val(llave03);
    $("#llave04").val(llave04);
    $("#llave05").val(llave05);
    $("#llave06").val(llave06);
    $("#valor").val(valor);
    $("#fk_llave_foranea").val(fk_llave_foranea);
    $("#estructura").val(estructura);
    $("#gui_relacion").val(gui_relacion);
    $("#pk_tbl_config").val(pk_tbl_config);


    $("#boton_agregar").css("display", "none");
    $("#botones").css("display", "block");
    $("#id_contacto_input").css("display", "block");

    $('#boton_multiple').text("Modificar Valor");
    $('#parrafo_configuracion').text("Modificar valor actual");
}

function Actualizar_Tabla_Configuracion() {

    var tbl_config = {
        'estado': estado,
        'consecutivo': $("#consecutivo").val(),
        'descripcion': $("#descripcion").val(),
        'observacion': $("#observacion").val(),
        'llave01': $("#llave01").val(),
        'llave02': $("#llave02").val(),
        'llave03': $("#llave03").val(),
        'llave04': $("#llave04").val(),
        'llave05': $("#llave05").val(),
        'llave06': $("#llave06").val(),
        'valor': $("#valor").val(),
        'fk_llave_foranea': $("#fk_llave_foranea").val(),
        'estructura': $("#estructura").val(),
        'gui_relacion': $("#gui_relacion").val(),
        'pk_tbl_config': $("#pk_tbl_config").val(),
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

                if (tbl_config != null) {
                    $.ajax({
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        type: 'POST',
                        url: '/Tabla_Configuracion/modificar_tabla_configuracion',
                        data: JSON.stringify(tbl_config),
                        success: function () {
                            swal({
                                title: "Hecho",
                                text: "Se ha modificado correctamente",
                                type: "success",
                                showConfirmButton: false
                            })

                            setTimeout('location.reload()', 2000);
                        },
                        failure: function (response) {
                            confirm(response);
                        },
                        error: function (result) {
                            confirm("ERROR " + result.status + ' ' + result.statusText);
                        }
                    })
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

function Agrega_Tabla_Configuracion() {

    var tabla_configuracion = new Object();
    tabla_configuracion.estado = $("#estado").val();
    tabla_configuracion.consecutivo = $("#consecutivo").val();
    tabla_configuracion.descripcion = $("#descripcion").val();
    tabla_configuracion.observacion = $("#observacion").val();
    tabla_configuracion.llave01 = $("#llave01").val();
    tabla_configuracion.llave02 = $("#llave02").val();
    tabla_configuracion.llave03 = $("#llave03").val();
    tabla_configuracion.llave04 = $("#llave04").val();
    tabla_configuracion.llave05 = $("#llave05").val();
    tabla_configuracion.llave06 = $("#llave06").val();
    tabla_configuracion.valor = $("#valor").val();
    tabla_configuracion.fk_llave_foranea = $("#fk_llave_foranea").val();
    tabla_configuracion.estructura = $("#estructura").val();
    tabla_configuracion.gui_relacion = $("#gui_relacion").val();


    swal({
        title: "\u00BFAgregar valor?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#34495E",
        confirmButtonText: "Si, agregar",
        cancelButtonText: "Cancelar",
        closeOnConfirm: false
    },
        function (isConfirm) {


            if (isConfirm) {

                if (tabla_configuracion != null) {
                    $.ajax({
                        type: "POST",
                        url: "/Tabla_Configuracion/agregar_tabla_configuracion",
                        data: JSON.stringify(tabla_configuracion),
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

function Eliminar_Tabla_Configuracion(id) {

    swal({
        title: "\u00BFDesea continuar?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, eliminar",
        cancelButtonText: "Cancelar",
        closeOnConfirm: true
    },
        function (isConfirm) {


            if (isConfirm) {

                $.ajax({
                    type: "POST",
                    url: "/Tabla_Configuracion/Eliminar_Tabla",
                    data: {
                        id: id,
                    },
                    success: function (response) {

                        $("#" + id).remove();
                    }

                });

                setTimeout('location.reload()', 2000);

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

var ShowPopup = function () {
    alert("No tiene permisos");

}

