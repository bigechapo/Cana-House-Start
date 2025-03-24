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
        public DbSet<Volunteers> Volunteers { get; set; }

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

        public byte[] ImageUrl { get; set; }
        public DateOnly Date { get; set; }
    }
}


public class Volunteers
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public System.DateTime SubmissionDate { get; set; }
    public string Event { get; set; }
}
