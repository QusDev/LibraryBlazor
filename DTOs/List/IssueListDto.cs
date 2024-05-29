using LibraryBlazor.Lookups;

namespace LibraryBlazor.DTOs.List
{
    public class IssueListDto
    {
        public List<IssueLookup> Issues { get; set; } = null!;
    }
}
