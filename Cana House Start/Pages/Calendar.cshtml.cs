using CanaHouse.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cana_House_Start.Pages
{
    public class CalendarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CalendarModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Event> Event { get; set; } = new List<Event>();

        public async Task OnGetAsync()
        {
            var today = DateTime.Now;
            Event = await _context.Event
                .Where(e => e.Date.Month == today.Month && e.Date.Year == today.Year)
                .ToListAsync();
        }
    }
}