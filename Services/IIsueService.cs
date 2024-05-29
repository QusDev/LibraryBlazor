using LibraryBlazor.Entity.Entities;

namespace LibraryBlazor.Services
{
    public interface IIsueService : ICrud<Issue>
    {
        Task AddReaderToIssueAsync(int issueId, Reader reader);
        Task AddBookToIssueAsync(int issueId, Book book);

    }
}
