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
    public class DetailsModel : PageModel
    {
        private readonly CarRentalApp.Data.DataContext _context;

        public DetailsModel(CarRentalApp.Data.DataContext context)
        {
            _context = context;
        }

        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car.FirstOrDefaultAsync(m => m.VIN == id.ToString());

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
