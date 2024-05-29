using Microsoft.AspNetCore.Mvc.Diagnostics;
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
        public int SelectedReaderId;

        [Required]
        public int SelectedBookId;
    }
}
