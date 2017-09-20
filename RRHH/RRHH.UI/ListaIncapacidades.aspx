<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaIncapacidades.aspx.cs" Inherits="RRHH.UI.ListaIncapacidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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

    <h1 style="font-family:cursive; font-size:30px; text-align:center;" >Lista de Incapacidades</h1>
    <br />

    <div class="col-xs-3  col-sm-offset-4">
        
        <asp:DropDownList   OnSelectedIndexChanged="DDLEstado_SelectedIndexChanged" ID="DDLEstado" CssClass="form-control" runat="server" AutoPostBack="True">
            <asp:ListItem>Activos </asp:ListItem>
            <asp:ListItem>Inactivos</asp:ListItem>
        </asp:DropDownList></div>

    <br /><br /> <br /><br /> <br /><br />
    
    <div class="table-responsive" >

        <asp:GridView ID="GV_inca"  CssClass="table table-bordered table-condensed "    runat ="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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

        </asp:GridView>

    </div>

   <div id="btn"  class="boton"> <asp:Button CssClass="btn btn-danger" ID="Button1" runat="server" Text="XXX" />
       </div>

</asp:Content>
