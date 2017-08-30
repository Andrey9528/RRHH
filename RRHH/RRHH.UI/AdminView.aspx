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
            <li><a href="#">Cambio de contraseña</a></li>
            <li><a href="#">Cerrar Sesión</a></li>
            <li class="divider"></li>
        </ul>
    </li>
</ul>

    <ol id="menu" >
    <li><a href="#">Home</a></li>
    <li><a href="#">Perfil</a></li>
    <li>
        <a href="#">Empleados</a>
        <ul>
            <li><a href="#">Agregar</a></li>
            <li><a href="#">Mantenimiento</a></li>
        </ul>
    </li>
    <li>
        <a href="#">Expedientes</a>
        <ul>
            <li><a href="#">Crear </a></li>
            <li><a href="#">Mantenimiento </a></li>
            
        </ul>
    </li>
    <li>
        <a href="#">Incapacidades</a>
        <ul>
            <li><a href="#">Registar </a></li>
            <li><a href="#">Mantenimiento </a></li>

        </ul>
    </li>
    <li>
        <a href="#">Vacaciones</a>
        <ul>
            <li><a href="#">Registrar </a></li>
            <li><a href="#">Mantenimiento </a></li>
            
        </ul>
    </li>
    <li>
        <a href="#">Departamentos</a>
        <ul>
           
            <li><a href="#">Registrar </a></li>
            <li><a href="#">Mantenimiento </a></li>
        </ul>
    </li>


    
</ol>
   
</asp:Content>
