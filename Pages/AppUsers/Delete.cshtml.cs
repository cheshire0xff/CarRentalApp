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
    public class DeleteModel : PageModel
    {
        private readonly CarRentalApp.Data.ApplicationDbContext _context;

        public DeleteModel(CarRentalApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppUser = await _context.Users.FindAsync(id);

            if (AppUser != null)
            {
                _context.Users.Remove(AppUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
