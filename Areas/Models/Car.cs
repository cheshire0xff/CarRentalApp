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
        public uint MileageKm{ get; set;}
        [Required]
        public DateTime ProductionDate{ get; set; }
    }
    
}