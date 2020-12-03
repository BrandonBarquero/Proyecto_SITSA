<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Control_Visitas.WebForm2" %>
<DOCTYPE html>
<html lang="en">
<head>
  
     <title>Login</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
   	<!--===============================================================================================-->	
    <link rel="icon" type="image/png" href="Assets_CTRL/images/icons/login.ico"/><!--Icono Página-->
    <link rel="stylesheet" type="text/css" href="Assets_CTRL/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" type="text/css" href="Assets_CTRL/fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
    <link rel="stylesheet" type="text/css" href="Assets_CTRL/css/util.css">
    <link rel="stylesheet" type="text/css" href="Assets_CTRL/css/main.css">
    <link rel="stylesheet" href="Assets_CTRL/css/all.css">
    <link rel="stylesheet" type="text/css" href="Assets_CTRL/css/bootstrap.min.css">

		<!--===============================================================================================-->
   <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js" integrity="sha384-B4gt1jrGC7Jh4AgTPSdUtOBvfO8shuf57BaghqFfPlYxofvL8/KUEfYiJOMMV+rV" crossorigin="anonymous"></script>
   
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>

    <script src="js/jquery-3.2.1.min.js" type="text/javascript"></script>
   
</head>


<!--Header-->
    <header>
        <nav class="navbar navbar-light">
            <a class="navbar-brand" href="#" style="color:white; font-family: Raleway-Regular; font-size: 15px;">
                SITSA S.A 
            </a>
        </nav>
    </header>
<!--Fin Header-->






<body >

   

 <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100 p-l-85 p-r-85 p-t-55 p-b-55" style="zoom:80%";>
               <form id="loginForm">
                    <div  style="display: none;" id="error_login" class="alert alert-danger">
               
                 <strong>¡Error!</strong> Usuario o contraseña incorrecta.
                      </div>
                 
                    <span class="login100-form-title p-b-32">
                        Control de Visitas
                    </span>

                    <span class="txt1 p-b-11">
                        Usuario
                    </span>
                    <div class="wrap-input100 validate-input m-b-36" data-validate="Username is required">
                        <input class="input100" type="text" id="logEmail" name="logEmail">
                        <span class="focus-input100"></span>
                    </div>

                    <span class="txt1 p-b-11">
                        Contraseña
                    </span>
                    <div class="wrap-input100 validate-input m-b-12" data-validate="Password is required">
                        <input class="input100" type="password" id="logPssword" name="logPssword">
                        <span class="focus-input100"></span>
                    </div>

                    <div class="flex-sb-m w-full p-b-48">
                        <div class="contact100-form-checkbox">
                            <input class="input-checkbox100" id="ckb1" type="checkbox" name="remember-me">
                          <%--  <label class="label-checkbox100" for="ckb1">
                                Recordar
                            </label>--%>
                        </div>

                        <div>
                           <a  data-toggle="modal" data-target="#recuperar_contrasenna" href="#" class="txt3">
                          ¿Olvidó contraseña?
                           </a>
                        </div>
                    </div>
                  
                   </form>
                    <div class="container-login100-form-btn">
                        <button type="submit" onclick="Login()" class="login100-form-btn">
                            Iniciar Sesión
                        </button>
                    </div>
                 <div  style="display: none;"  id="loader" class="flex-sb-m w-full p-b-48">
                       <img src="https://www.griferiaclever.com/images/giphy.gif" alt="" style="width: 380px;height:85px;" >

                   </div>
                    <div id="error">

                    </div>
                
            </div>
            
        </div>
    </div>


    <div id="dropDownSelect1"></div>
    <script src="js/main.js"></script>









       
<!--Popup Recuperar Contrasenna-->
       <div id="recuperar_contrasenna" class="modal fade" role="dialog">
        <div class="modal-dialog">
          <!-- Modal contenido-->
          <div class="modal-content">

            <div class="modal-header popup-estilo-head">
              <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>

            <div class="modal-body popup-estilo">
               
              <form role="form" method="post" id="form_usuario_recuperar_contrasenna">
                   <div id="msg2">
                       
                      <div class="alert alert-success">
              
                 <strong>¡Hecho!</strong> Correo enviado.
                    </div>


                   </div>
                   <div id="msg1">
                      <div class="alert alert-danger">
              
                 <strong>¡Error!</strong> Correo no válido.
                      </div>


                   </div>
                <p id="text_P">Recuperar Contraseña</p>

                <div id="Div_datos" class="form-group">
                  <label> Ingrese el correo electrónico:</label>
                  <input type="email" class="form-control" id="Mail" name="Mail">
                </div>

              </form>

                <div style="text-align: center;">

               <button id="boton"  onclick="Login1()" type="submit" class="popup-btn">Recuperar</button>

                    </div>

          </div>
          </div>
        </div>
      </div>
      <!--Fin Popup Recuperar Contrasenna-->


</body>




<!-- Footer -->
<footer class="page-footer font-small">

    <!-- Copyright -->
    <div class="footer-copyright text-center py-3">
        © 2020 Desarrollado por: SITSA S.A

    </div>
    <!-- Copyright -->

</footer>
<!-- Footer -->
</html> 

<script>
    //Login del sistema
    $("#msg").hide();
    $("#msg2").hide();
    var Login = function () {
        var data = $("#loginForm").serialize();
        $.ajax({
            type: "post",
            url: "/Default/login",
            data: data,
            beforeSend: function () {


                $("#loader").show();

            },
            success: function (result) {
                if (result == "fail") {
                    $("#loader").hide();
                    $("#error_login").show();
                }
                else {
                    $("#loader").hide();
                    window.location.href = "/Default/AfterLogin";

                }
            }
        })
    }
</script>
<script>
    //Login del sistema

    var ver = function () {
        $("#text_P").show();
        $("#Div_datos").show();
        $("#boton").show();
        $("#msg2").hide();
        $("#form_usuario_recuperar_contrasenna")[0].reset();
    }

    $("#msg1").hide();
    $("#msg2").hide();
    var Login1 = function () {

        var data = $("#form_usuario_recuperar_contrasenna").serialize();
        $.ajax({
            type: "post",
            url: "/Default/olvidocontrasenna",
            data: data,
            success: function (result) {
                if (result == "fail") {
                    $("#msg1").show();


                }
                else {
                    $("#msg2").show();
                    $("#msg1").hide();
                    $("#text_P").hide();
                    $("#Div_datos").hide();
                    $("#boton").hide();


                }
            }
        })
    }
</script>