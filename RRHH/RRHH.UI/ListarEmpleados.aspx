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

   <%-- <div class="table-responsive ">
        <asp:GridView ID="gv_datos" CssClass="table table-bordered" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
        </asp:GridView>
    </div>--%>

   

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
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BD_RRHHConnectionString3 %>" SelectCommand="SELECT [Cedula], [Nombre], [Direccion], [Telefono], [Correo], [EstadoCivil], [FechaNacimiento], [Estado], [Genero], [Imagen] FROM [Empleado]"></asp:SqlDataSource>


    

    
     <%--   <asp:ListView ID="lv_empleados"     DataKeyNames="Cedula"  runat="server">
            <EmptyDataTemplate>
                <table>
                    <tr><td>no hay datos </td></tr>
                </table>
            </EmptyDataTemplate>
            <EmptyItemTemplate>

            </EmptyItemTemplate>

            <ItemTemplate >
              <div class="table-responsive"> <table >
                
                    <tr>
                        <td>
                       <asp:Label ID="Label1"   runat="server" Text='<%# Eval("Cedula") %>'></asp:Label>

                        </td>

                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Direccion") %>'></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("Telefono") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("Correo") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("EstadoCivil") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("FechaNacimiento") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td> <asp:CheckBox ID="Chk_estado" Enabled="false" Checked='<%# Eval("Estado") %>' runat="server" />  </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("Genero") %>'></asp:Label></td>
                    </tr>
                      <tr>
                  <td>
                      <asp:Image ID="Imgperfil" runat="server" ImageUrl='<%# Eval("Imagen") %>'  Width="120px" Height="120"/>

                  </td>
                  </tr>
                </table>
                  </div>
            </ItemTemplate>
                <GroupTemplate>
                <tr id="itemPlaceholderContainer" runat="server">
                    <td id="itemPlaceholder" runat="server"></td>
                </tr>
            </GroupTemplate>
              <LayoutTemplate>
                <table style="width: 100%;">
                    <tbody>
                        <tr>
                            <td>
                                <table id="groupPlaceholderContainer" runat="server" style="width: 100%">
                                    <tr id="groupPlaceholder">
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
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr></tr>
                    </tbody>
                </table>
            </LayoutTemplate>
        </asp:ListView>
    --%>
</asp:Content>
