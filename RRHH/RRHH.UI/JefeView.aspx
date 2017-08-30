<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JefeView.aspx.cs" Inherits="RRHH.UI.JefeView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <style >
        body 
        {
            background-image: url("https://unedliberia.files.wordpress.com/2012/11/warp.jpg");
            background-attachment:fixed;
            background-size:100vw 100vh ;

        }    

    </style>

<%--<ul class="nav nav-pills nav-justified ">
  <li class="active"><a data-toggle="pill" href="#">Inicio</a></li>
  <li><a data-toggle="pill" href="#">Perfil</a></li>
  <li><a data-toggle="pill" href="#">Mensajes</a></li>
</ul>--%>
<ul class="nav nav-pills">
    <li  class="active"><a data-toggle="pill" href="#">Home</a></li>
    <li>
        <a href="#">Empleados</a>
        <ul>
             <li><a href="#">Agregar</a></li>
            <li><a href="#">Mantenimiento</a></li>
        </ul>
    </li>
    <li><a data-toggle="pill" href="#">Perfil</a></li>
    <li class="dropdown">
        <a href="#" data-toggle="dropdown" class="dropdown-toggle">Incapacidades <b class="caret"></b></a>
        <ul class="dropdown-menu">
            <li><a href="#">Registrar</a></li>
            <li><a href="#">Consulta</a></li>
            <li class="divider"></li>
        </ul>
    </li>
    <li class="dropdown">
        <a href="#" data-toggle="dropdown"  class="dropdown-toggle">Vacaciones <b class="caret"></b></a>
        <ul class="dropdown-menu">
            <li><a href="#">Solicitud</a></li>
            <li><a href="#">Consulta</a></li>
            <li><a href="#">Historial</a></li>
            <li class="divider"></li>
        </ul>
    </li>
    <li class="dropdown pull-right">
        <a href="#" data-toggle="dropdown" class="dropdown-toggle">Administración <b class="caret"></b></a>
        <ul class="dropdown-menu">
            <li><a href="#">Cambio de contraseña</a></li>
            <li><a href="#">Cerrar Sesión</a></li>
            <li class="divider"></li>
        </ul>
    </li>
</ul>
   
</asp:Content>
