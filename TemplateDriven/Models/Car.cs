using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TemplateDriven.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Car_Id { get; set; }
        public string  Brand_Name { get; set; }
        public bool Availability { get; set; }
        public string Description { get; set; }
        
        public string Registration_Number { get; set; }
        public string Color { get; set; }
        public string Transition { get; set; }
        public int Price { get; set; }
        public int Capacity { get; set; }
        public string ModelYear { get; set; }


        //FOREIGN PROPERTIES FOR LOCATION
        public int? Location_Id { get; set; }
        public virtual Location Location { get; set; }
        public string Location_Name { get; set; }

        //FOREIGN PROPERTIES FOR TYPE
        public int CarType_Id { get; set; }
        public virtual CarType Type { get; set; }
        public string CarType_Name { get; set; }


        //Relationship Booking
        public virtual ICollection<Booking> CarBooking { get; set; }


        //DATA INTERGRATION
        ApplicationDbContext db = new ApplicationDbContext();
        //Get Location Name

        public string LocationName()
        {
            var LName = (from LN in db.Locations
                         where LN.Location_Id == Location_Id
                         select LN.Location_Name).SingleOrDefault();

            return LName;
        }

    }
}