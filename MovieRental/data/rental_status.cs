//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MovieRental.data
{
    using System;
    using System.Collections.Generic;
    
    public partial class rental_status
    {
        public int id { get; set; }
        public int idmovies { get; set; }
        public int customer_id { get; set; }
        public int qty { get; set; }
        public string status { get; set; }
        public System.DateTime due_date { get; set; }
        public System.DateTime rent_date { get; set; }
        public string rental_statuscol { get; set; }
    }
}
