using LibraryBlazor.Entity.Entities;

namespace LibraryBlazor.Lookups
{
    public class IssueLookup
    {
        public int Id { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public bool Returned { get; set; }

        public ReaderLookup Reader { get; set; } = null!;

        public BookLookup Book { get; set; } = null!;
    }
}
