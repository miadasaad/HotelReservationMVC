using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Models
{
    public class Hotel
    {
        public int id { get; set; }

        [Required, StringLength(20,MinimumLength =3)]
        public string HotelName { get; set; }

        [Range(3,7)]
        public int Rates { get; set; }
        public int NumOfRooms { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string imgUrl { get; set; }
        [Required]
        public string location { get; set; }
        public int CityId { get; set; }
        public ICollection<Employee> Employees { get; set; }= new HashSet<Employee>();
        public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
        public City City { get; set; }
    }
}
