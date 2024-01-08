using System.ComponentModel.DataAnnotations;

namespace BOOKM1.Models
{
    public class Books
    {
        [Key]
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? Name { get; set; }
        public string? Wri_IN { get; set; }
        public decimal Bcost { get; set; }
        public decimal Wcost { get; set; }
        public int Sold { get; set; }

        // Foreign key
        public int AuthorId { get; set; }

        // Navigation property
        public Author ? Author { get; set; }
    }
}
