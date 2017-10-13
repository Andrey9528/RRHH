    <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarEmpleados.aspx.cs" Inherits="RRHH.UI.Lista_de_Empleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<style>
     body 
        {
            background-image: url("http://1070noticias.com.mx/wp-content/uploads/2016/07/fondos-de-pantalla-blancos-para-descargar.jpg");
            background-attachment:local;
            background-size:100vw 100vh ;
            background-color:transparent;
            


        }
</style>

     <div class="aler alert-danger" visible="false" id="mensajeError" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
            <strong id="textoMensajeError" runat="server"></strong>

        </div>

    <h1 style="text-align:center; font-family:cursive; font-size:27px;">Lista de empleados</h1>
   <br />
    <br />
    <div class="col-xs-2 col-sm-offset-5">
        <asp:DropDownList ID="DDLActivos"  CssClass="form-control  " runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLActivos_SelectedIndexChanged">
            <asp:ListItem>Activo</asp:ListItem>
            <asp:ListItem>Inactivo</asp:ListItem>
        </asp:DropDownList>

    </div>
    <br />
    <br />

    <br />
    <br />

  
   

   
     <div class="col-sm-offset-5">
      <asp:Button ID="btnregresar" runat="server" CssClass="btn btn-success" OnClick="btnregresar_Click" Text="Regresar"/>
     
         
      <asp:Button ID="btnPDF" runat="server" CssClass="btn btn-danger" OnClick="btnPDF_Click" Text="PDF"/>
          
     </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BD_RRHHConnectionString3 %>" SelectCommand="SELECT [Cedula], [Nombre], [Direccion], [Telefono], [Correo], [EstadoCivil], [FechaNacimiento], [Estado], [Genero], [Imagen] FROM [Empleado]"></asp:SqlDataSource>

    <div class="table-responsive">
        <asp:GridView ID="GV_personas" CssClass="table table-bordered " AutoGenerateColumns = False runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
           <Columns runat="server" >         
                <asp:BoundField  DataField = "Cedula" runat="server" HeaderText = "Cedula" />
                <asp:BoundField DataField = "Nombre" runat="server" HeaderText = "Nombre" />
                <asp:BoundField DataField = "Direccion" runat="server" HeaderText = "Direccion" />
                <asp:BoundField DataField = "Telefono" runat="server" HeaderText = "Telefono" />
                <asp:BoundField DataField = "Correo" runat="server" HeaderText = "Correo" />
                <asp:BoundField DataField = "EstadoCivil" runat="server" HeaderText = "Estado Civil" />
                <asp:BoundField DataField = "Genero" runat="server" HeaderText = "Genero" />
                <asp:BoundField DataField = "FechaNacimiento" runat="server" HeaderText = "Fecha de Nacimiento" />
                <asp:BoundField DataField = "Estado" runat="server" HeaderText = "Estado" />
                <asp:ImageField HeaderText="Imagen" runat="server"  DataImageUrlField="Imagen" 
            ControlStyle-Width="100">
<ControlStyle Width="100px"></ControlStyle>
                </asp:ImageField>
           </Columns>


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
    

    
   
</asp:Content>
