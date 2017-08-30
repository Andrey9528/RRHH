<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsertarDepartamentos.aspx.cs" Inherits="RRHH.UI.InsertarDepartamentos" %>
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

         <asp:Label ID="Label1" runat="server" Text="Numero de departamento:"></asp:Label>
         <asp:TextBox ID="txtdepar" CssClass="form-control" runat="server"></asp:TextBox>
     
     
     <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
         <asp:TextBox ID="txtnombre" CssClass="form-control" runat="server"></asp:TextBox>
     
     <br />
         <br />

         <asp:Button ID="btnagregar" CssClass="btn btn-success" runat="server" Text="Insertar" OnClick="btnagregar_Click" />
     </div>

</asp:Content>
