<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantenimientoDepa.aspx.cs" Inherits="RRHH.UI.MantenimientoDepa" %>
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
        if (confirm("Esta seguro que quiere actualizar este departamento?")) {
            confirm_value.value = "Yes";
        } else {
            confirm_value.value = "No";
        }
        document.forms[0].appendChild(confirm_value);
    }


</script>
    
    
    
    <div class="inline">
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
      <div class="alert  alert-info" visible="false"  id="mensajeinfo" runat="server">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times</a>
             <strong id="textomensajeinfo" runat="server"></strong>
        </div>

        <br />

        <h1 style="text-align:center; font-family:cursive;">Mantenimiento departamentos</h1>
        <br />
        <br />
      <br />
       
       <div><asp:Label ID="Label1" runat="server" Text="Departamento:"></asp:Label>
       
       <div style="margin-left:100px; margin-top:-24px;">
           <asp:DropDownList ID="DDLdepa" Width="280" CssClass="form-control" runat="server">
               
           </asp:DropDownList>
         
       <div style="margin-left:300px; margin-top:-24px; width: 75px;">
           <asp:Label ID="lblActivo" runat="server" Visible="false" Text="Activo:"></asp:Label>

       </div>
            <div style="width:137px; margin-left:350px; margin-top:-17px;">
                <asp:CheckBox  Enabled="false"  ID="Chk_estado" runat="server" /></div>
        </div>
         
       <br />
        <div > 
              <a class="btn btn-primary"  href="AdminView.aspx"><span class="glyphicon glyphicon-backward"></span> Regresar</a>

             <asp:Button CssClass="btn btn-primary" OnClick="btnbuscardepa_Click" ID="btnbuscardepa" runat="server" Text="Buscar" />

        </div>
           <br />
                  </div>
        </div>








    <div class="form-inline" id="mantenimientoDepa"  runat="server"  visible="false">
       <div style="margin-left:570px; margin-top:-99px; height: 34px; width: 219px;"> <asp:Label ID="Label2" runat="server" Text="Correo:"></asp:Label></div>
       <div style="margin-left:620px; margin-top:-40px;"> <asp:TextBox Width="190px" ID="txtcorreojefe" TextMode="Email"  CssClass="form-control" runat="server" Height="30px" ></asp:TextBox></div>
       <div style="margin-left:830px; margin-top:-27px; width: 56px;"><asp:Label ID="Label3" runat="server" Text="Nombre:"></asp:Label></div>
       
        
        
         <div style="margin-left:900px; margin-top:-23px;" ><asp:TextBox ID="txtnombre" CssClass="form-control" runat="server" Width="190px" Height="30px" ></asp:TextBox></div>
    
        <div style="margin-left:580px; margin-top:20px; width: 136px;">
            <asp:Button ID="btnactualizar" OnClientClick="Confirm()" CssClass="btn btn-warning" runat="server" OnClick="btnactualizar_Click" Text="Actualizar" />

        </div>
    
    <div style="margin-left:980px; margin-top:-30px;">
        
            </div>
        </div>
   

    <br />
    <br />
    <br />

    <br />


    <div class="table-responsive">
        <asp:GridView ID="Gv_datos" runat="server" AutoGenerateColumns = False CssClass="table table-bordered" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
             <Columns runat="server" >         
                <asp:BoundField  DataField = "IdDepartamento" runat="server" HeaderText = "N. Departamento" />
                <asp:BoundField  DataField = "Nombre" runat="server" HeaderText = "Nombre" />
                <asp:BoundField  DataField = "EmailjefeDpto" runat="server" HeaderText = "Email" />
                <asp:BoundField  DataField = "NombreJefe" runat="server" HeaderText = "Jefe" />
                <asp:BoundField  DataField = "Estado" runat="server" HeaderText = "Estado" />
           
                  </Columns>

        </asp:GridView>
    </div>


</asp:Content>
