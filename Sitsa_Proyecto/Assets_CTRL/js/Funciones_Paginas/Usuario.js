
$(document).ready(function () {
    $('#tabla-mant').DataTable();
});

$(document).ready(function () {
  
    $('.js-example-responsive').select2();

});

function toggle(checked) {
    var x = document.getElementById("1").checked;
    if (x == true) {
        window.alert("true");
    }

    else if (x == false) {
        window.alert("false");
    }
}

var cedula_N;
function Funcion(dato, dato2, dato3, dato4) {

    $("#cedula2").val(dato);
    $("#nombre2").val(dato2);
    $("#correo2").val(dato3);
    $("#perfil2").val(dato4);
}
function Modificar_Usuario(dato, dato2, dato3, dato4) {

    $("#cedula").val(dato);
    $("#nombre").val(dato2);
    $("#email").val(dato3);
    $("#perfil").val(dato4);

    $("#perfil option[value='nulo'").attr("selected", false);
    $("#perfil option[value=" + dato4 + "]").attr("selected", true);
    $('#perfil').val(dato4).trigger('change');


    $("#boton_enviar").css("display", "none");
    $("#botones").css("display", "block");
    $("#cedula").attr("readonly", "true");

    $('#boton_multiple').text("Modificar Usuario");
    $('#parrafo_servicio').text("Modificar usuario actual");
}

$(document).ready(function () {
    $('#cedula').change(function () {
        var cedula = $('#cedula').val();
        $.ajax({
            type: 'post',
            data: { cedula: cedula },
            url: '/Default/verificacedula',
            success: function (result) {
                if (result == "fail") {
                    $("#error_contrasenna").css("display", "none");
                }
                else {
                    if (cedula != cedula_N) {
                        $("#error_contrasenna").css("display", "block");
                    }
                    if (cedula == cedula_N) {
                        $("#error_contrasenna").css("display", "none");
                    }
                }
            }
        });
    });
});


$(document).ready(function () {
    $('#email').change(function () {
        var email = $('#email').val();
        $.ajax({
            type: 'post',
            data: { email: email },
            url: '/Default/verificaemail',
            success: function (result) {
                if (result == "fail") {
                    $("#error_email").css("display", "none");
                }
                else {
                    if (cedula != cedula_N) {
                        $("#error_email").css("display", "block");
                    }
                    if (cedula == cedula_N) {
                        $("#error_email").css("display", "none");
                    }
                }
            }
        });
    });
});


function Agregar_Usuario() {

    var usuario = new Object();
    usuario.cedula = $("#cedula").val();
    usuario.nombre = $("#nombre").val();
    usuario.correo = $("#email").val();
    usuario.fk_perfil = $("#perfil").val();

    swal({
        title: "\u00BFAgregar usuario?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#34495E",
        confirmButtonText: "Si, agregar",
        cancelButtonText: "Cancelar",
        closeOnConfirm: false
    },
        function (isConfirm) {


            if (isConfirm) {

    if (usuario != null) {
        $.ajax({
            type: "POST",
            url: "/Usuario/agregar_usuario",
            data: JSON.stringify(usuario),
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

function Actualizar_Usuario() {

    var usuario = new Object();
    usuario.cedula = $("#cedula").val();
    usuario.nombre = $("#nombre").val();
    usuario.correo = $("#email").val();
    usuario.fk_perfil = $("#perfil").val();


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
    if (usuario != null) {
        $.ajax({
            type: "POST",
            url: "/Usuario/actualizar_usuario",
            data: JSON.stringify(usuario),
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
    $('#select_usuario').change(function () {

        var val_select = $('#select_usuario').val();
        var url = window.location.href;
        var nuevaUrl = url.substring(0, url.indexOf('?'));
        window.location.href = nuevaUrl + "?Estado=" + val_select;

    });
});

function estado(dato_id, cedula) {



    var id_usuario = dato_id;
    var cedula_id = cedula;

    $("#" + cedula_id).on('change', function () {
        if ($(this).is(':checked')) {
            $.ajax({
                type: "post",
                url: "/Usuario/actualizar_estado_Habilitar_Usuario",
                data: {
                    id_usuario: id_usuario,

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
                url: "/Usuario/actualizar_estado_deshabilitar_Usuario",
                data: {
                    id_usuario: id_usuario,
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

var ShowPopup = function () {
    alert("No tiene permisos");
}

function Validar_Campo() {

    if (document.getElementById("cedula").value.trim() == "" || document.getElementById("nombre").value.trim() == "" || document.getElementById("email").value.trim() == "" || document.getElementById("perfil").value.trim() == "nulo") {

        document.getElementById("agregar_usuario").disabled = true;
        document.getElementById("modificar_usuario").disabled = true;
        document.getElementById("error_campos_vacios").style.display = "block";
        return false;
    } else {
        document.getElementById("agregar_usuario").disabled = false;
        document.getElementById("modificar_usuario").disabled = false;
        document.getElementById("error_campos_vacios").style.display = "none";
        return true;
    }
}