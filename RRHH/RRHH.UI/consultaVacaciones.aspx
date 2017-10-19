<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation = "false" CodeBehind="consultaVacaciones.aspx.cs" Inherits="RRHH.UI.consultaVacaciones" %>
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
    <div class="alert alert-danger" visible="false" id="mensajeError" runat="server">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong id="textoMensajeError" runat="server"></strong>
    </div>
     <div class="alert alert-info" visible="false" id="mensajeinfo" runat="server">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong id="textomensajeinfo" runat="server"></strong>
    </div>

    <h1 style="text-align:center; font-family:cursive;" >Consulta de Vacaciones</h1>
   <br />
    <br />
   
      <div class="form-inline" style="margin-top:-25px;">


       <asp:RadioButton ID="RB_personalizada" Autopostback="true" runat="server" GroupName="Seleccion" OnCheckedChanged="RB_personalizada_CheckedChanged" OnInit="DDLAño_SelectedIndexChanged" />
       <asp:Label ID="Label2" runat="server" Text="Busqueda Personalizada"></asp:Label>
       <asp:RadioButton ID="RB_busquedageneral" Autopostback="true" Checked="true" runat="server" GroupName="Seleccion" OnCheckedChanged="RB_busquedageneral_CheckedChanged" />
       <asp:Label ID="Label1" runat="server" Text="Busqueda general"></asp:Label>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             
     
           <asp:Label ID="Label3" runat="server" Text="De:"></asp:Label>
    
          
            <asp:TextBox ID="txtfechainicio" CssClass="form-control" Width="150"  TextMode="date" runat="server"></asp:TextBox>
          
            
       
           <asp:Label ID="Label5" runat="server" Text="Hasta:"></asp:Label>
      
          
            <asp:TextBox ID="txtfechafinal" CssClass="form-control" Width="150" TextMode="date"  runat="server"></asp:TextBox>
            &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;
   
              
       <asp:Label ID="Label4" runat="server" Text="Condicion:"></asp:Label>
       <asp:DropDownList ID="DDLcondicion" CssClass="form-control" Width="180" runat="server" OnTextChanged="DDLcondicion_TextChanged" AutoPostBack="True">
          <asp:ListItem>Aceptado</asp:ListItem>
          <asp:ListItem>Denegado</asp:ListItem>
          <asp:ListItem></asp:ListItem>
          </asp:DropDownList>
          

    
        <asp:Button ID="btnbuscar" OnClick="btnbuscar_Click"  CssClass="btn btn-primary" runat="server" Text="Buscar"  />
    &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;
      
    
    
        <asp:Label ID="lblExportar" runat="server" Text="Exportar:"></asp:Label>
    
    
    
           
        <asp:Button ID="btnexportar" CssClass="btn btn-danger"   OnClick="btnexportar_Click"  runat="server" Text="PDF" />

  </div>
    <br /><br />

    <div class="table-responsive" >
        <%-- AutoGenerateColumns = False  --%>
        <asp:GridView ID="gvdatos" runat="server"   AutoGenerateColumns = False CssClass="table table-responsive table-bordered " CellPadding="4" ForeColor="#333333" GridLines="None" Width="1030px">
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
            <Columns runat="server" >         
                <asp:BoundField  DataField = "IdSolicitud" runat="server" HeaderText = "N. Solicitud" />
               <%-- <asp:BoundField  DataField = "Cedula"  runat="server"  HeaderText = "Cédula" />--%>
                <asp:BoundField  DataField = "FechaInicio" runat="server" HeaderText = "Inicio" />
                <asp:BoundField  DataField = "FechaFinal" runat="server" HeaderText = "Final" />
                <asp:BoundField  DataField = "TotalDias" runat="server" HeaderText = "Cantidad de días" />
                <asp:BoundField  DataField = "Condicion" runat="server" HeaderText = "Condición" />
             </Columns>   
                 </asp:GridView>
    </div>
       
    
    <asp:Button CssClass="btn btn-success" ID="btnRegresar" OnClick="btnRegresar_Click" runat="server" Text="Regresar" />
</asp:Content>

