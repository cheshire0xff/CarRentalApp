using System;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApp.Models
{
    public class CarModel
    {
        [Key]
        public int ID{ get; set;}
        [Required]
        public string Manufacturer{ get; set;}
        [Required]
        public string Model{ get; set;}
    }
    
}