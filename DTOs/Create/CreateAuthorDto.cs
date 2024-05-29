using System.ComponentModel.DataAnnotations;

namespace LibraryBlazor.DTOs.Create
{
    public class CreateAuthorDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(2)]
        public string LastName { get; set; } = null!;
    }
}
