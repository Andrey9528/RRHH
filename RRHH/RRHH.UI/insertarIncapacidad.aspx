<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="insertarIncapacidad.aspx.cs" Inherits="RRHH.UI.insertarIncapacidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="form-group">

      <div class="alert alert-success" visible="false"  id="mensaje" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
             <strong id="textoMensaje" runat="server"></strong>
        </div>
        <div class="aler alert-danger" visible="false" id="mensajeError" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
            <strong id="textoMensajeError" runat="server"></strong>

        </div>
      <div class="aler alert-warning" visible="false" id="mensajawarning" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
            <strong id="textomensajewarning" runat="server"></strong>

        </div>
      <div class="alert alert-info" visible="false"  id="mensajeinfo" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
             <strong id="textomensajeinfo" runat="server"></strong>
        </div>


    <br />
    <asp:Label ID="Label1" runat="server" Text="id incapacidad"></asp:Label>
    <asp:TextBox ID="txtidsolicitud" CssClass="form-control" runat="server"></asp:TextBox>

    <asp:Label ID="Label2" runat="server" Text="Cedula:"></asp:Label>
    <asp:TextBox ID="txtcedula" CssClass="form-control" runat="server"></asp:TextBox>


    <asp:Label ID="Label3" runat="server" Text="Cantidad de dias:"></asp:Label>
    <asp:TextBox ID="txtcantidadDias"  Width="280" TextMode="Number" CssClass="form-control" runat="server"></asp:TextBox>


    <asp:Label ID="Label4" runat="server" Text="Tipo de incapacidad:"></asp:Label>
    <asp:DropDownList ID="DDLTipo" Width="280" CssClass="form-control" runat="server">
        <asp:ListItem>Enfermedad</asp:ListItem>
        <asp:ListItem>Maternidad</asp:ListItem>
        <asp:ListItem Selected="True">Indefinido</asp:ListItem>
      </asp:DropDownList>
   
    
     <asp:Label ID="Label9" runat="server" Text="Descripcion:"></asp:Label>
    <asp:TextBox ID="txtdescripcion"  Width="280" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>


    <asp:Label ID="Label5" runat="server" Text="Fecha de emisión:"></asp:Label>
    <asp:TextBox ID="txtfechaemision" Width="280" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>

     <asp:Label ID="Label7" runat="server" Text="Centro emisor"></asp:Label>
    <asp:TextBox ID="txtcentroemisor" CssClass="form-control" runat="server"></asp:TextBox>


    <asp:Label ID="Label8" runat="server" Text="Nombre del doctor"></asp:Label>
    <asp:TextBox ID="txtnombredoc" CssClass="form-control" runat="server"></asp:TextBox>


      <asp:Label ID="Label6" runat="server" Text="Condicion:"></asp:Label>
    <asp:CheckBox ID="Chk_condicion" runat="server" />

    <br />
    <br />
    <asp:Button ID="btninsertar" runat="server" Text="Insertar" CssClass="btn btn-success" OnClick="btninsertar_Click"  />


</div>


</asp:Content>
