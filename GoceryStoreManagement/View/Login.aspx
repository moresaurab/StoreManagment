<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GoceryStoreManagement.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="../Asset/lib/Bootstrap/css/bootstrap.min.css" />
    <link href="../Asset/lib/Bootstrap/css/MyCSS.css" rel="stylesheet" />
</head>
<body class="MyBG">
   <form id="form1" runat="server">
       
    <div class="container-fluid">
        <div class="row" style="height:90px;" ></div>
        <div class="row">
            <div class="col-md-2"></div>
             <div class="col-md-4">
                 <img src="../Asset/Images/img.png" class="img-fluid"/>
             </div>
            <div class="col-md-4">
                <h1>Sign Up</h1>
           
                    <div class="mb-3">
                        <label for="EmailID" class="form-label">Email address</label>
                        <%--<input type="email" class="form-control" id="EmailID" >--%>
                        <asp:TextBox ID="EmailId" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="Password" class="form-label">Password</label>
                        <%--<input type="password" class="form-control" id="Password">--%>
                        <asp:TextBox ID="UserPassword" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    <div class="mb-3 form-check">
                        <asp:RadioButton ID="RadioButton1" runat="server" Text="Admin" GroupName="Options" /><br />
                        <asp:RadioButton ID="RadioButton2" runat="server" Text="Seller" GroupName="Options" />

                    </div>
                    <div class="mb-3 d-grid">
                        <asp:Label ID="InfoMsg" runat="server" Text=""></asp:Label>
                      <!--  <input id="Button1" type="button" value="Login" class="btn btn-dark btn-block" /> -->
                        <asp:Button ID="Button1" runat="server"  Text="Login" class="btn btn-dark" OnClick="Button1_Click" />


                    </div>
                    <%--<button type="submit" class="btn btn-primary">Submit</button>--%>
                
            </div>
        </div>
    </div>
    </form>
        
   
       
   
</body>
</html>
