<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MovieRental.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Galagita Movie Rentals | Home</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="jumbotron text-center">
            <h1><strong>List of Movies</strong></h1>
        </div>
        <div class="col-lg-12 center-block">
            <asp:Panel ID="moviesPanel" runat="server">
            </asp:Panel>
            <div style="clear:both"></div>
            <div class=""></div>
            <div class="text-center">
              <ul class="pagination">
                <li class="page-item <% if (prevBtn) { %>disabled<% } %>">
                  <a class="page-link" href="index.aspx?page=<% = pageNum -1 %>" aria-label="Previous">
                    <span aria-hidden="true">&laquo;</span>
                    <span class="sr-only">Previous</span>
                  </a>
                </li>
                <asp:Literal ID="paginationPages" runat="server"></asp:Literal>                
                <li class="page-item <% if (nextBtn) { %>disabled<% } %>">
                  <a class="page-link" href="index.aspx?page=<% = pageNum + 1 %>" aria-label="Next">
                    <span aria-hidden="true">&raquo;</span>
                    <span class="sr-only">Next</span>
                  </a>
                </li>
              </ul>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </div>
        </div>
    </div>        
</asp:Content>
