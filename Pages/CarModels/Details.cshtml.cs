using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalApp.Data;
using CarRentalApp.Models;

namespace CarRentalApp.Pages.CarModels
{
    public class DetailsModel : PageModel
    {
        private readonly CarRentalApp.Data.DataContext _context;

        public DetailsModel(CarRentalApp.Data.DataContext context)
        {
            _context = context;
        }

        public CarModel CarModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarModel = await _context.CarModel.FirstOrDefaultAsync(m => m.ID == id);

            if (CarModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
