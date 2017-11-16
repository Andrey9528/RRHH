<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminView.aspx.cs" Inherits="RRHH.UI.AdminView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <style>
        body 
        {
            background-image: url("http://1070noticias.com.mx/wp-content/uploads/2016/07/fondos-de-pantalla-blancos-para-descargar.jpg");
            background-attachment:local;
            background-size:100vw 100vh ;
            background-color:transparent;
            


        }
     
         
        #menu, #menu ul {
        margin: 0;
        padding: 0;
        list-style: none;
    }

    #menu {
        width: 920px;
        margin: 60px auto;
        /*border: 1px solid #222;*/
      
        background-color:#2dadf7; 
        /*background-image: linear-gradient(#444, #111);*/
        border-radius: 10px;
        /*box-shadow: 0 1px 1px #777;*/
        margin-top: -40px;
        margin-left:-20px;
    }

        #menu:before,
        #menu:after {
            content: "";
            display: table;
        }

        #menu:after {
            clear: both;
        }

    #menu {
        zoom: 1;
    }

        #menu li {
            float: left;
            border-right: 0.5px solid #222;
            border-right-color:white;
            /*box-shadow: 1px 0 0 #444;*/
            position: relative;
        }

        #menu a {
            float: left;
            padding: 12px 30px;
            color: white;
            /*text-transform: uppercase;*/
            font-family:cursive;
            text-decoration: none;
            /*text-shadow: 0 1px 0 #000;*/
        }

        #menu li:hover > a {
            color:#fafafa;
        }

    html #menu li a:hover {
        /* IE6 only */ color:#fafafa;
    }

    #menu ul {
        margin: 20px 0 0 0;
        _margin: 0; /*IE6 only*/
        opacity: 0;
        visibility: hidden;
        position: absolute;
        top: 38px;
        left: 0;
        z-index: 1;
        /*background: #444;*/
        background-color:#04acec;   
        /*background: linear-gradient(#444, #111);
        box-shadow: 0 -1px 0 rgba(255,255,255,.3);*/
        border-radius: 3px;
        transition: all .2s ease-in-out;
    }

    #menu li:hover > ul {
        opacity: 1;
        visibility: visible;
        margin: 0;
    }

    #menu ul ul {
        top: 0;
        left: 150px;
        margin: 0 0 0 20px;
        _margin: 0; /*IE6 only*/
        box-shadow: -1px 0 0 rgba(255,255,255,.3);
    }

    #menu ul li {
        float: none;
        display: block;
        border: 0;
        _line-height: 0; /*IE6 only*/
        box-shadow: 0 1px 0 #111, 0 2px 0 #666;
    }

        #menu ul li:last-child {
            box-shadow: none;
        }

    #menu ul a {
        padding: 10px;
        width: 130px;
        _height: 10px; 
        display: block;
        white-space: nowrap;

      /*float:left;*/
        text-transform: none;
    }


        #menu ul a:hover {
            background-color: #0186ba;
            background-image: linear-gradient(#04acec, #0186ba);
        }

    #menu ul li:first-child > a {
        border-radius: 3px 3px 0 0;
    }

        #menu ul li:first-child > a:after {
            content: '';
            position: absolute;
            left: 40px;
            top: -6px;
            border-left: 6px solid transparent;
            border-right: 6px solid transparent;
            border-bottom: 6px solid #444;
        }

    #menu ul ul li:first-child a:after {
        left: -6px;
        top: 50%;
        margin-top: -6px;
        border-left: 0;
        border-bottom: 6px solid transparent;
        border-top: 6px solid transparent;
        border-right: 6px solid #3b3b3b;
    }

    #menu ul li:first-child a:hover:after {
        border-bottom-color: #04acec;
    }

    #menu ul ul li:first-child a:hover:after {
        border-right-color: #0299d3;
        border-bottom-color: transparent;
    }

    #menu ul li:last-child > a {
        border-radius: 0 0 3px 3px;
    }

    </style>
     <div class="form-group">


         
      <div class="alert alert-success" visible="false"  id="mensaje" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
             <strong id="textoMensaje" runat="server"></strong>
        </div>
        <div class="alert alert-danger" visible="false" id="mensajeError" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
            <strong id="textoMensajeError" runat="server"></strong>

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

   
        
            
 <div  style="margin-top:-3px;" >
 <img class="img-responsive img-rounded "  width="144" height="236"  src="Images/^88D82C5E5CC0B0B42C7F3BB75E1910BA0497497AC6B7AF664E^pimgpsh_fullsize_distr.jpg"/>
   
     </div>
           
        
   <nav   style="margin-top:-40px;   border-radius:10px; background-color:#04acec; color:white;"   class="  navbar-inverse col-sm-10 col-sm-offset-2 ">
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
        <li class="active" >
            

       <div style="margin-top:16px;">
           <asp:LinkButton ID="LnkHome" ForeColor="White" OnClick="LnkHome_Click" runat="server">Home</asp:LinkButton>
            </div>
            

        </li>
                   
          <li class="dropdown">
          
          <a class="dropdown-toggle" data-toggle="dropdown" href="#" style= "background-color:#04acec; font-size:14px; color:white; font-family:cursive;">Perfil <span class="caret"></span></a>
          <ul class="dropdown-menu">

            <li><a style="  font-family:cursive;   " data-target="#Miperfil" data-toggle="modal"  href="#">Perfil </a></li>  
          
          <li><a style="  font-family:cursive; " href="ModificarDatosVistaEmpleado.aspx" >Actualizar perfil</a></li> 
           
          </ul>
        </li>
         
        <li class="dropdown">
          
          <a class="dropdown-toggle" data-toggle="dropdown" href="#" style="background-color:#04acec; font-size:14px; color:white; font-family:cursive;">Empleados <span class="caret"></span></a>
          <ul class="dropdown-menu">
            
                
            <li><a  href="RegistroEmpleado.aspx">Agregar</a></li>
            <li><a  href="mantenimientoEmpleados.aspx">Mantenimiento</a></li>
           
          </ul>
        </li>
          <li class="dropdown">
          
         
        </li>
           <li class="dropdown">
          
          <a class="dropdown-toggle" data-toggle="dropdown" style="font-size:14px;  background-color:#04acec; color:white; font-family:cursive;" href="#">Incapacidades <span class="caret"></span></a>
          <ul class="dropdown-menu">

            <li><a href="insertarIncapacidad.aspx">Registrar incapacidades</a></li>
              <li><a href="ConsultaIncapacidadesAdmin.aspx">Consulta de incapacidades</a></li>
              <li><a  href="MantenimientoIncapacidades.aspx">Mantenimiento</a></li>
            
          </ul>
        </li>
           <li class="dropdown">
          
          <a class="dropdown-toggle"  data-toggle="dropdown" style="font-size:14px;  background-color:#04acec; color:white;    font-family:cursive;" href="#">Vacaciones <span class="caret"></span></a>
          <ul class="dropdown-menu">
            <li><a href="#" data-toggle="modal"  data-target="#vaca">Solicitud de vacaciones</a></li>
            <li><a href="ConsultaVacacionesAdmin.aspx">Consulta de vacaciones</a></li>
            <li><a  href="adminVacas.aspx">Mantenimiento</a></li>
            
          </ul>
        </li>
           <li class="dropdown">
          
          <a class="dropdown-toggle"  style="background-color:#04acec; color:white; font-size:14px;  font-family:cursive;" data-toggle="dropdown" href="#">Departamentos<span class="caret"></span></a>
          <ul  class="dropdown-menu">
            <li><a data-toggle="modal" data-target="#depa"  href="#">Registrar</a></li>
            <li><a  href="MantenimientoDepa.aspx">Mantenimiento</a></li>
            
          </ul>
        </li>
        <li style="font-family:cursive ">
            <asp:LinkButton ForeColor="White" ID="LKB_AyudaAdmin" OnClick="LKB_AyudaAdmin_Click" runat="server">Ayuda</asp:LinkButton></li>
        <li class="dropdown">
          
          <a class="dropdown-toggle"  style="background-color:#04acec; font-size:14px;  color:white; font-family:cursive;" data-toggle="dropdown" href="#">Administración<span class="caret"></span></a>
          <ul  class="dropdown-menu">
              <li>
                  <asp:LinkButton ID="LKB_Auditorias" OnClick="LKB_Auditorias_Click" runat="server">Auditorias</asp:LinkButton></li>
            <li><a data-target="#cambio" data-toggle="modal"  href="#">Cambio de contraseña</a></li>
            <li><asp:LinkButton ID="LKB_AdminSession" OnClick="LKB_AdminSession_Click" runat="server">Cerrar sesión</asp:LinkButton></li>
            
          </ul>
       
        </li>
           <li>
               <a href="#"><span class="glyphicon glyphicon-log-out"></span></a>

           </li>
      
       
      </ul>
        
       
     
    </div>
  </div>
</nav>
    

           
       
   
    
   
    
    
   
    <script type="text/javascript"  >
        function popup()
        {
            $('#cambio').modal('show');
        }
    </script>
        
    <div class="container">
          <div class="row">
              <div class="col-xs-12">
                  <%--<button class="btn btn-primary btn-sm pull-right" data-target="#olvide" data-toggle="modal">Popup</button>--%>
                  <div class="modal fade"  data-keyboard="false" data-backdrop="static" id="cambio"  tabindex="-1">
                      <div class="modal-dialog modal-sm">
                          <div class="modal-content" style="margin-top:100px;">
                              <div class="modal-header">
                                  <button class="close"  data-dismiss="modal">&times;</button>
                                  <h4 class="model-tittle">Cambio de contraseña</h4>


                              </div>
                              <div  class="modal-body">
                             
                                <div class="form-Group">
                                  <asp:Label ID="Label1" runat="server" Text="Digita tu contraseña actual:"></asp:Label>
                                  <asp:TextBox ID="txtContraseñaActual" TextMode="Password" runat="server" CssClass="form-control"  placeholder="Contraseña"></asp:TextBox>      
                                 <br />
                                   <p > <asp:Button ID= "btnConfirmar"  runat="server" CssClass="btn btn-warning" OnClick="btnConfirmar_Click" Text="Confirmar" /> 
                                    </p>
                                  <br> <br>
                             
                                  
                                 <asp:Label ID="Label2" runat="server" Text="Nueva contraseña"></asp:Label>
                                 <asp:TextBox ID="txtNuevaContraseña" Enabled="false" TextMode="Password" CssClass="form-control"  runat="server" placeholder="@Ejemplo123"></asp:TextBox>
<%--                                 <asp:CheckBox ID="ChkVerContraseña" OnCheckedChanged="ChkVerContraseña_CheckedChanged" runat="server" />--%>
                                 <asp:Label ID="Label3" runat="server"  Text="Confirmar contraseña"></asp:Label>
                                 <asp:TextBox ID="txtNuevaContraseñaConfirmar" Enabled="false" TextMode="Password" CssClass="form-control" runat="server" placeholder="Confirmar contraseña" ></asp:TextBox>
<%--                                 <asp:CheckBox ID="ChkVerContraseña2" runat="server" />--%>
                             </div>
                                </div>
                           <div class="modal-footer" >

                                  <asp:Button ID="btnCambiar" CssClass="btn btn-success" Enabled="false" runat="server" OnClick="btnCambiar_Click" Text="Cambiar" />
                                  <asp:Button ID="btnSalir" CssClass="btn btn-danger"  data-dismiss="modal" runat="server" OnClick="btnSalir_Click" Text="Salir" />   
                              </div>

                              </div>
                              
                          </div>
                          
                      </div>
                  </div>
              </div>
          </div>
    
      





     <div class="container">
  
 
  <div class="modal fade" data-keyboard="false" data-backdrop="static" id="depa" role="dialog">
       
    <div class="modal-dialog modal-sm">
       
      <div class="modal-content">
          
        <div class="modal-header">
          
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Insertar Departamentos</h4>
        </div>
        <div class="modal-body ">
          
         <asp:Label ID="Label4" runat="server" Text="Nombre del departamento:"></asp:Label>
         <asp:TextBox ID="txtnombre" CssClass="form-control" runat="server"></asp:TextBox>
         <asp:Label ID="Label5" runat="server" Text="Correo del jefe del departamento"></asp:Label>
         <asp:TextBox ID="txtemailjefedepa" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>
         <asp:Label ID="Label6" runat="server" Text="Nombre Jefe:"></asp:Label>
          <asp:TextBox ID="txtnombrejefe" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="modal-footer">
          <asp:Button ID="btndepa" runat="server" Text="Insertar" CssClass="btn btn-success"  OnClick="btndepa_Click" />

<%--          <button type="button" onclick="<%limpiarCamposDepa(); %>" class="btn btn-danger" data-dismiss="modal">Cerrar</button>--%>
            <asp:Button ID="btnSalirpopupDepa" runat="server" CssClass="btn btn-danger" Text="Cerrar" OnClick="btnSalirpopupDepa_Click" />
        </div>
      </div>
    </div>
  </div>
        </div>

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
            <br />
             <asp:Label ID="lblRol" runat="server" Text="Rol:"></asp:Label>
            <br />
            <p style="margin-left:280px; margin-top:-155px;"><asp:Image ID="imgPerfil" Width="170px" Height="120px" runat="server" />
                </p>






        </div>
        <div  style="margin-top:-30px;" class="modal-footer">
            <asp:Button ID="btnCerrarPopup" OnClick="btnCerrarPopup_Click"  CssClass="btn btn-danger"  runat="server" Text="Cerrar" />
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
            
          <%--<button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
         --%>
            <asp:Button ID="btnCerrar" runat="server" CssClass="btn btn-danger" OnClick="btnCerrar_Click" Text="Cerrar" />
        
        </div>
      </div>
    </div>
  </div>
        </div>


 
</asp:Content>
