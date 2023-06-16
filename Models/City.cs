using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Models
{
    public class City
    {
      
        public int Id { get; set; }
        public string Name { get; set; }
        public string url { get; set; }
        public ICollection<Hotel> Hotels { get; set; }=new HashSet<Hotel>();
    }
}
