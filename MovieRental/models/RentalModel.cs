using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRental.data;
using System.Collections;

namespace MovieRental.models
{
    public class RentalModel
    {
        cinemadbEntities db = new cinemadbEntities();

        public List<rental_status> getRentalList()
        {
            return (from c in db.rental_status select c).ToList();
        }

        public void addRental(rental_status rent)
        {
            db.rental_status.Add(rent);
            db.SaveChanges();
        }        

        public void updateRental(int id, rental_status rent)
        {
            rental_status rentUp = db.rental_status.Find(id);

            rentUp.customer_id = rent.customer_id;
            rentUp.idmovies = rent.idmovies;
            rentUp.qty = rent.qty;
            rentUp.rent_date = rent.rent_date;
            rentUp.due_date = rent.due_date;
            rentUp.status = rent.status;

            db.SaveChanges();
        }

        public void returnRental(int id, int movID, int qty)
        {
            movie mov = db.movies.Find(movID);
            rental_status retRent = db.rental_status.Find(id);

            mov.number_in_stock += qty;
            retRent.status = "returned";
            db.SaveChanges();
        }
    }
}