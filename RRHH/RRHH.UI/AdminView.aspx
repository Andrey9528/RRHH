<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminView.aspx.cs" Inherits="RRHH.UI.AdminView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <style>
        body 
        {
            background-image: url("https://unedliberia.files.wordpress.com/2012/11/warp.jpg");
            background-attachment:fixed;
            background-size:100vw 100vh ;


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

<%--<ul class="nav nav-pills nav-justified ">
  <li class="active"><a data-toggle="pill" href="#">Inicio</a></li>
  <li><a data-toggle="pill" href="#">Perfil</a></li>
  <li><a data-toggle="pill" href="#">Mensajes</a></li>
</ul>--%>
<ul class="nav nav-pills">
   <%-- <li  class="active"><a  href="#" style=" background:#2dadf7; color:white;" >Home</a></li>
    <li><a   style="background:#2dadf7; color:white;" href="#">Perfil</a></li>
   <li class="dropdown">
        <a href="#" data-toggle="dropdown" class="dropdown-toggle" style=" background:#2dadf7; color:white;">Empleados</a>
        <ul class="dropdown-menu">
             <li><a href="#"  >Agregar</a></li>
            <li><a href="#">Mantenimiento</a></li>
             <li class="divider"></li>
        </ul>
    </li>
    <li class="dropdown">
        <a href="#" data-toggle="dropdown" style=" background:#2dadf7; color:white;" class="dropdown-toggle">Expedientes</a>
        <ul class="dropdown-menu">
             <li><a href="#">Agregar</a></li>
            <li><a href="#">Mantenimiento</a></li>
             <li class="divider"></li>
        </ul>
    </li>
    <li class="dropdown">
        <a href="#" data-toggle="dropdown" style=" background:#2dadf7; color:white;" class="dropdown-toggle">Incapacidades</a>
        <ul class="dropdown-menu">
             <li><a href="#">Agregar</a></li>
            <li><a href="#">Mantenimiento</a></li>
             <li class="divider"></li>
        </ul>
    </li>
    <li class="dropdown">
        <a href="#" data-toggle="dropdown" style=" background:#2dadf7; color:white;" >Vacaciones</a>
        <ul class="dropdown-menu">
             <li><a href="#">Agregar</a></li>
            <li><a href="#">Mantenimiento</a></li>
             <li class="divider"></li>
        </ul>
    </li>
    <li class="dropdown" >
        <a href="#" data-toggle="dropdown" style=" background:#2dadf7; color:white;" class="dropdown-toggle">Departamentos</a>
        <ul class="dropdown-menu">
             <li><a href="#">Agregar</a></li>
            <li><a href="#">Mantenimiento</a></li>
             <li class="divider"></li>
        </ul>
    </li>--%>
    

   
    
    <li class="dropdown pull-right">
        <a href="#" data-toggle="dropdown" class="dropdown-toggle">Administración <b class="caret"></b></a>
        <ul class="dropdown-menu">
            <li><a data-target="#cambio" data-toggle="modal" href="#">Cambio de contraseña</a></li>

            <li><a href="Login.aspx">Cerrar Sesión</a></li>
            <li class="divider"></li>
        </ul>
    </li>
</ul>

    <ol id="menu" >
    <li><a href="AdminView.aspx">Home</a></li>
    <li><a href="#">Perfil</a></li>
    <li>
        <a href="#">Empleados</a>
        <ul>
            <li><a href="RegistroEmpleado.aspx">Agregar</a></li>
            <li><a href="mantenimientoEmpleados.aspx">Mantenimiento</a></li>
        </ul>
    </li>
    <li>
        <a href="#">Expedientes</a>
        <ul>
            
            <li><a href="#">Listado</a></li>
            
        </ul>
    </li>
    <li>
        <a href="#">Incapacidades</a>
        <ul>
           
            <li><a href="#">Mantenimiento </a></li>

        </ul>
    </li>
    <li>
        <a href="#">Vacaciones</a>
        <ul>
           
            <li><a href="adminVacacaciones.aspx">Mantenimiento </a></li>
            
        </ul>
    </li>
    <li>
        <a href="#">Departamentos</a>
        <ul>
           
            <li><a  data-toggle="modal" data-target="#depa"  href ="#">Registrar </a></li>
            <li><a href="MantenimientoDepa.aspx">Mantenimiento </a></li>
            
              
        </ul>
    </li>


    
</ol>
    <div class="container">
          <div class="row">
              <div class="col-xs-12">
                  <%--<button class="btn btn-primary btn-sm pull-right" data-target="#olvide" data-toggle="modal">Popup</button>--%>
                  <div class="modal fade"  data-keyboard="false" data-backdrop="static" id="cambio"  tabindex="-1">
                      <div class="modal-dialog modal-sm">
                          <div class="modal-content" style="margin-top:100px;">
                              <div class="modal-header">
                                  <button class="close"  data-dismiss="modal">&times;</button>
                                  <h4 class="model-tittle">Reseteo de contraseña</h4>


                              </div>
                              <div  class="modal-body">
                             <div class="form-group">
                                 <asp:Label ID="Label1" runat="server" Text="Digita tu contraseña actual:"></asp:Label>
                                  <asp:TextBox ID="txtContraseñaActual" TextMode="Password" runat="server" CssClass="form-control"  placeholder="Contraseña"></asp:TextBox>      
                                 <p style="margin-left:300px; margin-top:-35px;"> <asp:Button ID= "btnConfirmar"  runat="server" CssClass="btn btn-warning" OnClick="btnConfirmar_Click" Text="Confirmar" /> </p>
                                  <br> <br>
                                 <asp:Label ID="Label2" runat="server" Text="Nueva contraseña"></asp:Label>
                                 <asp:TextBox ID="txtNuevaContraseña" Enabled="false" TextMode="Password" CssClass="form-control"  runat="server" placeholder="Nueva contraseña"></asp:TextBox>
<%--                                 <asp:CheckBox ID="ChkVerContraseña" OnCheckedChanged="ChkVerContraseña_CheckedChanged" runat="server" />--%>
                                 <asp:Label ID="Label3" runat="server"  Text="Confirmar contraseña"></asp:Label>
                                 <asp:TextBox ID="txtNuevaContraseñaConfirmar" Enabled="false" TextMode="Password" CssClass="form-control" runat="server" placeholder="Confirmar contraseña" ></asp:TextBox>
<%--                                 <asp:CheckBox ID="ChkVerContraseña2" runat="server" />--%>
                             </div>
                             <div class="form-group">
                                 
                                 
                              </div>
                              </div>
                              <div class="modal-footer">

                                  <asp:Button ID="btnCambiar" CssClass="btn btn-success" Enabled="false" runat="server" OnClick="btnCambiar_Click" Text="Cambiar" />
                                  <asp:Button ID="btnSalir" CssClass="btn btn-danger" runat="server" OnClick="btnSalir_Click" Text="Salir" />   
                              </div>

                          </div>
                      </div>
                  </div>
              </div>
          </div>
      </div>





     <div class="container">
  
 
  <div class="modal fade" id="depa" role="dialog">
       
    <div class="modal-dialog modal-sm">
       
      <div class="modal-content">
          
        <div class="modal-header">
          
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Insertar Departamentos</h4>
        </div>
        <div class="modal-body">
          
         <asp:Label ID="Label4" runat="server" Text="Nombre del departamento:"></asp:Label>
         <asp:TextBox ID="txtnombre" CssClass="form-control" runat="server"></asp:TextBox>
         <asp:Label ID="Label5" runat="server" Text="Correo del jefe del departamento"></asp:Label>
         <asp:TextBox ID="txtemailjefedepa" TextMode="Email" runat="server"></asp:TextBox>
         <asp:Label ID="Label6" runat="server" Text="Nombre Jefe:"></asp:Label>
          <asp:TextBox ID="txtnombrejefe" runat="server"></asp:TextBox>
        </div>
        <div class="modal-footer">
          <asp:Button ID="btndepa" runat="server" Text="Insertar" CssClass="btn btn-success"  OnClick="btndepa_Click" />

          <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
        
        </div>
      </div>
    </div>
  </div>
        </div>
    
</asp:Content>
