using CanaHouse.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cana_House_Start.Pages
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
            /* Uncomment to test DB connectivity
            try
            {
                // Check if the Users table has any data
                int userCount = _context.Users.Count();
                Message = $"Database Connected! User Count: {userCount}";
            }
            catch (Exception ex)
            {
                Message = $"Database Connection Failed: {ex.Message}";
            }
            */
        }
    }
}

