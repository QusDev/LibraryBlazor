using System.ComponentModel.DataAnnotations;

namespace LibraryBlazor.DTOs.Create
{
    public class CreatBookDto
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

        [Required]
        [MinLength(1)]
        public int[] SelectedGenresId = { };

        [Required]
        [MinLength(1)]
        public int[] SelectedAuthorsId = { };
    }
}
