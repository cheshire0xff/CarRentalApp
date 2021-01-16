using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CarRentalApp.Data;
using CarRentalApp.Models;

namespace CarRentalApp.Pages.AppUsers
{
    public class DetailsModel : PageModel
    {
        private readonly CarRentalApp.Data.ApplicationDbContext _context;

        public DetailsModel(CarRentalApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IdentityUser AppUser { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppUser = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);

            if (AppUser == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
