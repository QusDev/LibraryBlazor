using System.ComponentModel.DataAnnotations;

namespace LibraryBlazor.Entity.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public string Title { get; set; } = null!;

        [Required]
        public DateTime Publication_year { get; set; }

        [Required]
        public int CountPage { get; set; }

        [Required]
        public bool Available { get; set; }

        public List<Author> Authors { get; set; } = [];
        public List<Genre> Genres { get; set; } = [];
    }
}
