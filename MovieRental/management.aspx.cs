using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieRental
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        WebService1 server = new WebService1();

        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack)              
                fillPage();                    
        }

        protected void fillPage()
        {
            if (Session["loggedIn"] != null)
            {
                loginPnl.Visible = false;
                managementPnl.Visible = true;
                createMovieDS();
                createRentalDS();
                createCustDS();
            }            
        }

        private void createMovieDS()
        {
            movieListGV.DataSource = server.getMoviesList();
            movieListGV.DataBind();
        }

        private void createRentalDS()
        {
            rentListGV.DataSource = server.getRentalList();
            rentListGV.DataBind();
        }

        private void createCustDS()
        {
            customerGV.DataSource = server.getCustomers();
            customerGV.DataBind();
        }
        
        protected void movieListGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            movieListGV.PageIndex = e.NewPageIndex;
            createMovieDS();
        }

        protected void movieListGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            movieListGV.EditIndex = e.NewEditIndex;
            createMovieDS();
        }

        protected void movieListGV_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            movieListGV.EditIndex = -1;
            createMovieDS();
        }

        protected void movieListGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = int.Parse(movieListGV.Rows[e.RowIndex].Cells[1].Text);
            String title = ((TextBox)movieListGV.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            int year = int.Parse(((TextBox)movieListGV.Rows[e.RowIndex].Cells[3].Controls[0]).Text);
            int stock = int.Parse(((TextBox)movieListGV.Rows[e.RowIndex].Cells[4].Controls[0]).Text);
            double rate = int.Parse(((TextBox)movieListGV.Rows[e.RowIndex].Cells[5].Controls[0]).Text);

            server.updateMovie(id, title, year, stock, rate);
            movieListGV.EditIndex = -1;
            createMovieDS();
        }

        protected void rentListGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            rentListGV.PageIndex = e.NewPageIndex;
            createRentalDS();
        }

        protected void rentListGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            rentListGV.EditIndex = e.NewEditIndex;
            createRentalDS();
        }

        protected void rentListGV_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            rentListGV.EditIndex = -1;
            createRentalDS();
        }

        protected void rentListGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = int.Parse(rentListGV.Rows[e.RowIndex].Cells[1].Text);
            int custID = int.Parse(((TextBox)rentListGV.Rows[e.RowIndex].Cells[2].Controls[0]).Text);
            int movID = int.Parse(((TextBox)rentListGV.Rows[e.RowIndex].Cells[3].Controls[0]).Text);
            int qty = int.Parse(((TextBox)rentListGV.Rows[e.RowIndex].Cells[4].Controls[0]).Text);
            DateTime rentD = DateTime.Parse(((TextBox)rentListGV.Rows[e.RowIndex].Cells[5].Controls[0]).Text);
            DateTime dueD = DateTime.Parse(((TextBox)rentListGV.Rows[e.RowIndex].Cells[6].Controls[0]).Text);
            String stat = ((TextBox)rentListGV.Rows[e.RowIndex].Cells[7].Controls[0]).Text;

            server.updateRentals(id, custID, movID, qty, rentD, dueD, stat);
            rentListGV.EditIndex = -1;
            createRentalDS();
        }

        protected void customerGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            customerGV.PageIndex = e.NewPageIndex;
            createCustDS();
        }

        protected void customerGV_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            customerGV.EditIndex = -1;
            createCustDS();
        }

        protected void customerGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            customerGV.EditIndex = e.NewEditIndex;
            createCustDS();
        }

        protected void customerGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = int.Parse(customerGV.Rows[e.RowIndex].Cells[1].Text);
            String[] fullName = (((TextBox)customerGV.Rows[e.RowIndex].Cells[2].Controls[0]).Text).Split(new[] { ", " }, StringSplitOptions.None);
            String mobileNo = ((TextBox)customerGV.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            String emailAdd = ((TextBox)customerGV.Rows[e.RowIndex].Cells[4].Controls[0]).Text;

            String lName = fullName[0];
            String fNmae = fullName[1];

            server.updateCustomer(id, fNmae, lName, mobileNo, emailAdd);
            customerGV.EditIndex = -1;
            createCustDS();
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            if (uNameTB.Text == "admin" && passTB.Text == "admin")
            {
                Session["loggedIn"] = 1;
                fillPage();
            }
            else
                msgLbl.Text = "Incorrect login details";
        }      
        
        protected Boolean onRentCheck(String stat)
        {
            if (stat == "returned")
                return false;
            else
                return true;
        }   

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;            
            int rowIdx = ((GridViewRow)btn.NamingContainer).RowIndex;

            int id = int.Parse(rentListGV.Rows[rowIdx].Cells[1].Text);
            int movID = int.Parse(rentListGV.Rows[rowIdx].Cells[3].Text);
            int qty = int.Parse(rentListGV.Rows[rowIdx].Cells[4].Text);

            server.returnRental(id, movID, qty);
            fillPage();
        }

        //protected void isOverdue()
        //{
        //    var rentalList = server.getRentalList();            
        //    var rentalDue = server.getRentalList();       
        //    int overdueRate = 50;

        //    for (int i = 0; i < rentalList.Count; i++)
        //    {
        //        int difference = DateTime.Compare(rentalList[i].due_date, rentalList[i].rent_date);

        //        if (difference > 0)
        //            rentalDue[i].is_overdue

        //    }
        //}
    }
}
