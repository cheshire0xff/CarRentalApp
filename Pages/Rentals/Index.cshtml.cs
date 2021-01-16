using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarRentalApp.Data;
using CarRentalApp.Models;
using Microsoft.AspNetCore.Identity;

namespace CarRentalApp.Pages.Rentals
{
    public class IndexModel : PageModel
    {
        private readonly CarRentalApp.Data.DataContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(CarRentalApp.Data.DataContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Rental> Rental { get;set; }

        public async Task OnGetAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Rental = new List<Rental>();
                return;
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (User.IsInRole("Administrator"))
            {
                Rental = await _context.Rental.ToListAsync();
            }
            else
            {
                Rental = await _context.Rental.Where(r => r.UserID == user.Id).ToListAsync();
            }
        }
    }
}
