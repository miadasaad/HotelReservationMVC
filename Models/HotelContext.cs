using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Models
{
    
    public class HotelContext:DbContext
    {
        public HotelContext(DbContextOptions options) : base(options)
        {
        }
        public HotelContext()
        {

        }
        public DbSet<Hotel> Hotels { get; set; }
         public DbSet<Room> Rooms { get; set; }
         public DbSet<City> Cities { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=HotelReservation;Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().HasKey(a => new { a.GuestId, a.RoomId,a.HotelId,a.ReservationNum,a.StReservDate });
            base.OnModelCreating(modelBuilder);
        }
    }
}
