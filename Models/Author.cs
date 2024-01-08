namespace BOOKM1.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string? Name { get; set; }
        public DateTime Dob { get; set; }
        public DateTime DOJ { get; set; }
        public string? Sex { get; set; }
        public string? Lang1 { get; set; }
        public string? Lang2 { get; set; }
        public decimal Salary { get; set; }

        // Navigation properties
        public ICollection<Books> Books { get; set; } = new List<Books>();
        public ICollection<Study> Studies { get; set; } = new List<Study>();
    }
}
