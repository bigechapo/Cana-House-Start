using CanaHouse.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cana_House_Start.Pages
{
    public class VolunteerListModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public VolunteerListModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Volunteers> Volunteer { get; set; } 

        public async Task OnGetAsync()
        {
            Volunteer = await _context.Volunteers 
                .OrderByDescending(v => v.SubmissionDate)
                .ToListAsync();
        }
        public async Task<IActionResult> OnPostDeleteAllAsync()
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Volunteers;");
                Console.WriteLine("All volunteers deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting volunteers: {ex.Message}");
            }

            return RedirectToPage();
        }
    }
}
