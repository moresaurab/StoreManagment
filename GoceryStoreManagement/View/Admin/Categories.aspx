<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="GoceryStoreManagement.View.Admin.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-8"><br /><img src="../../Asset/Images/im13 (1).jpg" /><h4>Manage Categories</h4></div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <h2>Category Details</h2>
                <div class="mb-3">
                    <label for="exampleInputEmail1" class="form-label">Category Name</label>
                    <input type="text" class="form-control" id="CatNameTb" runat="server" />
                </div>

                <div class="mb-3">
                    <label for="exampleInputEmail1" class="form-label">Category Remark</label>
                    <input type="text" class="form-control" id="CatRemarkTb" runat="server" />
                </div>

                <label id="ErrMsg" runat="server" class="text-danger"></label>
                    <br /><br />
                     <asp:Button Text=" Edit " class="btn btn-primary" runat="server" ID="btnEdit" OnClick="btnEdit_Click" />
                     <asp:Button Text=" Save " class="btn btn-primary" runat="server" ID="btnSave" OnClick="btnSave_Click" />
                     <asp:Button Text="Delete" class="btn btn-primary" runat="server" ID="btnDelete" OnClick="btnDelete_Click" />
                                          
            </div>
            <div class="col-md-8">
                <!--Table Here----->
                <asp:GridView ID="GridView1" runat="server" class="table table-danger" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >

                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
