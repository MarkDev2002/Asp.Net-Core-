using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityDemo.Models
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }

        // Relationship
        public ICollection<CartDetail> CartDetails { get; set; }
    }
}
