<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="popup.aspx.cs" Inherits="RRHH.UI.popup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <div class="container">
          <div class="row">
              <div class="col-xs-12">
                  <button class="btn btn-primary btn-sm pull-right" data-target="#olvide" data-toggle="modal">Popup</button>
                  <div class="modal fade"  data-keyboard="false" data-backdrop="static" id="olvide"  tabindex="-1">
                      <div class="modal-dialog modal-sm">
                          <div class="modal-content">
                              <div class="modal-header">
                                  <button class="close"  data-dismiss="modal">&times;</button>
                                  <h4 class="model-tittle">Login</h4>


                              </div>
                              <div  class="modal-body">
                             <div class="form-group">
                                  <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>      <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                  <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                              </div>
                             <div class="form-group">
                                 <asp:Button ID="Button1" CssClass="btn btn-danger" runat="server" Text="Button" />
                                 <asp:Button ID="Button2" runat="server" CssClass="btn btn-success" Text="Button" />
                              </div>
                              </div>
                              <div class="modal-footer">
                                  <asp:Button ID="Button3" CssClass="btn btn-success" runat="server" Text="Button" />
                                  <asp:Button ID="Button4" runat="server" Text="close" data-dismiss="modal" CssClass="btn btn-danger" />
                              </div>

                          </div>
                      </div>
                  </div>
              </div>
          </div>
      </div>

</asp:Content>
