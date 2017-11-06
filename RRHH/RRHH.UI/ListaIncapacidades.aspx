<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaIncapacidades.aspx.cs" Inherits="RRHH.UI.ListaIncapacidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
         <div class="alert alert-danger" visible="false"  id="Div1" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
             <strong id="Strong1" runat="server"></strong>
        </div>
        <div class="alert alert-success" visible="false"  id="mensaje" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
             <strong id="textoMensaje" runat="server"></strong>
        </div>
           <div class="alert alert-warning" visible="false" id="mensajawarning" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
            <strong id="textomensajewarning" runat="server"></strong>

        </div>
      <div class="alert alert-info" visible="false"  id="mensajeinfo" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
             <strong id="textomensajeinfo" runat="server"></strong>
        </div>
        </div>
    <style >
        body 
        {
            background-image: url("http://1070noticias.com.mx/wp-content/uploads/2016/07/fondos-de-pantalla-blancos-para-descargar.jpg");
            background-attachment:fixed;
            background-size:100vw 100vh ;
            


        }
       
        #btn {
            margin-left:800px;
        }
        @media only screen and (max-width: 500px)  {

            #btn{
                margin-left:50px;
            }
        }
        </style>
    <div class="aler alert-danger" visible="false" id="mensajeError" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
            <strong id="textoMensajeError" runat="server"></strong>

        </div>

    <h1 style="font-family:cursive; font-size:30px; text-align:center;" >Lista de Incapacidades</h1>
    <br />

    <div class="col-xs-3  col-sm-offset-4">
        
        <asp:DropDownList   OnSelectedIndexChanged="DDLEstado_SelectedIndexChanged" ID="DDLEstado" CssClass="form-control" runat="server" AutoPostBack="True">
            <asp:ListItem>Registradas</asp:ListItem>
            <asp:ListItem>No registradas</asp:ListItem>
        </asp:DropDownList></div>

    <br /><br /> <br /><br /> <br /><br />
    
    <div class="table-responsive" >

        <asp:GridView ID="GV_inca" AutoGenerateColumns = False CssClass="table table-bordered table-condensed "    runat ="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <EmptyDataRowStyle Font-Names="Broadway" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" BorderStyle="Solid" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
            <Columns runat="server" >
                <asp:BoundField  DataField = "NombreEmpleado" runat="server" HeaderText = "Nombre del empleado" />         
                <asp:BoundField  DataField = "IdIncapacidad" runat="server" HeaderText = "N. Incapacidad" />
                <asp:BoundField  DataField = "Cedula" runat="server" HeaderText = "Cédula" />
                <asp:BoundField  DataField = "Fecha_Inicio" runat="server" HeaderText = "Inicio" />
                <asp:BoundField  DataField = "Fecha_finalizacion" runat="server" HeaderText = "Finalización" />
                <asp:BoundField  DataField = "CantidadDias" runat="server" HeaderText = "Cantidad de dias" />
                <asp:BoundField  DataField = "TipoIncapacidad" runat="server" HeaderText = "Tipo" />
                <asp:BoundField  DataField = "Descripcion" runat="server" HeaderText = "Descripción" />
                <asp:BoundField  DataField = "FechaEmision" runat="server" HeaderText = "Fecha de Emisión" />
                <asp:BoundField  DataField = "CentroEmisor" runat="server" HeaderText = "Emisor" />
                <asp:BoundField  DataField = "NombreDoctor" runat="server" HeaderText = "Doctor" />
                <%--<asp:BoundField  DataField = "Estado" runat="server" HeaderText = "Estado" />--%>

    
             </Columns>
        </asp:GridView>

    </div>

    
    <asp:Button ID="btnRegresar" CssClass="btn btn-primary"  OnClick="btnRegresar_Click" runat="server" Text="Regresar" />   

</asp:Content>
