$(document).ready(function () {
    $('#tabla-mant').DataTable();
});


var Agregar_Servicio = function () {

    var descripcion = $("#desc_servicio").val();


    swal({
        title: "\u00BFAgregar Servicio?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#34495E",
        confirmButtonText: "Si, agregar",
        cancelButtonText: "Cancelar",
        closeOnConfirm: false
    },
        function (isConfirm) {


            if (isConfirm) {

    $.ajax({
        type: "post",
        url: "/Servicio/agregar_servicio",
        data: {
            descripcion: descripcion,

        },
        success: function (result) {
            swal({
                title: "Hecho",
                text: "Se ha agregado correctamente",
                type: "success",
                showConfirmButton: false
            })

            setTimeout('location.reload()', 2000);
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


var Actualizar_Servicio = function () {


    var id_servicio = $("#consecutivo_servicio").val();

    var descripcion = $("#desc_servicio").val();


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
        type: "post",
        url: "/Servicio/actualizar_servicio",
        data: {
            id_servicio: id_servicio,
            descripcion: descripcion,

        },
        success: function (result) {
            swal({
                title: "Hecho",
                text: "Se ha modificado correctamente",
                type: "success",
                showConfirmButton: false
            })

            setTimeout('location.reload()', 2000);
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

function Modificar_Servicio(dato, dato2, dato3) {




    $("#consecutivo_servicio").val(dato);
    $("#desc_servicio").val(dato2);

    cedula_N = dato;

    $("#boton_enviar").css("display", "none");
    $("#campo_consecutivo").css("display", "block");
    $("#botones").css("display", "block");
    //   $("#campo_consecutivo").css("text-align", "");
    $("#consecutivo_servicio").attr("readonly", "true");
    $('#boton_multiple').text("Modificar Servicio");
    $('#parrafo_servicio').text("Modificar servicio actual");

}

function estado(dato_id) {


    var id_servicio = dato_id;

    $("#" + id_servicio).on('change', function () {
        if ($(this).is(':checked')) {

            $.ajax({
                type: "post",
                url: "/Servicio/actualizar_estado_Habilitar_servicio",
                data: {
                    id_servicio: id_servicio,
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
                url: "/Servicio/actualizar_estado_deshabilitar_servicio",
                data: {
                    id_servicio: id_servicio,
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


function estado_inhabilitar_boton() {

    var id_servicio = $("#consecutivo_servicio").val();

    alert("check");

    $.ajax({
        type: "post",
        url: "/Servicio/actualizar_estado_deshabilitar_servicio",
        data: {
            id_servicio: id_servicio,
        },
        success: function (result) {
            if (result == "fail") {



            }
            else {

                window.alert("exito");

            }
        }
    })
};

$(document).ready(function () {
    $('#select_proyect').change(function () {

        var val_select = $('#select_proyect').val();
        var url = window.location.href;
        var nuevaUrl = url.substring(0, url.indexOf('?'));
        window.location.href = nuevaUrl + "?Estado=" + val_select;

    });
});

var ShowPopup = function () {
    alert("No tiene permisos");

}

function Validar_Campo() {

    if (document.getElementById("desc_servicio").value.trim() == "") {

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