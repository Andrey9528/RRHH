﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RRHH.UI.Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        body {
            background-color:#75c7d5;
        }
    </style>

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
            <div class="panel panel-info" >
                <div class="panel-heading">
                    <div class="panel-title"  style="font-family:cursive; text-align:center;" >Sistema de recursos humanos</div>
                </div>
                <div style="padding-top: 30px; background:white;"    class="panel-body">
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
                                          
                                           <div class="btn-group"><asp:Button ID="btnRegistrar" data-target="#olvide" data-toggle="modal"   runat="server" Text="Olvidé contraseña"   CssClass="btn btn-success" OnClick="btnRegistrar_Click" />  </div>    
                                         
                                            
                                      </div>
                                  </div>
                              </div>

                        </div>
                       
                        </div>
                       
                          
                    </div>
                    
                </div>
            </div>
        </div>

    <div class="container">
          <div class="row">
              <div class="col-xs-12">
                  <%--<button class="btn btn-primary btn-sm pull-right" data-target="#olvide" data-toggle="modal">Popup</button>--%>
                  <div class="modal fade"  data-keyboard="false" data-backdrop="static" id="olvide"  tabindex="-1">
                      <div class="modal-dialog modal-sm">
                          <div class="modal-content" style="margin-top:100px;">
                              <div class="modal-header">
                                  <button class="close"  data-dismiss="modal">&times;</button>
                                  <h4 class="model-tittle">Olvidé mi contraseña</h4>


                              </div>
                              <div  class="modal-body">
                             <div class="form-group">
                                 <asp:Label ID="Label1" runat="server" Text="Digita tu correo:"></asp:Label>
                                  <asp:TextBox ID="txtemail" TextMode="Email" runat="server" CssClass="form-control" placeholder="Correo"></asp:TextBox>      
                                 
                              </div>
                             <div class="form-group">
                                 
                                 
                              </div>
                              </div>
                              <div class="modal-footer">
                                  <asp:Button ID="btnValidar" CssClass="btn btn-success" runat="server" Text="Enviar"  OnClick="btnValidar_Click" />
                                  <asp:Button ID="btnsalir" runat="server" Text="Salir" data-dismiss="modal" CssClass="btn btn-danger"  />
                              </div>

                          </div>
                      </div>
                  </div>
              </div>
          </div>
      </div>

   
    


</asp:Content>
