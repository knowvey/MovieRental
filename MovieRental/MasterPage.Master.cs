using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieRental
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        WebService1 server = new WebService1();
        public String activeTab = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            checkSession();
            fillPage();
            setActiveTab();                    
        }

        protected void checkSession()
        {
            if (Session.Contents.Count == 0)                            
                Session["cartItems"] = new List<cartList>();             
        }

        protected void fillPage()
        {
            List<cartList> onCart = ((List<cartList>)Session["cartItems"]);      
            int cartNo = 0;
            foreach (cartList item in onCart)
                cartNo += item.qty;
            lblCartCount.Text = cartNo.ToString();
        }

        protected void setActiveTab()
        {
            String activePage = Request.RawUrl;

            if (activePage.Contains("index.aspx"))
                activeTab = "home";
            else if (activePage.Contains("rentals.aspx"))
                activeTab = "rentals";
            else if (activePage.Contains("management.aspx"))
                activeTab = "management";
            else if (activePage.Contains("addMovie.aspx"))
                activeTab = "addMovie";
            else if (activePage.Contains("cart.aspx"))
                activeTab = "cart";
        }
    }
}