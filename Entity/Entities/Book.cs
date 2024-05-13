namespace LibraryBlazor.Entity.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime publication_year { get; set; }
        public int CountPage { get; set; }
        public bool available { get; set; }

        public List<Author> Authors { get; } = [];
        public List<Genre> Genres { get; } = [];
    }
}
