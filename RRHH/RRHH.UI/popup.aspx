<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="popup.aspx.cs" Inherits="RRHH.UI.popup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 

    <a href="#" data-target="#Miperfil" data-toggle="modal">Prueba</a>
    <div class="container"> 
    <div class="modal fade" data-keyboard="false" data-backdrop="static" id="Miperfil" role="dialog">
    <div class="modal-dialog col-sm-1 " style="  margin-top:110px;">
      <div class="modal-content  " >
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Mi Perfil</h4>
        </div>
        <div class="modal-body">
            <asp:Label ID="lblnombre" runat="server" Text="Nombre:"></asp:Label>
            <br />
            <asp:Label ID="lblCedula" runat="server" Text="Cedula"></asp:Label>
            <br />
            <asp:Label ID="lblDirreccion" runat="server" Text="Dirrección:"></asp:Label>
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
             <asp:Label ID="lblRol" runat="server" Text="Rol:"></asp:Label>
            <br /><br />
            <div id="img-reponsive " style= " "><asp:Image ID="imgPerfil" Width="170px" Height="120px" runat="server" />
                </div>


           
                    </div>
          
             <footer class="col-sm-offset-8">
               <p>&copy; <%: DateTime.Now.Month %>  Farmacias San Gabriel</p></footer>
            

        <div  style="" class="modal-footer">
            <asp:Button ID="btnCerrarPopup"   CssClass="btn btn-danger"  runat="server" Text="Cerrar" />
        </div>
      </div>
    </div>
  </div>
</div>
    

  
     

  
  <%--  <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
  ControlToValidate="txtCedula"
  ErrorMessage="Cedula es requerida."
  ForeColor="Red">
</asp:RequiredFieldValidator>
      
--%>

   
  
</asp:Content>
