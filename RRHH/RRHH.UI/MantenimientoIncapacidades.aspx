<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantenimientoIncapacidades.aspx.cs" Inherits="RRHH.UI.MantenimientoIncapacidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">
    function Confirm() {
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden";
        confirm_value.name = "confirm_value";
        if (confirm("Esta seguro que quiere dar de baja este usuario?")) {
            confirm_value.value = "Yes";
        } else {
            confirm_value.value = "No";
        }
        document.forms[0].appendChild(confirm_value);
    }


</script>
<div class="form-inline">
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



    <asp:Label ID="lbIdProducto" runat="server" Text="Cédula: "></asp:Label>
        <asp:TextBox ID="txtcedula" runat="server" CssClass="form-control"></asp:TextBox>
        
    <asp:Button ID="btnsBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnsBuscar_Click" />
    <br><br>
    <asp:GridView ID="grVacaciones" runat="server"></asp:GridView>
    </div>


    <div class="form-horizontal" id="mantenimientoInca" runat="server" visible="false">


   <asp:Label ID="Label2" runat="server" Text="Fecha de inicio:"></asp:Label>
    <asp:TextBox ID="txtfechainicio" Width="280" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>

     <asp:Label ID="Label1" runat="server" Text="Fecha de finalizacion:"></asp:Label>
    <asp:TextBox ID="txtfechafinal" Width="280" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>


  
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

     <asp:Label ID="Label7" runat="server" Text="Centro emisor:"></asp:Label>
    <asp:TextBox ID="txtcentroemisor" CssClass="form-control" runat="server"></asp:TextBox>


    <asp:Label ID="Label8" runat="server" Text="Nombre del doctor:"></asp:Label>
    <asp:TextBox ID="txtnombredoc" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="Estado"></asp:Label>
         <asp:CheckBox ID="chkEstado" runat="server" />
        <br />

        <br />
         <div class="form-horizontal">
            <br />
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning"  OnClick="btnModificar_Click" />
            <asp:Button ID="btndesahabilitar"  runat="server" Text="Deshabilitar" CssClass="btn btn-danger" OnClick="btndesahabilitar_Click"  OnClientClick="Confirm()" />
        </div>
    </div>
</asp:Content>
