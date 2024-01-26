using System.ComponentModel.DataAnnotations;

namespace GreenBasket.Models
{
    public class Customer
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double Latetude { get; set; }
        public double Longitude { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string FcmToken { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
    }
}
