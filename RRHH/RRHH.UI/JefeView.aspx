<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JefeView.aspx.cs" Inherits="RRHH.UI.JefeView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <style >
        body 
        {
            background-image: url("http://1070noticias.com.mx/wp-content/uploads/2016/07/fondos-de-pantalla-blancos-para-descargar.jpg");
            background-attachment:fixed;
            background-size:100vw 100vh ;
            


        }
          #menu, #menu ul {
        margin: 0;
        padding: 0;
        list-style: none;
    }

    #menu {
        width: 758px;
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
   
   
   
   
    <li class="dropdown pull-right">
        <a href="#" data-toggle="dropdown" class="dropdown-toggle">Administración <b class="caret"></b></a>
        <ul class="dropdown-menu">
<%--            <li><a href="#">Cambio de contraseña</a></li>--%>
               <li><a data-target="#cambiojefe" data-toggle="modal" href="#">Cambio de contraseña</a></li>

             <li><a href="#">Ayuda</a></li>
            <li><a href="Login.aspx">Cerrar Sesión</a></li>
            
            <li class="divider"></li>
        </ul>
    </li>
</ul>
   

      <ol id="menu" >
    <li><a href="JefeView.aspx">Home</a></li>
    <li><a href="#">Perfil</a></li>
    <li>
        <a href="#">Empleados</a>
        <ul>
            <li><a href="#">Lista empleados</a></li>
            
        </ul>
    </li>
    <li>
        <a href="#">Expedientes</a>
        <ul>
            <li><a href="#">Lista expedientes</a></li>
            
            
        </ul>
    </li>
    <li>
        <a href="#">Incapacidades</a>
        <ul>
            <li><a href="#"> Lista incapacidades</a></li>
           
        </ul>
    </li>
    <li>
        <a href="#">Vacaciones</a>
        <ul>
            
             <li><a href="mantenimientoVaca.aspx">Ver solicitudes</a></li>
            
            
        </ul>
    </li>
           
    

    
</ol>

    <div class="container">
          <div class="row">
              <div class="col-xs-12">
                  <%--<button class="btn btn-primary btn-sm pull-right" data-target="#olvide" data-toggle="modal">Popup</button>--%>
                  <div class="modal fade"  data-keyboard="false" data-backdrop="static" id="cambiojefe"  tabindex="-1">
                      <div class="modal-dialog modal-sm">
                          <div class="modal-content" style="margin-top:100px;">
                              <div class="modal-header">
                                  <button class="close"  data-dismiss="modal">&times;</button>
                                  <h4 class="model-tittle">Olvidé mi contraseña</h4>


                              </div>
                              <div  class="modal-body">
                             <div class="form-group">
                                 <asp:Label ID="Label1" runat="server" Text="Digita tu contraseña actual:"></asp:Label>
                                  <asp:TextBox ID="txtContraseñaActualJefe" TextMode="Password" runat="server" CssClass="form-control"  placeholder="Contraseña"></asp:TextBox>      
                                 <p style="margin-left:300px; margin-top:-35px;"> <asp:Button ID= "btnConfirmarJefe"   runat ="server" Text="Confirmar" CssClass="btn btn-warning" OnClick="btnConfirmarJefe_Click" /> </p>
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
                                  <asp:Button ID="btnCambiarJefe" CssClass="btn btn-success" Enabled="false" runat="server" OnClick="btnCambiarJefe_Click" Text="Cambiar" />
                                  <asp:Button ID="btnSalirJefe" CssClass="btn btn-danger" OnClick="btnSalirJefe_Click" runat="server"  Text="Salir" />
                              </div>

                          </div>
                      </div>
                  </div>
              </div>
          </div>
      </div>
</asp:Content>
