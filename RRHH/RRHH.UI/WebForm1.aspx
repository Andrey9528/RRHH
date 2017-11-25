<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="RRHH.UI.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <title>Empleado</title>
     <link href="https://www.javatpoint.com/fullformpages/images/Medical.png" rel="shortcut icon" type="image/x-icon" />

<%--<script type="text/javascript">
     
        function Alerta() {
            alert('Tecuerda  cambiar tu contraseña al menos una vez cada tres meses: '+"<br>"+ <%= "Cantidad de días restamtes: "+RRHH.UI.Login.EmpleadoGlobal.DiasAntesCaducidad%>);
        }
     
    </script>--%>
</head>
<body>
    <style>
       body 
        {
            background-image: url("http://1070noticias.com.mx/wp-content/uploads/2016/07/fondos-de-pantalla-blancos-para-descargar.jpg");
            background-attachment:fixed;
            background-size:100vw 100vh ;
            


        }
     
 </style>
    <form runat="server">
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
   
 <nav style="margin-top:-20px;  background-color:#04acec; color:white;" class=" navbar-inverse">
  <div class="container-fluid">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>                        
      </button>
      <a class="navbar-brand" style="color:white;" href="#">Empleado</a>
    </div>
    <div class="collapse navbar-collapse" id="myNavbar">
      <ul class="nav navbar-nav">
        
        <li class="dropdown">
          
          <a class="dropdown-toggle" data-toggle="dropdown" href="#" style= "background-color:#04acec; font-size:14px; color:white; font-family:cursive;">Perfil <span class="caret"></span></a>
          <ul class="dropdown-menu">

            <li><a style="  font-family:cursive;   " data-target="#Miperfil" data-toggle="modal"  href="#">Perfil </a></li>  
          
          <li><a style="  font-family:cursive; " href="ModificarDatosVistaEmpleado.aspx" >Actualizar perfil</a></li> 
           
          </ul>
        </li>

           <li class="dropdown">
          
          <a class="dropdown-toggle" data-toggle="dropdown" href="#" style="background-color:#04acec; font-size:14px; color:white; font-family:cursive;">Incapacidades <span class="caret"></span></a>
          <ul class="dropdown-menu">

            <li><a  href="insertarIncapacidad.aspx">Registrar</a></li>
            <li><a  href="ConsultaIncapacidades.aspx">Consulta</a></li>
           
          </ul>
        </li>
            <li class="dropdown">
          
          <a class="dropdown-toggle" data-toggle="dropdown" style="font-size:14px;  background-color:#04acec; color:white; font-family:cursive;" href="#">Vacaciones <span class="caret"></span></a>
          <ul class="dropdown-menu">

            <li><a data-toggle="modal"  data-target="#vaca"  href="#">Solicitud</a></li>
             <li><a  href="consultaVacaciones.aspx">Consulta</a></li>
            
          </ul>
        </li>

        
          <li style="font-family:cursive;"><asp:LinkButton OnClick="LKB_Ayuda_Click" ForeColor="White"    ID="LKB_Ayuda" runat="server">Ayuda</asp:LinkButton></li>
           <li class="dropdown">
          
          <a class="dropdown-toggle"  style="background-color:#04acec; font-size:14px;  color:white; font-family:cursive;" data-toggle="dropdown" href="#">Administración<span class="caret"></span></a>
          <ul  class="dropdown-menu">
            <li><a data-target="#cambioEmpleado" data-toggle="modal"  href="#">Cambio de contraseña</a></li>
             <li> 
                 <asp:LinkButton OnClick="LbSesion_Click" ID="LbSesion" runat="server">Cerrar sesión</asp:LinkButton>
         </li>
                  </ul>
       
        </li>

          
      
      </ul>
  
      <ul class="nav navbar-nav navbar-right">
         <li>
               <a style="color:white;" href="#"><span style="color:white;" class="glyphicon glyphicon-log-out "></span> Salir</a>
           </li>
      </ul>
    </div>
  </div>
</nav>

    <br />
  
<div class="container text-center">    
  <div class="row">
    <div class="col-sm-3 well">
      <div class="well">
          <p>
              <asp:Label ID="lblNombre2" runat="server" ></asp:Label>

          </p>
       <%-- <p><a  href="#">Mi perfil</a></p>--%>

      <asp:Image ID="Image1" Width="80px" Height="80px"  CssClass="img-circle" runat="server" />
     
     
           </div>
      <div class="well">



        <h6 style="font-family:Arial, Helvetica, sans-serif;">Mis Datos</h6>

          <div class="form-horizontal">
              <div style="font-family:Arial, Helvetica, sans-serif;"><asp:Label ID="lblcorreo2"    CssClass="control-label" runat="server" ></asp:Label>
              <asp:Label ID="lbldirreccion2" runat="server" Text=""></asp:Label>
              <asp:Label ID="lblGenero2" runat="server" Text=""></asp:Label>
                  </div>

          </div>

       <%-- <p>
          <span class="label label-default">News</span>
          <span class="label label-primary">W3Shools</span>
          <span class="label label-success">Labels</span>
          <span class="label label-info">Football</span>
          <span class="label label-warning">Gaming</span>
          <span class="label label-danger">Friends</span>
        </p>--%>

          
      </div>
      <%--<div class="alert alert-success fade in">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">×</a>
        <p><strong>Ey!</strong></p>
        People are looking at your profile. Find out who.
      </div>--%>
     <%-- <p><a href="#">Link</a></p>
      <p><a href="#">Link</a></p>
      <p><a href="#">Link</a></p>--%>
    </div>
    <div class="col-sm-7">
    
     <%-- <div class="row">
        <div class="col-sm-12">
          <div class="panel panel-default text-left">
            <div class="panel-body">
              <p contenteditable="true">Status: Feeling Blue</p>
              <button type="button" class="btn btn-default btn-sm">
                <span class="glyphicon glyphicon-thumbs-up"></span> Like
              </button>     
            </div>
          </div>
        </div>
      </div>--%>
      
      <div class="row">
        <div class="col-sm-3">
          <div class="well">
           <p>Misión</p>
           <img src="Images/icono-mision.png" class="img-circle  " height="55" width="60" alt="Avatar"/>
          </div>
        </div>
        <div class="col-sm-9">
          <div class="well">
            <p style="font-family:Arial, Helvetica, sans-serif;" >Somos una empresa dedicada a la excelencia en el servicio como tambien preocupada por la mejoria de salud en todos nuestros clientes.</p>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-sm-3">
          <div class="well">
           <p>Visión</p>
           <img src="Images/icono-Vision.png" class="img-circle" height="55" width="60" alt="Avatar"/>
          </div>
        </div>
        <div class="col-sm-9">
          <div class="well">
            <p style="font-family:Arial, Helvetica, sans-serif;">Ser la farmacia con la mejor calidad de servicio, producto y compromiso con sus clientes y colaboradores.</p>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-sm-3">
          <div class="well">
           <p>Sistema RRHH</p>
           <img src="Images/^88D82C5E5CC0B0B42C7F3BB75E1910BA0497497AC6B7AF664E^pimgpsh_fullsize_distr.jpg" class="img-circle" height="55" width="75" alt="Avatar"/>
          </div>
        </div>
        <div class="col-sm-9">
          <div class="well">
            <p style="font-family:Arial, Helvetica, sans-serif;">Solicite vacaciones,incapacidades</p>
          </div>
        </div>
      </div>
           
    </div>
    <div class="col-sm-2 well">
      <div class="thumbnail">
        <p>Contáctenos:</p>
        <img src="Images/^3D0DC1289D3BDF88217B01A82B7D97BC5426586684389B6CE5^pimgpsh_fullsize_distr.jpg" width="200" height="600"/>
        <p><strong>Farmacias San Gabriel</strong></p>
        <p>Teléfono:24462046</p>
       
      </div>      
     
    </div>
  </div>
</div>

        <hr />
        <footer class="text-center">
           Sistema de Recursos Humanos
        </footer>



        
     <script type="text/javascript"  >
        function popupCerrarPerfil()
        {
            $('#MiPerfil').modal('hide');
        }
    </script>

     <div class="container"  >
  
  <div class="modal fade" data-keyboard="false" data-backdrop="static" id="Miperfil" role="dialog">
    <div class="modal-dialog modal-md " style="margin-top:110px;">
      <div class="modal-content "  style="">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Mi Perfil</h4>
        </div>
        <div class="modal-body"> 
            <div class="container">
                <div class="row">
                    <div class="col-sm-4">

            <asp:Label ID="lblnombre" runat="server" Text="Nombre:"></asp:Label>
            <br />
            <asp:Label ID="lblCedula" runat="server" Text="Cedula"></asp:Label>
            <br />
            <asp:Label ID="lblDirreccion" runat="server" Text="Dirección:"></asp:Label>
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
            <br />
              <br />
                    </div>

                    <div class="col-sm-4">
<div style=""><asp:Image ID="imgPerfil" Width="170px" Height="120px" runat="server" />
                </div>
                    </div>
                </div>
                <br />
               
            </div>   
        
<%--             <asp:Label ID="lblRol" runat="server" Text="Rol:"></asp:Label>--%>
            
             <footer class="col-sm-offset-8">
               <p>&copy; <%: DateTime.Now.Month %>  Farmacias San Gabriel</p></footer>
            
        </div>
        <div class="modal-footer">
          <%--<button  type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>--%> 
           <div ><asp:Button ID="btnsalir" CssClass="btn btn-warning" runat="server" Text="Salir"  OnClick="btnsalir_Click" />
        </div>
            </div>
      </div>
    </div>
  </div>
         </div>
<%--</div>--%>


    <div class="container">
  
 
  <div class="modal fade" data-keyboard="false" data-backdrop="static" id="vaca" role="dialog">
       
    <div class="modal-dialog modal-sm">
       
      <div class="modal-content">
          
        <div class="modal-header">
          
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Solicitud de vacaciones</h4>
        </div>
        <div class="modal-body">
          
    <asp:Label ID="Label4" runat="server" Text="Fecha de Inicio:"></asp:Label>
    <asp:TextBox ID="txtfechadeincio"  TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>


    <asp:Label ID="Label5" runat="server" Text="Fecha Final:"></asp:Label>
    <asp:TextBox ID="txtfechafinal"  TextMode="Date" CssClass="form-control" runat="server" ></asp:TextBox>
        

            <br />
            <asp:Label ID="lblSaldoVaca" runat="server" ></asp:Label>
        </div>
        <div class="modal-footer">
            
          <asp:Button ID="btnvaca" runat="server" Text="Insertar" CssClass="btn btn-success" OnClick="btnvaca_Click"  />
         

            <asp:Button OnClick="CerrarPopupVaca_Click" CssClass="btn btn-danger" ID="CerrarPopupVaca" runat="server" Text="Cerrar" />
        </div>
      </div>
    </div>
  </div>
        </div>


     <script type="text/javascript"  >
        function popup()
        {
            $('#cambioEmpleado').modal('show');
        }
    </script>
 <div class="container">
          <div class="row">
              <div class="col-xs-12">
                  <%--<button class="btn btn-primary btn-sm pull-right" data-target="#olvide" data-toggle="modal">Popup</button>--%>
                  <div class="modal fade"  data-keyboard="false" data-backdrop="static" id="cambioEmpleado"  tabindex="-1">
                      <div class="modal-dialog modal-sm">
                          <div class="modal-content" style="margin-top:100px;">
                              <div class="modal-header">
                                  <button class="close"  data-dismiss="modal">&times;</button>
                                  <h4 class="model-tittle">Cambio de contraseña</h4>


                              </div>
                              <div  class="modal-body">
                             <div class="form-group">
                             
                                 <asp:Label ID="Label1" runat="server" Text="Digita tu contraseña actual:"></asp:Label>
                                  <asp:TextBox ID="txtContraseñaActualEmpleado" TextMode="Password" runat="server" CssClass="form-control"  placeholder="Contraseña"></asp:TextBox>
                                       
                                 <p style="margin-top:10px;">  
                                     
                                     <asp:Button ID= "btnConfirmarEmpleado" runat="server" Text="Confirmar" CssClass="btn btn-warning" OnClick="btnConfirmarEmpleado_Click" /> </p>
                                 <br/> <br/>
                                 <asp:Label ID="Label2" runat="server" Text="Nueva contraseña"></asp:Label>
                                 <asp:TextBox ID="txtNuevaContraseña" Enabled="false" TextMode="Password" CssClass="form-control"  runat="server" placeholder="@Ejemplo123"></asp:TextBox>
<%--                                 <asp:CheckBox ID="ChkVerContraseña" OnCheckedChanged="ChkVerContraseña_CheckedChanged" runat="server" />--%>
                                 <asp:Label ID="Label3" runat="server"  Text="Confirmar contraseña"></asp:Label>
                                 <asp:TextBox ID="txtNuevaContraseñaConfirmar" Enabled="false" TextMode="Password" CssClass="form-control" runat="server" placeholder="Confirmar contraseña" ></asp:TextBox>
<%--                                 <asp:CheckBox ID="ChkVerContraseña2" runat="server" />--%>
                             
                                     </div>
                             <div class="form-group">
                                 
                                 
                              </div>
                              </div>
                              <div class="modal-footer">
                              
                                  <asp:Button ID="btnCambiarEmpleado" CssClass ="btn btn-success" Enabled="false" OnClick="btnCambiarEmpleado_Click" runat="server"  Text="Cambiar" />
                                  <asp:Button ID="btnSalirEmpleado" data-dismiss="modal" CssClass="btn btn-danger" OnClick="btnSalirEmpleado_Click"  runat="server"  Text="Salir" />
                              
                                      </div>

                          </div>
                      </div>
                  </div>
              </div>
          </div>
      </div> 



    <script type="text/javascript">

        function CerrarPopup() {
            $('#btnsalir').click(function () {
                $('#Miperfil').modal('hide');
            });
        }
    </script>
        </form>
</body>
</html>
