<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuditoriasAdmin.aspx.cs" Inherits="RRHH.UI.AuditoriasAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RRHH</title>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
  <link href="https://www.javatpoint.com/fullformpages/images/Medical.png" rel="shortcut icon" type="image/x-icon" />

</head>
<body>
    <style>
       body 
        {
            background-image: url("http://1070noticias.com.mx/wp-content/uploads/2016/07/fondos-de-pantalla-blancos-para-descargar.jpg");
            background-attachment:fixed;
            background-size:100vw 100vh;
            


        }
     
 </style>

    <form id="form1" runat="server">
    <h1 style="font-family:cursive; text-align:center;">Auditorias</h1>
    
    <br /><br />
    
       
    <div class="form-inline ">

     <asp:Label ID="lblAudi" runat="server" Text="Tipo de Auditoria:"></asp:Label>
           
    <asp:DropDownList ID="DDLAudi" OnTextChanged="DDLAudi_TextChanged" CssClass="form-control" runat="server" AutoPostBack="True">
               <asp:ListItem Selected="True">Empleados</asp:ListItem>
               <asp:ListItem>Jefes</asp:ListItem>
               <asp:ListItem>Administradores</asp:ListItem>
           </asp:DropDownList>

        <asp:Button ID="btnRegresar" OnClick="btnRegresar_Click" runat="server" CssClass="btn btn-primary" Text="Regresar" />
       </div>  
        
        
        <div class="col-sm-offset-4" style="font-family:cursive; font-size:30px;">
            <asp:Label ID="lblMensaje" runat="server" ></asp:Label>
            </div>




        <div class="table-responsive">
            <asp:GridView ID="Gv_datos"  CssClass="table table-bordered" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
        </div>

     
    </form>



</body>
</html>
