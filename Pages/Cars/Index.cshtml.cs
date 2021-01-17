using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalApp.Data;
using CarRentalApp.Models;
using System.Diagnostics;

namespace CarRentalApp.Pages.Cars
{
    public class CarModelCar
    {
        public Car Car;
        public CarModel CarModel;
    }
    public class IndexModel : PageModel
    {
        private readonly CarRentalApp.Data.DataContext _context;

        public IndexModel(CarRentalApp.Data.DataContext context)
        {
            _context = context;
        }

        public IList<CarModelCar> CarModelCar { get; set; }

        public async Task OnGetAsync()
        {
            var CarList = await _context.Car.ToListAsync();
            var CarModelList = await _context.CarModel.ToListAsync();
            CarModelCar = new List<CarModelCar>();
            foreach (var car in CarList)
            {
                CarModelCar.Add(new CarModelCar  
                { Car = car, CarModel = CarModelList.FirstOrDefault(c => c.ID == car.ModelId) });
            }
        }
    }
}
