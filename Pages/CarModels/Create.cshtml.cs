using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalApp.Data;
using CarRentalApp.Models;

namespace CarRentalApp.Pages.CarModels
{
    public class CreateModel : PageModel
    {
        private readonly CarRentalApp.Data.DataContext _context;

        public CreateModel(CarRentalApp.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CarModel CarModel { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CarModel.Add(CarModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
