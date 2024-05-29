using System.ComponentModel.DataAnnotations;

namespace LibraryBlazor.DTOs.Create
{
    public class CreateIssueDto
    {
        public int Id { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        [Required]
        public bool Returned { get; set; }

        [Required]
        public int SelectedReaderId = -1;

        [Required]
        public int SelectedBookId = -1;
    }
}
