<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="addMovie.aspx.cs" Inherits="MovieRental.addMovie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Add Movie | Galagita Movie Rentals</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">        
        <div class="col-md-offset-3 col-md-6 col-md-offset-3 jumbotron">
            <h2 class="text-center">Add Movie</h2>
            <div class="text-center">
                <asp:Label ID="litStatus" ForeColor="DarkGreen" runat="server"></asp:Label>
            </div>
            <div class="form-group">
                <label>Movie Title</label>
                <asp:TextBox ID="titleTB" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Year Released</label>
                <asp:TextBox ID="yearTB" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Rental Daily Rate</label>
                <asp:TextBox ID="rateTB" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>No. of Stocks</label>
                <asp:TextBox ID="stocksTB" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Image</label>
                <asp:FileUpload ID="imageFU" CssClass="custom-file-input" runat="server" />
            </div>            
            <div class="form-group btnAdd">
                <asp:Button ID="addBtn" runat="server" OnClick="addBtn_Click" CssClass="btn btn-primary btn-lg center-block btnAdd2" Text="Add Movie" />
            </div>            
        </div>
    </div>
</asp:Content>
