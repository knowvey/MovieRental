using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieRental
{
    public partial class movieDetails : System.Web.UI.Page
    {
        WebService1 server = new WebService1();
        int id;

        protected void Page_Load(object sender, EventArgs e)
        {                        
            fillPage();
            fillSuggestions();  
        }

        private void fillPage()
        {
            if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
                var movieDet = server.getMovie(id);

                movieImg.ImageUrl = "~/images/" + movieDet.image;
                movieImg.CssClass = "movieImage";
                movieTitle1.Text = movieDet.movie_title;
                movieTitle2.Text = movieDet.movie_title;
                movieYear.Text = movieDet.release_year.ToString();
                movieRate.Text = "₱ " + movieDet.rental_daily_rate.ToString();

                checkQty();                    
            }
        }

        private void fillSuggestions()
        {
            var movieList = server.getMoviesList();
            movieList.RemoveAt(id-1);
            var random = new Random();
            
            for (int i = 0; i < 4; i++)
            {
                int idx = random.Next(0, movieList.Count);                

                Panel mPanel = new Panel();
                ImageButton imgBtn = new ImageButton();
                Label lblTitle = new Label();
                Label lblYear = new Label();

                imgBtn.ImageUrl = "~/images/" + movieList[idx].image;
                imgBtn.CssClass = "movieImage";
                imgBtn.PostBackUrl = "~/movieDetails.aspx?id=" + movieList[idx].idmovies;
                imgBtn.Click += suggestClick;

                lblTitle.Text = movieList[idx].movie_title;
                lblTitle.CssClass = "movieTitle";

                lblYear.Text = movieList[idx].release_year.ToString();
                lblYear.CssClass = "movieYear";

                mPanel.Controls.Add(new Literal { Text = "<div class=\"col-md-3 col-sm-6 img-padding center-block text-center\">" });
                mPanel.Controls.Add(imgBtn);
                mPanel.Controls.Add(new Literal { Text = "<br />" });
                mPanel.Controls.Add(lblTitle);
                mPanel.Controls.Add(new Literal { Text = "<br />" });
                mPanel.Controls.Add(lblYear);
                mPanel.Controls.Add(new Literal { Text = "</div>" });

                suggestionsPnl.Controls.Add(mPanel);
                movieList.RemoveAt(idx);
            }
        }

        private void suggestClick(object sender, EventArgs e)
        {
            fillPage();
        }

        protected void rentBtn_Click(object sender, EventArgs e)
        {
            addToSessionList(id);
            var movie = server.getMovie(id);
            List<cartList> cartItems = (List<cartList>)Session["cartItems"];
            int cartNo = 0;
            foreach (cartList item in cartItems)
                cartNo += item.qty;

            modalImage.ImageUrl = "~/images/" + movie.image;
            modalTitle.Text = movie.movie_title;
            modalYear.Text = movie.release_year.ToString();
            modalRate.Text = "₱ " + movie.rental_daily_rate.ToString();

            modalCartItems.Text = cartNo + "";
            Label noItems = (Label)Master.FindControl("lblCartCount");
            noItems.Text = cartNo + "";
            modalTotal.Text = "₱ " + (server.getTotal(cartItems) - (server.getTotal(cartItems) * .1)).ToString();
            modalVat.Text = "₱ " + (server.getTotal(cartItems) * .1).ToString();
            modalTotal2.Text = "₱ " + server.getTotal(cartItems).ToString();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            checkQty();
        }

        private void addToSessionList(int idx)
        {
            List<cartList> cartItems = (List<cartList>)Session["cartItems"];
            Boolean isOnList = false;

            foreach (cartList mList in cartItems)
            {
                if (idx == mList.movieID)
                {
                    mList.qty += 1;
                    isOnList = true;
                }
            }

            if (!isOnList)
                cartItems.Add(new cartList { movieID = idx, qty = 1 });
            Session["cartItems"] = cartItems;
        }

        private void checkQty()
        {
            var movie = server.getMovie(id);
            List<cartList> cartItems = (List<cartList>)Session["cartItems"];
            int idx = 99;
            Boolean isNotAvailable = false;

            if (cartItems.Count > 0)
            {
                for (int i = 0; i < cartItems.Count; i++)
                {
                    if (cartItems[i].movieID == id)
                        idx = i;
                }

                if (idx != 99)
                {
                    if (movie.number_in_stock == cartItems[idx].qty || cartItems[idx].qty == 5)
                        isNotAvailable = true;
                }
                else if (movie.number_in_stock == 0)
                    isNotAvailable = true;

                if (isNotAvailable)
                {
                    rentBtn.CssClass = "btn btn-danger btn-lg disabled";
                    rentBtn.Enabled = false;
                    if (cartItems[idx].qty == 5)
                        stockLbl.Text = "Maximum of 5 copies only";
                    else if (movie.number_in_stock == 0)
                        stockLbl.Text = "No stocks available";
                    else
                    {
                        stockLbl.Text = "Only " + movie.number_in_stock;
                        if (movie.number_in_stock == 1)
                            stockLbl.Text += " copy in stock";
                        else
                            stockLbl.Text += " copies in stock";
                    }
                }
                else
                {
                    rentBtn.CssClass = "btn btn-danger btn-lg";
                    rentBtn.Enabled = true;
                    stockLbl.Text = "";
                }
            }
            else
            {
                if (movie.number_in_stock == 0)
                {
                    rentBtn.CssClass = "btn btn-danger btn-lg disabled";
                    rentBtn.Enabled = false;
                    stockLbl.Text = "No stocks available";
                }
                else
                {
                    rentBtn.CssClass = "btn btn-danger btn-lg";
                    rentBtn.Enabled = true;
                    stockLbl.Text = "";
                }
            }
        }
    }
}