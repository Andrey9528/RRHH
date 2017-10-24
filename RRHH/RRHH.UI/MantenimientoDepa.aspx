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
        </div>
        <br />

        <h1 style="text-align:center; font-family:cursive;">Mantenimiento departamentos</h1>
        <br />
        <br />
      <br />
       
    
       

   




    <div class="form-inline " id="mantenimientoDepa"  runat="server"  visible="true">

      
        <div class="container">
            <div class="row">
                <div class="col-sm-4">
        <asp:Label ID="Label1" runat="server" Text="Departamento:"></asp:Label>
        <asp:DropDownList ID="DDLdepa"  CssClass="form-control" runat="server">
               
           </asp:DropDownList>
       <br /><br />
             <asp:Button CssClass="btn btn-primary"  ID="btnRegresar" OnClick="btnRegresar_Click" runat="server" Text="Regresar" />

             <asp:Button CssClass="btn btn-primary" OnClick="btnbuscardepa_Click" ID="btnbuscardepa" runat="server" Text="Buscar" />

          </div>
                <div class="col-sm-4">
                    <div class="form-inline">
  <asp:Label ID="lblActivo" runat="server"  Text="Activo:"></asp:Label>
                        
                        
                        <asp:CheckBox  Enabled="false"  ID="Chk_estado" runat="server" />
       <asp:Label ID="Label2" runat="server" Text="Correo:"></asp:Label>
        <asp:TextBox ID="txtcorreojefe" TextMode="Email"  CssClass="form-control" runat="server" Height="30px" ></asp:TextBox>
       
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="form-inline">
 
                         </div>
                </div>
                <div class="col-sm-4">
                    <div class="form-inline">

        <asp:Label ID="Label3" runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="txtnombre" CssClass="form-control" runat="server"  ></asp:TextBox>
    
            <asp:Button ID="btnactualizar" Enabled="false" OnClientClick="Confirm()" CssClass="btn btn-warning" runat="server" OnClick="btnactualizar_Click" Text="Actualizar" />

                    </div>
                </div>

            </div>
        </div>
      
          
        
     
       
        

    </div>
       
        
        
   
        
    <br /><br /><br />
    
    
        
           
   

   


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
