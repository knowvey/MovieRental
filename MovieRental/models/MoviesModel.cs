using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRental.data;

namespace MovieRental.models
{
    public class MoviesModel
    {
        cinemadbEntities db = new cinemadbEntities();

        public List<movie> getMovieList()
        {            
            return (from c in db.movies select c).ToList();
        }

        public movie getMovie(int idx)
        {            
            return (from c in db.movies where c.idmovies == idx select c).First();
        }

        public double getTotal(List<cartList> list)
        {
            double total = 0;

            foreach (cartList item in list)
            {
                total += getMovie(item.movieID).rental_daily_rate * item.qty;
            }

            return total;
        }

        public void addMovie(movie mov)
        {
            db.movies.Add(mov);
            db.SaveChanges();
        }

        public void minusQty(int idx, int qty)
        {
            movie mov = (from c in db.movies where c.idmovies == idx select c).First();
            mov.number_in_stock -= qty;
            db.SaveChanges();
        }

        public void updateMovie(int id, movie mov)
        {
            movie upMov = db.movies.Find(id);

            upMov.movie_title = mov.movie_title;
            upMov.release_year = mov.release_year;
            upMov.number_in_stock = mov.number_in_stock;
            upMov.rental_daily_rate = mov.rental_daily_rate;

            db.SaveChanges();
        }
    }
}