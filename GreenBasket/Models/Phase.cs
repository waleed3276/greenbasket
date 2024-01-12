using System.ComponentModel.DataAnnotations;

namespace GreenBasket.Models
{
    public class Phase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
    }
}
