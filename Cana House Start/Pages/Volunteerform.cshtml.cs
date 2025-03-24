using CanaHouse.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Cana_House_Start.Pages
{
    public class VolunteerFormModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public VolunteerFormModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Volunteers VolunteerInput { get; set; } = new Volunteers();

        public string Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Message = "Please fill out all fields correctly.";
                return Page();
            }

            var volunteer = new Volunteers 
            {
                FirstName = VolunteerInput.FirstName,
                LastName = VolunteerInput.LastName,
                PhoneNumber = VolunteerInput.PhoneNumber,
                Email = VolunteerInput.Email,
                SubmissionDate = DateTime.UtcNow,
                Event = VolunteerInput.Event
            };

            _context.Volunteers.Add(volunteer); 
            await _context.SaveChangesAsync();

            Message = "Thank you for signing up!";
            return RedirectToPage("/EventA");
        }
    }
}
