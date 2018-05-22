using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieRental
{
    public partial class cart : System.Web.UI.Page
    {
        WebService1 server = new WebService1();

        protected void Page_Load(object sender, EventArgs e)
        {            
            fillPage();            
        }        

        protected void fillPage()
        {
            List<cartList> cartItems = (List<cartList>)Session["cartItems"];
            int cartNo = 0;
            foreach (cartList item in cartItems)
                cartNo += item.qty;

            if (cartItems.Count > 0)
            {
                cartItemsPanel.Controls.Add(new Literal { Text = "<tr class=\"table_header\">\n<td class=\"table_img\">\n" });
                cartItemsPanel.Controls.Add(new Label { Text = cartNo + " items", ID = "lblCartNo"});
                cartItemsPanel.Controls.Add(new Literal
                {
                    Text = "</td><td class=\"table_desc tbl_pad\"></td>\n<td class=\"table_price tbl_pad\">Rent rate</td>" +
                    "<td class=\"table_quantity tbl_pad\">Quantity</td><td class=\"table_remove\"></td></tr>"
                });

                sumTotal.Text = "₱ " + (server.getTotal(cartItems) - (server.getTotal(cartItems) * .1)).ToString();
                sumVat.Text = "₱ " + (server.getTotal(cartItems) * .1).ToString();
                sumTotal2.Text = "₱ " + server.getTotal(cartItems).ToString();

                for (int i = 0; i < cartItems.Count; i++ )
                {
                    var movie = server.getMovie(cartItems[i].movieID);

                    Panel mPanel = new Panel();
                    ImageButton imgBtn = new ImageButton();
                    Label lblTitle = new Label();
                    Label lblYear = new Label();
                    Label lblStock = new Label();
                    DropDownList ddlQty = new DropDownList();
                    Label lblRate = new Label();
                    LinkButton btnRemove = new LinkButton();
                    LinkButton btnMinus = new LinkButton();
                    LinkButton btnPlus = new LinkButton();

                    imgBtn.ImageUrl = "~/images/" + movie.image;
                    imgBtn.CssClass = "modal_image";
                    imgBtn.PostBackUrl = "~/movieDetails.aspx?id=" + movie.idmovies;

                    lblTitle.Text = movie.movie_title;
                    lblYear.Text = "(" + movie.release_year + ")";
                    lblRate.Text = "₱ " + movie.rental_daily_rate * cartItems[i].qty;
                    lblRate.CssClass = "cartRate";
                    lblRate.ID = i + "rate";
                    lblStock.Text = "In stock";
                    if (movie.number_in_stock <= 5)
                        lblStock.Text = "Only " + movie.number_in_stock + " copies in stock";

                    btnRemove.ID = i + "";
                    btnRemove.Click += new EventHandler(removeCartItem_Click);
                    btnRemove.Text = "<span class=\"glyphicon glyphicon-remove\"></span>";
                    btnRemove.CssClass = "cartRemove";

                    ddlQty.CssClass = "form-control btnQtyIpt";
                    if (movie.number_in_stock < 5)
                    {
                        ddlQty.DataSource = Enumerable.Range(1, movie.number_in_stock);
                        ddlQty.DataBind();
                    }
                    else
                    {
                        ddlQty.DataSource = Enumerable.Range(1, 5);
                        ddlQty.DataBind();
                    }
                    ddlQty.SelectedValue = cartItems[i].qty.ToString();
                    ddlQty.ID = i + "ddl";
                    ddlQty.AutoPostBack = true;
                    ddlQty.SelectedIndexChanged += new EventHandler(ddlQty_SelectedIndexChanged);

                    btnMinus.ID = i + "minus";
                    btnMinus.CssClass = "btn btn-default btn-number btnQty";
                    btnMinus.Text = "<span class=\"glyphicon glyphicon-minus\"></span>";
                    btnMinus.Click += new EventHandler(minusQtyBtn_Click);
                    if (cartItems[i].qty == 1)
                        btnMinus.CssClass = "btn btn-default btn-number btnQty disabled";

                    btnPlus.ID = i + "plus";
                    btnPlus.CssClass = "btn btn-default btn-number btnQty";
                    btnPlus.Text = "<span class=\"glyphicon glyphicon-plus\"></span>";
                    btnPlus.Click += new EventHandler(plusQtyBtn_Click);
                    if (cartItems[i].qty >= movie.number_in_stock || cartItems[i].qty == 5)
                        btnPlus.CssClass = "btn btn-default btn-number btnQty disabled";

                    mPanel.Controls.Add(new Literal { Text = "<tr class=\"cartItem_row\">\n<td class=\"table_img\">" });
                    mPanel.Controls.Add(imgBtn);
                    mPanel.Controls.Add(new Literal { Text = "</td>\n<td class=\"table_desc\"><div class=\"cartTitle\">" });
                    mPanel.Controls.Add(lblTitle);
                    mPanel.Controls.Add(new Literal { Text = "</div><div class=\"cartYear\">" });
                    mPanel.Controls.Add(lblYear);
                    mPanel.Controls.Add(new Literal { Text = "</div><div class=\"cartStock\">" });
                    mPanel.Controls.Add(lblStock);
                    mPanel.Controls.Add(new Literal { Text = "</div></td>\n<td class=\"table_price\">" });
                    mPanel.Controls.Add(lblRate);
                    mPanel.Controls.Add(new Literal { Text = "</td>\n<td class=\"table_quantity\"><div class=\"input-group\"><span class=\"input-group-btn\">" });
                    mPanel.Controls.Add(btnMinus);
                    mPanel.Controls.Add(new Literal { Text = "</span>" });
                    mPanel.Controls.Add(ddlQty);
                    mPanel.Controls.Add(new Literal { Text = "<span class=\"input-group-btn\">" });
                    mPanel.Controls.Add(btnPlus);
                    mPanel.Controls.Add(new Literal { Text = "</span></div></td>\n<td class=\"table_remove\">" });
                    mPanel.Controls.Add(btnRemove);
                    mPanel.Controls.Add(new Literal { Text = "</td></tr>" });

                    cartItemsPanel.Controls.Add(mPanel);
                }
            }
            else
            {
                Label msg = new Label();
                msg.Text = "No items found";

                cartItemsPanel.Controls.Add(msg);
                summaryOrder.Visible = false;
            }
        }

        protected void removeCartItem_Click(object sender, EventArgs e)
        {
            List<cartList> cartItems = (List<cartList>)Session["cartItems"];
            int itemIdx = Int32.Parse(((LinkButton)sender).ID);             

            cartItems.RemoveAt(itemIdx);
            Session["cartItems"] = cartItems;
            refreshValues();
        }

        protected void minusQtyBtn_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;            
            List<cartList> cartItems = (List<cartList>)Session["cartItems"];
            int idx = Int32.Parse(btn.ID[0].ToString());                                    

            --cartItems[idx].qty;
            Session["cartItems"] = cartItems;
            refreshValues();     
        }

        protected void plusQtyBtn_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            List<cartList> cartItems = (List<cartList>)Session["cartItems"];
            int idx = Int32.Parse(btn.ID[0].ToString());

            ++cartItems[idx].qty;
            Session["cartItems"] = cartItems;
            refreshValues(); 
        }

        protected void ddlQty_SelectedIndexChanged(object sender, EventArgs e)
        {            
            DropDownList ddl = sender as DropDownList;
            List<cartList> cartItems = (List<cartList>)Session["cartItems"];
            int idx = Int32.Parse(ddl.ID[0].ToString());

            cartItems[idx].qty = Int32.Parse(ddl.SelectedValue);
            Session["cartItems"] = cartItems;
            refreshValues();
        }

        private void refreshValues()
        {
            List<cartList> cartItems = (List<cartList>)Session["cartItems"];
            Label noItems = (Label)Master.FindControl("lblCartCount");
            int cartNo = 0;
            foreach (cartList item in cartItems)
                cartNo += item.qty;
            noItems.Text = cartNo + "";
            cartItemsPanel.Controls.Clear();
            fillPage();     
        }
    }
}