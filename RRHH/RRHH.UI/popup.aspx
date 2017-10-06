<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="popup.aspx.cs" Inherits="RRHH.UI.popup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <style>
       body 
        {
            background-image: url("http://1070noticias.com.mx/wp-content/uploads/2016/07/fondos-de-pantalla-blancos-para-descargar.jpg");
            background-attachment:fixed;
            background-size:100vw 100vh ;
            


        }
     
 </style>
    <h1 style="font-size:30px; font-family:cursive; text-align:center; ">Registro de Incapacidades</h1>
 
     <br />
   
    <div class="row">
       <div class="col-xs-6 col-sm-4 col-sm-offset-2">
           <div class="form-inline col-sm-offset-0">
        <div class="form-inline">
     <asp:Label ID="Label1" runat="server"   Text="Fecha de Inicio"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:TextBox ID="txtCedula" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
  

        </div>
               <br /><br />
               <div class="form-inline">

<asp:Label ID="Label2" runat="server"  Text="Fecha de emision"></asp:Label>&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtNombre" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>

               </div>
               <br /><br />
               <div class="form-inline">

   <asp:Label ID="Label4" runat="server"    Text="Tipo de incapacidad"></asp:Label>
                   <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                          <asp:ListItem>Enfermedad</asp:ListItem>
        <asp:ListItem>Maternidad</asp:ListItem>
        <asp:ListItem Selected="True">Indefinido</asp:ListItem>
                   </asp:DropDownList>
                     
               </div>
               <br /><br />
               <div class="form-inline">
   <asp:Label ID="Label5" runat="server"   Text="Centro emisor"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtCorreo" CssClass="form-control" runat="server"></asp:TextBox>
    
    
               </div>
              
             

           </div>
       </div>



       <div class="clearfix visible-xs"></div>
       <div class="col-xs-6 col-sm-4 ">

           <div class="form-inline">

               <div class="form-inline">
          <asp:Label ID="Label7"  runat="server" Text="Fecha de Finalizacion "></asp:Label> 

    <asp:TextBox ID="txtFechaNacimiento" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
    
               </div>
               <br /><br /><br />
               <div class="form-inline">

    <asp:Label ID="Label11" runat="server" Text="Descricpcion"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" CssClass="form-control" TextMode="Multiline" runat="server"></asp:TextBox>
   
               </div>
               <br /><br /><br />
               <div class="form-inline">

  <asp:Label ID="Label6" runat="server"   Text="Doctor"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   
  <asp:TextBox ID="TextBox2" CssClass="form-control"  runat="server"></asp:TextBox>
     
               </div>
             

           </div>
       </div>

   </div>
    <br /><br />
    <div class="form-inline col-sm-offset-5">
 <a class="btn btn-primary"  href="AdminView.aspx"><span class="glyphicon glyphicon-backward"></span> Regresar</a>
    
        <asp:Button ID="btnCrear" CssClass="btn btn-success" runat="server" Text="Crear" />
    <asp:Button ID="btnLimpiar"  CssClass="btn btn-danger" runat="server" Text="Limpiar" />
        
   
    </div>
    
   
        
        
        
       
   
   
    
      
  
   <%-- <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
  ControlToValidate="txtCedula"
  ErrorMessage="Cedula es requerida."
  ForeColor="Red">
</asp:RequiredFieldValidator>--%>
      


   
  
</asp:Content>
