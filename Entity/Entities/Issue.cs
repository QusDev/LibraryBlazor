using System.ComponentModel.DataAnnotations;

namespace LibraryBlazor.Entity.Entities
{
    public class Issue
    {
        public int Id { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public bool Returned { get; set; }

        public int ReaderId { get; set; }
        public Reader Reader { get; set; } = null!;

        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
    }
}
