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
           <div class="video-container"><iframe width="230"  src="https://www.youtube.com/embed/Xr3Zp54woI4" frameborder="0" gesture="media" allowfullscreen></iframe>
               </div>
        </div>
        <div class="panel-footer"><asp:Button ID="btnReportar" OnClick="btnReportar_Click" CssClass="btn btn-link" runat="server" Text="Descargar tutorial" /> </div>
      </div>
    </div>
    <div class="col-sm-4"> 
      <div class="panel panel-danger">
        <div class="panel-heading">Gestión de incapacidades</div>
        <div class="panel-body">
         <div class="video-container"> <iframe width="230"  src="https://www.youtube.com/embed/68z0i8oejRk" frameborder="0" gesture="media" allowfullscreen></iframe>
        </div>
         </div>
        <div class="panel-footer">
            <asp:LinkButton ID="LKB_ReporteInca" OnClick="LKB_ReporteInca_Click" runat="server">Descargar Tutorial</asp:LinkButton></div>
      </div>
    </div>
    <div class="col-sm-4"> 
      <div class="panel panel-success">
        <div class="panel-heading">Gestión de Vacaciones</div>
        <div class="panel-body">
            
          <div class="video-container"><iframe width="230" src="https://www.youtube.com/embed/wlqKvR6fbHs" frameborder="0" gesture="media" allowfullscreen></iframe>
        </div>
          </div>
        <div class="panel-footer"><asp:LinkButton ID="LKB_ReporteVaca" OnClick="LKB_ReporteVaca_Click" runat="server">Descargar Tutorial</asp:LinkButton></div>
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
          <div class="video-container">  <iframe width="230"  src="https://www.youtube.com/embed/wd0QNhPys68" frameborder="0" gesture="media" allowfullscreen></iframe>

        </div>
          
        </div>
        <div class="panel-footer"><asp:LinkButton ID="LKB_ReporteContrasena" OnClick="LKB_ReporteContrasena_Click" runat="server">Descarga Tutorial </asp:LinkButton></div></div>
    </div>
    <div class="col-sm-4"> 
      <div class="panel panel-primary">
        <div class="panel-heading">Olvidé Contraseña</div>
        <div class="panel-body">
            <div class="video-container">
        <iframe width="230"src="https://www.youtube.com/embed/xRQfR1xiUtM" frameborder="0" gesture="media" allowfullscreen></iframe>
        </div>
            </div>
        <div class="panel-footer"><asp:LinkButton ID="LKB_ReporteOlvideContrasena" OnClick="LKB_ReporteOlvideContrasena_Click" runat="server">Descarga Tutorial</asp:LinkButton></div>
      </div>
    </div>
    <div class="col-sm-4"> 
      <div class="panel panel-primary">
        <div class="panel-heading">Vista General</div>
        <div class="panel-body">
        <div class="video-container"> <iframe width="230" src="https://www.youtube.com/embed/nFgXzZGOqQY" frameborder="0" gesture="media" allowfullscreen></iframe>
        </div>
        </div>
        <div class="panel-footer"><asp:LinkButton ID="LKB_Reporte5" runat="server">Descarga Tutorial</asp:LinkButton></div>
      </div>
    </div>

        



       

       
  </div>
</div>
    &nbsp;&nbsp;&nbsp;<asp:Button ID="btnRegresar" CssClass="btn btn-primary" OnClick="btnRegresar_Click" runat="server" Text="Regresar" />
     


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
</asp:Content>
