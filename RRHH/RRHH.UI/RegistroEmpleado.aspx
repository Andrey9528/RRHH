<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroEmpleado.aspx.cs" Inherits="RRHH.UI.RegistroEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      
    
<div class="form-group" style=" margin-top:-30px;" > 
     
    
    <div class = "form-group"> 
    <div class="alert alert-success" visible="false"  id="mensaje" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
             <strong id="textoMensaje" runat="server"></strong>
        </div>        
    <asp:Label ID="Label1" runat="server"   Text="Cédula"></asp:Label>
    <asp:TextBox ID="txtCedula" CssClass="form-control" runat="server"></asp:TextBox>
  
    <asp:Label ID="Label2" runat="server"  Text="Nombre"></asp:Label>
    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
    <asp:Label ID="Label3" runat="server"   Text="Direccion"></asp:Label>
    <asp:TextBox ID="txtDireccion" CssClass="form-control"  Width="280"  TextMode="MultiLine" runat="server"></asp:TextBox>
      <asp:Label ID="Label4" runat="server"    Text="Teléfono"></asp:Label>
    <asp:TextBox ID="txtTelefono" CssClass="form-control"    runat="server"></asp:TextBox>
    
    <asp:Label ID="Label5" runat="server"   Text="Correo"></asp:Label>
    <asp:TextBox ID="txtCorreo" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
    <asp:Label ID="Label6" runat="server"   Text="Estado Civil"></asp:Label>
     <br> 
    <asp:DropDownList ID="DddlEstadoCivil" Width="280" class = "form-control" runat="server">
        <asp:ListItem>Casado</asp:ListItem>
        <asp:ListItem>Soltero</asp:ListItem>
        <asp:ListItem>Unión libre</asp:ListItem>
        <asp:ListItem>Viudo</asp:ListItem>
        <asp:ListItem Selected="True">Indefinido</asp:ListItem>
    </asp:DropDownList>
        <asp:Label ID="Label7"  runat="server" Text="Fecha Nacimiento"></asp:Label>
     <br> 
    <asp:TextBox ID="txtFechaNacimiento" Width="280" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
    <asp:Label ID="Label8"    runat="server" Text="Departamento"></asp:Label>
     <br> 
    <asp:DropDownList ID="ddlDepartamento" Width="280" class = "form-control" runat="server"> </asp:DropDownList>
    <asp:Label ID="Label9"   runat="server" Text="Rol"></asp:Label>
     <br> 
    <asp:DropDownList ID="ddlRol" Width="280" class = "form-control" runat="server"></asp:DropDownList>


    <asp:Label ID="Label10"   runat="server" Text="Imagen"></asp:Label>    
   <%-- <asp:TextBox ID="txtImagen" CssClass="form-control" runat="server"></asp:TextBox>--%>
    <asp:FileUpload ID="fupImagen" accept="image/*" runat="server"  />

   
    <br/>
    
    
    <asp:Button ID="btnCrear" OnClick="btnCrear_Click" CssClass="btn btn-success" runat="server" Text="Crear" />
    <asp:Button ID="btnLimpiar" onclick="btnLimpiar_Click" CssClass="btn btn-danger" runat="server" Text="Limpiar" />
   <%-- <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
  ControlToValidate="txtCedula"
  ErrorMessage="Cedula es requerida."
  ForeColor="Red">
</asp:RequiredFieldValidator>--%>
</div>
</asp:Content>
