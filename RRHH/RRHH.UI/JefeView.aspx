<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JefeView.aspx.cs" Inherits="RRHH.UI.JefeView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <style >
        body 
        {
            background-image: url("http://1070noticias.com.mx/wp-content/uploads/2016/07/fondos-de-pantalla-blancos-para-descargar.jpg");
            background-attachment:fixed;
            background-size:100vw 100vh ;
            


        }
         
    
  

    </style>

<%--<ul class="nav nav-pills nav-justified ">
  <li class="active"><a data-toggle="pill" href="#">Inicio</a></li>
  <li><a data-toggle="pill" href="#">Perfil</a></li>
  <li><a data-toggle="pill" href="#">Mensajes</a></li>
</ul>--%>
<%--<ul class="nav nav-pills">
   
   
   
   
    <li class="dropdown pull-right">
        <a href="#" data-toggle="dropdown" class="dropdown-toggle">Administración <b class="caret"></b></a>
        <ul class="dropdown-menu">

               <li><a data-target="#cambiojefe" data-toggle="modal" href="#">Cambio de contraseña</a></li>

             <li><a href="#">Ayuda</a></li>
            <li><a href="Login.aspx">Cerrar Sesión</a></li>
            
            <li class="divider"></li>
        </ul>
    </li>
</ul>
   

      <ol id="menu" >
    <li><a href="JefeView.aspx">Home</a></li>
    <li><a  href="#">Perfil</a>

        <ul>
            <li><a data-target="#Miperfil" data-toggle="modal" href="#">Ver mi perfil</a></li>
            <li><a  href="ModificarDatosVistaEmpleado.aspx">Actualizar perfil</a></li>
        
        </ul>
    </li>
    <li>
        <a href="#">Empleados</a>
        <ul>
            <li><a href="ListarEmpleados.aspx">Lista empleados</a></li>
            
        </ul>
    </li>
    <li>
      
    </li>
    <li>
        <a href="#">Incapacidades</a>
        <ul>
            <li><a href="ListaIncapacidades.aspx"> Lista incapacidades</a></li>
           
        </ul>
    </li>
    <li>
        <a href="#">Vacaciones</a>
        <ul>
            
             <li><a href="mantenimientoVaca.aspx">Ver solicitudes</a></li>
            
            
        </ul>
    </li>
           
    

    
</ol>
    --%>
     <nav   style=" border-radius:10px; background-color:#04acec; color:white;"   class="  navbar-inverse col-sm-9 col-sm-offset-1 ">
  <div class="container-fluid"  >
        <div class="navbar-header">	
          <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>                        
          </button>
      
    </div>
  
    <div class="collapse navbar-collapse" id="myNavbar">
      <ul class="nav navbar-nav">
        <li class=""><a style="background-color:#04acec; font-size:14px; color:white; font-family:cursive;" href="JefeView.aspx">Home</a></li>

           <li class="dropdown">
          
          <a class="dropdown-toggle" data-toggle="dropdown" href="#" style= "background-color:#04acec; font-size:14px; color:white; font-family:cursive;">Perfil <span class="caret"></span></a>
          <ul class="dropdown-menu">

            <li><a style="  font-family:cursive;  " data-target="#Miperfil" data-toggle="modal"  href="#">Perfil </a></li>  
          
          <li><a style="  font-family:cursive; " href="ModificarDatosVistaEmpleado.aspx" >Actualizar perfil</a></li> 
           
          </ul>
        </li>
         
        <li class="dropdown">
          
          <a class="dropdown-toggle" data-toggle="dropdown" href="#" style="background-color:#04acec; font-size:14px; color:white; font-family:cursive;">Empleados <span class="caret"></span></a>
          <ul class="dropdown-menu">

            <li><a  href="ListarEmpleados.aspx">Lista de empleados</a></li>
            
          </ul>
        </li>
          <li class="dropdown">
          
         
        </li>
           <li class="dropdown">
          
          <a class="dropdown-toggle" data-toggle="dropdown" style="font-size:14px;  background-color:#04acec; color:white; font-family:cursive;" href="#">Incapacidades <span class="caret"></span></a>
          <ul class="dropdown-menu">

        <li><a  href="ListaIncapacidades.aspx">Lista de incapacidades</a></li>
            
            
          </ul>
        </li>
        <li class="dropdown">
          
          <a class="dropdown-toggle" data-toggle="dropdown" style="font-size:14px;  background-color:#04acec; color:white; font-family:cursive;" href="#">Vacaciones <span class="caret"></span></a>
          <ul class="dropdown-menu">

            <li><a  href="mantenimientoVaca.aspx">Ver solicitudes</a></li>
            	
            
          </ul>
        </li>
           
          
        <li><a style="color:white; font-size:14px; " href="Ayuda.aspx">Ayuda</a></l>
        <li class="dropdown">
          
          <a class="dropdown-toggle"  style="background-color:#04acec; font-size:14px;  color:white; font-family:cursive;" data-toggle="dropdown" href="#">Administración<span class="caret"></span></a>
          <ul  class="dropdown-menu">
            <li><a data-target="#cambiojefe" data-toggle="modal"  href="#">Cambio de contraseña</a></li>
            <li><a  href="Login.aspx">Cerrar sesión</a></li>
            
          </ul>
       
        </li>
           <li>
               <a style="color:white;" href="Login.aspx"><span style="color:white;" class="glyphicon glyphicon-log-out "></span> Salir</a>
           </li>
      
       
      </ul>
        
       
     
    </div>
  </div>
</nav>
 
     
    
    
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
                                 <p style="margin-left:300px; margin-top:-35px;"> <asp:Button ID= "btnConfirmarJefe"   runat ="server" Text="Confirmar" CssClass="btn btn-warning" OnClick="btnConfirmarJefe_Click" /> </p>
                                 <br> <br>
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
  
  <div class="modal fade" id="Miperfil" role="dialog">
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
                <asp:Image ID="imgPerfil" Width="170px" Height="120px" runat="server" />
                
            </p>






        </div>
        <div class="modal-footer">
          <button style="margin-top:-30px;" type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
        </div>
      </div>
    </div>
  </div>
</div>
    <%-- Actualizar mi perfil --%>
     <div class="container"  >
  
  <div class="modal fade" id="updatePerfil" role="dialog">
    <div class="modal-dialog modal-sm">
      <div class="modal-content " style=" margin-top:130px; margin-left:35px; height:300px; width:500px;">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Mi Perfil</h4>
        </div>
        <div class="modal-body">
 
            <asp:TextBox ID="txtnombre" CssClass="form-control" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtcedula" CssClass="form-control" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtdirreccion" CssClass="form-control" runat="server"></asp:TextBox>
           <br />
             <asp:TextBox ID="txttelefono" CssClass="form-control" runat="server"></asp:TextBox>
           <br />
             <asp:TextBox ID="txtcorreo" CssClass="form-control" runat="server"></asp:TextBox>
           <br />
             
            <asp:TextBox ID="txtestadocivil" CssClass="form-control" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtfechanaci" CssClass="form-control" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtdepa" CssClass="form-control" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtrol" CssClass="form-control" runat="server"></asp:TextBox>
            
           
            <p style="margin-left:280px; margin-top:-155px;">
                
                <asp:FileUpload ID="fileUpload1" accept="image/*"  runat="server" />
                </p>






        </div>
        <div class="modal-footer">
          <button style="margin-top:-30px;" type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
        </div>
      </div>
    </div>
  </div>
</div>




     <style>
        .navbar2 {
      margin-bottom: 0;
      border-radius: 0;
    }
    
   
     
  .carousel-inner img {
      width: 100%; /* Set width to 100% */
      margin: auto;
      max-height:400px;
  }
      .col-sm-4  {
      width:33%;
      height:100%;
      }
      .well p  {
     text-align:center;
     width:100%;
     height:100%;
     color:red;
      }
  

  /* Hide the carousel text when the screen is less than 600 pixels wide */
  @media (max-width: 600px) {
    .carousel-caption {
      display: none; 
    }
  }
    </style>


    <br />

<div id="myCarousel" class="carousel slide" data-ride="carousel">
    <!-- Indicators -->
    <ol class="carousel-indicators">
      <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
      <li data-target="#myCarousel" data-slide-to="1"></li>
      <li data-target="#myCarousel" data-slide-to="2"></li>
    </ol>

    <!-- Wrapper for slides -->
    <div class="carousel-inner" role="listbox">
      <div class="item active">
        <img src="Images/^BAB9AE299E8BA8FD8EB5E52078106B4C4357E19194980363CD^pimgpsh_fullsize_distr.png"   alt="Image">
        <div class="carousel-caption">
          
          
        </div>      
      </div>

      <div class="item">
        <img src="Images/^3D0DC1289D3BDF88217B01A82B7D97BC5426586684389B6CE5^pimgpsh_fullsize_distr.jpg" alt="Image">
        <div class="carousel-caption">
         
          
        </div>      
      </div>

        <div class="item">
        <img src="Images/bombillo.jpg" alt="Image">
        <div class="carousel-caption">
         
         
        </div>      
      </div>
    </div>

    <!-- Left and right controls -->
    <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
      <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
      <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
      <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
      <span class="sr-only">Next</span>
    </a>
</div>
    
     <br />
            <footer style="">
                <p>&copy; <%: DateTime.Now.Year %>  RRHH</p>
            </footer>
</asp:Content>
