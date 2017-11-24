<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaJefe.aspx.cs" Inherits="RRHH.UI.VistaJefe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vista Jefe</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
 <link href="https://www.javatpoint.com/fullformpages/images/Medical.png" rel="shortcut icon" type="image/x-icon" />

</head>

<body>

    <form id="form1" runat="server">
         <%--<div class="form-group">
         <div class="alert alert-danger" visible="false"  id="mensajeError" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
             <strong id="textomensajeError" runat="server"></strong>
        </div>
        <div class="alert alert-success" visible="false"  id="mensaje" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
             <strong id="textoMensaje" runat="server"></strong>
        </div>
           <div class="alert alert-warning" visible="false" id="mensajawarning" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
            <strong id="textomensajewarning" runat="server"></strong>

        </div>
      <div class="alert alert-info" visible="false"  id="mensajeinfo" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
             <strong id="textomensajeinfo" runat="server"></strong>
        </div>
          </div>--%>
  <style>
    /* Set height of the grid so .sidenav can be 100% (adjust as needed) */
    .row.content {height: 550px}
    
    /* Set gray background color and 100% height */
    .sidenav {
      background-color: #f1f1f1;
      height: 100%;
    }
        
    /* On small screens, set height to 'auto' for the grid */
    @media screen and (max-width: 767px) {
      .row.content {height: auto;} 
    }
        body 
        {
            background-image: url("http://1070noticias.com.mx/wp-content/uploads/2016/07/fondos-de-pantalla-blancos-para-descargar.jpg");
            background-attachment:fixed;
            background-size:100vw 100vh ;
        }
  </style>

    <nav class="navbar navbar-inverse visible-xs" style="margin-top:-20px;">
  <div class="container-fluid">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>                        
      </button>
      <a class="navbar-brand" href="#">Jefe Departamento</a>
     
    </div>
    
    <div class="collapse navbar-collapse" id="myNavbar">
      <ul class="nav navbar-nav">
          
         <li class="active"><a  href="#">Menú</a></li>
           
        <li><a data-target="#Miperfil" data-toggle="modal" href="#">Perfil</a></li>
           <li><a  href="ModificarDatosVistaEmpleado.aspx">Actualizar Perfil</a></li>
        <li><a href="ListarEmpleados.aspx">Lista de empleados</a></li>
        <li><a  href="ListaIncapacidades.aspx">Lista de Incapacidades</a></li>
          <li><a  href="mantenimientoVaca.aspx">Ver solicitudes</a></li>
          <li><a href="#" data-toggle="modal"  data-target="#vaca">Solicitud de vacaciones</a></li>
            <li><a href="ConsultaVacacionesJefe.aspx">Consulta de vacaciones</a></li>
            <li><a href="insertarIncapacidad.aspx">Registrar incapacidad</a></li>
           <li><a href="ConsultaIncaJefe.aspx">Consulta de incapacacidad</a></li>
            <li><a  data-target="#cambiojefe" data-toggle="modal"  href="#">Cambio de  contraseña</a></li>
            <li><asp:LinkButton ID="LinkButton1" OnClick="LKB_AyudaJefe_Click" runat="server">Ayuda</asp:LinkButton></li>
           <li><asp:LinkButton ID="LinkButton2" OnClick="LKB_JefeSesion_Click" runat="server">Cerrar sesión</asp:LinkButton></li>
         
          
               </ul>
    </div>
  </div>
</nav>
      
<div class="container-fluid">
  <div class="row content">
    <div class="col-sm-3 sidenav hidden-xs" style="margin-top:-19px;">
      <h2 style="text-align:center;">
          <asp:Image ID="imgPerfil2" Width="100" Height="100" runat="server" /></h2>
      <ul class="nav nav-pills nav-stacked">
         <li class="active"><a  href="#">Menú</a></li>
           
        <li><a data-target="#Miperfil" data-toggle="modal" href="#">Perfil</a></li>
           <li><a   href="ModificarDatosVistaEmpleado.aspx">Actualizar Perfil</a></li>
        <li><a   href="ListarEmpleados.aspx">Lista de empleados</a></li>
        <li><a  href="ListaIncapacidades.aspx">Lista de Incapacidades</a></li>
          <li><a   href="mantenimientoVaca.aspx">Ver solicitudes</a></li>
           <li><a href="#" data-toggle="modal"  data-target="#vaca">Solicitud de vacaciones</a></li>
            <li><a href="ConsultaVacacionesJefe.aspx">Consulta de vacaciones</a></li>
            <li><a href="insertarIncapacidad.aspx">Registrar incapacidad</a></li>
           <li><a href="ConsultaIncaJefe.aspx">Consulta de incapacacidad</a></li>
            <li><a data-target="#cambiojefe" data-toggle="modal"  href="#">Cambio de  contraseña</a></li>
          <li><asp:LinkButton ID="LKB_AyudaJefe" OnClick="LKB_AyudaJefe_Click" runat="server">Ayuda</asp:LinkButton></li>
           <li><asp:LinkButton ID="LKB_JefeSesion" OnClick="LKB_JefeSesion_Click" runat="server">Cerrar sesión</asp:LinkButton></li>
         
     
      </ul><br/>
    </div>
    <br/>
    
    <div class=" col-sm-9">

         <div class="form-group">
         <div class="alert alert-danger" visible="false"  id="mensajeError" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
             <strong id="textomensajeError" runat="server"></strong>
        </div>
        <div class="alert alert-success" visible="false"  id="mensaje" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
             <strong id="textoMensaje" runat="server"></strong>
        </div>
           <div class="alert alert-warning" visible="false" id="mensajawarning" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
            <strong id="textomensajewarning" runat="server"></strong>

        </div>
      <div class="alert alert-info" visible="false"  id="mensajeinfo" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
             <strong id="textomensajeinfo" runat="server"></strong>
        </div>
          </div>
      <div   style="background-image:url(Images/^3D0DC1289D3BDF88217B01A82B7D97BC5426586684389B6CE5^pimgpsh_fullsize_distr.jpg); background-size:100vw 100vh;"  class="well ">
        <h4 style="color:black; font-size:30px; font-family:cursive; text-align:center;" >Gestión de Empleados</h4>
        <p style="color:black; text-align:center;">RRHH</p>
          
      </div>
      
       <style>
* {box-sizing: border-box;}
ul {list-style-type: none;}
body {font-family: Verdana, sans-serif;}

.month {
    padding: 70px 25px;
    width: 100%;
    background: #1abc9c;
    text-align: center;
}

.month ul {
    margin: 0;
    padding: 0;
}

.month ul li {
    color: white;
    font-size: 20px;
    text-transform: uppercase;
    letter-spacing: 3px;
}

.month .prev {
    float: left;
    padding-top: 10px;
}

.month .next {
    float: right;
    padding-top: 10px;
}

.weekdays {
    margin: 0;
    padding: 10px 0;
    background-color: #ddd;
}

.weekdays li {
    display: inline-block;
    width: 13.6%;
    color: #666;
    text-align: center;
}

.days {
    padding: 10px 0;
    background: #eee;
    margin: 0;
}

.days li {
    list-style-type: none;
    display: inline-block;
    width: 13.6%;
    text-align: center;
    margin-bottom: 5px;
    font-size:12px;
    color: #777;
}

.days li .active {
    padding: 5px;
    background: #1abc9c;
    color: white !important
}

/* Add media queries for smaller screens */
@media screen and (max-width:720px) {
    .weekdays li, .days li {width: 13.1%;}
}

@media screen and (max-width: 420px) {
    .weekdays li, .days li {width: 12.5%;}
    .days li .active {padding: 2px;}
}

@media screen and (max-width: 290px) {
    .weekdays li, .days li {width: 12.2%;}
}
</style>


     
<div class="month">      
  <ul>
    <li class="prev">&#10094;</li>
    <li class="next">&#10095;</li>
    <li>
      Noviembre<br/>
      <span style="font-size:18px">2017</span>
    </li>
  </ul>
</div>

<ul class="weekdays">
  <li>Miércoles</li>
  <li>Jueves</li>
  <li>Viernes </li>
  <li>Sábado</li>
  <li>Domingo </li>
  <li>Lunes</li>
  <li>Martes</li>
</ul>

<ul class="days">  
  <li>1</li>
  <li>2</li>
  <li>3</li>
  <li>4</li>
  <li>5</li>
  <li><span class="active">6</span></li>
  <li>7</li>
  <li>8</li>
  <li>9</li>
  <li>10</li>
  <li>11</li>
  <li>12</li>
  <li>13</li>
  <li>14</li>
  <li>15</li>
  <li>16</li>
  <li>17</li>
  <li>18</li>
  <li>19</li>
  <li>20</li>
  <li>21</li>
  <li>22</li>
  <li>23</li>
  <li>24</li>
  <li>25</li>
  <li>26</li>
  <li>27</li>
  <li>28</li>
  <li>29</li>
  <li>30</li>
  
</ul>

    <%--  <div class="row">
        <div class="col-sm-3">
          <div class="well">
            <h4>Empleados</h4>
            <p>n# de empleados</p> 
          </div>    
        </div>
        <div class="col-sm-3">
          <div class="well">
            <h4>Incapacidades</h4>
            <p>100 Million</p> 
          </div>
        </div>
        <div class="col-sm-3">
          <div class="well">
            <h4>Sessions</h4>
            <p>10 Million</p> 
          </div>
        </div>
        <div class="col-sm-3">
          <div class="well">
            <h4>Bounce</h4>
            <p>30%</p> 
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-sm-4">
          <div class="well">
            <p>Text</p> 
            <p>Text</p> 
            <p>Text</p> 
          </div>
        </div>
        <div class="col-sm-4">
          <div class="well">
            <p>Text</p> 
            <p>Text</p> 
            <p>Text</p> 
          </div>
        </div>
        <div class="col-sm-4">
          <div class="well">
            <p>Text</p> 
            <p>Text</p> 
            <p>Text</p> 
          </div>
        </div>
      </div>--%>
        <br />
      
      <div class="row">

        <div class="col-sm-8">
          <div class="well">
            <p style="font-family:cursive;">2017 RRHH Farmacia San Gabriel</p> 
          </div>
        </div>
       
      </div>
    </div>
  </div>
</div>

          <div class="container">
          <div class="row">
              <div class="col-xs-12">
                  <%--<button class="btn btn-primary btn-sm pull-right" data-target="#olvide" data-toggle="modal">Popup</button>--%>
                  <div class="modal fade"  data-keyboard="false" data-backdrop="static" id="cambiojefe"    tabindex="-1">
                      <div class="modal-dialog modal-sm">
                          <div class="modal-content" style="margin-top:100px;">
                              <div class="modal-header">
                                  <button class="close"  data-dismiss="modal">&times;</button>
                                  <h4 class="model-tittle">Cambio de contraseña</h4>


                              </div>
                              <div   class="modal-body">
                             <div class="form-group">
                                 <asp:Label ID="Label1" runat="server" Text="Digita tu contraseña actual:"></asp:Label>
                                  <asp:TextBox ID="txtContraseñaActualJefe" TextMode="Password" runat="server" CssClass="form-control"  placeholder="Contraseña"></asp:TextBox>      
                                 <p style=" margin-top:5px;"> <asp:Button ID= "btnConfirmarJefe"   runat ="server" Text="Confirmar" CssClass="btn btn-warning" OnClick="btnConfirmarJefe_Click" /> </p>
                                 <br/> <br/>
                                 <asp:Label ID="Label2" runat="server" Text="Nueva contraseña"></asp:Label>
                                 <asp:TextBox ID="txtNuevaContraseña" Enabled="false" TextMode="Password" CssClass="form-control"  runat="server" placeholder="@Ejemplo123"></asp:TextBox>
                                <%--<asp:CheckBox ID="ChkVerContraseña" OnCheckedChanged="ChkVerContraseña_CheckedChanged" runat="server" />--%>
                                 <asp:Label ID="Label3" runat="server"  Text="Confirmar contraseña"></asp:Label>
                                 <asp:TextBox ID="txtNuevaContraseñaConfirmar" Enabled="false" TextMode="Password" CssClass="form-control" runat="server" placeholder="Confirmar contraseña" ></asp:TextBox>
                                <%--<asp:CheckBox ID="ChkVerContraseña2" runat="server" />--%>
                             </div>
                             <div class="form-group">
                                 
                                 
                              </div>
                              </div>
                              <div class="modal-footer">
                                  <asp:Button ID="btnCambiarJefe" CssClass="btn btn-success" Enabled="false" runat="server" OnClick="btnCambiarJefe_Click" Text="Cambiar" />
                                  <asp:Button ID="btnSalirJefe" CssClass="btn btn-danger" data-dismiss="modal" OnClick="btnSalirJefe_Click" runat="server"  Text="Salir" />
                              </div>

                          </div>
                      </div>
                  </div>
              </div>
          </div>
      </div>
    
    <script type="text/javascript"  >
        function popup()
        {
            $('#cambiojefe').modal('show');
        }
    </script>
        <script type="text/javascript"  >
        function popupCerrarPerfil()
        {
            $('#MiPerfil').modal('hide');
        }
    </script>

           <div class="container"  >
  
  <div class="modal fade" data-keyboard="false" data-backdrop="static" id="Miperfil" role="dialog">
    <div class="modal-dialog modal-sm">
      <div class="modal-content " style=" margin-top:130px; margin-left:35px; height:300px; width:500px;">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Mi Perfil</h4>
        </div>
        <div class="modal-body">
            <asp:Label ID="lblnombre" runat="server" Text="Nombre:"></asp:Label>
            <br />
            <asp:Label ID="lblCedula" runat="server" Text="Cedula"></asp:Label>
            <br />
            <asp:Label ID="lblDirreccion" runat="server" Text="Dirrección:"></asp:Label>
            <br />
             <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label>
            <br />
             <asp:Label ID="lblCorreo" runat="server" Text="Correo:"></asp:Label>
            <br />
             <asp:Label ID="lblestadocivil" runat="server" Text="Estado Civil:"></asp:Label>
            <br />
             <asp:Label ID="lblfechaNaci" runat="server" Text="Fecha de nacimiento:"></asp:Label>
            <br />
             <asp:Label ID="lbldepa" runat="server" Text="Departamento:"></asp:Label>
         
            
            <p style="margin-left:280px; margin-top:-155px;">
                <asp:Image ID="imgPerfil" Width="150px" Height="120px" runat="server" />
                
            </p>






        </div>
        <div class="modal-footer">
            
            <asp:Button ID="btnCerarPopup" runat="server" Text="Cerrar" OnClick="btnCerarPopup_Click" CssClass="btn btn-warning" />
        </div>
      </div>
    </div>
  </div>
</div>



         <div class="container">
  
 
  <div class="modal fade" data-keyboard="false" data-backdrop="static" id="vaca" role="dialog">
       
    <div class="modal-dialog modal-sm">
       
      <div class="modal-content">
          
        <div class="modal-header">
          
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Solicitud de vacaciones</h4>
        </div>
        <div class="modal-body">
          
    <asp:Label ID="Label7" runat="server" Text="Fecha de Inicio:"></asp:Label>
    <asp:TextBox ID="txtfechadeincio"  TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>


    <asp:Label ID="Label8" runat="server" Text="Fecha Final:"></asp:Label>
    <asp:TextBox ID="txtfechafinal"  TextMode="Date" CssClass="form-control" runat="server" ></asp:TextBox>
        

            <br />
            <asp:Label ID="lblSaldoVaca" runat="server" ></asp:Label>
        </div>
        <div class="modal-footer">
            
          <asp:Button ID="btnvaca" runat="server" Text="Insertar" CssClass="btn btn-success" OnClick="btnvaca_Click"  />
            <asp:Button ID="btnCerrarPopupVaca" OnClick="btnCerrarPopupVaca_Click" CssClass="btn btn-danger" runat="server" Text="Cerrar" /> 
         
        </div>
      </div>
    </div>
  </div>
        </div>


    
    </form>
</body>
</html>
