using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TemplateDriven.Models
{
    public enum Transition
    {
        Manual,Automatic
    }
    public enum CarType
    {
        Sedan,Coupe,SUV,Taxi,Van,Convertible,Hatch_Back
    }
    public enum Colors
    {
        White,Black,Yellow,Red,Gray,Blue
    }
    public enum Brand
    {
        Toyota,Mazda,Bmw,Mercedes,Volvo,Vw,Auto,Opel
    }
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Car_Id { get; set; }

        public Brand Brand_Name { get; set; }

        public bool Available { get; set; }

        public string Description { get; set; }

        public string Regi_Number { get; set; }

        public Colors Color { get; set; }
        public Transition Transitions { get; set; }

        public int Price { get; set; }

        public int Capacity { get; set; }
        public string ModelYear { get; set; }


        //FOREIGN PROPERTIES FOR LOCATION
        public int? Location_Id { get; set; }
        public virtual Location Location { get; set; }

        public CarType CarTypes { get; set; }
        [Display(Name = "Type")]

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