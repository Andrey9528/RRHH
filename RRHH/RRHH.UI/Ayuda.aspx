<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ayuda.aspx.cs" Inherits="RRHH.UI.Ayuda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">




<style>
video {
    width: 100%;
    height: auto;
}
</style>
   
   <style>
       body 
        {
            background-image: url("http://1070noticias.com.mx/wp-content/uploads/2016/07/fondos-de-pantalla-blancos-para-descargar.jpg");
            background-attachment:fixed;
            background-size:100vw 100vh;
            


        }
     
 </style>
        

<h1 style="text-align:center; font-family:cursive; font-size:30px;">Tutoriales en Video</h1>

    <br /><br />
    <div class="container">    
  <div class="row">
    <div class="col-sm-4">
      <div class="panel panel-primary">
        <div class="panel-heading">Ver perfil y modificar</div>
        <div class="panel-body">
            <video width="400" controls><source src="Videos/Empleado/Perfil.mp4" type="video/mp4"></video>

        </div>
        <div class="panel-footer"><asp:Button ID="btnReportar" OnClick="btnReportar_Click" CssClass="btn btn-link" runat="server" Text="Descargar tutorial" /> </div>
      </div>
    </div>
    <div class="col-sm-4"> 
      <div class="panel panel-danger">
        <div class="panel-heading">Gestión de incapacidades</div>
        <div class="panel-body">
          <video width="400" controls><source src="Videos/Empleado/IncapacidadesEmpleado.mp4" type="video/mp4"></video>
    
        </div>
        <div class="panel-footer">
            <asp:LinkButton ID="LKB_Reporte" runat="server">Descargar Tutorial</asp:LinkButton></div>
      </div>
    </div>
    <div class="col-sm-4"> 
      <div class="panel panel-success">
        <div class="panel-heading">Gestión de Vacaciones</div>
        <div class="panel-body">
            
          <video width="400" controls><source  src="Videos/Empleado/VacacionesEmpleado.mp4" type="video/mp4"></video>

        </div>
        <div class="panel-footer"><asp:LinkButton ID="LKB_Reporte2" runat="server">Descargar Tutorial</asp:LinkButton></div>
      </div>
    </div>
  </div>
</div><br>

<div class="container">    
  <div class="row">
    <div class="col-sm-4">
      <div class="panel panel-primary">
        <div class="panel-heading">Cambio de contraseña</div>
        <div class="panel-body">
          <video width="400" controls><source src="Videos/Empleado/CambioContrase_a.mp4" type="video/mp4"></video>
    
        </div>
        <div class="panel-footer"><asp:LinkButton ID="LKB_Reporte3" runat="server">Descarga Tutorial </asp:LinkButton></div></div>
    </div>
    <div class="col-sm-4"> 
      <div class="panel panel-primary">
        <div class="panel-heading">Olvidé Contraseña</div>
        <div class="panel-body">
          <video width="400" controls><source src="Videos/RegistroIncapacidadEditado.mp4" type="video/mp4"></video>
    
        </div>
        <div class="panel-footer"><asp:LinkButton ID="LKB_Reporte4" runat="server">Descarga Tutorial</asp:LinkButton></div>
      </div>
    </div>
    <div class="col-sm-4"> 
      <div class="panel panel-primary">
        <div class="panel-heading">Vista General</div>
        <div class="panel-body">
          <video width="400" controls><source src="Videos/Empleado/EmpleadoGeneral.mp4" type="video/mp4"></video>
    
        </div>
        <div class="panel-footer"><asp:LinkButton ID="LKB_Reporte5" runat="server">Descarga Tutorial</asp:LinkButton></div>
      </div>
    </div>
  </div>
</div>
    &nbsp;&nbsp;&nbsp;<asp:Button ID="btnRegresar" CssClass="btn btn-primary" OnClick="btnRegresar_Click" runat="server" Text="Regresar" />
     

</asp:Content>
