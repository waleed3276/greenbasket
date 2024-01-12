using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenBasket.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("PhaseId")]
        public int PhaseId { get; set; }
        public virtual Phase Phases { get; set; }
        public string Name { get; set; }
        public string Image { get; set; } // For Slider
        public string Icon { get; set; } // For show data
        //public string Description { get; set; }
        public bool IsPromossion { get; set; } // For Promotion apply or not
        public int Priority { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
    }
}
