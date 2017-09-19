<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="popup.aspx.cs" Inherits="RRHH.UI.popup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <%--    <div class="container">
          <div class="row">
              <div class="col-xs-12">
                  <button class="btn btn-primary btn-sm pull-right" data-target="#olvide" data-toggle="modal">Popup</button>
                  <div class="modal fade"  data-keyboard="false" data-backdrop="static" id="olvide"  tabindex="-1">
                      <div class="modal-dialog modal-sm">
                          <div class="modal-content">
                              <div class="modal-header">
                                  <button class="close"  data-dismiss="modal">&times;</button>
                                  <h4 class="model-tittle">Login</h4>


                              </div>
                              <div  class="modal-body">
                             <div class="form-group">
                                  <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>      <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                  <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                              </div>
                             <div class="form-group">
                                 <asp:Button ID="Button1" CssClass="btn btn-danger" runat="server" Text="Button" />
                                 <asp:Button ID="Button2" runat="server" CssClass="btn btn-success" Text="Button" />
                              </div>
                              </div>
                              <div class="modal-footer">
                                  <asp:Button ID="Button3" CssClass="btn btn-success" runat="server" Text="Button" />
                                  <asp:Button ID="Button4" runat="server" Text="close" data-dismiss="modal" CssClass="btn btn-danger" />
                              </div>

                          </div>
                      </div>
                  </div>
              </div>
          </div>
      </div>--%>

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
    <div class="form-horizontal "  style=" margin-top:-350px;"   id="Empleadosmantenimiento" runat="server" visible="true">
           
   
   <asp:Label ID="Label2" runat="server"   Text="Nombre"></asp:Label>
    
      <div class="">  <asp:TextBox ID="txtNombre" CssClass="form-control " runat="server"></asp:TextBox>
      </div>
   

   
   
    
      
    <div class="col-xs-3"> 
        <asp:Label ID="Label10"  runat="server"   Text="Direccion"></asp:Label>
       
                 <asp:TextBox ID="TextBox1"  CssClass="form-control "    TextMode="MultiLine" runat="server"></asp:TextBox>
       </div>
        
     
     <div>
        
     
          <asp:Label ID="Label4"  runat="server"    Text="Teléfono"></asp:Label>
   
          <asp:TextBox ID="txtTelefono" CssClass="form-control"    runat="server"></asp:TextBox>
       </div>



    <asp:Label ID="Label5" runat="server"   Text="Correo"></asp:Label>
 <div><asp:TextBox ID="txtCorreo" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
     </div>


            <asp:Label ID="Label6"  runat="server"   Text="Estado Civil:"></asp:Label>
    
  <div>  <asp:DropDownList ID="DddlEstadoCivil"   class = "form-control" runat="server">
        <asp:ListItem>Casado</asp:ListItem>
        <asp:ListItem>Soltero</asp:ListItem>
        <asp:ListItem>Unión libre</asp:ListItem>
        <asp:ListItem>Viudo</asp:ListItem>
        <asp:ListItem Selected="True">Indefinido</asp:ListItem>
    </asp:DropDownList>
      </div>

        
        <asp:Label ID="Label7"    runat="server" Text="Fecha Nacimiento"></asp:Label>
   
   <div> <asp:TextBox ID="txtFechaNacimiento"    CssClass="form-control"  runat="server"></asp:TextBox>
    </div>
    

                <asp:Label ID="Label8"     runat="server" Text="Departamento"></asp:Label>
     
   <div><asp:DropDownList ID="ddlDepartamento"   class = "form-control" runat="server">
       <asp:ListItem>Programacion</asp:ListItem>
       <asp:ListItem>Vacunas</asp:ListItem>
       <asp:ListItem>Medicamentos</asp:ListItem>
       <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
        </div>    
   

   
    <asp:Label ID="Label9"   runat="server" Text="Rol"></asp:Label>
      
   
 <div> <asp:DropDownList ID="ddlRol" class = "form-control" runat="server">
      <asp:ListItem>Empleado</asp:ListItem>
      <asp:ListItem>Jefe</asp:ListItem>
      <asp:ListItem>Admin</asp:ListItem>
      <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
   </div>

  
   
   
        <asp:Label ID="Label1"  runat="server" Text="Genero"></asp:Label>
   <div> <asp:DropDownList ID="DDLgenero"    CssClass="form-control" runat="server">
       <asp:ListItem>Masculino</asp:ListItem>
       <asp:ListItem>Femenino</asp:ListItem>
       <asp:ListItem>Sin Establecer</asp:ListItem>
        </asp:DropDownList>
   </div>
   
     
    <div  style="margin-left:360px; margin-top:-450px; "> 
    <asp:Label ID="Label13"  runat="server" Text="Empleado:"></asp:Label>    
        <asp:Image ID="imgEmple" Width="200px" Height="180px" runat="server" />
   </div>
       <div class="form-inline" style="margin-left:430px;">

        <asp:TextBox ID="txtImagen"  placeholder="Cambiar foto" runat="server" CssClass="form-control"></asp:TextBox>
         <asp:FileUpload ID="fileUpload1" accept="image/*" style="display:none;" runat="server" />
        <input type="button" id="btnnAdjuntar" runat="server" value="adjuntar" class="btn btn-success" onclick="adjuntarImagen()" /> 
       
       
        </div>
          <script>
           function adjuntarImagen()
           {
               
               document.getElementById('MainContent_fileUpload1').click();
               document.getElementById('MainContent_txtImagen').readOnly = false;
              <%  
              string img = fileUpload1.FileName;
              imgEmple.ImageUrl=img;

               %>
           }
       </script>
 
       

    </div>
    <div class="form-horizontal" style="margin-top:-15px; margin-left:720px; width: 347px;">
           
             <a   class="btn btn-primary"  href="EmpleadoView.aspx"><span class="glyphicon glyphicon-backward"></span> Regresar</a>

             <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning"  />         
        </div>
</asp:Content>
