using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TemplateDriven.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Booking_Id { get; set; }
        public DateTime Rental_Date { get; set; }
        public DateTime Return_Date { get; set; }
        public int Total_Price { get; set; }
        public string Booking_Status { get; set; }

        //PROPERTIES FOR CAR
        public int Car_Id { get; set; }
        public virtual Car Car { get; set; }

        public string Registration_Number { get; set; }
        public string Brand_Name { get; set; }

        //PROPERTIES FOR PICKUP LOCATION
        public int Location_Id { get; set; }
        public virtual Location Location { get; set; }

        public string Location_Name { get; set; }


    }
}