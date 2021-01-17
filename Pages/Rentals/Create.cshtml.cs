using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarRentalApp.Data;
using CarRentalApp.Models;
using Microsoft.AspNetCore.Identity;

namespace CarRentalApp.Pages.Rentals
{
    public class CreateModel : PageModel
    {
        private readonly CarRentalApp.Data.DataContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(CarRentalApp.Data.DataContext context,
        UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // if when getting page id was provided
        // on post use it fill car id;
        public Car Car { get; set;}
        public CarModel CarModel { get; set;}
        public IActionResult OnGet(string id)
        {
            if (id != null)
            {
                Car = _context.Car.Find(id.ToString());
                if (Car != null)
                {
                    CarModel = _context.CarModel.Find(Car.ModelId);
                }
            }
            return Page();
        }

        [BindProperty]
        public Rental Rental { get; set; }
        public int? days {get; set;}

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id!= null)
            {
                Car = _context.Car.Find(id.ToString());
            }
            if (!User.IsInRole("Administrator"))
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                Rental.UserID = user.Id;
            }
            if ((Rental.StartDate - DateTime.Now).TotalDays <= 0)
            {
                ModelState.AddModelError("DateIncorrect", "Start date cannot be in the past");
                return Page();
            }
            if (Rental.StartDate > Rental.EndDate)
            {
                ModelState.AddModelError("DateIncorrect", "Start Date has to be greater than EndDate");
                return Page();
            }
            if (Car != null)
            {
                Rental.CarID = Car.VIN;
                Rental.Price = (int)Math.Ceiling((Rental.EndDate - Rental.StartDate).TotalDays * Car.PricePerDay);
            }
            if (await _context.Car.FindAsync(Rental.CarID) == null)
            {
                ModelState.AddModelError("CarNotFound", "Car VIN doesn't exist!");
                return Page();
            }
            ModelState.Clear();
            if(!TryValidateModel(Rental, nameof(Rental)))
            {
                ModelState.AddModelError("CarNotFound", Rental.UserID);
                return Page();
            }
            _context.Rental.Add(Rental);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
