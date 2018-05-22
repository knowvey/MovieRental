<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="movieDetails.aspx.cs" Inherits="MovieRental.movieDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><asp:Literal ID="movieTitle1" runat="server"></asp:Literal> | Galagita Movie Rentals</title>        
    <script type="text/javascript">
        function openModal() {
            $('#myModal').modal('show');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <asp:UpdatePanel ID="panel1" runat="server"><ContentTemplate>                                                  
    <div class="container">
    <div class="row">
        <div class="col-md-7 movieImgDtls">
            <asp:Image ID="movieImg" runat="server" />
        </div>
        <div class="col-md-5 movieDetails">
            <h1><asp:Literal ID="movieTitle2" runat="server"></asp:Literal></h1>
            <h5 class="movieYear">(<asp:Literal ID="movieYear" runat="server"></asp:Literal>)</h5>
            <br />
            <h4>Rent daily rate: <span><asp:Literal ID="movieRate" runat="server"></asp:Literal></span></h4>
            <br />         
            <br />   
            <%--<button type="button" runat="server" onserverclick="rentBtn_Click" class="btn btn-danger btn-lg disabled" data-toggle="modal" data-target="#mymodal">
                Add to Cart <span class="glyphicon glyphicon-shopping-cart"></span>
            </button>--%>
            <asp:Button ID="rentBtn" runat="server" CssClass="btn btn-danger btn-lg" OnClick="rentBtn_Click" data-toggle="modal" data-target="#mymodal" Text="Add to Cart" />            
            <asp:Label ID="stockLbl" CssClass="stockLit" ForeColor="Red" runat="server"></asp:Label>
            <br />
            <br />
            <asp:LinkButton ID="LinkButton1" PostBackUrl="~/index.aspx" CssClass="btn btn-default" runat="server">Back</asp:LinkButton>           
        </div>
    </div>
    <div style="clear:both"></div>
    <br />    
                     
    <!-- Modal -->       
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog modal-md">
            <div class="modal-content">        
                <div class="modal-body">
                    <div class="row center-block">
                        <div class="col-sm-8 modal_col">
                            <h5 class="left_modal_header">
                                <span class="glyphicon glyphicon-check"></span>
                                1 item has been added to your cart
                            </h5>                            
                            <asp:ImageButton ID="modalImage" CssClass="modal_image" runat="server" />
                            <div class="modal_desc">
                                <h2><asp:Literal ID="modalTitle" runat="server"></asp:Literal></h2>
                                <h4>(<asp:Literal ID="modalYear" runat="server"></asp:Literal>)</h4>                                
                                <h3>Rental rate: <asp:Literal ID="modalRate" runat="server"></asp:Literal></h3>
                            </div>                            
                        </div>
                        <div class="col-sm-4 modal_cart">
                            <div class="right_modal_header">
                                <span class="modal_head">Shopping Cart </span>
                                <span class="modal_noItems">
                                    (<asp:Literal ID="modalCartItems" runat="server"></asp:Literal>
                                     items)
                                </span>                                
                                <span>
                                    <asp:LinkButton ID="LinkButton2" PostBackUrl="cart.aspx" runat="server">
                                        <i class="glyphicon glyphicon-edit"></i>
                                    </asp:LinkButton>
                                </span>                                
                            </div>
                            <div class="modal_summary">
                                <span class="col">Subtotal:</span>
                                <span class="col text-right">
                                    <asp:Literal ID="modalTotal" runat="server"></asp:Literal>
                                </span>
                            </div>
                            <div class="modal_summary">
                                <span class="col">Vat(10%):</span>
                                <span class="col text-right">
                                    <asp:Literal ID="modalVat" runat="server"></asp:Literal>
                                </span>
                            </div>
                            <div class="modal_total">
                                <span class="col total1">Total:</span>
                                <h3 class="col text-right total2">
                                    <asp:Literal ID="modalTotal2" runat="server"></asp:Literal>
                                </h3>
                            </div>
                            <asp:Button ID="Button1" PostBackUrl="~/checkout.aspx" CssClass="btn btn-warning" runat="server" Text="proceed to checkout" />
                            <button type="button" class="continue_btn" data-dismiss="modal">Continue Shopping</button>
                        </div>
                    </div>
                </div>       
            </div>
        </div>
    </div>                                
    </div>    
    </ContentTemplate></asp:UpdatePanel>           
    <!--Suggestions Panel-->
    <div class="container">
        <h3>You may also like:</h3>
        <div class="row center-block suggestionsPnl">            
            <asp:Panel ID="suggestionsPnl" runat="server"></asp:Panel>                    
        </div>   
    </div>
</asp:Content>
