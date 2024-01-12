using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GreenBasket.Models
{
    public class Product
    {
        [Key]
        public long Id { get; set; }
        public int PhaseId { get; set; }
        [ForeignKey("UnitId")]
        public int UnitId { get; set; }
        public virtual Unit Units { get; set; }
        [ForeignKey("SubCategoryId")]
        public int SubCategoryId { get; set; }
        public virtual SubCategory SubCategories { get; set; }
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal? Discount { get; set; }
        public DiscountTypeEnum DiscountType { get; set; }
        public string Description { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal? Tax { get; set; }
        public string Image { get; set; } // For Slider
        public int MaxLimit { get; set; }
        public bool IsPromossion { get; set; } // For Promotion apply or not
        public bool Status { get; set; }
        public DateTime Date { get; set; }
    }
    public enum DiscountTypeEnum
    {
    Flat,
    Percentage
    }
}
