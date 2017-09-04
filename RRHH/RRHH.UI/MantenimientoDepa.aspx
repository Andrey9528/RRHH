<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantenimientoDepa.aspx.cs" Inherits="RRHH.UI.MantenimientoDepa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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

        <br />

        <h1 style="text-align:center; font-family:cursive;">Mantenimiento departamentos</h1>
        <br />
        <br />
      <br />
       
       <div><asp:Label ID="Label1" runat="server" Text="Departamento:"></asp:Label></div>
       <div style="margin-left:100px; margin-top:-24px;">
           <asp:DropDownList ID="DDLdepa" Width="280" CssClass="form-control" runat="server">
               
           </asp:DropDownList>
         
       <br />
        <div >  <asp:Button CssClass="btn btn-primary" OnClick="btnbuscardepa_Click" ID="btnbuscardepa" runat="server" Text="Buscar" /></div>
           <br />
                  </div>
        </div>








    <div class="form-inline" id="mantenimientoDepa"  runat="server"  visible="false">
       <div style="margin-left:410px; margin-top:-99px; height: 34px; width: 219px;"> <asp:Label ID="Label2" runat="server" Text="Correo de jefe de departamento:"></asp:Label></div>
       <div style="margin-left:620px; margin-top:-40px;"> <asp:TextBox Width="190px" ID="txtcorreojefe" TextMode="Email"  CssClass="form-control" runat="server" Height="30px" ></asp:TextBox></div>
   <div style="margin-left:830px; margin-top:-27px; width: 56px;"><asp:Label ID="Label3" runat="server" Text="Nombre:"></asp:Label></div>
       
        
        
         <div style="margin-left:900px; margin-top:-23px;" ><asp:TextBox ID="txtnombre" CssClass="form-control" runat="server" Width="190px" Height="30px" ></asp:TextBox></div>
    
        <div style="margin-left:580px; margin-top:20px; width: 136px;">
            <asp:Button ID="btnactualizar" CssClass="btn btn-warning" runat="server" OnClick="btnactualizar_Click" Text="Actualizar" />

        </div>
    
    <div style="margin-left:980px; margin-top:-30px;">
        <asp:Button ID="btndesahabilitar" OnClick="btndesahabilitar_Click" CssClass="btn btn-danger"  runat="server" Text="Borrar" />
    </div>
        </div>


    <br />
    <br />
    <br />

    <br />


    <div class="table-responsive">
        <asp:GridView ID="Gv_datos" runat="server" CssClass="table table-bordered" CellPadding="4" ForeColor="#333333" GridLines="None">
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


</asp:Content>
