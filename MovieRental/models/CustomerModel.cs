using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRental.data;
using System.Collections;

namespace MovieRental.models
{
    public class CustomerModel
    {
        cinemadbEntities db = new cinemadbEntities();

        public IList getCustomers()
        {
            return (from c in db.customers
                    select new {    
                        c.id, fullName = c.last_name + ", " + c.first_name,
                        c.mobile_number, c.email_address
                    }).ToList();
        }

        public int addCustomer(customer cust)
        {
            db.customers.Add(cust);
            db.SaveChanges();
            
            return cust.id;
        }

        public void updateCustomer(int id, customer cust)
        {
            customer upCust = db.customers.Find(id);

            upCust.first_name = cust.first_name;
            upCust.last_name = cust.last_name;
            upCust.mobile_number = cust.mobile_number;
            upCust.email_address = cust.email_address;

            db.SaveChanges();
        }
    }
}