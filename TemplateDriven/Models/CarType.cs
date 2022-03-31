using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TemplateDriven.Models
{
    public class CarType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarType_Id { get; set; }
        public string CarType_Name { get; set; }

        //RELATION WITH CAR
        public ICollection<Car> TypeCars { get; set; }

    }
}