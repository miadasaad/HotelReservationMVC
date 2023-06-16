using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, StringLength(11, MinimumLength = 11)]
        public string Phone { get; set; }

        [Required, DataType(DataType.Password)]
        public string password { get; set; }
        public string url { get; set; }
        public string Address { get; set; }
        public int balance { get; set; }
        public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
    }
}
