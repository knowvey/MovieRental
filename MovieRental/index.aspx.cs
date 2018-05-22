using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieRental
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        WebService1 server = new WebService1();
        public Boolean prevBtn = true;
        public Boolean nextBtn = true;
        public int pageNum = 0;
        int page = 0;
        int noOfPages = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            fillPage();
        }

        private void fillPage()
        {
            var moviesList = server.getMoviesList();            
            double partialPage = (double)moviesList.Count / 12;

            //Sets number of pages
            if (partialPage % 1 == 0)
                noOfPages = (int)partialPage;
            else
                noOfPages = (int)partialPage + 1;            

            //Check page number and only display 12 movies
            if (!String.IsNullOrWhiteSpace(Request.QueryString["page"]))
            {
                page = Convert.ToInt32(Request.QueryString["page"]);
                pageNum = page;

                if (page == 1)
                {
                    moviesList.RemoveRange(12, moviesList.Count - 12);
                    if (page < noOfPages)
                        nextBtn = false;

                }
                else if (page > 1)
                {
                    prevBtn = false;
                    moviesList.RemoveRange(0, 12 * (page - 1));
                    if (moviesList.Count > 12)
                    {
                        moviesList.RemoveRange(12, moviesList.Count - (12 * (page - 1)));
                        nextBtn = false;
                    }
                }
            }
            else
            {
                page = 1;
                pageNum = page;
                moviesList.RemoveRange(12, moviesList.Count - 12);
                if (page < noOfPages)
                    nextBtn = false;
            }

            //Displays movie details
            if (moviesList.Count >= 1)
            {
                for (int i = 0; i < moviesList.Count; i++)
                {
                    Panel mPanel = new Panel();
                    ImageButton imgBtn = new ImageButton();
                    Label lblTitle = new Label();
                    Label lblYear = new Label();

                    imgBtn.ImageUrl = "~/images/" + moviesList[i].image;
                    imgBtn.CssClass = "movieImage";
                    imgBtn.PostBackUrl = "~/movieDetails.aspx?id=" + moviesList[i].idmovies;

                    lblTitle.Text = moviesList[i].movie_title;
                    lblTitle.CssClass = "movieTitle";

                    lblYear.Text = moviesList[i].release_year.ToString();
                    lblYear.CssClass = "movieYear";

                    mPanel.Controls.Add(new Literal { Text = "<div class=\"col-lg-3 col-md-4 col-sm-6 img-padding center-block text-center\">" });
                    mPanel.Controls.Add(imgBtn);
                    mPanel.Controls.Add(new Literal { Text = "<br />" });
                    mPanel.Controls.Add(lblTitle);
                    mPanel.Controls.Add(new Literal { Text = "<br />" });
                    mPanel.Controls.Add(lblYear);
                    mPanel.Controls.Add(new Literal { Text = "</div>" });

                    moviesPanel.Controls.Add(mPanel);
                }
            }

            //Sets pagination number of page
            for (int i = 1; i <= noOfPages; i++)
            {
                if (i == page)
                    paginationPages.Text += "<li class=\"page-item active\"><a class=\"page-link\" href=\"index.aspx?page=" + i + "\">" + i + "</a></li>";
                else
                    paginationPages.Text += "<li class=\"page-item\"><a class=\"page-link\" href=\"index.aspx?page=" + i + "\">" + i + "</a></li>";
            }
        }
    }
}