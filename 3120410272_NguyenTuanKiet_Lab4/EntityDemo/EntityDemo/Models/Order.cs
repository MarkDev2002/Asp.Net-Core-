using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityDemo.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime? CreatedOn { get; set; }
        public decimal? TotalAmount { get; set; }
        public string PaymentMethod { get; set; }

        [ForeignKey("UserAddress")]
        public int? AddressId { get; set; }
        public string Status { get; set; }

        // Relationship
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual UserAddress UserAddress { get; set; }
    }
}
