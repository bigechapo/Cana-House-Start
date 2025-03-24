using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CanaHouse.Data;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Cana_House_Start.Pages
{
    public class EventBModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public EventBModel(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public List<EventInputModel> EventInputModels { get; set; } = new List<EventInputModel>();

        public class EventInputModel
        {
            public string EventTitle { get; set; }
            public string EventDescription { get; set; }
            public string EventDate { get; set; }
            public IFormFile EventImage { get; set; } // Change to IFormFile for image upload
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState is invalid");
                return Page();
            }

            Console.WriteLine($"Received {EventInputModels.Count} events");

            foreach (var eventData in EventInputModels)
            {
                byte[] imageBytes = null;

                if (eventData.EventImage != null && eventData.EventImage.Length > 0)
                {
                    // Convert the uploaded image to byte array
                    using (var memoryStream = new MemoryStream())
                    {
                        await eventData.EventImage.CopyToAsync(memoryStream);
                        imageBytes = memoryStream.ToArray(); // Store the image as byte array
                    }
                }

                DateOnly.TryParse(eventData.EventDate, out DateOnly parsedDate);

                var newEvent = new Event
                {
                  
                    Title = eventData.EventTitle,
                    Description = eventData.EventDescription,
                    Date = parsedDate,
                    ImageUrl = imageBytes // Store the image as byte array in the database
                };

                _context.Event.Add(newEvent);
            }

            await _context.SaveChangesAsync();
            Console.WriteLine("Data successfully pushed to database");

            return RedirectToPage("EventB");
        }

        public async Task<IActionResult> OnPostDeleteAllAsync()
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Event;");
                Console.WriteLine("All events deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting events: {ex.Message}");
            }

            return RedirectToPage();
        }
    }
}
