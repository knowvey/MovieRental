using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieRental
{
    public partial class addMovie : System.Web.UI.Page
    {
        WebService1 server = new WebService1();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            server.addMovie(titleTB.Text, Int32.Parse(yearTB.Text), Double.Parse(rateTB.Text),
                Int32.Parse(stocksTB.Text), imageFU.FileName);
            imageFU.SaveAs(Server.MapPath("~/images/" + imageFU.FileName));
            
            litStatus.Text = "Movie successfully added";
            titleTB.Text = "";
            yearTB.Text = "";
            rateTB.Text = "";
            stocksTB.Text = "";
            imageFU = new FileUpload();
        }        
    }
}