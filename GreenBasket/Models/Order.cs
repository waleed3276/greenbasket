using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GreenBasket.Models
{
    public class Order
    {
        [Key]
        public long Id { get; set; }
        public int PhaseId { get; set; }
        [ForeignKey("CustomerId")]
        public long? CustomerId { get; set; }
        [JsonIgnore]
        public virtual Customer? Customers { get; set; }
        public string OrderCode { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public double Latetude { get; set; }
        public double Longitude { get; set; }
        public string Location { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPayment { get; set; }
        public string VoucherNo { get; set; }
        public int VoucherAmount { get; set; }
        public int DeleveryFee { get; set; }
        public int ServiceFee { get; set; }
        public int TotalItems { get; set; }
        public double TotalDiscount { get; set; }
        public double GSTAmount { get; set; }
        public double SubTotalAmount { get; set; }
        public double TotalAmunt { get; set; }
        [Display(Name = "Order Status")]
        public OrderStatusEnum OrderStatus { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public bool Status { get; set; }
        public DateTime Date { get; set; }
    }
    public enum OrderStatusEnum
    {

        Pending,
        InProgress,
        Shipped,
        Delivered,
        Cancelled
    }
}
