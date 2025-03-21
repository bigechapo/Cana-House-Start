// SignInModel.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CanaHouse.Data;
using System.Linq;

namespace Cana_House_Start.Pages
{
    public class SignInModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public SignInModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            var user = _context.Users.FirstOrDefault(u => u.Usernames == Username && u.Passwords == Password);
            if (user != null)
            {
                return RedirectToPage("/EventB");
            }
            else
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }
        }
    }
}
