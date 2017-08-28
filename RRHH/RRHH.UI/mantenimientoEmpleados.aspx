<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="mantenimientoEmpleados.aspx.cs" Inherits="RRHH.UI.mantenimientoEmpleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <div class="form-inline">
        <div class="alert alert-success" visible="false"  id="mensaje" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
             <strong id="textoMensaje" runat="server"></strong>
        </div>
        <div class="aler alert-danger" visible="false" id="mensajeError" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
            <strong id="textoMensajeError" runat="server"></strong>

        </div>
        <asp:Label ID="lbIdProducto" runat="server" Text="Cédula: "></asp:Label>
        <asp:TextBox ID="txtcedula" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Button ID="btnsBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnsBuscar_Click" />
    </div>

    <div class="form-horizontal " id="Empleadosmantenimiento" runat="server" visible="false">
           
    
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
    <asp:TextBox ID="txtFechaNacimiento" Width="280" CssClass="form-control"  runat="server"></asp:TextBox>
    <asp:Label ID="Label8"    runat="server" Text="Departamento"></asp:Label>
     <br> 
<%--    <asp:DropDownList ID="ddlDepartamento" width="280" class = "form-control" runat="server"> </asp:DropDownList>--%>
            <asp:TextBox ID="txtDepartamento" Width="280" CssClass="form-control"  runat="server"></asp:TextBox>

    <asp:Label ID="Label9"   runat="server" Text="Rol"></asp:Label>
     <br> 
<%--    <asp:DropDownList ID="ddlRol" Width="280" class = "form-control" runat="server"></asp:DropDownList>--%>
    <asp:TextBox ID="txtRol" Width="280" CssClass="form-control"  runat="server"></asp:TextBox>


    <asp:Label ID="Label10"   runat="server" Text="Imagen"></asp:Label>    
   <%-- <asp:TextBox ID="txtImagen" CssClass="form-control" runat="server"></asp:TextBox>--%>
    <asp:FileUpload ID="fupImagen" accept="image/*" runat="server"  />

        <asp:Label ID="Label11" runat="server" Text="Estado"></asp:Label>
        <asp:CheckBox ID="Chk_estado" runat="server" />


   <br />
        <div class="form-horizontal">
            <br />
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning"  OnClick="btnModificar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Deshabilitar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
        </div>

    </div>

</asp:Content>
