using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TemplateDriven.Models
{
      
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Location_Id { get; set; }
        public string Location_Name { get; set; }
        public int Total_Cars { get; set; }

        //Relationship with Cars, send location details to car
        public ICollection<Car> LocationCars { get; set; }


        //Relationship with booking,send location to booking
        public ICollection<Booking> BookingsLocation { get; set; }

    }
}