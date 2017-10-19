<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="popup.aspx.cs" Inherits="RRHH.UI.popup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 
 
   <ul> 
   <li><a data-target="#Miperfil" data-toggle="modal" href="#">hola</a></li>
          
       </ul> 
           
   <div class="container"  >
  
  <div class="modal fade" data-keyboard="false" data-backdrop="static" id="Miperfil" role="dialog">
    <div class="modal-dialog modal-sm">
      <div class="modal-content " style=" margin-top:130px;  ">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Mi Perfil</h4>
        </div>
        <div class="modal-body">    
        <div class="container">

            <div class="row">
                <div class="col-sm-4">
 <asp:Label ID="lblnombre" runat="server" Text="Nombre:"></asp:Label>
            <br />
            <asp:Label ID="lblCedula" runat="server" Text="Cedula"></asp:Label>
            <br />
            <asp:Label ID="lblDirreccion" runat="server" Text="Dirección:"></asp:Label>
            <br />
             <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label>
            <br />
             <asp:Label ID="lblCorreo" runat="server" Text="Correo:"></asp:Label>
            <br />
             <asp:Label ID="lblestadocivil" runat="server" Text="Estado Civil:"></asp:Label>
            <br />
             <asp:Label ID="lblfechaNaci" runat="server" Text="Fecha de nacimiento:"></asp:Label>
            <br />
             <asp:Label ID="lbldepa" runat="server" Text="Departamento:"></asp:Label>
            <br />
<%--             <asp:Label ID="lblRol" runat="server" Text="Rol:"></asp:Label>--%>
            <br />
                </div>
                <div class="col-sm-5" style="">
  
            <asp:Image ID="imgPerfil" Width="170px" Height="120px" runat="server" />
             </div>  
                
            </div>
        </div>
           
       
        </div>
        <div class="modal-footer">
          <button  type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
<%--           <div style="margin-top:-30px;"><asp:Button ID="btnsalir" CssClass="btn btn-danger" runat="server" Text="Salir"  OnClick="btnsalir_Click" />--%>
        </div>
            </div>
      </div>
    </div>
  </div>
      


  
   <%-- <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
  ControlToValidate="txtCedula"
  ErrorMessage="Cedula es requerida."
  ForeColor="Red">
</asp:RequiredFieldValidator>--%>
      


   
  
</asp:Content>
