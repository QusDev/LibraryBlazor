using LibraryBlazor.Entity.Entities;

namespace LibraryBlazor.Services
{
    public interface IBookService : ICrud<Book>
    {
        List<Author> GetAuthors(int bookId);
        List<Genre> GetGenres(int bookId);

        Task<List<Author>> GetAuthorsAsync(int bookId);
        Task<List<Genre>> GetGenresAsync(int bookId);

        Task AddGenresToBookAsync(int bookId, List<int> genresId);
        Task AddAuthorsToBookAsync(int bookId, List<int> authrosId);

        Task UpdateGenresAsync(int bookId, List<int> genresId);
        Task UpdateAuthorsAsync(int bookId, List<int> authorsId);
    }
}
