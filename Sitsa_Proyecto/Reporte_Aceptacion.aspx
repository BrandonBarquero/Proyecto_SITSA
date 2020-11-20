<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reporte_Aceptacion.aspx.cs" Inherits="Sitsa_Proyecto.Reporte_Aceptacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

        <link rel="icon" type="image/png" href="Assets_CTRL/images/icons/login.ico"/><!--Icono Página-->
    <link rel="stylesheet" type="text/css" href="Assets_CTRL/fonts/font-awesome-4.7.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" type="text/css" href="Assets_CTRL/fonts/Linearicons-Free-v1.0.0/icon-font.min.css"/>
    <link rel="stylesheet" type="text/css" href="Assets_CTRL/css/util.css"/>
    <link rel="stylesheet" type="text/css" href="Assets_CTRL/css/main.css"/>
    <link rel="stylesheet" href="Assets_CTRL/css/all.css"/>
    <link rel="stylesheet" type="text/css" href="Assets_CTRL/css/bootstrap.min.css"/>

		<!--===============================================================================================-->
   <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js" integrity="sha384-B4gt1jrGC7Jh4AgTPSdUtOBvfO8shuf57BaghqFfPlYxofvL8/KUEfYiJOMMV+rV" crossorigin="anonymous"></script>
   
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>

    <title></title>
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


<body class="hidden">
      <div id="onload" class="centrado">
   <div class="loadingio-spinner-double-ring-q8rek8psfur"><div class="ldio-v9xjutbhmuj">
<div></div>
<div></div>
<div><div></div></div>
<div><div></div></div>
</div></div></div>
    <style type="text/css">
@keyframes ldio-v9xjutbhmuj {
  0% { transform: rotate(0) }
  100% { transform: rotate(360deg) }
}
.ldio-v9xjutbhmuj div { box-sizing: border-box!important }
.ldio-v9xjutbhmuj > div {
  position: absolute;
  width: 89.60000000000001px;
  height: 89.60000000000001px;
  top: 67.2px;
  left: 67.2px;
  border-radius: 50%;
  border: 4.48px solid #000;
  border-color: #1b252f transparent #1b252f transparent;
  animation: ldio-v9xjutbhmuj 1.7241379310344827s linear infinite;
}
 .centrado{
        background-color: white;
          height: 100vh;
          display: flex;
          justify-content: center;
          align-items: center;
    }
    .hidden {
         overflow: hidden;
    }
.ldio-v9xjutbhmuj > div:nth-child(2), .ldio-v9xjutbhmuj > div:nth-child(4) {
  width: 76.16000000000001px;
  height: 76.16000000000001px;
  top: 73.92px;
  left: 73.92px;
  animation: ldio-v9xjutbhmuj 1.7241379310344827s linear infinite reverse;
}
.ldio-v9xjutbhmuj > div:nth-child(2) {
  border-color: transparent #34495e transparent #34495e
}
.ldio-v9xjutbhmuj > div:nth-child(3) { border-color: transparent }
.ldio-v9xjutbhmuj > div:nth-child(3) div {
  position: absolute;
  width: 100%;
  height: 100%;
  transform: rotate(45deg);
}
.ldio-v9xjutbhmuj > div:nth-child(3) div:before, .ldio-v9xjutbhmuj > div:nth-child(3) div:after { 
  content: "";
  display: block;
  position: absolute;
  width: 4.48px;
  height: 4.48px;
  top: -4.48px;
  left: 38.080000000000005px;
  background: #1b252f;
  border-radius: 50%;
  box-shadow: 0 85.12px 0 0 #1b252f;
}
.ldio-v9xjutbhmuj > div:nth-child(3) div:after {
  left: -4.48px;
  top: 38.080000000000005px;
  box-shadow: 85.12px 0 0 0 #1b252f;
}

.ldio-v9xjutbhmuj > div:nth-child(4) { border-color: transparent; }
.ldio-v9xjutbhmuj > div:nth-child(4) div {
  position: absolute;
  width: 100%;
  height: 100%;
  transform: rotate(45deg);
}
.ldio-v9xjutbhmuj > div:nth-child(4) div:before, .ldio-v9xjutbhmuj > div:nth-child(4) div:after {
  content: "";
  display: block;
  position: absolute;
  width: 4.48px;
  height: 4.48px;
  top: -4.48px;
  left: 31.360000000000003px;
  background: #34495e;
  border-radius: 50%;
  box-shadow: 0 71.68px 0 0 #34495e;
}
.ldio-v9xjutbhmuj > div:nth-child(4) div:after {
  left: -4.48px;
  top: 31.360000000000003px;
  box-shadow: 71.68px 0 0 0 #34495e;
}
.loadingio-spinner-double-ring-q8rek8psfur {
  width: 224px;
  height: 224px;
  display: inline-block;
  overflow: hidden;
  background: none;
}
.ldio-v9xjutbhmuj {
  width: 100%;
  height: 100%;
  position: relative;
  transform: translateZ(0) scale(1);
  backface-visibility: hidden;
  transform-origin: 0 0; /* see note above */
}
.ldio-v9xjutbhmuj div { box-sizing: content-box; }

</style>
        

     <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100 p-l-85 p-r-85 p-t-55 p-b-55" style="zoom:80%";>

                      
              


                 <form id="form1" runat="server">
       
                 

                      <%
                        List<Biblioteca_Clases.Models.Reporte> list = new List<Biblioteca_Clases.Models.Reporte>();
                        list = Datos_Reporte();

                        int autoincrement = 0;
                        foreach (var dato in list)
                        {
                            autoincrement = autoincrement + 1;
                    %>

                     <span class="login100-form-title p-b-32">
                        Reporte #<%=dato.PK_ID_REPORTE%>
                    </span>

                            <%    List<Biblioteca_Clases.Models.Cliente> list2 = new List<Biblioteca_Clases.Models.Cliente>();
                         list2 = Nombre_Cliente_Reporte();

                         int autoincrement2 = 0;
                         foreach (var dato2 in list2)
                         {
                             autoincrement2 = autoincrement2 + 1;

                         %>

                            <div class="form-group">
                            <label>Cliente: </label>
                            <input   type="text" class="form-control" readonly="true" value="<%=dato2.NOMBRE%>" />
                        </div>

                     <%} %>

                         <div class="form-group">
                            <label>Tipo de Reporte: </label>
                            <input   type="text" class="form-control" readonly="true" value="<%=dato.TIPO_DOCUMENTO%>" />
                        </div>

                       <%    List<Biblioteca_Clases.Models.Contrato> list3 = new List<Biblioteca_Clases.Models.Contrato>();
                         list3 = Nombre_Contrato_Proyecto_Reporte();

                         int autoincrement3 = 0;
                         foreach (var dato3 in list3)
                         {
                             autoincrement3 = autoincrement3 + 1;

                         %>

                            <div class="form-group">
                            <label>Nombre de documento: </label>
                            <input   type="text" class="form-control" readonly="true" value="<%=dato3.NOMBRE_CONTRATO%>" />
                        </div>

                     <%} %>

                        <div class="form-group">
                            <label>Observación: </label>
                            <textarea rows="2" class="form-control" readonly="true" ><%=dato.OBSERVACION%></textarea>
                        </div>
                   
                      <%}%>

              



                              <div class="alert alert-info" Visible="false" runat="server" id="Div2">
                    <asp:Label ID="Label3" runat="server" Text="Ya se hizo la verificación"></asp:Label>
                    </div>

                     <br />
                 <div runat="server" id="Div3">
                 <asp:Label Font-Bold="true" CssClass="txt1 p-b-11" ID="Label1" runat="server" Text="Seleccione una opción:"></asp:Label>
                     <br/><br/>
                 <asp:DropDownList CssClass="form-control" AutoPostBack="True" OnTextChanged="Mostrar" ID="DropDownList1" runat="server">
                  <asp:ListItem  Value=""> Seleccione </asp:ListItem>
                  <asp:ListItem Value="Aceptar">Aceptar</asp:ListItem>
                  <asp:ListItem Value="Rechazar">Rechazar</asp:ListItem>
                 </asp:DropDownList>

                     <br/>

                 <div Visible="false" runat="server" id="Div1">
                 <asp:Label CssClass="txt1 p-b-11" ID="Label2" runat="server" Text="Ingrese el motivo:"></asp:Label>
                     <br/><br/>
                 <asp:TextBox CssClass="form-control" TextMode="MultiLine" ID="TextBox1" runat="server"></asp:TextBox>
                 </div>

                     <br/>

                      <div class="container-login100-form-btn">
                            <asp:Button CssClass="login100-form-btn" OnClick="Cambio" ID="Button1" runat="server" Text="Confirmar" />
                    </div>


               
                </div>
        </form>
                   
                 
                
            </div>
            
        </div>
    </div>
    
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


        window.onload = function () {
        $('#onload').fadeOut();
        $('body').removeClass('hidden');
    }

</script>
