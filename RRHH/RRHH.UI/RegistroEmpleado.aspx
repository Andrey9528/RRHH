<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroEmpleado.aspx.cs" Inherits="RRHH.UI.RegistroEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class = "form-group">       
    <asp:Label ID="Label1" runat="server" Text="Cédula"></asp:Label>
    <asp:TextBox ID="txtCedula" CssClass="form-control" runat="server"></asp:TextBox>
    <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
    <asp:Label ID="Label3" runat="server" Text="Direccion"></asp:Label>
    <asp:TextBox ID="txtDireccion" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
      <asp:Label ID="Label4" runat="server"  Text="Teléfono"></asp:Label>
    <asp:TextBox ID="txtTelefono" textmode="Phone" CssClass="form-control" runat="server"></asp:TextBox>
    <asp:Label ID="Label5" runat="server" Text="Correo"></asp:Label>
    <asp:TextBox ID="txtCorreo" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
    <asp:Label ID="Label6" runat="server" Text="Estado Civil"></asp:Label>
     <br> 
    <asp:DropDownList ID="DddlEstadoCivil" class = "form-control" runat="server">
        <asp:ListItem>Casado</asp:ListItem>
        <asp:ListItem>Soltero</asp:ListItem>
        <asp:ListItem>Unión libre</asp:ListItem>
        <asp:ListItem>Viudo</asp:ListItem>
        <asp:ListItem Selected="True">Indefinido</asp:ListItem>
    </asp:DropDownList>
        <asp:Label ID="Label7" runat="server" Text="Fecha Nacimientol"></asp:Label>
     <br> 
    <asp:TextBox ID="txtFechaNacimiento" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
    <asp:Label ID="Label8" runat="server" Text="Departamento"></asp:Label>
     <br> 
    <asp:DropDownList ID="ddlDepartamento" class = "form-control" runat="server"> </asp:DropDownList>
    <asp:Label ID="Label9" runat="server" Text="Rol"></asp:Label>
     <br> 
    <asp:DropDownList ID="ddlRol" class = "form-control" runat="server"></asp:DropDownList>

    <div class="form-inline"> 
    <asp:Label ID="Label10" runat="server" Text="Imagen"></asp:Label>    
    <asp:TextBox ID="txtImagen" CssClass="form-control" runat="server"></asp:TextBox>
    <asp:FileUpload ID="fupImagen" runat="server" />

    </div>
    <br>
    
    
    <asp:Button ID="btnCrear" OnClick="btnCrear_Click" CssClass="btn btn-success" runat="server" Text="Crear" />
    <asp:Button ID="btnLimpiar" onclick="btnLimpiar_Click" CssClass="btn btn-danger" runat="server" Text="Limpiar" />

</div>
</asp:Content>
