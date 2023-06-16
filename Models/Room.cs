using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Models
{
    
    public class Room
    {
        public int Id { get; set; }
        [Required,StringLength(10,MinimumLength =3)]
        public string type { get; set; }
        public int price { get; set; }
        public string imgUrl { get; set; }
        public int offer { get; set; }
        public Boolean available { get; set; }
        public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
    }

}
