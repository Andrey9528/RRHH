<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="consultaVacaciones.aspx.cs" Inherits="RRHH.UI.consultaVacaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<style>
     body 
        {
            background-image: url("http://1070noticias.com.mx/wp-content/uploads/2016/07/fondos-de-pantalla-blancos-para-descargar.jpg");
            background-attachment:local;
            background-size:100vw 100vh ;
            background-color:transparent;
            


        }
</style>
    <h1 style="text-align:center; font-family:cursive;" >Consulta de Vacaciones</h1>
   <br />
    
   
      <div style="margin-left:80px;">
       <asp:RadioButton ID="RB_personalizada" Autopostback="true" runat="server" GroupName="Seleccion" OnCheckedChanged="RB_personalizada_CheckedChanged" OnInit="DDLAño_SelectedIndexChanged" />
       <asp:Label ID="Label2" runat="server" Text="Busqueda Personalizada"></asp:Label>
        <br />
       <asp:RadioButton ID="RB_busquedageneral" Autopostback="true" Checked="true" runat="server" GroupName="Seleccion" OnCheckedChanged="RB_busquedageneral_CheckedChanged" />
       <asp:Label ID="Label1" runat="server" Text="Busqueda general"></asp:Label>
       </div>
       <div style="width: 34px; margin-left:350px; margin-top:-30px; "> 
           <asp:Label ID="Label3" runat="server" Text="Año:"></asp:Label></div>
       <div style="margin-left:400px; margin-top:-30px;  width: 115px;">
      
       <asp:DropDownList CssClass="form-control"  Width="180" ID="DDLAño" runat="server" OnSelectedIndexChanged="DDLAño_SelectedIndexChanged" AutoPostBack="True">
           </asp:DropDownList>
            </div>
       
       <div style="width: 69px; margin-left:600px; margin-top:-20px;"><asp:Label ID="Label4" runat="server" Text="Condicion:"></asp:Label></div>
      <div style="width: 178px; margin-left:680px; margin-top:-30px;"> <asp:DropDownList ID="DDLcondicion" CssClass="form-control" Width="180" runat="server" AutoPostBack="True">
          <asp:ListItem>Aceptado</asp:ListItem>
          <asp:ListItem>Denegado</asp:ListItem>
          <asp:ListItem></asp:ListItem>
          </asp:DropDownList>
           </div>

    <div style="width: 87px; margin-left:900px; margin-top:-30px;">
        <asp:Button ID="btnbuscar" OnClick="btnbuscar_Click"  CssClass="btn btn-primary" runat="server" Text="Buscar"  />
    
    </div>
    <div style="margin-left:1000px; margin-top:-20px;">
        <asp:Label ID="lblExportar" runat="server" Text="Exportar:"></asp:Label>
    </div>
    
    <div style="margin-left:1060px; margin-top:-30px;">
           
        <asp:Button ID="btnexportar" CssClass="btn btn-danger"  OnClick="btnexportar_Click" runat="server" Text="PDF" />

    </div>


    <div style="width: 969px; margin-left:84px; margin-top:40px;">

        <asp:GridView ID="gvdatos" runat="server"    CssClass="table table-responsive table-bordered " CellPadding="4" ForeColor="#333333" GridLines="None" Width="1030px">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
       
    <a class="btn btn-success" href="EmpleadoView.aspx"><span class="glyphicon glyphicon-backward"></span> Regresar</a>

</asp:Content>

