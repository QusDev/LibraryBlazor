using LibraryBlazor.Lookups;

namespace LibraryBlazor.DTOs.List
{
    public class BookListDto
    {
        public List<BookLookup> Books { get; set; } = null!;
    }
}
