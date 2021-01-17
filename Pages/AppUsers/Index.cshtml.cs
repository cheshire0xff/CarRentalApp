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
        public string UserSort { get; set; }
        

        public async Task OnGetAsync(string sortOrder)
        {
            //UserSort = sortOrder == "User" ? "User_desc" : "User_asc";

            //IQueryable<IdentityUser> usersIQ = from s in _context.AppUser
            //                              select s;

            //switch (sortOrder)
            //{
            //    case "User_desc":
            //        usersIQ = usersIQ.OrderByDescending(s => s.VIN);
            //        UserSort = "VIN_asc";
            //        break;
            //    case "User_asc":
            //        usersIQ = usersIQ.OrderBy(s => s.VIN);
            //        UserSort = "User_desc";
            //        break;
            //    default:
            //        usersIQ = usersIQ.OrderBy(s => s.VIN);
            //        break;
            //}

            //Car = await carsIQ.AsNoTracking().ToListAsync();

            AppUser = await _context.Users.ToListAsync();
        }
    }
}
