using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CarRentalApp.Data;
using CarRentalApp.Models;

namespace CarRentalApp.Pages.AppUsers
{
    public class IndexModel : PageModel
    {
        private readonly CarRentalApp.Data.ApplicationDbContext _context;

        public IndexModel(CarRentalApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<IdentityUser> AppUser { get;set; }

        public async Task OnGetAsync()
        {
            AppUser = await _context.Users.ToListAsync();
        }
    }
}
