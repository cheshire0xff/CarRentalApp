using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarRentalApp.Models;

namespace CarRentalApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<CarRentalApp.Models.Car> Car { get; set; }

        public DbSet<CarRentalApp.Models.CarModel> CarModel { get; set; }

        public DbSet<CarRentalApp.Models.Rental> Rental { get; set; }
    }
}
