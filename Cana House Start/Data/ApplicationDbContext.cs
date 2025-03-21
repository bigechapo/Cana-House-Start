using Microsoft.EntityFrameworkCore;

namespace CanaHouse.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Event { get; set; }
        public DbSet<Users> Users { get; set; }
    }

    public class Users
    {
        public int Id { get; set; }
        public string Usernames { get; set; }
        public string Passwords { get; set; }
        public Boolean isAdmin { get; set; }
    }

    public class Event
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        // Store the image as a byte array
        public byte[] ImageUrl { get; set; }
        public DateOnly Date { get; set; }
    }
}

