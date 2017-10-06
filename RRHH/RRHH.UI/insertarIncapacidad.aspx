<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="insertarIncapacidad.aspx.cs" Inherits="RRHH.UI.insertarIncapacidad" %>
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
        <div class="aler alert-danger" visible="false" id="mensajeError" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
            <strong id="textoMensajeError" runat="server"></strong>

        </div>
      <div class="aler alert-warning" visible="false" id="mensajawarning" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
            <strong id="textomensajewarning" runat="server"></strong>

        </div>
      <div class="alert alert-info" visible="false"  id="mensajeinfo" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
             <strong id="textomensajeinfo" runat="server"></strong>
        </div>

</div>
    <br />

    <h1 style="font-size:30px; font-family:cursive; text-align:center; ">Registro de Incapacidades</h1>
 
     <br /><br />
   

    <div class="row">
        <div class="col-xs-6 col-sm-4 col-sm-offset-2">


            <div class="form-inline col-sm-offset-0">

                <div class="form-inline">

<asp:Label ID="Label2" runat="server" Text="Fecha de inicio:"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtfechainicio"  TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>

                </div>
               
                <br /><br />
                <div class="form-inline">
 <asp:Label ID="Label5" runat="server" Text="Fecha de emisión:"></asp:Label>&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtfechaemision"  TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>

                </div>
                <br /><br />
                <div class="form-inline">
  <asp:Label ID="Label4" runat="server" Text="Tipo de incapacidad:"></asp:Label>
    <asp:DropDownList ID="DDLTipo"  CssClass="form-control" runat="server">
        <asp:ListItem>Enfermedad</asp:ListItem>
        <asp:ListItem>Maternidad</asp:ListItem>
        <asp:ListItem Selected="True">Indefinido</asp:ListItem>
      </asp:DropDownList>
   
    
                </div>
                <br /><br />
                <div class="form-inline">
   <asp:Label ID="Label7" runat="server" Text="Centro emisor:"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtcentroemisor" CssClass="form-control" runat="server"></asp:TextBox>

                </div>
               
            </div>
        </div>

         <div class="clearfix visible-xs"></div>
        <div class="col-xs-6 col-sm-4">
            <div class="form-inline">
            <div class="form-inline">
 <asp:Label ID="Label1" runat="server" Text="Fecha de finalizacion:"></asp:Label>
    <asp:TextBox ID="txtfechafinal"  TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>

            </div>
            <br /><br /><br/>
            <div class="form-inline">
<asp:Label ID="Label9" runat="server" Text="Descripcion:"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtdescripcion"   TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>

            </div>
            <br /><br /><br /><br />
            <div class="form-inline">

    <asp:Label ID="Label8" runat="server" Text="Doctor:"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtnombredoc" CssClass="form-control" runat="server"></asp:TextBox>

            </div>
        </div>
            </div>
    </div>
    <br /><br />

    
  
  


    

   
  


    

    <div class="form-inline col-sm-offset-5">
    
    <asp:Button ID="btninsertar" runat="server" Text="Insertar" CssClass="btn btn-success" OnClick="btninsertar_Click"  />
    <a   class="btn btn-primary"  href="WebForm1.aspx"><span class="glyphicon glyphicon-backward"></span> Regresar</a>



        </div>

</asp:Content>
