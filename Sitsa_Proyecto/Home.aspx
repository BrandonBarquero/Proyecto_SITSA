<%@ Page Title="" Language="C#" MasterPageFile="~/Pagina_Maestra.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Control_Visitas.WebForm1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="styles" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="container-home">
	  
			<!-- Page Header -->
			<div class="#">
				<h3 class="text-left">
				<i class="fas fa-door-open color-icono"></i> &nbsp; Bienvenido
				</h3>
				<p class="text-justify txt5">
					Lorem ipsum dolor sit amet, consectetur adipisicing elit. Suscipit nostrum rerum animi natus beatae ex. Culpa blanditiis tempore amet alias placeat, obcaecati quaerat ullam, sunt est, odio aut veniam ratione.
				</p>
			</div>
			
			<!-- Contenido -->
			<div class="full-box tile-container" style="zoom: 80%;">

				
                    <%int clientes = Contar_Cliente(); int usuarios = Contar_Usuarios(); int contratos = Contar_Contratos(); int servicios = Contar_Servicios(); int proyectos = Contar_Proyectos(); int cierre_mes = Contar_Cierre_Mes(); %>

                        

				<a href="Man_Cliente.aspx" class="tile">
					<div class="tile-tittle txt1">Clientes</div>
					<div class="tile-icon">
						<i class="fas fa-users fa-fw color-icono"></i>
						<p class="txt3"><%=clientes%> Registrados</p>
					</div>
				</a>

					<a href="Man_Usuario.aspx" class="tile">
					<div class="tile-tittle txt1">Usuarios</div>
					<div class="tile-icon">
				    <i class="fas fa-user-friends color-icono"></i>
						<p class="txt3"><%=usuarios%> Registrados</p>
					</div>
				</a>

				<a href="Man_Contrato.aspx" class="tile">
					<div class="tile-tittle txt1">Contratos</div>
					<div class="tile-icon">
						<i class="fas fa-file-contract color-icono"></i>
						<p class="txt3"><%=contratos%> Registrados</p>
					</div>
				</a>

				<a href="Man_Servicio.aspx" class="tile">
					<div class="tile-tittle txt1">Servicios</div>
					<div class="tile-icon">
						<i class="fas fa-file-invoice-dollar fa-fw color-icono"></i>
						<p class="txt3"><%=servicios%> Registrados</p>
					</div>
				</a>

				<a href="Man_Proyecto.aspx" class="tile">
					<div class="tile-tittle txt1">Proyectos</div>
					<div class="tile-icon">
					<i class="fas fa-drafting-compass color-icono"></i>
						<p class="txt3"><%=proyectos%> Registrada</p>
					</div>
				</a>
				
				<a href="Cierre_Mes.aspx" class="tile">
					<div class="tile-tittle txt1">Cierre de mes</div>
					<div class="tile-icon">
					<i class="fas fa-calendar-times color-icono"></i>
						<p class="txt3"><%=cierre_mes%> Registrada</p>
					</div>
				</a>

			</div> <!--Fin Contenido-->
			
	</div> <!--Fin contenedor Home-->
</asp:Content>
