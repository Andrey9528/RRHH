<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroEmpleado.aspx.cs" Inherits="RRHH.UI.RegistroEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      
    
    <style>
       body 
        {
            background-image: url("http://1070noticias.com.mx/wp-content/uploads/2016/07/fondos-de-pantalla-blancos-para-descargar.jpg");
            background-attachment:fixed;
            background-size:100vw 100vh ;
            


        }
     
 </style>
    
    <div class="alert alert-success" visible="false"  id="mensaje" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
             <strong id="textoMensaje" runat="server"></strong>
        </div>        
   
     <h1 style="font-size:30px; font-family:cursive; text-align:center; ">Agregar Empleado</h1>
  
      <br />
   <div class="row">
       <div class="col-xs-6 col-sm-4 col-sm-offset-2">
           <div class="form-inline col-sm-offset-2">
        <div class="form-inline">
     <asp:Label ID="Label1" runat="server"   Text="Cédula"></asp:Label>&nbsp;&nbsp;
      <asp:TextBox ID="txtCedula" CssClass="form-control" runat="server"></asp:TextBox>
  

        </div>
               <br /><br />
               <div class="form-inline">

<asp:Label ID="Label2" runat="server"  Text="Nombre"></asp:Label>&nbsp;
    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>

               </div>
               <br /><br />
               <div class="form-inline">

   <asp:Label ID="Label4" runat="server"    Text="Teléfono"></asp:Label>
    <asp:TextBox ID="txtTelefono" CssClass="form-control"    runat="server"></asp:TextBox>
    
               </div>
               <br /><br />
               <div class="form-inline">
   <asp:Label ID="Label5" runat="server"   Text="Correo"></asp:Label>&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtCorreo" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
    
    
               </div>
               <br /><br />
             <div class="form-inline">

 <asp:Label ID="Label9"   runat="server" Text="Rol"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
       <asp:DropDownList ID="ddlRol" class = "form-control" runat="server"></asp:DropDownList>
       
               </div>
               <br /><br />
               
  <div class="form-inline col-sm-offset-2">

<asp:Label ID="Label7"  runat="server" Text="Fecha Nacimiento "></asp:Label>&nbsp;&nbsp;
    <asp:TextBox ID="txtFechaNacimiento" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
    
               </div>
           </div>
       </div>



       <div class="clearfix visible-xs"></div>
       <div class="col-xs-6 col-sm-4">

           <div class="form-inline">

               <div class="form-inline">
                   <asp:Label ID="Label10" runat="server"   Text="Imagen"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   
<asp:TextBox ID="txtImagen" placeholder="imagen" runat="server" CssClass="form-control"></asp:TextBox>       
         <asp:FileUpload ID="fileUpload1" accept="image/*" style="display:none;" runat="server" />
        <input type="button" id="btnnAdjuntar" runat="server" value="adjuntar" class="btn btn-success" onclick="adjuntarImagen()" /> 
       

               </div>
               <br /><br />
               <div class="form-inline">

    <asp:Label ID="Label11" runat="server" Text="Genero"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DDLgenero"   CssClass="form-control" runat="server">
            <asp:ListItem>Masculino</asp:ListItem>
            <asp:ListItem>Femenino</asp:ListItem>
            <asp:ListItem Selected="True">Sin establecer</asp:ListItem>
        </asp:DropDownList> 
               </div>
               <br /><br />
               <div class="form-inline">

  <asp:Label ID="Label6" runat="server"   Text="Estado Civil"></asp:Label>&nbsp;&nbsp;&nbsp;
     
    <asp:DropDownList ID="DddlEstadoCivil" class = "form-control" runat="server">
        <asp:ListItem>Casado/a</asp:ListItem>
        <asp:ListItem>Soltero/a</asp:ListItem>
        <asp:ListItem>Unión libre</asp:ListItem>
        <asp:ListItem>Viudo/a</asp:ListItem>
        <asp:ListItem Selected="True">Indefinido</asp:ListItem>
    </asp:DropDownList>
               </div>
               <br /><br />
               <div class="form-inline">

<asp:Label ID="Label8"    runat="server" Text="Departamento"></asp:Label>
      
    <asp:DropDownList ID="ddlDepartamento" class = "form-control" runat="server"> </asp:DropDownList>
    
               </div>
               <br /><br />
               <div class="form-inline">
 <asp:Label ID="Label3" runat="server"   Text="Direccion"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtDireccion" CssClass="form-control"    TextMode="MultiLine" runat="server"></asp:TextBox>
   

               </div>
               <br /><br />

           </div>
       </div>

   </div>
    <br /><br />
    <div class="form-inline col-sm-offset-5">
 <a class="btn btn-primary"  href="AdminView.aspx"><span class="glyphicon glyphicon-backward"></span> Regresar</a>
    
        <asp:Button ID="btnCrear" OnClick="btnCrear_Click" CssClass="btn btn-success" runat="server" Text="Crear" />
    <asp:Button ID="btnLimpiar" onclick="btnLimpiar_Click" CssClass="btn btn-danger" runat="server" Text="Limpiar" />
        
   
    </div>
    
   
        
        
        
       
   
       <script>
           function adjuntarImagen()
           {
               document.getElementById('MainContent_fileUpload1').click();
               document.getElementById('MainContent_txtImagen').readOnly = true;

           }
       </script>

    
   
   
    
      
             
    
            
         
   <%-- <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
  ControlToValidate="txtCedula"
  ErrorMessage="Cedula es requerida."
  ForeColor="Red">
</asp:RequiredFieldValidator>--%>
      


   
   
</asp:Content>
