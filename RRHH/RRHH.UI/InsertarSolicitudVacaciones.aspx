<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsertarSolicitudVacaciones.aspx.cs" Inherits="RRHH.UI.InsertarSolicitud" %>
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

    <asp:Label ID="Label1" runat="server" Text="id solicitud:"></asp:Label>
    <asp:TextBox ID="txtidsolicitud" CssClass="form-control" runat="server"></asp:TextBox>


    <asp:Label ID="Label3" runat="server" Text="Fecha de Inicio:"></asp:Label>
    <asp:TextBox ID="txtfechadeincio" Width="280" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>


    <asp:Label ID="Label4" runat="server" Text="Fecha Final:"></asp:Label>
    <asp:TextBox ID="txtfechafinal" Width="280" TextMode="Date" CssClass="form-control" runat="server" ></asp:TextBox>


   <%-- <asp:Label ID="Label5" runat="server" Text="Total de dias:"></asp:Label>
    <asp:TextBox ID="txttotaldias" TextMode="Number" CssClass="form-control"  OnTextChanged="txttotaldias_TextChanged" Width="280" runat="server" Enabled="False"></asp:TextBox>--%>


    <%--  <asp:Label ID="Label6" runat="server" Text="Condicion:"></asp:Label>
    <asp:CheckBox ID="Chk_condicion" runat="server" />--%>

    <br />
    <br />
    <asp:Button ID="btninsertar" runat="server" Text="Insertar" CssClass="btn btn-success" OnClick="btninsertar_Click"  />

</div>

</asp:Content>
