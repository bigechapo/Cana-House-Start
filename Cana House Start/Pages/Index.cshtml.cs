using CanaHouse.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cana House Start.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public string Message { get; private set; } = "Database Not Connected";

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            try
            {
                int eventCount = _context.Event.Count();  // Count events instead
                Message = $"Database Connected! Event Count: {eventCount}";
            }
            catch (Exception ex)
            {
                Message = $"Database Connection Failed: {ex.Message}";
            }
        }
    }
}

