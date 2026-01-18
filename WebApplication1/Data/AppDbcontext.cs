using Microsoft.EntityFrameworkCore;
using BookingAPI.Models;

namespace BookingAPI.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users => Set<User>();
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Resource> Resources => Set<Resource>();
        public DbSet<Booking> Bookings => Set<Booking>();//what the hell is this???
    }
}