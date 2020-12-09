let fases = [];
let fases_Modificar = [];
let proyectos = [];
let numero = 0; 

$(document).ready(function () {
   
    $('.js-example-responsive').select2();

});

$(document).ready(function () {
    $('#tabla-mant').DataTable();
});

let g_id = null;

$(document).ready(function () {
    let params = new URLSearchParams(location.search);
    g_id = params.get('id');
    if (g_id != null) {
        $("#collapseProyectos").collapse('show');
        $('#boton_multiple').text("Detalles del Proyecto");
        $('#parrafo_proyecto').text("Detalles del proyecto actual");
        $("#boton_agregar").css("display", "none");
        $("#botones").css("display", "block");
        $("#consecutivo_proyecto_div").css("display", "block");
        $("#consecutivo_proyecto").attr("readonly", "true");

        devolver_proyecto(g_id);
    
    } else {
        return;
    }
});

var g_proyecto = new Object();

function devolver_proyecto(id) {



    $.ajax({
        type: "POST",
        url: "/Proyecto/devuelve_proyecto",
        data: JSON.stringify({
            id: id,
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSend: function () {
        },
        success: function (response) {

            g_proyecto = response;

            $("#consecutivo_proyecto").val(g_proyecto.ID_PROYECTO);
            $("#nombre_proyecto").val(g_proyecto.NOMBRE);
            $("#desc_proyecto").val(g_proyecto.DESCRIPCION);
            $("#precio").val(g_proyecto.PRECIO);
            $("#cliente_proyecto option[value='nulo'").attr("selected", false);
            $("#cliente_proyecto option[value=" + g_proyecto.FK_ID_CLIENTE + "]").attr("selected", true);
            $('#cliente_proyecto').val(g_proyecto.FK_ID_CLIENTE).trigger('change');

        }
    })


            $.ajax({
                type: "POST",
                url: "/Fase_Tiempo/Listar_Fases_Proyecto",
                data: JSON.stringify({
                    id: id,
                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                beforeSend: function () {
                },
                success: function (response) {

            let json_obj6 = $.parseJSON(response);
            let cantidadDeClaves6 = Object.keys(json_obj6).length;


            $("#t_fase > tbody").empty();


            for (let i = 0; i < cantidadDeClaves6; i++) {
                servicios3.push($('#t_fase').val());

                let htmlTags6 = `<tr id=${json_obj6[i].ID_FASE}>
                            <td>${json_obj6[i].TIEMPO}</td> 
                            <td>${json_obj6[i].DESCRIPCION}</td>
                            <td style="text-align: center;"><a onclick='Eliminar_Fase(${json_obj6[i].ID_FASE});actualizarRespuesta()'><i class="fas fa-trash color-icono" aria-hidden="true"></td> </tr>`;

                $('#t_fase tbody').append(htmlTags6);
            }

        }
    })

}


var valor_id_fase;
var servicios = [];
var servicios3 = [];

function ver_detalles(id, nombre, descripcion, precio, cliente) {
    $("#consecutivo_proyecto2").val(id);
    $("#nombre_proyecto2").val(nombre);
    $("#desc_proyecto2").val(descripcion);
    $("#precio2").val(precio);
    $("#cliente_proyecto2").val(cliente);
}

function Eliminar_Fase(id) {

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
        url: "/Proyecto/Eliminar_Fases",
        data: {
            id: id,
        },
        success: function (response) {

            $("#" + id).remove();
        }

    });

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
function editar(id, nombre, descripcion, precio, cliente) {

    numero = 0;
    $("#t_fase > tbody").empty();
    fases.splice(0, fases.length)


    $("#consecutivo_proyecto").val(id);
    $("#nombre_proyecto").val(nombre);
    $("#desc_proyecto").val(descripcion);
    $("#precio").val(precio);
    $("#cliente_proyecto option[value='nulo'").attr("selected", false);
    $("#cliente_proyecto option[value=" + cliente + "]").attr("selected", true);
    $('#cliente_proyecto').val(cliente).trigger('change');
    

    $("#boton_agregar").css("display", "none");
    $("#botones").css("display", "block");
    $("#consecutivo_proyecto_div").css("display", "block");
    $("#consecutivo_proyecto").attr("readonly", "true");

    $('#boton_multiple').text("Modificar Proyecto");
    $('#parrafo_proyecto').text("Modificar proyecto actual");

    $.ajax({
        type: "post",
        url: "/Fase_Tiempo/Listar_Fases_Proyecto",
        data: {
            id: id,
        },
        success: function (result) {

            let json_obj6 = $.parseJSON(result);
            let cantidadDeClaves6 = Object.keys(json_obj6).length;


            $("#t_fase > tbody").empty();


            for (let i = 0; i < cantidadDeClaves6; i++) {
                servicios3.push($('#t_fase').val());

                let htmlTags6 = `<tr id=${json_obj6[i].ID_FASE}>
                            <td>${json_obj6[i].TIEMPO}</td> 
                            <td>${json_obj6[i].DESCRIPCION}</td>
                            <td style="text-align: center;"><a onclick='Eliminar_Fase(${json_obj6[i].ID_FASE});actualizarRespuesta()'><i class="fas fa-trash color-icono" aria-hidden="true"></td> </tr>`;

                $('#t_fase tbody').append(htmlTags6);
            }

        }
    })
}

function fase_dato2(id) {

    $.ajax({
        type: "get",
        url: "/Fase_Tiempo/obtener_id_fase",
        data: {
            id: id,
        },
        success: function (result) {

            setTimeout('location.reload()', 0);



            if (result == "fail") {

            }
            else {

                window.alert("exito");

            }
        }
    })

    $("#id_proyecto").val(id);


}
function MostrarMensaje(id) {

    $("#id_proyecto").val(id);
}

function Agregar_Proyecto() {

    var proyecto = new Object();
    proyecto.nombre = $("#nombre_proyecto").val();
    proyecto.descripcion = $("#desc_proyecto").val();
    proyecto.precio = $("#precio").val();
    proyecto.fk_id_cliente = $("#cliente_proyecto").val();

    //proyectos.push(proyecto);

    swal({
        title: "\u00BFAgregar Proyecto?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#34495E",
        confirmButtonText: "Si, agregar",
        cancelButtonText: "Cancelar",
        closeOnConfirm: false
    },
        function (isConfirm) {


            if (isConfirm) {

                if (proyecto != null) {
                    $.ajax({
                        type: "POST",
                        url: "/Proyecto/agregar_proyecto",
                        data: JSON.stringify(proyecto),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {

                            Prueba_Fase();


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

function Prueba_Fase() {

    $.ajax({
        type: "POST",
        url: "/Proyecto/agregar_fases",
        data: JSON.stringify({ fases: fases }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

        }

    });
}

function Agregar_Fase() {

    numero = numero + 1;
    let fase_proyecto = new Object();
    fase_proyecto.key = numero;
    fase_proyecto.descripcion = $("#descripcion_fase").val();
    fase_proyecto.tiempo = $("#tiempo_proyecto").val();

    servicios.push($('#fase_tiempo').val());

    let htmlTags = `<tr id="${numero}">
                <td>${$('#tiempo_proyecto').val()}</td>
                <td>${$('#descripcion_fase').val()}</td>
                <td  style="text-align: center;"><a onclick="eliminarFila(${numero})"><i class="fas fa-trash color-icono" aria-hidden="true"></td>
                </tr>`;

    $('#t_fase tbody').append(htmlTags);

    fases.push(fase_proyecto);

    $("#descripcion_fase").val("");
    $("#tiempo_proyecto").val("");

}

function eliminarFila(Number) {

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

    $("#" + Number).remove();

                for (var i = 0; i < fases.length; i++) {
                    if (fases[i].key === Number) {
                        fases.splice(i, 1);
                    }
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

function Actualizar_Proyecto() {

    var proyecto = new Object();
    proyecto.id_proyecto = $("#consecutivo_proyecto").val();
    proyecto.nombre = $("#nombre_proyecto").val();
    proyecto.descripcion = $("#desc_proyecto").val();
    proyecto.precio = $("#precio").val();
    proyecto.fk_id_cliente = $("#cliente_proyecto").val();

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

                if (proyecto != null) {
                    $.ajax({
                        type: "POST",
                        url: "/Proyecto/actualizar_proyecto",
                        data: JSON.stringify(proyecto),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            Prueba_Fase();
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

function Deshabilitar(val) {

    var fase_tiempo = new Object();
    fase_tiempo.id_fase = val;

    if (fase_tiempo != null) {
        $.ajax({
            type: "POST",
            url: "/Fase_Tiempo/actualizar_estado_deshabilitar_fase_tiempo",
            data: JSON.stringify(fase_tiempo),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response != null) {
                    alert("Name : " + response.Name + ", Designation : " + response.Designation + ", Location :" + response.Location);
                } else {
                    alert("Something went wrong");
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

function estado(dato_id) {


    var id_proyecto = dato_id;

    $("#" + id_proyecto).on('change', function () {
        if ($(this).is(':checked')) {

            $.ajax({
                type: "post",
                url: "/Proyecto/actualizar_estado_Habilitar_proyecto",
                data: {
                    id_proyecto: id_proyecto,
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
                url: "/Proyecto/actualizar_estado_deshabilitar_proyecto",
                data: {
                    id_proyecto: id_proyecto,
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

    if (document.getElementById("cliente_proyecto").value.trim() == "nulo" || document.getElementById("nombre_proyecto").value.trim() == "" || document.getElementById("precio").value.trim() == "" || document.getElementById("desc_proyecto").value.trim() == "") {

        document.getElementById("boton_agregar_proyecto").disabled = true;
        document.getElementById("boton_modificar").disabled = true;
        document.getElementById("error_campos_vacios").style.display = "block";

        return false;
    } else {
        document.getElementById("boton_agregar_proyecto").disabled = false;
        document.getElementById("boton_modificar").disabled = false;
        document.getElementById("error_campos_vacios").style.display = "none";
        return true;
    }
}

function Validar_Campo2() {

    if (document.getElementById("descripcion_fase").value.trim() == "" || document.getElementById("tiempo_proyecto").value.trim() == "") {

        document.getElementById("agregar_fases").disabled = true;
        document.getElementById("boton_modificar").disabled = true;
        document.getElementById("error_campos_vacios2").style.display = "block";
        return false;
    } else {
        document.getElementById("agregar_fases").disabled = false;
        document.getElementById("boton_modificar").disabled = false;
        document.getElementById("error_campos_vacios2").style.display = "none";
        return true;
    }
}
