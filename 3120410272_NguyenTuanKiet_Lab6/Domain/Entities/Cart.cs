using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Models
{
    [Table("Carts")]
	public class Cart : EntityBase<int>
    {
		public int? UserId { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime UpdatedOn { get; set; }
		public User User { get; set; }
		public ICollection<CartItem> CartItems { get; set; }
	}
}
