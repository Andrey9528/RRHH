<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantenimientoVaca.aspx.cs" Inherits="RRHH.UI.MantenimientoVaca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
          body 
        {
            background-image: url("http://1070noticias.com.mx/wp-content/uploads/2016/07/fondos-de-pantalla-blancos-para-descargar.jpg");
            background-attachment:fixed;
            background-size:100vw 100vh ;
            


        }
    </style>
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


        
        <asp:Label ID="lbIcedula" runat="server" Text="Cédula: "></asp:Label>
        <asp:TextBox ID="txtcedula" runat="server" CssClass="form-control"></asp:TextBox>
        
    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
     <br />
    <br />
    
    <asp:GridView ID="gvdatos" CssClass="table  table-bordered " runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
     </asp:GridView>
   <br />
    <br />
    <p style="margin-top:50px; margin-left:20px; width: 144px;"><asp:Label ID="Label1" runat="server" Text="Numero de Solicitud"></asp:Label></p>
   <p style="margin-left:160px; margin-top:-35px; width: 185px;"> <asp:DropDownList ID="DDLidsolicitud" Width="178px" CssClass="form-control" runat="server"></asp:DropDownList></p>
    <p style="margin-left:400px; margin-top:-38px;"><asp:Label ID="Label2" runat="server" Text="Estado"></asp:Label></p>
    <p style="margin-left:460px; margin-top:-30px; width: 157px;" ><asp:DropDownList ID="DDLestado" Width="151px" CssClass="form-control" runat="server">
        <asp:ListItem>Aprobado</asp:ListItem>
        <asp:ListItem Selected="True">Denegado</asp:ListItem>
        <asp:ListItem></asp:ListItem>
     </asp:DropDownList></p>


   <p style="margin-left:670px; margin-top:-40px;"> <asp:Button ID="btnactualizar" CssClass="btn btn-warning" OnClick="btnactualizar_Click" runat="server" Text="Actualizar" /></p>
 <p style="margin-top:-43px; width: 142px; height: 30px;"><a style="margin-left:800px; " class="btn btn-primary "  href="VistaJefe.aspx"><span class="glyphicon glyphicon-backward"></span> Regresar</a>
    </p>

</div>
    
   
</asp:Content>
