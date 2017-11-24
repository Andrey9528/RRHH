<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="RRHH.UI.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
   <link href="https://www.javatpoint.com/fullformpages/images/Medical.png" rel="shortcut icon" type="image/x-icon" />

     
 <style>
       body 
        {
            background-image:  url("http://1070noticias.com.mx/wp-content/uploads/2016/07/fondos-de-pantalla-blancos-para-descargar.jpg");
            background-attachment:fixed;
            background-size:100vw 100vh ;
            


        }
     
 </style>
    <title>Error de Usuario</title>
</head>
<body>
    <form id="form1" runat="server">
   
      <div>
          <h1 style="text-align:center;">¡Parece que quieres ingresar de modo inseguro!</h1>

         
           <div class="col-sm-offset-5">   <asp:Button  CssClass="btn btn-warning btn-lg " OnClick="btnregresarLogin_Click" ID="btnregresarLogin" runat="server" Text="Regresar al login" />
    </div>
               

               </div>  

        <br /><br />
        <center>
            <img  class="img-responsive  img-circle" src="Images/^88D82C5E5CC0B0B42C7F3BB75E1910BA0497497AC6B7AF664E^pimgpsh_fullsize_distr.jpg" width="500" height="300" />
    </center>
            </form>
</body>
</html>
