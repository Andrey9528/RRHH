﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminVacas.aspx.cs" Inherits="RRHH.UI.AdminVacas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <style>
       body 
        {
            background-image: url("http://1070noticias.com.mx/wp-content/uploads/2016/07/fondos-de-pantalla-blancos-para-descargar.jpg");
            background-attachment:fixed;
            background-size:100vw 100vh ;
            


        }
     
 </style>
<div class="inline">
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


    
    <div style="margin-top:40px; margin-left:70px; width: 100px;"><asp:Label ID="Label2" runat="server" Text="Fecha de inicio:"></asp:Label></div>
        <p style="margin-top:-30px; margin-left:170px; width: 224px;"><asp:TextBox ID="txtfechaincio" CssClass="form-control" runat="server"></asp:TextBox></p>
      
    <p style="margin-left:400px; margin-top:-35px; width: 54px;"><asp:Label ID="Label1" runat="server" Text="Solicitud:"></asp:Label></p>
    <p style="margin-top:-38px; margin-left:460px;" ><asp:DropDownList ID="DDLidsoli" CssClass="form-control" Width="280" runat="server"></asp:DropDownList></p>

      <p style="margin-left:760px; margin-top:-34px; width: 154px;"><asp:Label ID="Label3" runat="server" Text="Fecha de finalización:"></asp:Label></p>
        <p style="margin-top:-40px; margin-left:900px; width: 224px;"><asp:TextBox ID="txtfechafinal" CssClass="form-control" runat="server"></asp:TextBox></p>
       
    <br />
     
    <div class="form-inline col-xs-6 col-md-4 col-md-4 "  >
         <asp:Button ID="btnactualizar" CssClass="btn btn-warning " OnClick="btnactualizar_Click" runat="server"   Text="Actualizar" /> 
        <asp:Button ID="btnbuscar" CssClass="btn btn-primary" runat="server" Text="Buscar" OnClick="btnbuscar_Click" /></div>
    
</div>
    <br /><br />
    <asp:GridView ID="Gv_datos"  CssClass="table  table-bordered table-responsive"   runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>


    


    <br />


     <a class="btn btn-primary"  href="AdminView.aspx"><span class="glyphicon glyphicon-backward"></span> Regresar</a>


</asp:Content>
