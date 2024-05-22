using LibraryBlazor.Entity.DbContexts;
using LibraryBlazor.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryBlazor.Services
{
    public class BookService : IBookService
    {
        private readonly ILibraryDbContext _libraryDbContext;

        public BookService(ILibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public async Task AddAsync(Book entity)
        {
            if (entity is null)
            {
                return;
            }

            _libraryDbContext.Books.Add(entity);
            await _libraryDbContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _libraryDbContext.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (book is null)
            {
                return;
            }

            _libraryDbContext.Books.Remove(book);
            await _libraryDbContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<List<Book>> GetAllAsync() => await _libraryDbContext.Books.ToListAsync();

        public async Task<Book?> GetAsync(int id) => await _libraryDbContext.Books.FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(int id, Book entity)
        {
            var book = await _libraryDbContext.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (book is null)
            {
                return;
            }

            book.Title = entity.Title;
            book.publication_year = entity.publication_year;
            book.CountPage = entity.CountPage;
            book.available = entity.available;
            book.Authors = entity.Authors;
            book.Genres = entity.Genres;

            await _libraryDbContext.SaveChangesAsync(CancellationToken.None);
        }
    }
}
