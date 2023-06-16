using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservation.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public double salary { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required,StringLength(11,MinimumLength =11)]
        public string Phone { get; set; }
        [Required,DataType(DataType.Password)]
        public string password { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string Address { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
       
    }
}
