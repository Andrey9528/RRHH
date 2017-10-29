<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JefeAyuda.aspx.cs" Inherits="RRHH.UI.JefeAyuda" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RRHH</title>
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
   <link href="https://www.javatpoint.com/fullformpages/images/Medical.png" rel="shortcut icon" type="image/x-icon" />

</head>
<body>
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
    <form id="form1" runat="server">
    <h1 style="text-align:center; font-family:cursive; font-size:30px;">Tutoriales en Video</h1>

    <br /><br />
    <div class="container">    
  <div class="row">
    <div class="col-sm-4">
      <div class="panel panel-primary">
        <div class="panel-heading">Ver perfil y modificar</div>
        <div class="panel-body">
            <video width="400" controls="controls"><source src="Videos/Jefe/PerfilJefe.mp4" type="video/mp4"/></video>

        </div>
        <div class="panel-footer"><asp:Button ID="btnReportar"  OnClick="btnReportar_Click" CssClass="btn btn-link" runat="server" Text="Descargar tutorial" /> </div>
      </div>
    </div>
    <div class="col-sm-4"> 
      <div class="panel panel-primary">
        <div class="panel-heading">Cambio de Contraseña</div>
        <div class="panel-body">
          <video width="400" controls="controls"><source src="Videos/Jefe/CambioContraseñaJefe.mp4" type="video/mp4"/></video>
    
        </div>
        <div class="panel-footer">
            <asp:LinkButton ID="LKB_Reporte" runat="server">Descargar Tutorial</asp:LinkButton></div>
      </div>
    </div>
    <div class="col-sm-4"> 
      <div class="panel panel-primary">
        <div class="panel-heading">Gestión de Vacaciones</div>
        <div class="panel-body">
            
          <video width="400" controls="controls"><source  src="Videos/Jefe/AproVacaciones.mp4" type="video/mp4"/></video>

        </div>
        <div class="panel-footer"><asp:LinkButton ID="LKB_Reporte2" runat="server">Descargar Tutorial</asp:LinkButton></div>
      </div>
    </div>
  </div>
</div><br />

<div class="container">    
  <div class="row">
    <div class="col-sm-4">
      <div class="panel panel-primary">
        <div class="panel-heading">Lista de empleados</div>
        <div class="panel-body">
          <video width="400" controls="controls"><source src="Videos/Jefe/JefeListarEmpleados.mp4" type="video/mp4"/></video>
    
        </div>
        <div class="panel-footer"><asp:LinkButton ID="LKB_Reporte3" runat="server">Descarga Tutorial </asp:LinkButton></div></div>
    </div>
    <div class="col-sm-4"> 
      <div class="panel panel-primary">
        <div class="panel-heading">Lista de Incapacidades</div>
        <div class="panel-body">
          <video width="400" controls="controls"><source src="Videos/Jefe/VacacionesJefe.mp4" type="video/mp4"/></video>
    
        </div>
        <div class="panel-footer"><asp:LinkButton ID="LKB_Reporte4" runat="server">Descarga Tutorial</asp:LinkButton></div>
      </div>
    </div>
    <div class="col-sm-4"> 
      <div class="panel panel-primary">
        <div class="panel-heading">Vista General</div>
        <div class="panel-body">
          <video width="400" controls="controls"><source src="Videos/RegistroIncapacidadEditado.mp4" type="video/mp4"/></video>
    
        </div>
        <div class="panel-footer"><asp:LinkButton ID="LKB_Reporte5" runat="server">Descarga Tutorial</asp:LinkButton></div>
      </div>
    </div>
  </div>
</div>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnRegresar" CssClass="btn btn-primary" OnClick="btnRegresar_Click" runat="server" Text="Regresar" />

    </form>
</body>
</html>
