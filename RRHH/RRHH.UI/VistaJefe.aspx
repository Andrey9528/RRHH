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

    <nav class="navbar navbar-inverse visible-xs">
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
           
        <li><a  href="#">Perfil</a></li>
           <li><a  href="#">Actualizar Perfil</a></li>
        <li><a href="#">Lista de empleados</a></li>
        <li><a  href="#">Lista de Incapacidades</a></li>
          <li><a  href="#">Ver solicitudes</a></li>
            <li><a  href="#">Cambio de  contraseña</a></li>
          <li><a  href="#">Cerrar seccion</a></li>
          <li><a  href="#">Salir</a></li>

               </ul>
    </div>
  </div>
</nav>
      
<div class="container-fluid">
  <div class="row content">
    <div class="col-sm-3 sidenav hidden-xs">
      <h2 style="text-align:center;">
          <asp:Image ID="imgPerfil2" Width="100" Height="100" runat="server" /></h2>
      <ul class="nav nav-pills nav-stacked">
         <li class="active"><a  href="VistaJefe.aspx">Menú</a></li>
           
        <li><a data-target="#Miperfil" data-toggle="modal" href="#">Perfil</a></li>
           <li><a   href="ModificarDatosVistaEmpleado.aspx">Actualizar Perfil</a></li>
        <li><a   href="ListarEmpleados.aspx">Lista de empleados</a></li>
        <li><a  href="ListaIncapacidades.aspx">Lista de Incapacidades</a></li>
          <li><a   href="mantenimientoVaca.aspx">Ver solicitudes</a></li>
            <li><a data-target="#cambiojefe" data-toggle="modal"  href="#">Cambio de  contraseña</a></li>
          <li><a  href="Login.aspx">Cerrar seccion</a></li>
          <li><a   href="#">Ayuda</a></li>
     
      </ul><br/>
    </div>
    <br/>
    
    <div class=" col-sm-9">
      <div   style="background-image:url(Images/^3D0DC1289D3BDF88217B01A82B7D97BC5426586684389B6CE5^pimgpsh_fullsize_distr.jpg); background-size:100vw 100vh;"  class="well ">
        <h4 style="color:black; font-size:30px; font-family:cursive; text-align:center;" >Dashboard</h4>
        <p style="color:black; text-align:center;">Some text..</p>
          
      </div>
      <div class="row">
        <div class="col-sm-3">
          <div class="well">
            <h4>Empleados</h4>
            <p>n# de empleados</p> 
          </div>    
        </div>
        <div class="col-sm-3">
          <div class="well">
            <h4>Pages</h4>
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
      </div>
      <div class="row">
        <div class="col-sm-8">
          <div class="well">
            <p>Text</p> 
          </div>
        </div>
        <div class="col-sm-4">
          <div class="well">
            <p>Text</p> 
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
                                  <h4 class="model-tittle">Olvidé mi contraseña</h4>


                              </div>
                              <div   class="modal-body">
                             <div class="form-group">
                                 <asp:Label ID="Label1" runat="server" Text="Digita tu contraseña actual:"></asp:Label>
                                  <asp:TextBox ID="txtContraseñaActualJefe" TextMode="Password" runat="server" CssClass="form-control"  placeholder="Contraseña"></asp:TextBox>      
                                 <p style=" margin-top:5px;"> <asp:Button ID= "btnConfirmarJefe"   runat ="server" Text="Confirmar" CssClass="btn btn-warning" OnClick="btnConfirmarJefe_Click" /> </p>
                                 <br/> <br/>
                                 <asp:Label ID="Label2" runat="server" Text="Nueva contraseña"></asp:Label>
                                 <asp:TextBox ID="txtNuevaContraseña" Enabled="false" TextMode="Password" CssClass="form-control"  runat="server" placeholder="Nueva contraseña"></asp:TextBox>
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
            <br />
             <asp:Label ID="lblRol" runat="server" Text="Rol:"></asp:Label>
            <br />
            <p style="margin-left:280px; margin-top:-155px;">
                <asp:Image ID="imgPerfil" Width="150px" Height="120px" runat="server" />
                
            </p>






        </div>
        <div class="modal-footer">
          <button style="" type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
        </div>
      </div>
    </div>
  </div>
</div>


    
    </form>
</body>
</html>
