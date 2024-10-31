using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Genres")]
	public class Genre : EntityBase<int>
    {
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; } = true;
		public ICollection<Book> Books { get; set; }
	}
}
