namespace LibraryBlazor.Entity.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public List<Book> Books { get; } = [];
    }
}
