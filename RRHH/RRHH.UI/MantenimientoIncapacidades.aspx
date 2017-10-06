<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantenimientoIncapacidades.aspx.cs" Inherits="RRHH.UI.MantenimientoIncapacidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
       body 
        {
            background-image: url("http://1070noticias.com.mx/wp-content/uploads/2016/07/fondos-de-pantalla-blancos-para-descargar.jpg");
            background-attachment:fixed;
            background-size:100vw 100vh ;
            


        }
     
 </style>
<script type="text/javascript">
    function Confirm() {
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden";
        confirm_value.name = "confirm_value";
        if (confirm("Esta seguro de actualizar esta incapacidad?")) {
            confirm_value.value = "Yes";
        } else {
            confirm_value.value = "No";
        }
        document.forms[0].appendChild(confirm_value);
    }


</script>
<div class="form-inline">
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
      <div class="alert alert-info" visible="false"  id="mensajeinfo" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
             <strong id="textomensajeinfo" runat="server"></strong>
        </div>

    <h1 style="text-align:center; font-family:'Comic Sans MS'; font-size:25px;">Mantenimiento de Incapacidades</h1>
    <br />
    <br />
    <br />
    <asp:Label ID="lbIdProducto" runat="server" Text="Cédula: "></asp:Label>
        <asp:TextBox ID="txtcedula" runat="server" CssClass="form-control"></asp:TextBox>
        
    <asp:Button ID="btnsBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnsBuscar_Click" />
    <br><br>

    <asp:GridView ID="grVacaciones"  AutoGenerateColumns = False CssClass="table  table-condensed table-bordered  "  runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True"  HorizontalAlign="Center" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
        <Columns runat="server" >         
                <asp:BoundField  DataField = "idIncapacidad" runat="server" HeaderText = "N. Incapacidad" />
                <asp:BoundField  DataField = "Cedula" runat="server" HeaderText = "Cédula" />
                <asp:BoundField  DataField = "Fecha_Inicio" runat="server" HeaderText = "Inicio" />
                <asp:BoundField  DataField = "Fecha_finalizacion" runat="server" HeaderText = "Finaliza" />
                <asp:BoundField  DataField = "CantidadDias" runat="server" HeaderText = "Cantidad de dias" />
                <asp:BoundField  DataField = "TipoIncapacidad" runat="server" HeaderText = "Tipo" />
                <asp:BoundField  DataField = "Descripcion" runat="server" HeaderText = "Descripción" />
                <asp:BoundField  DataField = "FechaEmision" runat="server" HeaderText = "Emitido" />
                <asp:BoundField  DataField = "CentroEmisor" runat="server" HeaderText = "Emisor" />
                <asp:BoundField  DataField = "NombreDoctor" runat="server" HeaderText = "Doctor" />


            </Columns>
    </asp:GridView>
    </div>







    <br />
    <br />
    <br />
     <br />
   

    <div class="form-inline" id="mantenimientoInca" runat="server" visible="true">

<div class="form-group">
   <p><asp:Label ID="Label2" runat="server" Text="Numero de incapacidad:"></asp:Label></p>
   <p style="margin-left:153px; margin-top:-35px;"> <asp:DropDownList ID="DDLid_incapacidad" CssClass="form-control" Width="280" runat="server"></asp:DropDownList></p>
    <asp:Button ID="btnBuscarIncapacidad" OnClick="btnBuscarIncapacidad_Click" CssClass="btn btn-success" runat="server" Text="Mostrar datos" />

    </div>

        <br />
        <br />
        <br />
        
        <p>
            <asp:Label ID="Label1" runat="server" Text="Fecha Inicio:"></asp:Label></p>
        <p style="margin-left:90px; margin-top:-40px; width: 174px;">
            <asp:TextBox CssClass="form-control" ID="txtfechainicio" runat="server" Width="147px"></asp:TextBox></p>

         <p style="margin-left:260px; width: 146px; margin-top:-32px;">
            <asp:Label ID="Label3"  runat="server" Text="Fecha de finalización:  "></asp:Label></p>
        <p style="margin-left:403px; margin-top:-40px; width: 184px;">
            <asp:TextBox CssClass="form-control" Width="147px" ID="txtfechafinalizacion" runat="server"></asp:TextBox></p>

         <p style="margin-left:570px; width: 146px; margin-top:-32px;">
            <asp:Label ID="Label4"  runat="server" Text="Fecha de emisión:  "></asp:Label></p>
        <p style="margin-left:699px; margin-top:-40px; width: 184px;">
            <asp:TextBox CssClass="form-control" Width="147px" ID="txtfechaemision" runat="server"></asp:TextBox></p>


        <p style="margin-left:855px; width: 146px; margin-top:-32px;">
            <asp:Label ID="Label5"  runat="server" Text="Nombre del doctor:  "></asp:Label></p>
        <p style="margin-left:980px; margin-top:-40px; width: 184px;">
            <asp:TextBox CssClass="form-control" Width="147px" ID="txtdoctor" runat="server"></asp:TextBox></p>

        
        <br />
        <br />
        <p>
            <asp:Label ID="Label6" runat="server" Text="Tipo"></asp:Label></p>
        <p style="margin-left:90px; margin-top:-40px; width: 134px;">
            <asp:DropDownList ID="DDLtipoenfermedad" CssClass="form-control" Width="147" runat="server">
                <asp:ListItem>Enfermedad</asp:ListItem>
                <asp:ListItem>Maternidad</asp:ListItem>
                <asp:ListItem Selected="True">Sin establecer</asp:ListItem>
            </asp:DropDownList>  </p>



         <p style="margin-left:280px; margin-top:-35px; width: 97px;">
            <asp:Label ID="Label7" runat="server" Text="Centro emisor:"></asp:Label></p>
        <p style="margin-left:399px; margin-top:-35px; width: 179px;">

             <asp:TextBox CssClass="form-control" Width="149px" ID="txtcentroemisor" runat="server"></asp:TextBox>

        </p>




         <p style="margin-left:600px; margin-top:-35px; width: 97px;">
            <asp:Label ID="Label8" runat="server" Text="Descripción:"></asp:Label></p>
        <p style="margin-left:699px; margin-top:-35px; width: 179px;">

             <asp:TextBox CssClass="form-control" Width="147px" ID="txtdescripcion" runat="server"></asp:TextBox>

        </p>


         <p style="margin-left:890px; margin-top:-35px; width: 97px;">
            <asp:Label ID="Label9" runat="server" Text="Estado:"></asp:Label></p>
        <p style="margin-left:940px; margin-top:-28px; width: 179px;">

            <asp:CheckBox ID="Chk_estado"  runat="server" />

        </p>


              



      
        <br />
        <br />
  
    
   
    


    
    
     

         <div class="form-inline">
            <br />
               <a class="btn btn-primary"  href="AdminView.aspx"><span class="glyphicon glyphicon-backward"></span> Regresar</a>

            <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning"  OnClick="btnModificar_Click" OnClientClick="Confirm()" />
            
        </div>
    </div>
</asp:Content>
