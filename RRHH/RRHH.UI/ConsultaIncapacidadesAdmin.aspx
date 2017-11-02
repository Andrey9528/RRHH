<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaIncapacidadesAdmin.aspx.cs" Inherits="RRHH.UI.ConsultaIncapacidadesAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


 <style>
     body 
        {
            background-image: url( "http://1070noticias.com.mx/wp-content/uploads/2016/07/fondos-de-pantalla-blancos-para-descargar.jpg");
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

    <h1 style="text-align:center; font-family:cursive;" >Consulta de Incapacidades</h1>
   <br />
    
   <br />
    <div class="form-inline" style="margin-top:-25px;">
      
       <asp:RadioButton ID="RB_personalizada" Autopostback="true" runat="server" GroupName="Seleccion" OnCheckedChanged="RB_personalizada_CheckedChanged"  />
       <asp:Label ID="Label2" runat="server" Text="Busqueda Personalizada"></asp:Label>
      
       <asp:RadioButton ID="RB_busquedageneral" Autopostback="true" Checked="true" runat="server" GroupName="Seleccion" OnCheckedChanged="RB_busquedageneral_CheckedChanged" />
       <asp:Label ID="Label1" runat="server" Text="Busqueda general"></asp:Label>
      
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         
           <asp:Label ID="Label3" runat="server" Text="De:"></asp:Label>
       
          
            <asp:TextBox ID="txtfechainicio" CssClass="form-control" Width="150"  TextMode="date" runat="server"></asp:TextBox>
          
        
           <asp:Label ID="Label5" runat="server" Text="Hasta:"></asp:Label>
       
          
            <asp:TextBox ID="txtfechafinal" CssClass="form-control" Width="150" TextMode="date"  runat="server"></asp:TextBox>
          
          &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;
   
       
     

    
        <asp:Button ID="Btnbusca" OnClick="Btnbusca_Click" CssClass="btn btn-primary" runat="server" Text="Buscar" />
     &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;
       
    
        <asp:Label ID="lblExportar" runat="server" Text="Exportar:"></asp:Label>
    
    
    
           
        <asp:Button ID="btnexportar" CssClass="btn btn-danger"  OnClick="btnexportar_Click" runat="server" Text="PDF" />

    
</div>
    <br /><br /><br />
    <div class="table-responsive">

        <%--AutoGenerateColumns = False para que funcione los alias y descomentar lo de abajo --%>
        <asp:GridView ID="gvdatos" runat="server"    AutoGenerateColumns = False   CssClass="table table-responsive table-bordered " CellPadding="4" ForeColor="#333333" GridLines="None" Width="1200px">
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
                <asp:BoundField  DataField = "IdIncapacidad" runat="server" HeaderText = "N. Incapacidad" />
                <%--<asp:BoundField  DataField = "Cedula" runat="server" HeaderText = "Cédula" />--%>
                <asp:BoundField  DataField = "Fecha_Inicio" runat="server" HeaderText = "Inicio" />
                <asp:BoundField  DataField = "Fecha_finalizacion" runat="server" HeaderText = "Finalización" />
                <asp:BoundField  DataField = "CantidadDias" runat="server" HeaderText = "Cantidad de dias" />
                <asp:BoundField  DataField = "TipoIncapacidad" runat="server" HeaderText = "Tipo" />
                <asp:BoundField  DataField = "Descripcion" runat="server" HeaderText = "Descripción" />
                <asp:BoundField  DataField = "FechaEmision" runat="server" HeaderText = "Fecha de Emisión" />
                <asp:BoundField  DataField = "CentroEmisor" runat="server" HeaderText = "Emisor" />
                <asp:BoundField  DataField = "NombreDoctor" runat="server" HeaderText = "Doctor" />
                <%--<asp:BoundField  DataField = "Estado" runat="server" HeaderText = "Estado" />
    --%>
             </Columns>
        </asp:GridView>
    </div>
    <asp:Button ID="btnregresar" OnClick="btnregresar_Click" runat="server" CssClass="btn btn-success" Text="Regresar" /> 
  

</asp:Content>
