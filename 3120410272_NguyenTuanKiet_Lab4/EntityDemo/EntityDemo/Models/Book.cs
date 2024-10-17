using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityDemo.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int? Available { get; set; }
        public decimal? Cost { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }

        // Foreign Key
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        // Relationship
        public ICollection<BookCatalogue> BookCatalogues { get; set; }
        public ICollection<BookImages> BookImages { get; set; }
    }
}
