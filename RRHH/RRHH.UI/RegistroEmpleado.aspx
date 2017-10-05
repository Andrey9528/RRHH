<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroEmpleado.aspx.cs" Inherits="RRHH.UI.RegistroEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      
    
    <style>
       body 
        {
            background-image: url("http://1070noticias.com.mx/wp-content/uploads/2016/07/fondos-de-pantalla-blancos-para-descargar.jpg");
            background-attachment:fixed;
            background-size:100vw 100vh ;
            


        }
     
 </style>
     <h1 style="font-size:30px; font-family:cursive; text-align:center; ">Agregar Empleado</h1>
    <br />
    <br />
    <div class = "form-group col-sm-offset-2" style="margin-top:-30px;" > 
    <div class="alert alert-success" visible="false"  id="mensaje" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
             <strong id="textoMensaje" runat="server"></strong>
        </div>        
    <asp:Label ID="Label1" runat="server"   Text="Cédula"></asp:Label>
    <asp:TextBox ID="txtCedula" CssClass="form-control" runat="server"></asp:TextBox>
  
    <asp:Label ID="Label2" runat="server"  Text="Nombre"></asp:Label>
    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
    <asp:Label ID="Label3" runat="server"   Text="Direccion"></asp:Label>
    <asp:TextBox ID="txtDireccion" CssClass="form-control"    TextMode="MultiLine" runat="server"></asp:TextBox>
      <asp:Label ID="Label4" runat="server"    Text="Teléfono"></asp:Label>
    <asp:TextBox ID="txtTelefono" CssClass="form-control"    runat="server"></asp:TextBox>
    
    <asp:Label ID="Label5" runat="server"   Text="Correo"></asp:Label>
    <asp:TextBox ID="txtCorreo" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
    <asp:Label ID="Label6" runat="server"   Text="Estado Civil"></asp:Label>
     <br> 
    <asp:DropDownList ID="DddlEstadoCivil" class = "form-control" runat="server">
        <asp:ListItem>Casado</asp:ListItem>
        <asp:ListItem>Soltero</asp:ListItem>
        <asp:ListItem>Unión libre</asp:ListItem>
        <asp:ListItem>Viudo</asp:ListItem>
        <asp:ListItem Selected="True">Indefinido</asp:ListItem>
    </asp:DropDownList>
        <asp:Label ID="Label7"  runat="server" Text="Fecha Nacimiento"></asp:Label>
     <br> 
    <asp:TextBox ID="txtFechaNacimiento" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
    <asp:Label ID="Label8"    runat="server" Text="Departamento"></asp:Label>
     <br> 
    <asp:DropDownList ID="ddlDepartamento" class = "form-control" runat="server"> </asp:DropDownList>
    <asp:Label ID="Label9"   runat="server" Text="Rol"></asp:Label>
     <br> 
    <asp:DropDownList ID="ddlRol" class = "form-control" runat="server"></asp:DropDownList>
        <br />
       <div class="form-inline">
       
        <asp:TextBox ID="txtImagen" placeholder="imagen" runat="server" CssClass="form-control"></asp:TextBox>
       
         <asp:FileUpload ID="fileUpload1" accept="image/*" style="display:none;" runat="server" />
        <input type="button" id="btnnAdjuntar" runat="server" value="adjuntar" class="btn btn-success" onclick="adjuntarImagen()" /> 
       
        </div>
       <script>
           function adjuntarImagen()
           {
               document.getElementById('MainContent_fileUpload1').click();
               document.getElementById('MainContent_txtImagen').readOnly = true;

           }
       </script>

        <asp:Label ID="Label11" runat="server" Text="Genero"></asp:Label>
        <asp:DropDownList ID="DDLgenero"   CssClass="form-control" runat="server">
            <asp:ListItem>Masculino</asp:ListItem>
            <asp:ListItem>Femenino</asp:ListItem>
            <asp:ListItem Selected="True">Sin establecer</asp:ListItem>
        </asp:DropDownList> 
   
   
    </div>
      
             
     <a class="btn btn-primary"  href="AdminView.aspx"><span class="glyphicon glyphicon-backward"></span> Regresar</a>
    
        <asp:Button ID="btnCrear" OnClick="btnCrear_Click" CssClass="btn btn-success" runat="server" Text="Crear" />
    <asp:Button ID="btnLimpiar" onclick="btnLimpiar_Click" CssClass="btn btn-danger" runat="server" Text="Limpiar" />
        
   
            
         
   <%-- <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
  ControlToValidate="txtCedula"
  ErrorMessage="Cedula es requerida."
  ForeColor="Red">
</asp:RequiredFieldValidator>--%>
      
</>

   
   <style>
       @media only screen and (max-width: 1024px) and (max-height: 768px) {
           #img {
              
               margin-left:-20px;
               width:303px;
               height:200px;
           }
       }
   </style>
</asp:Content>
