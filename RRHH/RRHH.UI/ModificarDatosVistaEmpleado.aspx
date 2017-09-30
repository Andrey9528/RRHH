﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarDatosVistaEmpleado.aspx.cs" Inherits="RRHH.UI.ModificarDatosVistaEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
       body 
        {
            background-image: url("http://1070noticias.com.mx/wp-content/uploads/2016/07/fondos-de-pantalla-blancos-para-descargar.jpg");
            background-attachment:fixed;
            background-size:100vw 100vh ;
        }
     
 </style>
<div class="form-inline">
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

        <h1 style="text-align:center; font-family:cursive;">Actualizar datos</h1>
 
    
 </div>
    <br />
    
    <img id="img1" src="https://3.imimg.com/data3/HQ/KK/MY-8835125/5-250x250.png" runat="server"   class="img-responsive" />
    <br />
    <br />
    <br />
    <div class="form-horizontal "  style="margin-left:420px; margin-top:-350px; width: 319px; height: 465px;"   id="Empleadosmantenimiento" runat="server" visible="true">
           
   
    <asp:Label ID="Label2" runat="server"   Text="Nombre"></asp:Label>
    
       <asp:TextBox ID="txtNombre" CssClass="form-control " runat="server"></asp:TextBox>
       
   

   
   
    <asp:Label ID="Label3"  runat="server"   Text="Direccion"></asp:Label>
   
      <asp:TextBox ID="txtDireccion" Width="280" CssClass="form-control "    TextMode="MultiLine" runat="server"></asp:TextBox>
          
        
         <asp:Label ID="Label4"  runat="server"    Text="Teléfono"></asp:Label>
    
        <asp:TextBox ID="txtTelefono" CssClass="form-control"    runat="server"></asp:TextBox>
    



    <asp:Label ID="Label5" runat="server"   Text="Correo"></asp:Label>
<asp:TextBox ID="txtCorreo" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
    


            <asp:Label ID="Label6"  runat="server"   Text="Estado Civil:"></asp:Label>
    
  <asp:DropDownList ID="DddlEstadoCivil"  Width="280" class = "form-control" runat="server">
        <asp:ListItem>Casado</asp:ListItem>
        <asp:ListItem>Soltero</asp:ListItem>
        <asp:ListItem>Unión libre</asp:ListItem>
        <asp:ListItem>Viudo</asp:ListItem>
        <asp:ListItem Selected="True">Indefinido</asp:ListItem>
    </asp:DropDownList>
       

        
        <asp:Label ID="Label7"    runat="server" Text="Fecha Nacimiento"></asp:Label>
   
   <asp:TextBox ID="txtFechaNacimiento"  Width="280"  CssClass="form-control"  runat="server"></asp:TextBox>
   
    

                <asp:Label ID="Label8"     runat="server" Text="Departamento"></asp:Label>
     
   <asp:DropDownList ID="ddlDepartamento"  Width="280" class = "form-control" runat="server">
       <asp:ListItem>Programacion</asp:ListItem>
       <asp:ListItem>Vacunas</asp:ListItem>
       <asp:ListItem>Medicamentos</asp:ListItem>
       <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
       
   

   
    <asp:Label ID="Label9"   runat="server" Text="Rol"></asp:Label>
      
   
  <asp:DropDownList ID="ddlRol" Width="280" class = "form-control" runat="server">
      <asp:ListItem>Empleado</asp:ListItem>
      <asp:ListItem>Jefe</asp:ListItem>
      <asp:ListItem>Admin</asp:ListItem>
      <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
  

  
   
   
        <asp:Label ID="Label1"  runat="server" Text="Genero"></asp:Label>
   <asp:DropDownList ID="DDLgenero"  Width="280"  CssClass="form-control" runat="server">
       <asp:ListItem>Masculino</asp:ListItem>
       <asp:ListItem>Femenino</asp:ListItem>
       <asp:ListItem>Sin Establecer</asp:ListItem>
        </asp:DropDownList>
  
   
     
  <p  style="margin-left:360px; margin-top:-450px; "> 
    <asp:Label ID="Label13"  runat="server" Text="Empleado:"></asp:Label>    
        <asp:Image ID="imgEmple" Width="200px" Height="180px" runat="server" />
   </p>
       <div class="form-inline" style="margin-left:430px;">

        <asp:TextBox ID="txtImagen" Width="180" placeholder="Cambiar foto" runat="server" CssClass="form-control"></asp:TextBox>
         <asp:FileUpload ID="fileUpload1" accept="image/*" runat="server" />
        <input type="button" id="btnnAdjuntar" runat="server" value="adjuntar" class="btn btn-success" onclick="adjuntarImagen()" /> 
       
       
        </div>
          <script>
           function adjuntarImagen()
           {
               
               document.getElementById('MainContent_fileUpload1').click();
               document.getElementById('MainContent_txtImagen').readOnly = false;
             
           }
       </script>
 
       

    </div>
    <div class="form-horizontal" style="margin-top:-15px; margin-left:720px; width: 347px;">
           
             <%--<a   class="btn btn-primary"   href="EmpleadoView.aspx" ><span class="glyphicon glyphicon-backward"></span> Regresar</a>--%>
            <asp:Button ID="btnRegresar" OnClick="btnRegresar_Click" CssClass="btn btn-success" runat="server" Text="Regresar" />
             <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning" OnClick="btnModificar_Click" />         
        </div>
</asp:Content>
