<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="management.aspx.cs" Inherits="MovieRental.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Management | Galagia Movie Rentals   </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
    <div class="container">
        <asp:Panel ID="loginPnl" runat="server">
            <div class="login-container">                
                <h1><asp:Label ID="msgLbl" CssClass="loginLbl" runat="server" ForeColor="Red"></asp:Label></h1>
                <form>
                    <asp:TextBox ID="uNameTB" placeholder="Username" runat="server" TextMode="SingleLine"></asp:TextBox>
                    <asp:TextBox ID="passTB" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:Button ID="loginBtn" CssClass="login login-submit" runat="server" OnClick="loginBtn_Click" Text="Login" />                    
                </form>					                
            </div>
        </asp:Panel>
        <asp:Panel ID="managementPnl" runat="server" Enabled="True" Visible="False">
            <div class="col-md-offset-1 col-md-10 col-md-offset-1">
            <div class="mngmtHeader">Movie List</div>
            <asp:GridView ID="movieListGV" CssClass="table-fill" AllowPaging="True" OnPageIndexChanging="movieListGV_PageIndexChanging" PageSize ="5" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" OnRowCancelingEdit="movieListGV_RowCancelingEdit" OnRowEditing="movieListGV_RowEditing" OnRowUpdating="movieListGV_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="idmovies" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="movie_title" HeaderText="Title" />
                    <asp:BoundField DataField="release_year" HeaderText="Year" />
                    <asp:BoundField DataField="number_in_stock" HeaderText="No. of Stock" />
                    <asp:BoundField DataField="rental_daily_rate" HeaderText="Daily Rental Rate" />
                </Columns>
            </asp:GridView>   
            <div class="mngmtHeader">Customer List</div>
            <asp:GridView ID="customerGV" runat="server" CssClass="table-fill" PageSize="5" AllowPaging="True" AutoGenerateColumns="False" AutoGenerateEditButton="True" OnPageIndexChanging="customerGV_PageIndexChanging" OnRowCancelingEdit="customerGV_RowCancelingEdit" OnRowEditing="customerGV_RowEditing" OnRowUpdating="customerGV_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="fullName" HeaderText="Full Name" />
                    <asp:BoundField DataField="mobile_number" HeaderText="Mobile No." />
                    <asp:BoundField DataField="email_address" HeaderText="Email Address" />
                </Columns>
            </asp:GridView>     
            <div class="mngmtHeader">Rental List</div>
            <asp:GridView ID="rentListGV" CssClass="table-fill" PageSize="5" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="rentListGV_PageIndexChanging" OnRowCancelingEdit="rentListGV_RowCancelingEdit" OnRowEditing="rentListGV_RowEditing" OnRowUpdating="rentListGV_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="customer_id" HeaderText="Customer ID" />
                    <asp:BoundField DataField="idmovies" HeaderText="Movie ID" />
                    <asp:BoundField DataField="qty" HeaderText="Qty" />
                    <asp:BoundField DataField="rent_date" DataFormatString="{0:d}" HeaderText="Rent Date" />
                    <asp:BoundField DataField="due_date" DataFormatString="{0:d}" HeaderText="Due Date" />
                    <asp:BoundField DataField="status" HeaderText="Status" />
                    <asp:BoundField DataField="is_overdue" HeaderText="Is Overdue" />
                </Columns>
            </asp:GridView>                        
        </div>         
        </asp:Panel>               
    </div>
    </ContentTemplate></asp:UpdatePanel>
</asp:Content>
