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

  
   

    <div class="table-responsive">

    <asp:ListView ID="lv_datos" runat="server" DataKeyNames="Cedula" >
        <AlternatingItemTemplate >
           
                <table class="table" style="text-align:center;">
            <tr  >
                <td>
                    <asp:Label ID="CedulaLabel" runat="server" Text='<%# Eval("Cedula") %>' />
                </td>
                <td>
                    <asp:Label ID="NombreLabel" runat="server" Text='<%# Eval("Nombre") %>' />
                </td>
                <td>
                    <asp:Label ID="DireccionLabel" runat="server" Text='<%# Eval("Direccion") %>' />
                </td>
                <td>
                    <asp:Label ID="TelefonoLabel" runat="server" Text='<%# Eval("Telefono") %>' />
                </td>
                <td>
                    <asp:Label ID="CorreoLabel" runat="server" Text='<%# Eval("Correo") %>' />
                </td>
                <td>
                    <asp:Label ID="EstadoCivilLabel" runat="server" Text='<%# Eval("EstadoCivil") %>' />
                </td>
                <td>
                    <asp:Label ID="FechaNacimientoLabel" runat="server" Text='<%# Eval("FechaNacimiento") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="EstadoCheckBox" runat="server" Checked='<%# Eval("Estado") %>' Enabled="false" />
                </td>
                <td>
                    <asp:Label ID="GeneroLabel" runat="server" Text='<%# Eval("Genero") %>' />
                </td>
                <td>
                    <asp:Image ID="imperfil" ImageUrl='<%# Eval("Imagen") %>' Width="100" Height="100" runat="server" />
                   
                </td>
            </tr>
             </table>
                   </AlternatingItemTemplate>
     
        <EmptyDataTemplate>
            <table runat="server" style="">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
       
        <ItemTemplate>
            <table class="table" style="text-align:center;  ">
              <tr style="">
                <td>
                    <asp:Label ID="CedulaLabel" runat="server" Text='<%# Eval("Cedula") %>' />
                </td>
                <td>
                    <asp:Label ID="NombreLabel" runat="server" Text='<%# Eval("Nombre") %>' />
                </td>
                <td>
                    <asp:Label ID="DireccionLabel" runat="server" Text='<%# Eval("Direccion") %>' />
                </td>
                <td>
                    <asp:Label ID="TelefonoLabel" runat="server" Text='<%# Eval("Telefono") %>' />
                </td>
                <td>
                    <asp:Label ID="CorreoLabel" runat="server" Text='<%# Eval("Correo") %>' />
                </td>
                <td>
                    <asp:Label ID="EstadoCivilLabel" runat="server" Text='<%# Eval("EstadoCivil") %>' />
                </td>
                <td>
                    <asp:Label ID="FechaNacimientoLabel" runat="server" Text='<%# Eval("FechaNacimiento") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="EstadoCheckBox" runat="server" Checked='<%# Eval("Estado") %>' Enabled="false" />
                </td>
                <td>
                    <asp:Label ID="GeneroLabel" runat="server" Text='<%# Eval("Genero") %>' />
                </td>
                <td>
                    <asp:Image ID="imperfil" ImageUrl='<%# Eval("Imagen") %>' Width="100" Height="100" runat="server" />
                   
                </td>
            </tr>
               
              </table>
               
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        
                        <table id="itemPlaceholderContainer" runat="server" border="0"  class="table">
                            <tr runat="server" style="">
                                <th runat="server">Cedula</th>
                                <th runat="server">Nombre</th>
                                <th runat="server">Direccion</th>
                                <th runat="server">Telefono</th>
                                <th runat="server">Correo</th>
                                <th runat="server">EstadoCivil</th>
                                <th runat="server">FechaNacimiento</th>
                                <th runat="server">Estado</th>
                                <th runat="server">Genero</th>
                                <th runat="server">Perfil</th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                        
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style=""></td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <tr style="">
                <td>
                    <asp:Label ID="CedulaLabel" runat="server" Text='<%# Eval("Cedula") %>' />
                </td>
                <td>
                    <asp:Label ID="NombreLabel" runat="server" Text='<%# Eval("Nombre") %>' />
                </td>
                <td>
                    <asp:Label ID="DireccionLabel" runat="server" Text='<%# Eval("Direccion") %>' />
                </td>
                <td>
                    <asp:Label ID="TelefonoLabel" runat="server" Text='<%# Eval("Telefono") %>' />
                </td>
                <td>
                    <asp:Label ID="CorreoLabel" runat="server" Text='<%# Eval("Correo") %>' />
                </td>
                <td>
                    <asp:Label ID="EstadoCivilLabel" runat="server" Text='<%# Eval("EstadoCivil") %>' />
                </td>
                <td>
                    <asp:Label ID="FechaNacimientoLabel" runat="server" Text='<%# Eval("FechaNacimiento") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="EstadoCheckBox" runat="server" Checked='<%# Eval("Estado") %>' Enabled="false" />
                </td>
                <td>
                    <asp:Label ID="GeneroLabel" runat="server" Text='<%# Eval("Genero") %>' />
                </td>
                <td>
                   <asp:Image ID="imperfil" ImageUrl='<%# Eval("Imagen") %>' Width="100" Height="100" runat="server" />
                   
                
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
        </div>
     <div class="col-sm-offset-5">
      <a class="btn btn-success btn-sm"  href="JefeView.aspx"><span class="glyphicon glyphicon-backward"></span> Regresar</a>
      <asp:Button ID="btnPDF" runat="server" CssClass="btn btn-danger" OnClick="btnPDF_Click" Text="PDF"/>
          </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BD_RRHHConnectionString3 %>" SelectCommand="SELECT [Cedula], [Nombre], [Direccion], [Telefono], [Correo], [EstadoCivil], [FechaNacimiento], [Estado], [Genero], [Imagen] FROM [Empleado]"></asp:SqlDataSource>

    <div class="table-responsive">
        <asp:GridView ID="GV_personas" AutoGenerateColumns = False runat="server">
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
            ControlStyle-Width="100"></asp:ImageField>
           </Columns>


        </asp:GridView>

    </div>
    

    
   
</asp:Content>
