using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalApp.Data;
using CarRentalApp.Models;

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
        public string VINSort { get; set; }
        public string ModelIdSort { get; set; }
        public string ManufacturerSort { get; set; }
        public string ModelSort { get; set; }
        public string PricePerDaySort { get; set; }
        public string MileageKMSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            var CarList = await _context.Car.ToListAsync();
            var CarModelList = await _context.CarModel.ToListAsync();
            CarModelCar = new List<CarModelCar>();
            foreach (var car in CarList)
            {
                CarModelCar.Add(new CarModelCar  
                { Car = car, CarModel = CarModelList.FirstOrDefault(c => c.ID == car.ModelId) });
            }

            // using System;
            VINSort = string.IsNullOrEmpty(sortOrder) ? "VIN_desc" : "VIN_asc";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            ModelIdSort = sortOrder == "ModelId" ? "ModelId_desc" : "ModelId_asc";
            ManufacturerSort = sortOrder == "Manufacturer" ? "Manufacturer_desc" : "Manufacturer_asc";
            ModelSort = sortOrder == "Model" ? "Model_desc" : "Model_asc";
            PricePerDaySort = sortOrder == "Model" ? "PricePerDay_desc" : "PricePerDay_asc";
            MileageKMSort = sortOrder == "Model" ? "MileageKM_desc" : "MileageKM_asc";

            CurrentFilter = searchString;

            IQueryable<CarModelCar> carsIQ = from s in CarModelCar.AsQueryable()
                                     select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                carsIQ = carsIQ.Where(s => s.CarModel.Manufacturer.Contains(searchString, StringComparison.CurrentCultureIgnoreCase) 
                ||
                s.CarModel.Model.Contains(searchString, StringComparison.CurrentCultureIgnoreCase));
            }

            switch (sortOrder)
            {
                case "VIN_desc":
                    carsIQ = carsIQ.OrderByDescending(s => s.Car.VIN);
                    VINSort = "VIN_asc";
                    break;
                case "VIN_asc":
                    carsIQ = carsIQ.OrderBy(s => s.Car.VIN);
                    VINSort = "VIN_desc";
                    break;
                case "ModelId_desc":
                    carsIQ = carsIQ.OrderByDescending(s => s.Car.ModelId);
                    ModelIdSort = "ModelId_asc";
                    break;
                case "ModelId_asc":
                    carsIQ = carsIQ.OrderBy(s => s.Car.ModelId);
                    ModelIdSort = "ModelId_desc";
                    break;
                case "Manufacturer_desc":
                    carsIQ = carsIQ.OrderByDescending(s => s.CarModel.Manufacturer); //Poprawiæ
                    ManufacturerSort = "Manufacturer_asc";
                    break;
                case "Manufacturer_asc":
                    carsIQ = carsIQ.OrderBy(s => s.CarModel.Manufacturer);//Poprawiæ
                    ManufacturerSort = "Manufacturer_desc";
                    break;
                case "Model_desc":
                    carsIQ = carsIQ.OrderByDescending(s => s.CarModel.Model);//Poprawiæ
                    ModelIdSort = "Model_asc";
                    break;
                case "Model_asc":
                    carsIQ = carsIQ.OrderBy(s => s.CarModel.Model);//Poprawiæ
                    ModelIdSort = "Model_desc";
                    break;
                case "PricePerDay_desc":
                    carsIQ = carsIQ.OrderByDescending(s => s.Car.PricePerDay);
                    PricePerDaySort = "PricePerDay_asc";
                    break;
                case "PricePerDay_asc":
                    carsIQ = carsIQ.OrderBy(s => s.Car.PricePerDay);
                    PricePerDaySort = "PricePerDay_desc";
                    break;
                case "MileageKM_desc":
                    carsIQ = carsIQ.OrderByDescending(s => s.Car.MileageKm);
                    MileageKMSort = "MileageKM_asc";
                    break;
                case "MileageKM_asc":
                    carsIQ = carsIQ.OrderBy(s => s.Car.MileageKm);
                    MileageKMSort = "MileageKM_desc";
                    break;
                case "Date":
                    carsIQ = carsIQ.OrderBy(s => s.Car.ProductionDate);
                    break;
                case "date_desc":
                    carsIQ = carsIQ.OrderByDescending(s => s.Car.ProductionDate);
                    break;
                default:
                    carsIQ = carsIQ.OrderBy(s => s.Car.VIN);
                    break;
            }

            CarModelCar = carsIQ.AsNoTracking().ToList();
        }
    }
}