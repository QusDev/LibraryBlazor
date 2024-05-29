using LibraryBlazor.Entity.Entities;

namespace LibraryBlazor.Lookups
{
    public class BookLookup
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public DateTime Publication_year { get; set; }

        public int CountPage { get; set; }

        public bool Available { get; set; }

        public List<AuthorLookup> Authors { get; set; } = [];
        public List<GenreLookup> Genres { get; set; } = [];
    }
}
