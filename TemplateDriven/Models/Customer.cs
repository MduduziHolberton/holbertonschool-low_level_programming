using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TemplateDriven.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Customer_Id { get; set; }
        public int License_Number { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Surname { get; set; }
    }
}