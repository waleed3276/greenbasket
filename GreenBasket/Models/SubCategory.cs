using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GreenBasket.Models
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        public int PhaseId { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public virtual Category Categories { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
    }
}
