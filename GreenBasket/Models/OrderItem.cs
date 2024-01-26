using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GreenBasket.Models
{
    public class OrderItem
    {
        [Key]
        public long Id { get; set; }
        public int PhaseId { get; set; }
        [ForeignKey("ProductId")]
        public long ProductId { get; set; }
        [JsonIgnore]
        public virtual Product? Products { get; set; }
        [ForeignKey("OrderId")]
        public long OrderId { get; set; }
        [JsonIgnore]
        public virtual Order? Orders { get; set; }
        public int Amount { get; set; }
        public long TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public DiscountTypeEnum DiscountType { get; set; }
        public double DiscountAmount { get; set; }
        [ForeignKey("UnitId")]
        public int? UnitId { get; set; }
        [JsonIgnore]
        public virtual Unit? Units { get; set; }
        [ForeignKey("SubCategoryId")]
        public int? SubCategoryId { get; set; }
        [JsonIgnore]
        public virtual SubCategory? SubCategories { get; set; }
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        [JsonIgnore]
        public virtual Category? Categories { get; set; }
        public string Unit { get; set; }
        public int Quantiy { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
    }
}
