<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="MovieRental.checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Checkout | Galagita Movie Rentals</title>
    <script type="text/javascript">
        function openModal() {
            $('#myModal').modal('show');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="panel1" runat="server"><ContentTemplate>    
    <div class="container">
        <div class="col-sm-12 tbl_margin">
            <div class="col-sm-8 checkout_box">
                <div class="checkout_heading">
                    <h3 class="chk_head">Customer information</h3>
                </div> 
                <div class="checkout_form ">
                    <div class="checkout_row">
                        <div class="checkout_title">
                            <label>First Name</label>
                        </div>
                        <div class="checkout_input">
                            <asp:TextBox ID="fNameTB" CssClass="chk_tb" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="checkout_row">
                        <div class="checkout_title">
                            <label>Last Name</label>
                        </div>
                        <div class="checkout_input">
                            <asp:TextBox ID="lNameTB" CssClass="chk_tb" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="checkout_row">
                        <div class="checkout_title">
                            <label>Mobile Number</label>
                        </div>
                        <div class="checkout_input">
                            <asp:TextBox ID="numTB" CssClass="chk_tb" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="checkout_row">
                        <div class="checkout_title">
                            <label>Email</label>
                        </div>
                        <div class="checkout_input">
                            <asp:TextBox ID="emailTB" CssClass="chk_tb" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="btn_size">                        
                        <button id="Button3" type="button" runat="server" onserverclick="checkout_click" class="btn btn-warning" data-toggle="modal" data-target="#mymodal">Checkout</button>                        
                    </div>
                </div>               
            </div>
            <div class="col-sm-4">
                <div class="checkout_sum">
                    <div class="sum_header">
                        <h3 class="chk_sum_title">
                            Order Summary
                            <span class="chk_sum_noItems">
                                <asp:Label ID="chk_items" runat="server"></asp:Label>
                            </span>
                        </h3>
                    </div>                    
                    <div class="order_sum">
                        <table class="order_sum_labels">
                            <tr>
                                <th class="product item_pad">Product</th>
                                <th class="quantity item_pad2">Quantity</th>
                                <th class="price item_pad3">Price</th>
                            </tr>
                        </table>                        
                    </div>
                    <div class="order_items">       
                        <asp:Panel ID="orderItems" runat="server"></asp:Panel>                                                                
                        <div class="orderSum_padding">
                            <table class="orderTotal">
                                <tr>
                                    <td class="oTotal">
                                        <strong>Total</strong>
                                        <span class="vatLabel">(VAT incl.)</span>
                                    </td>
                                    <td class="tot__">
                                        <strong class="tot_price">
                                            <asp:Label ID="tot_priceL" runat="server"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>                
            </div>
        </div>        
    <!-- Modal -->
    <div id="myModal" class="modal fade" data-keyboard="false" data-backdrop="static" role="dialog">
      <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content modal-trans">         
          <div class="modal-body">
            <div class="modal_sucess">
                <div class="suc_check">
                    <i class="fa fa-5x fa-inverse fa-check-square"></i>
                </div>
                <div class="suc_text1">
                    Order Complete
                </div>
                <div class="suc_text2">
                    Your order has been processed. Thank you for purchasing.
                </div>               
            </div>
            <div class="suc_return">
                <div class="suc_btn">
                    <asp:Button ID="Button2" PostBackUrl="~/index.aspx" CssClass="btn btn-ret" runat="server" Text="Return to Home" />
                </div>
            </div>
          </div>          
        </div>
      </div>
    </div>
    </div>    
    </ContentTemplate></asp:UpdatePanel>     
</asp:Content>
