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
        .video-container {
	position:relative;
	padding-bottom:56.25%;
	padding-top:30px;
	height:0;
	overflow:hidden;
}

.video-container iframe, .video-container object, .video-container embed {
	position:absolute;
	top:0;
	left:0;
	width:100%;
	height:100%;
}
    </style>
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
           <div class="video-container">
               <iframe width="230" src="https://www.youtube.com/embed/TBZ12TpsHaU" frameborder="0" gesture="media" allowfullscreen></iframe>
           </div>
        </div>
        <div class="panel-footer"><asp:Button ID="btnReportar"  OnClick="btnReportar_Click" CssClass="btn btn-link" runat="server" Text="Descargar tutorial" /> </div>
      </div>
    </div>
    <div class="col-sm-4"> 
      <div class="panel panel-primary">
        <div class="panel-heading">Cambio de Contraseña</div>
        <div class="panel-body">
         <div class="video-container">
             <iframe width="230" src="https://www.youtube.com/embed/e-aaJcam64E" frameborder="0" gesture="media" allowfullscreen></iframe>
         </div>
        </div>
        <div class="panel-footer">
            <asp:LinkButton ID="LKB_ReporteCambioContraseña" OnClick="LKB_ReporteCambioContraseña_Click" runat="server">Descargar Tutorial</asp:LinkButton></div>
      </div>
    </div>
    <div class="col-sm-4"> 
      <div class="panel panel-primary">
        <div class="panel-heading">Gestión de Vacaciones</div>
        <div class="panel-body">
            
        <div class="video-container">
            <iframe width="230" src="https://www.youtube.com/embed/gW_of6SQHAc" frameborder="0" gesture="media" allowfullscreen></iframe>
        </div>       
        </div>
        <div class="panel-footer"><asp:LinkButton ID="GestionVaca" OnClick="GestionVaca_Click" runat="server">Descargar Tutorial</asp:LinkButton></div>
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
         <div class="video-container">
             <iframe width="230" src="https://www.youtube.com/embed/A_g2JmuCW7k" frameborder="0" gesture="media" allowfullscreen></iframe>
         </div>
        </div>
        <div class="panel-footer"><asp:LinkButton ID="ReportelistaEmple" OnClick="ReportelistaEmple_Click" runat="server">Descarga Tutorial </asp:LinkButton></div></div>
    </div>
    <div class="col-sm-4"> 
      <div class="panel panel-primary">
        <div class="panel-heading">Lista de Incapacidades</div>
        <div class="panel-body">
          <div class="video-container">
              <iframe width="230" src="https://www.youtube.com/embed/0H43Uis8leE" frameborder="0" gesture="media" allowfullscreen></iframe>
          </div>
        </div>
        <div class="panel-footer"><asp:LinkButton ID="ReporteInca" OnClick="ReporteInca_Click" runat="server">Descarga Tutorial</asp:LinkButton></div>
      </div>
    </div>
    <div class="col-sm-4"> 
      <div class="panel panel-primary">
        <div class="panel-heading">Vista General</div>
        <div class="panel-body">
         <div class=" video-container">
             <iframe width="230"  src="https://www.youtube.com/embed/3JxNjOc0BXw" frameborder="0" gesture="media" allowfullscreen></iframe>
         </div>
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
