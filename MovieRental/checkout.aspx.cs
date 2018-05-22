using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieRental
{
    public partial class checkout : System.Web.UI.Page
    {
        WebService1 server = new WebService1();

        protected void Page_Load(object sender, EventArgs e)
        {
            fillPage();
        }

        protected void fillPage()
        {
            List<cartList> cartItems = (List<cartList>)Session["cartItems"];            
            double total = 0;
            chk_items.Text = "(" + cartItems.Count + " items)";

            foreach (cartList item in cartItems)
            {               
                var movie = server.getMovie(item.movieID);                
                double rate = (movie.rental_daily_rate * item.qty);
                total += rate;

                Panel mPanel = new Panel();                
                Label lblTitle = new Label();
                Label lblQty = new Label();
                Label lblRate = new Label();

                lblTitle.Text = movie.movie_title;                
                lblQty.Text = item.qty + "";
                lblRate.Text = "₱ " + rate;

                mPanel.Controls.Add(new Literal { Text = "<table class=\"order_prod_list\"><tr><td class=\"product item_padding\">" });
                mPanel.Controls.Add(lblTitle);
                mPanel.Controls.Add(new Literal { Text = "</td><td class=\"quantity\">" });
                mPanel.Controls.Add(lblQty);
                mPanel.Controls.Add(new Literal { Text = "</td><td class=\"price\">" });
                mPanel.Controls.Add(lblRate);
                mPanel.Controls.Add(new Literal { Text = "</td></tr></table>" });

                orderItems.Controls.Add(mPanel);
            }

            tot_priceL.Text = "₱ " + total;
        }
        
        protected void checkout_click(object sender, EventArgs e)
        {
            int id = server.addCustomer(fNameTB.Text, lNameTB.Text, numTB.Text, emailTB.Text);
            List<cartList> cartItems = (List<cartList>)Session["cartItems"];            
            DateTime rentDate = DateTime.Now.Date;
            DateTime dueDate = DateTime.Now.AddDays(5);

            foreach (cartList item in cartItems)            
                server.addRental(item.movieID, id, item.qty, dueDate, rentDate);            

            Session["cartItems"] = new List<cartList>();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true); 
        }
    }   
}