using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MovieRental.data;
using MovieRental.models;
using System.Collections;

namespace MovieRental
{    
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
 
    public class WebService1 : System.Web.Services.WebService
    {
        MoviesModel mModel = new MoviesModel();
        CustomerModel cModel = new CustomerModel();
        RentalModel rModel = new RentalModel();

        [WebMethod]
        public List<movie> getMoviesList()
        {
            return mModel.getMovieList();
        }

        [WebMethod]
        public List<rental_status> getRentalList()
        {
            return rModel.getRentalList();
        }

        [WebMethod]
        public IList getCustomers()
        {
            return cModel.getCustomers();
        }

        [WebMethod]
        public movie getMovie(int idx)
        {
            return mModel.getMovie(idx);
        }

        [WebMethod]
        public double getTotal(List<cartList> list)
        {
            return mModel.getTotal(list);
        }

        [WebMethod]
        public int addCustomer(String fname, String lname,String num, String email)
        {
            return cModel.addCustomer(new customer
            {
                first_name = fname,
                last_name = lname,
                mobile_number = num,
                email_address = email
            });
        }

        [WebMethod]
        public void addRental(int movieID, int custID, int quantity, DateTime due, DateTime rent)
        {
            rModel.addRental(new rental_status
            {
                idmovies = movieID,
                customer_id = custID,
                qty = quantity,
                status = "on rent",
                due_date = due,
                rent_date = rent,                
            });

            mModel.minusQty(movieID, quantity);
        }

        [WebMethod]
        public void addMovie(String title, int year, double rate, int stocks, String img)
        {
            mModel.addMovie(new movie
            {
                movie_title = title,
                release_year = year,
                rental_daily_rate = rate,
                number_in_stock = stocks,
                image = img
            });
        }

        [WebMethod]
        public void updateMovie(int idx, String title, int year, int stock, double rate)
        {
            mModel.updateMovie(idx, new movie
            {
                movie_title = title,
                release_year = year,
                number_in_stock = stock,
                rental_daily_rate = rate
            });
        }

        [WebMethod]
        public void updateRentals(int idx, int custID, int movID, int qty, DateTime rentD, DateTime dueD, String status)
        {
            rModel.updateRental(idx, new rental_status
            {
                customer_id = custID,
                idmovies = movID,
                qty = qty,
                rent_date = rentD,
                due_date = dueD,
                status = status
            });
        }

        [WebMethod]
        public void updateCustomer(int idx, String fname, String lname, String mobileNo, String emailAdd)
        {
            cModel.updateCustomer(idx, new customer
            {
                first_name = fname,
                last_name = lname,
                mobile_number = mobileNo,
                email_address = emailAdd
            });
        }

        [WebMethod]
        public void returnRental(int id, int movID, int qty)
        {
            rModel.returnRental(id, movID, qty);
        }
    }
}
