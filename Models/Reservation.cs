namespace HotelReservation.Models
{
    public class Reservation
    {

        public int ReservationNum { get; set; }
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public int GuestId { get; set; }
        public DateTime StReservDate { get; set; }
        public DateTime EndReservDate { get; set; }
    
        public Guest Guest { get; set; } 
        public Room Room { get; set; } 
        public Hotel Hotel { get; set; } 
    }
}
