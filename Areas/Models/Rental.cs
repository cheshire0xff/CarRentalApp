
using System;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApp.Models
{
    public class Rental
    {
        [Key]
        public int ID{ get; set;}
        [Required]
        public int CarID { get; set;}
        [Required]
        public int UserID { get; set;}
        [Required]
        public int Price { get; set;}

        [Required]
        public DateTime StartDate{ get; set; }
        [Required]
        public DateTime EndDate{ get; set; }
    }
    
}