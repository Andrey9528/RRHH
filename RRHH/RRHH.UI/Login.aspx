<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RRHH.UI.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



<br />
    <div class="alert alert-success" visible="false" id="mensaje" runat="server">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong id="textoMensaje" runat="server"></strong>
    </div>
    <div class="alert alert-danger" visible="false" id="mensajeError" runat="server">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong id="textoMensajeError" runat="server"></strong>
    </div>
     <div class="alert alert-info" visible="false" id="mensajeinfo" runat="server">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong id="textomensajeinfo" runat="server"></strong>
    </div>



    <div class="container" style="width:800px; " >
        <div id="loginbox" style="margin-top: 50px; "  class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
            <div class="" style=" background-color:#16a3ea;">
                <div class="panel-heading">
                    <div class="panel-title" style="color:black; font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; font-size:17px;" >Sistema de recursos humanos</div>
                </div>
                <div style="padding-top: 30px; background-color:#16a3ea;"  class="panel-body">
                    <div class="form-horizontal">
                        <div style="padding-top:30px" class="panel-body">
                              <div class="form-horizontal">
                                  <div style="margin-bottom:25px;" class="input-group">
                                      <span class="input-group-addon"><i class="glyphicon glyphicon-user "></i></span>
                                      <asp:TextBox ID="txtcorreo" runat="server" class="form-control" placeholder="Email"></asp:TextBox>

                                  </div>
                                  <div style="margin-bottom:25px;" class="input-group">
                                      <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                      <asp:TextBox ID="txtcontra" runat="server" class="form-control" TextMode="Password" placeholder="Contraseña"></asp:TextBox>

                                  </div>
                                  <div style="margin-top:10px;" class="form-group">
                                      <div class="col-sm-12">
                                          <div class="btn-group" ><asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" />  </div>
                                          
                                           <div class="btn-group"><asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-success" OnClick="btnRegistrar_Click" />  </div>    
                                         
                                            
                                      </div>
                                  </div>
                              </div>

                        </div>
                        
						
                       
                       
                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
