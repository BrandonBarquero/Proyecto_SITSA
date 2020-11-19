$(document).ready(function () {
    debugger;
    $('.js-example-responsive').select2();

});


var cliente_a;

let Contactos_A = [];
var servicios = [];
var servicios2 = [];
var servicios3 = [];
$(document).ready(function () {
    $('#tabla-mant').DataTable();


});

function Borrar(dato) {

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

                    type: "post",
                    url: "/Contacto/eliminar_contacto_cliente",
                    data: { dato: dato },
                    success: function (result) {

                        for (let i = 0; i < Contactos_A.length; i++) {

                            if (Contactos_A[i].AUX == dato) {

                                Contactos_A.splice(i, 1);



                                $("#Prueba" + dato).remove();

                            }
                        }

                    },
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

function Borrar_Servicios(dato) {

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

                    type: "post",
                    url: "/Servicio/eliminar_servicio_cliente",
                    data: { dato: dato },
                    success: function (result) {

                        for (let i = 0; i < servicios2.length; i++) {

                            if (servicios2[i].AUX == dato) {

                                servicios2.splice(i, 1);



                                $("#Prueba" + dato).remove();

                            }
                        }

                    },
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

function AsignarCLiente(dato) {

    cliente_a = dato;


    $.ajax({
        type: "post",
        url: "/Cliente/ContactosCliente",
        data: { dato: dato },
        success: function (result) {
            var json_obj6 = $.parseJSON(result);
            var cantidadDeClaves6 = Object.keys(json_obj6).length;

            $("#tabla-mant6 > tbody").empty();

            for (var i = 0; i < cantidadDeClaves6; i++) {
                Contactos_A.push(json_obj6[i]);
                servicios3.push($('#tabla-mant6').val());

                var htmlTags6 = `<tr id=Prueba${json_obj6[i].AUX}> 
                              <td>${json_obj6[i].ID_CONTACTO}</td>
                              <td>${json_obj6[i].ENCARGADO}</td>
                              <td>${json_obj6[i].TELEFONO}</td>
                              <td>${json_obj6[i].CORREO}</td>
                              <td>${json_obj6[i].TIPO_ENCARGADO}</td>
                              <td style="text-align: center;"><a onclick="Borrar(${json_obj6[i].AUX})"><i class="fas fa-trash color-icono" aria-hidden="true"></td>
                              </tr>`;

                $('#tabla-mant6 tbody').append(htmlTags6);
            }



        }
    })


}

function Agregar() {

    var Cliente_Servicio = new Object();
    Cliente_Servicio.fk_id_cliente = $("#Cliente").val();
    Cliente_Servicio.fk_id_servicio = $("#Servicio").val();
    Cliente_Servicio.tarifa_hora = $("#Tarifa").val();

    swal({
        title: "\u00BFAsignar Servicio?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#34495E",
        confirmButtonText: "Si, asignar",
        cancelButtonText: "Cancelar",
        closeOnConfirm: false
    },
        function (isConfirm) {


            if (isConfirm) {

                $.ajax({
                    type: "post",
                    url: "/Cliente/agrega",
                    data: JSON.stringify(Cliente_Servicio),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",

                    success: function (data) {
                        if (data == "fail") {
                            window.alert("fail");
                        }
                        else {

                            var htmlTags = '<tr id=' + $('#tabla-mant2').val() + '>' +
                                '<td>' + data + '</td>' +
                                '<td>' + $('#Servicio option:selected').html() + '</td>' +
                                '<td>' + $('#Tarifa').val() + '</td>' +
                                '<td style="text-align: center;"><a onclick="Borrar_Servicios(' + data + ')" ><i class="fas fa-trash color-icono" aria-hidden="true"></td>' +
                                '</tr>';

                            $('#tabla-mant1 tbody').append(htmlTags);

                        }

                        swal({
                            title: "Hecho",
                            text: "Se ha asignado correctamente",
                            type: "success",
                            showConfirmButton: true
                        })
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





function Cliente(dato) {


    var dato1 = dato;
    $.ajax({
        type: "post",
        url: "/Cliente/SesionCLeinte",
        data: {
            dato1: dato1,
        },
        success: function (result) {
            var json_obj = $.parseJSON(result);
            var cantidadDeClaves = Object.keys(json_obj).length;
            var currentValue = parseInt(cantidadDeClaves);





            $("#tabla-mant2 > tbody").empty();



            for (var i = 0; i < currentValue; i++) {
                servicios.push($('#tabla-mant111').val());

                var htmlTags = '<tr id=i' + i + '>' +
                    '<td>' + json_obj[i].ID_CONTRATO + '</td>' +
                    '<td>' + json_obj[i].NOMBRE_CONTRATO + '</td>' +
                    '<td style="text-align: center;"><a href="#"><i class="fas fa-file-alt color-icono" aria-hidden="true"></td>' +
                    '</tr>';

                $('#tabla-mant2 tbody').append(htmlTags);
            }


        }
    })
    $("#Cliente").val(dato1);







    $.ajax({
        type: "post",
        url: "/Cliente/ServiciosCliente",
        data: {
            dato1: dato1,
        },
        success: function (result) {
            var json_obj1 = $.parseJSON(result);
            var cantidadDeClaves1 = Object.keys(json_obj1).length;
            var currentValue1 = parseInt(cantidadDeClaves1);




            $("#tabla-mant1 > tbody").empty();





            for (var i = 0; i < currentValue1; i++) {
                servicios2.push($('#tabla-mant1234').val());

                var htmlTags1 = `<tr id=Prueba${json_obj1[i].AUX}> 
                    <td>${json_obj1[i].PK_CLIENTE_SERVICIO}</td>
                    <td>${json_obj1[i].USAURIO_MODIFICACION}</td>
                    <td>${json_obj1[i].TARIFA_HORA}</td>
                    <td style="text-align: center;"><a onclick="Borrar_Servicios(${json_obj1[i].AUX})"><i class="fas fa-trash color-icono" aria-hidden="true"></td>' +
                    </tr>`;

                $('#tabla-mant1 tbody').append(htmlTags1);
            }
        }
    })

    $.ajax({
        type: "post",
        url: "/Cliente/ProyectosCliente",
        data: {
            dato1: dato1,
        },
        success: function (result) {
            var json_obj1 = $.parseJSON(result);
            var cantidadDeClaves1 = Object.keys(json_obj1).length;
            var currentValue1 = parseInt(cantidadDeClaves1);




            $("#tabla-mant3 > tbody").empty();





            for (var i = 0; i < currentValue1; i++) {
                servicios2.push($('#tabla-mant1234').val());

                var htmlTags1 = '<tr id=u' + i + '>' +
                    '<td>' + json_obj1[i].ID_PROYECTO + '</td>' +
                    '<td>' + json_obj1[i].NOMBRE + '</td>' +

                    '<td style="text-align: center;"><a href="#"><i class="fas fa-file-alt color-icono" aria-hidden="true"></td>' +
                    '</tr>';

                $('#tabla-mant3 tbody').append(htmlTags1);
            }


        }
    })


}

function Agregar_Contacto() {

    for (let i = 0; i < Contactos_A.length; i++) {

        if (Contactos_A[i].ID_CONTACTO == $("#Contacto_cliente").val()) {
            swal({
                title: "Error",
                text: "El contacto ya se encuentra registrado",
                type: "error",
                showConfirmButton: true
            })
            return false;
        }

    }

    var contacto = new Object();
    contacto.ID_CONTACTO = $("#Contacto_cliente").val();
    contacto.ENCARGADO = cliente_a.toString();


    swal({
        title: "\u00BFAsignar Contacto?",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#34495E",
        confirmButtonText: "Si, asignar",
        cancelButtonText: "Cancelar",
        closeOnConfirm: false
    },
        function (isConfirm) {


            if (isConfirm) {

                $.ajax({
                    type: "post",
                    url: "/Cliente/agrega_contactos",
                    data: JSON.stringify(contacto),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                 
                      
                 
                    success: function (result) {

                        swal({
                            title: "Hecho",
                            text: "Se ha agregado correctamente",
                            type: "success",
                            showConfirmButton: true
                        })

                        let json_obj6 = $.parseJSON(result);
                        let cantidadDeClaves6 = Object.keys(json_obj6).length;

                        $("#tabla-mant6 > tbody").empty();

                        Contactos_A.length = 0;

                        for (let i = 0; i < cantidadDeClaves6; i++) {
                            servicios3.push($('#tabla-mant6').val());
                            Contactos_A.push(json_obj6[i]);
                            let htmlTags6 = `<tr id=Prueba${json_obj6[i].AUX}>
                              <td>${json_obj6[i].ID_CONTACTO}</td> 
                              <td>${json_obj6[i].ENCARGADO}</td> 
                              <td>${json_obj6[i].TELEFONO}</td> 
                              <td>${json_obj6[i].CORREO}</td> 
                              <td>${json_obj6[i].TIPO_ENCARGADO}</td>
                    <% if (Permisos.EDTIAR == true)
                                  { 

                                 %>
                              <td style="text-align: center;"><a onclick="Borrar(${json_obj6[i].AUX})"><i class="fas fa-trash color-icono" aria-hidden="true"></td>
                          <%} %>
                     </tr>`;

                            $('#tabla-mant6 tbody').append(htmlTags6);
                        }

                      



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

function Validar_Campo() {

    if (document.getElementById("Contacto_cliente").value.trim() == "nulo") {

        document.getElementById("boton_agregar_contacto").disabled = true;
        document.getElementById("error_campos_vacios").style.display = "block";

        return false;
    } else {
        document.getElementById("boton_agregar_contacto").disabled = false;
        document.getElementById("error_campos_vacios").style.display = "none";
        return true;
    }
}

function Validar_Campo_Servicio() {

    if (document.getElementById("Servicio").value.trim() == "nulo" || document.getElementById("Tarifa").value.trim() == "") {

        document.getElementById("boton_enviar_serv").disabled = true;
        document.getElementById("error_campos_vacios_servicios").style.display = "block";

        return false;
    } else {
        document.getElementById("boton_enviar_serv").disabled = false;
        document.getElementById("error_campos_vacios_servicios").style.display = "none";
        return true;
    }
}