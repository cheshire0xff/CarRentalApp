using System;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApp.Models
{
    public class Car
    {
        [Key]
        public int VIN { get; set;}
        [Required]
        public int ModelId{ get; set;}
        [Required]
        [MinLength(0)]
        public int MileageKm{ get; set;}
        [Required]
        public DateTime ProductionDate{ get; set; }
    }
    
}