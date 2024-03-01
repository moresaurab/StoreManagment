<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Seller.aspx.cs" Inherits="GoceryStoreManagement.View.Admin.Seller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-8"><br /><img src="../../Asset/Images/im13 (1).jpg" /><h4>Manage Products</h4></div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <h2>Seller Details</h2>
                <div class="mb-3">
                   <%-- <label for="SNameTb" class="form-label">Seller Name</label>--%>
                    <asp:Label ID="Label1" runat="server" Text="Label">Seller Name</asp:Label>
                    <%--<input type="text" class="form-control" id="SNameTb" />--%>
                    <asp:TextBox ID="SellerName" runat="server"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <%--<label for="SEmailTb" class="form-label">Seller Email</label>--%>
                    <asp:Label ID="Label2" runat="server" Text="Label">Seller Email</asp:Label>
                    <%--<input type="email" class="form-control" id="SEmailTb" />--%>
                      <asp:TextBox ID="SellerEmail" runat="server"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <%--<label for="sellerPassTb" class="form-label">Seller Password</label>--%>
                     <asp:Label ID="Label3" runat="server" Text="Label">Seller Password</asp:Label>
                   <%-- <input type="text" class="form-control" id="sellerPassTb" />--%>
                     <asp:TextBox ID="SellerPassword" runat="server"></asp:TextBox>
                </div>

                <div class="mb-3">
                   <%-- <label for="phoneTb" class="form-label">Seller Phone</label>--%>
                    <asp:Label ID="Label4" runat="server" Text="Label">Seller Phone</asp:Label>
                    <%--<input type="text" class="form-control" id="phoneTb" />--%>
                     <asp:TextBox ID="SellerPhone" runat="server"></asp:TextBox>
                </div>

                <div class="mb-3">
                   <%-- <label for="AddressTb" class="form-label">Seller Address</label>--%>
                     <asp:Label ID="Label5" runat="server" Text="Label">Seller Address</asp:Label>
                  <%--  <input type="text" class="form-control" id="AddressTb" />--%>
                     <asp:TextBox ID="SellerAddress" runat="server"></asp:TextBox>
                </div>
                    <%-- <label id="ErrMsg" runat="server" class="text-danger"></label>--%>
                <asp:Label ID="Label6" runat="server" Text="" class="text-danger"></asp:Label>
                     <asp:Button Text=" Edit " class="btn btn-primary" runat="server" ID="Editbtn" OnClick="Editbtn_Click" />
                     <asp:Button Text=" Save " class="btn btn-primary" runat="server" ID="Savebtn" OnClick="Savebtn_Click" />
                     <asp:Button Text="Delete" class="btn btn-primary" runat="server" ID="Deletebtn" OnClick="Deletebtn_Click" />
                                          
            </div>
            <div class="col-md-8">
                <asp:GridView ID="GridView1" runat="server" class="table table-hover table-dark" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">

                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
