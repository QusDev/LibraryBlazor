using LibraryBlazor.Entity.Entities;

namespace LibraryBlazor.Lookups
{
    public class IssueLookup
    {
        public int Id { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public bool Returned { get; set; }

        public Reader Reader { get; set; } = null!;

        public Book Book { get; set; } = null!;
    }
}
