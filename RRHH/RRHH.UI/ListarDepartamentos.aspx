<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarDepartamentos.aspx.cs" Inherits="RRHH.UI.ListarDepartamentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h1 style="text-align:center; font-family:cursive; font-size:30px;">Departamentos</h1>
    <br />
   <div class="table-responsive">
   <p style="margin-left:300px;" > <asp:GridView  ID="GridView1" CssClass="table  table-bordered" runat="server" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
       <AlternatingRowStyle BackColor="White" />
       <Columns>
          
           <asp:CommandField ControlStyle-CssClass="btn btn-danger" ShowDeleteButton="True"  DeleteText="Eliminar" ButtonType="Button" HeaderText="Eliminar" FooterStyle-BorderStyle="None" ControlStyle-BorderStyle="Solid" >
            <ControlStyle BorderStyle="Solid" CssClass="btn btn-danger"></ControlStyle>

<FooterStyle BorderStyle="None"></FooterStyle>
           </asp:CommandField>
           <asp:CommandField ControlStyle-CssClass="btn btn-warning"   ShowEditButton="True" EditText="Editar" ButtonType="Button" HeaderText="Actualizar" >
       
                  
           </asp:CommandField>
         
       </Columns>
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
       </asp:GridView></p>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BD_RRHHConnectionString %>" DeleteCommand="DELETE FROM [Departamento] WHERE [IdDepartamento] = @IdDepartamento" InsertCommand="INSERT INTO [Departamento] ([Nombre], [EmailJefeDpto], [NombreJefe]) VALUES (@Nombre, @EmailJefeDpto, @NombreJefe)" SelectCommand="SELECT * FROM [Departamento]" UpdateCommand="UPDATE [Departamento] SET [Nombre] = @Nombre, [EmailJefeDpto] = @EmailJefeDpto, [NombreJefe] = @NombreJefe WHERE [IdDepartamento] = @IdDepartamento">
        <DeleteParameters>
            <asp:Parameter Name="IdDepartamento" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Nombre" Type="String" />
            <asp:Parameter Name="EmailJefeDpto" Type="String" />
            <asp:Parameter Name="NombreJefe" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Nombre" Type="String" />
            <asp:Parameter Name="EmailJefeDpto" Type="String" />
            <asp:Parameter Name="NombreJefe" Type="String" />
            <asp:Parameter Name="IdDepartamento" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>

</asp:Content>
