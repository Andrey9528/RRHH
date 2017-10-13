<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminVacas.aspx.cs" Inherits="RRHH.UI.AdminVacas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <style>
       body 
        {
            background-image: url("http://1070noticias.com.mx/wp-content/uploads/2016/07/fondos-de-pantalla-blancos-para-descargar.jpg");
            background-attachment:fixed;
            background-size:100vw 100vh ;
            


        }
     
 </style>
<div class="form-group">
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
      <div class="alert  alert-info" visible="false"  id="mensajeinfo" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
             <strong id="textomensajeinfo" runat="server"></strong>
        </div>
</div>   
     <div class="container col-sm-offset-1">
    <div class="form-inline">
   
     <asp:Label ID="Label2" runat="server" Text="Fecha de inicio:"></asp:Label>
    <asp:TextBox ID="txtfechaincio" CssClass="form-control" runat="server"></asp:TextBox>
   
      
    <asp:Label ID="Label1" runat="server" Text="Solicitud:"></asp:Label>
   <asp:DropDownList ID="DDLidsoli" CssClass="form-control"  runat="server"></asp:DropDownList> 
  
        
 
   <asp:Label ID="Label3" runat="server" Text="Fecha de finalización:"></asp:Label>
   <asp:TextBox ID="txtfechafinal" CssClass="form-control" runat="server"></asp:TextBox>
         </div>  
        </div>
    <br />
     
    <div class="form-inline col-xs-6 col-md-4 col-md-4 "  >
         <asp:Button ID="btnactualizar" CssClass="btn btn-warning " OnClick="btnactualizar_Click" runat="server"   Text="Actualizar" /> 
        <asp:Button ID="btnbuscar" CssClass="btn btn-primary" runat="server" Text="Buscar" OnClick="btnbuscar_Click" /></div>
    

    <br /><br />
    <div class="table-responsive">
    <asp:GridView ID="Gv_datos" AutoGenerateColumns = False  CssClass="table  table-bordered table-responsive"   runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
            <Columns runat="server" >         
            <asp:BoundField  DataField = "IdSolicitud" runat="server" HeaderText = "N.solicitud" />
            <asp:BoundField  DataField = "Cedula" runat="server" HeaderText = "Cédula" />
            <asp:BoundField  DataField = "FechaInicio" runat="server" HeaderText = "Inicio" />
            <asp:BoundField  DataField = "FechaFinal" runat="server" HeaderText = "Final" />
            <asp:BoundField  DataField = "TotalDias" runat="server" HeaderText = "Cantidad de dias" />
            <asp:BoundField  DataField = "Condicion" runat="server" HeaderText = "Estado" />

                  </columns>
        </asp:GridView>
        </div>

    


    <br />


 <%--    <a class="btn btn-primary"  href="AdminView.aspx"><span class="glyphicon glyphicon-backward"></span> Regresar</a>--%>
    <asp:Button ID="btnRegresar" OnClick="btnRegresar_Click" CssClass="btn btn-primary"  runat="server" Text="Regresar" />

</asp:Content>
