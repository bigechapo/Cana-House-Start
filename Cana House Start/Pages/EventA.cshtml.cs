
using Microsoft.AspNetCore.Mvc.RazorPages;
using CanaHouse.Data;
using System.Collections.Generic;
using System.Linq;

namespace Cana_House_Start.Pages
{
    public class EventA : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EventA(ApplicationDbContext context)
        {
            _context = context;
        }

        // Property to hold events
        public List<Event> Events { get; set; }

        // Method to fetch events when the page is loaded (GET request)
        public void OnGet()
        {
            // Ensure the ID field is of type int and fetch events ordered by ID
            Events = _context.Event.OrderBy(e => e.Date).ToList();
        }
    }
}