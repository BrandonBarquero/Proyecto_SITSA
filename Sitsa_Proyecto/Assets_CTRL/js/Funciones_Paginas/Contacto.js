$(document).ready(function () {
    $('#tabla-mant').DataTable();


});

function ver_detalles(id, encargado, telefono, correo, tipo_encargado) {
    $("#id_contacto2").val(id);
    $("#encargado2").val(encargado);
    $("#telefono2").val(telefono);
    $("#email2").val(correo);
    $("#tipo_encargado2").val(tipo_encargado);
}

function editar(id, encargado, telefono, correo, tipo_encargado) {
    $("#id_contacto").val(id);
    $("#encargado").val(encargado);
    $("#telefono").val(telefono);
    $("#correo").val(correo);
    $("#tipo_encargado").val(tipo_encargado);

    $("#boton_agregar").css("display", "none");
    $("#botones").css("display", "block");
    $("#id_contacto_input").css("display", "block");

    $('#boton_multiple').text("Modificar Contacto");
    $('#parrafo_servicio').text("Modificar contacto actual");
}

function Actualizar_Contacto() {

    var tipo_contrato = {
        'id_contacto': $("#id_contacto").val(),
        'encargado': $("#encargado").val(),
        'telefono': $("#telefono").val(),
        'correo': $("#correo").val(),
        'tipo_encargado': $("#tipo_encargado").val(),
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
                $.ajax({
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    type: 'POST',
                    url: '/Contacto/modificar_contacto',
                    data: JSON.stringify(tipo_contrato),
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

function Eliminar_Contacto(id) {

    var tipo_contrato = {
        'id_contacto': id,
    }

    swal({
        title: "\u00BFEst\u00E1 seguro de eliminarlo?",
        text: "No podr\u00E1 recuperarlo luego",
        type: "error",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, eliminar",
        cancelButtonText: "Cancelar",
        closeOnConfirm: false
    },
        function (isConfirm) {
            if (isConfirm) {
                $.ajax({
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    type: 'POST',
                    url: '/Contacto/eliminar_contacto',
                    data: JSON.stringify(tipo_contrato),
                    success: function (dato) {

                        if (dato == "ErrorCont") {
                            swal({
                                title: "Error",
                                text: "No se puede eliminar un contacto ligado a un cliente",
                                type: "error",
                                showConfirmButton: true
                            })

                            return false;
                        }

                        swal({
                            title: "Hecho",
                            text: "Se ha eliminado satisfactoriamente",
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



function Agrega_Contacto() {

    var contacto = new Object();
    contacto.encargado = $("#encargado").val();
    contacto.telefono = $("#telefono").val();
    contacto.correo = $("#correo").val();
    contacto.tipo_encargado = $("#tipo_encargado").val();

    swal({
        title: "\u00BFAgregar contacto?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#34495E",
        confirmButtonText: "Si, agregar",
        cancelButtonText: "Cancelar",
        closeOnConfirm: false
    },
        function (isConfirm) {


            if (isConfirm) {

                if (contacto != null) {
                    $.ajax({
                        type: "POST",
                        url: "/Contacto/agregar_contacto",
                        data: JSON.stringify(contacto),
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

var ShowPopup = function () {
    alert("No tiene permisos");

}




function Validar_Campo() {

    if (document.getElementById("encargado").value.trim() == "" || document.getElementById("telefono").value.trim() == "" || document.getElementById("correo").value.trim() == "" || document.getElementById("tipo_encargado").value.trim() == "") {

        document.getElementById("boton_agregar_contacto").disabled = true;
        document.getElementById("boton_modificar").disabled = true;
        document.getElementById("error_campos_vacios").style.display = "block";
        return false;
    } else {
        document.getElementById("boton_agregar_contacto").disabled = false;
        document.getElementById("boton_modificar").disabled = false;
        document.getElementById("error_campos_vacios").style.display = "none";
        return true;
    }
}