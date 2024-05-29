using LibraryBlazor.Entity.Entities;
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
        [Range(1, int.MaxValue)]
        public int CountPage { get; set; }

        [Required]
        public bool Available { get; set; }

        [MinLength(1, ErrorMessage = "Select at least 1")]
        public int[] SelectedGenresId { get; set; } = { };

        [MinLength(1, ErrorMessage = "Select at least 1")]
        public int[] SelectedAuthorsId { get; set; } = { };
    }
}
