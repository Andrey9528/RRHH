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
    </div>
    <br />
    <div class="form-inline">
    <asp:Label ID="lbIdProducto" runat="server" Text="Cédula: "></asp:Label>
    <asp:TextBox ID="txtcedula" runat="server" CssClass="form-control"></asp:TextBox>    
    <asp:Button ID="btnsBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnsBuscar_Click" />
    </div>
    <br />
    <br />
        <div class="table-responsive">

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
   

    <div class="form-inline" id="mantenimientoInca" runat="server" visible="true">


   <asp:Label ID="Label2" runat="server" Text="Numero de incapacidad:"></asp:Label>
   <asp:DropDownList ID="DDLid_incapacidad" CssClass="form-control"  runat="server"></asp:DropDownList>
    <br />
        <asp:Button ID="btnBuscarIncapacidad" OnClick="btnBuscarIncapacidad_Click" CssClass="btn btn-success" runat="server" Text="Mostrar datos" />
        
     <br />
        <br />


        <div class="container">
            <div class="row">
                <div class="col-sm-4">
                    <div class="form-inline">
 <asp:Label ID="Label1" runat="server" Text="Fecha Inicio:"></asp:Label>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox CssClass="form-control" ID="txtfechainicio" runat="server" ></asp:TextBox>

        
                    </div>
                </div>

                 <div class="col-sm-4">
                    <div class="form-inline">
  <asp:Label ID="Label3"  runat="server" Text="Fecha de finalización:  "></asp:Label>
        
            <asp:TextBox CssClass="form-control" Width="147px" ID="txtfechafinalizacion" runat="server"></asp:TextBox>

                    </div>
                </div>



                 <div class="col-sm-4">
                    <div class="form-inline">
 <asp:Label ID="Label5"  runat="server" Text="Nombre del doctor:  "></asp:Label>
        
            <asp:TextBox CssClass="form-control"  ID="txtdoctor" runat="server"></asp:TextBox>

                    </div>
                </div>
            </div>
        </div>

        <br /><br />
        <div class="container">
            <div class="row">
                 <div class="col-sm-4">
                     <div class="form-inline">

 <asp:Label ID="Label4"  runat="server" Text="Fecha de emisión:  "></asp:Label>
        
            <asp:TextBox CssClass="form-control"  ID="txtfechaemision" runat="server"></asp:TextBox>


                     </div>
                 </div>
                <div class="col-sm-4">
                     <div class="form-inline">
   <asp:Label ID="Label8" runat="server" Text="Descripción:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            
             <asp:TextBox CssClass="form-control"  ID="txtdescripcion" runat="server"></asp:TextBox>

       

                     </div>
                 </div>
                <div class="col-sm-4">
                     <div class="form-inline">
 <asp:Label ID="Label7" runat="server" Text="Centro emisor:"></asp:Label>
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox CssClass="form-control"  ID="txtcentroemisor" runat="server"></asp:TextBox>


                     </div>
                 </div>
            </div>
        </div>
        
           <br /><br />
          
        <div class="container">
            <div class="row">
                <div class="col-sm-4">
                    <div class="form-inline">

   <asp:Label ID="Label6" runat="server" Text="Tipo"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
            <asp:DropDownList ID="DDLtipoenfermedad" CssClass="form-control" runat="server">
                <asp:ListItem>Enfermedad</asp:ListItem>
                <asp:ListItem>Maternidad</asp:ListItem>
                <asp:ListItem Selected="True">Sin establecer</asp:ListItem>
            </asp:DropDownList> 


                    </div>
                </div>

                 <div class="col-sm-4">
                    <div class="form-inline">
 <asp:Label ID="Label9" runat="server" Text="Estado:"></asp:Label>
        

            <asp:CheckBox ID="Chk_estado"  runat="server" />

        


                    </div>
                </div>

                <div class="row">
                 <div class="col-sm-4">
                    <div class="form-inline">
   <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-primary"  OnClick="btnRegresar_Click"  />
            
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning"  OnClick="btnModificar_Click" OnClientClick="Confirm()" />
            

                    </div>
                </div>
              </div>
            </div>
        </div>
   </div>
</asp:Content>
