<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Maestra.Master" AutoEventWireup="true" CodeBehind="Man_Cliente.aspx.cs" Inherits="WebApplication2.Man_Cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="styles" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="Assets_CTRL/js/Funciones_Paginas/Cliente.js"></script>

 

     <div class="container-mant">


    <div style="margin-right: auto;"> <!--Cabecera-->
      <h3 class="text-left">
       <i class="fas fa-user-check color-icono" aria-hidden="true"></i>&nbsp; Clientes
     </h3>
     <p class="text-justify txt5">
   Mantenimiento para el manejo y control de la información de los clientes.
         </p>
  </div><!--Fin Cabecera-->

  <br>

<!-- Contenido -->
  <div class="container">

   <div id="accordion">
        <div class="card">

<div class="collapse hide" id="collapseServicios" aria-expanded="false" aria-labelledby="headingOne" data-parent="#accordion">
  <div id="prueba11" class="card card-body txt2">

                        <div style="display: none; text-align: center;" id="error_campos_vacios_servicios" class="alert alert-warning">
                            <strong>¡Cuidado!</strong> Campos sin completar.
                        </div>

    <p id="parrafo_servicio">Asignar nuevo servicio</p>
      <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    

        <div class="row">

         <div  id="campo_consecutivo" style="" class="col-12 col-md-12">

          <div  class="form-group">
            <label> Cliente:</label>

                
                 <input readonly="readonly" name="Cliente" id="Cliente" class="form-control">

              <br/>

               <label> Seleccionar servicio:</label>

              <select onchange="Validar_Campo_Servicio()" id="Servicio"  lang="es" class="js-example-responsive" style="width:100%;"  name="state">
                          <option selected value="two" disabled>  </option>

      <%

          Biblioteca_Clases.DAO.ServicioDAO dao3 = new Biblioteca_Clases.DAO.ServicioDAO();

          List<Biblioteca_Clases.Models.Servicio> list3 = dao3.listaServicios();

          int autoincrement3 = 0;

          foreach (var dato in list3)
          {
              autoincrement3 = autoincrement3 + 1;

                 %>
  <option value="<%=dato.ID_SERVICIO%>"><%=dato.DESCRIPCION%></option>
   
           <%} %>
                    </select>
              
          </div>

        </div>


    

             <div class="col-12 col-md-12">

          <div class="form-group">
              <label> Agregar tarifa:</label>
                 
            <input onblur="Validar_Campo_Servicio()" maxlength="25" id="Tarifa" class="form-control">

          </div>

        </div>

      </div>

         <div id="boton_enviar" style="display: block; text-align: center">

       <button disabled id="boton_enviar_serv"  onclick="Agregar()"  type="button" class="popup-btn">Asignar</button>
             </div>


      <br> 


        <p>Servicios del cliente</p>
           <table id="tabla-mant1" class="table table-striped table-bordered" style="width:100%;"><!--Tabla-->

        <thead class="estilo-thead">
          <tr>
            <th>ID</th>
            <th>Descripción</th>
            <th>Tarifa por hora</th>  
            <th>Eliminar</th>
   
          </tr>
        </thead>



        <tbody>    
        </tbody>

                 </table><!--Fin Tabla-->

                  <p>Contratos del cliente</p>

                  <table id="tabla-mant2" class="table table-striped table-bordered" style="width:100%;"><!--Tabla-->

        <thead class="estilo-thead">
          <tr>
            <th>Consecutivo</th>
            <th>Nombre de contrato</th>
            <th>Detalles</th>
          </tr>
        </thead>

        <tbody> </tbody>





                 </table><!--Fin Tabla-->


               <p>Proyectos del cliente</p>
           <table id="tabla-mant3" class="table table-striped table-bordered" style="width:100%;"><!--Tabla-->

        <thead class="estilo-thead">
          <tr>
            <th>Consecutivo</th>
            <th>Nombre del proyecto</th>
            <th>Detalles</th>
          </tr>
        </thead>

        <tbody>

          

                     </tbody>

                 </table><!--Fin Tabla-->
  </div>
</div>
   

                </div>




      <!--Segundo collapse-->

      <div id="collapseTwo" aria-expanded="false" class="collapse" aria-labelledby="headingTwo" data-parent="#accordion">
      <div id="prueba112" class="card card-body txt2">

          <div style="display: none; text-align: center;" id="error_campos_vacios" class="alert alert-warning">
                            <strong>¡Cuidado!</strong> Contacto sin seleccionar.
                        </div>


      <p id="parrafo_contacto">Asignar nuevo contacto</p>
    
        <div class="row">

         <div  id="a" style="" class="col-12 col-md-12">

          <div  class="form-group">
            <label> Seleccionar Contacto:</label>


               <select onchange="Validar_Campo()" id="Contacto_cliente"  lang="es" class="js-example-responsive" style="width:100%;"  name="state">
                          <option selected value="two" disabled>  </option>

      <%
          Biblioteca_Clases.DAO.ContactoDAO dao2 = new Biblioteca_Clases.DAO.ContactoDAO();
          List<Biblioteca_Clases.Models.Contacto> list2 = dao2.listaContactos();
          int autoincrement2 = 0;
          foreach (var dato in list2)
          {
              autoincrement2 = autoincrement2 + 1;
                 %>
  <option value="<%=dato.ID_CONTACTO%>"><%=dato.ENCARGADO%></option>
   
           <%} %>
                    </select> 

                        <br/> <br/>
              <div id="boton_contacto" style="display: block; text-align: center">
                <button disabled onclick="Agregar_Contacto()" id="boton_agregar_contacto"  type="button" class="popup-btn">Asignar</button>
             </div>


          </div>
             <p>Contactos del cliente</p>
           <table id="tabla-mant6" class="table table-striped table-bordered" style="width:100%;"><!--Tabla-->

        <thead class="estilo-thead">
          <tr>
            <th>ID</th>
            <th>Encargado</th>
            <th>Teléfono</th>
            <th>Correo</th>
            <th>Tipo de Encargado</th>
            <th>Eliminar</th>
          </tr>
        </thead>

        <tbody>  
            

        </tbody>

                 </table><!--Fin Tabla-->

                 
        </div>


        </div>
  </div>
</div>




       </div>






  <br>

       <table id="tabla-mant" class="table table-striped table-bordered" style="width:100%;"><!--Tabla-->

        <thead class="estilo-thead">
          <tr>
            <th>ID cliente</th>
            <th>Nombre de Cliente</th>
                      <% if (Permisos.CREAR == true)
                          {

            %>
            <th>Asignar Servicio</th>
            <th>Asignar Contacto</th>
               <%}%>
          </tr>
        </thead>

        <tbody>

             <%

                 Biblioteca_Clases.DAO.ClienteDAO dao = new Biblioteca_Clases.DAO.ClienteDAO();

                 List<Biblioteca_Clases.Models.Cliente> list = dao.listaClientes();

                 int autoincrement = 0;

                 foreach (var dato in list)
                 {
                     autoincrement = autoincrement + 1;

                 %>

          <tr class="txt2">
            <td><%=dato.ID_CLIENTE%></td>
            <td><%=dato.NOMBRE%></td>
                       <% if (Permisos.CREAR == true)
                           {

            %>
             <td onclick="Cliente(<%=dato.ID_CLIENTE%>)" style="text-align: center"> <a  class="btn btn-link collapsed" data-toggle="collapse" data-target="#collapseServicios" aria-expanded="false" aria-controls="collapseServicios"" href="#" /><i class="fa fa-plus-circle color-icono" aria-hidden="true"/></td>
            <td style="text-align: center;"><a onclick="AsignarCLiente(<%=dato.ID_CLIENTE%>)" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo" href="#"><i class="fa fa-id-badge color-icono" aria-hidden="true"/></a></td>
                 <%}%>
              </tr>  

               <%}%>

                     </tbody>

                     <tfoot class="estilo-thead">
                      <tr>
                       <th>ID cliente</th>
                       <th>Nombre de Cliente</th>
                          <% if (Permisos.CREAR == true)
                              {

            %>
                       <th>Asignar Servicio</th>
                       <th>Asignar Contacto</th>
 <%}%>
                     </tr>
                   </tfoot>

                 </table><!--Fin Tabla-->

               </div> <!--Container-->

             </div>  <!--Container mant-->

      <script type="text/javascript">

          $('#Tarifa').on('input', function (e) {
              if (!/^[ 0-9]*$/i.test(this.value)) {
                  this.value = this.value.replace(/[^ 0-9]+/ig, "");
              }
          });

      </script>

</asp:Content>
