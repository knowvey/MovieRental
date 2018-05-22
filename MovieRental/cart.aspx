    <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="MovieRental.cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Cart | Galagita Movie Rentals</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
    <div class="container">
        <div class="row cart_border">            
            <asp:LinkButton ID="LinkButton1" PostBackUrl="~/index.aspx" CssClass="continue_btn" runat="server"><span class="glyphicon glyphicon-chevron-left"></span> Continue Shopping</asp:LinkButton>
        </div>        
        <h5 class="cart_header">My Shopping Cart</h5>
        <div class="col-sm-12 tbl_margin">
            <div class="col-sm-8 tbl_margin">            
                <table>
                    <asp:Panel ID="cartItemsPanel" runat="server"></asp:Panel>                                                
                </table>
            </div>
            <div class="col-sm-4 sum_cart">
                <asp:Panel ID="summaryOrder" runat="server">
                    <h5 class="summaryHeader">Order Summary</h5>
                    <div class="cart_summary">
                        <span class="col">Subtotal:</span>
                        <span class="col text-right">
                            <asp:Literal ID="sumTotal" runat="server"></asp:Literal>
                        </span>
                    </div>
                    <div class="cart_summary">
                        <span class="col">Vat(10%):</span>
                        <span class="col text-right">
                            <asp:Literal ID="sumVat" runat="server"></asp:Literal>
                        </span>
                    </div>
                    <div class="cart_total">
                        <span class="col total1">Total:</span>
                        <h3 class="col text-right total2">
                            <asp:Literal ID="sumTotal2" runat="server"></asp:Literal>
                        </h3>
                    </div>
                    <asp:Button ID="Button1" PostBackUrl="~/checkout.aspx" CssClass="btn btn-warning" runat="server" Text="proceed to checkout" />
                </asp:Panel>
            </div>  
        </div>                  
    </div>        
    </ContentTemplate></asp:UpdatePanel>
</asp:Content>
