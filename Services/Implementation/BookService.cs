using LibraryBlazor.Entity.DbContexts;
using LibraryBlazor.Entity.Entities;
using LibraryBlazor.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryBlazor.Services.Implementation
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

        public async Task<List<Book>> GetAllAsync() => await _libraryDbContext.Books.Include(b => b.Genres).Include(b => b.Authors).ToListAsync();

        public async Task<Book?> GetAsync(int id) => await _libraryDbContext.Books.Include(b => b.Genres).Include(b => b.Authors).FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(int id, Book entity)
        {
            var book = await _libraryDbContext.Books.Include(b => b.Genres).Include(b => b.Authors).FirstOrDefaultAsync(x => x.Id == id);

            if (book is null)
            {
                return;
            }

            book.Title = entity.Title;
            book.Publication_year = entity.Publication_year;
            book.CountPage = entity.CountPage;
            book.Available = entity.Available;
            book.Genres = entity.Genres;
            book.Authors = entity.Authors;

            await _libraryDbContext.SaveChangesAsync(CancellationToken.None);
        }


    }
}
