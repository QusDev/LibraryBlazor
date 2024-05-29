using LibraryBlazor.Entity.DbContexts;
using LibraryBlazor.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public async Task AddAuthorsToBookAsync(int bookId, List<int> authrosId)
        {
            if (!await _libraryDbContext.Books.AnyAsync(x => x.Id == bookId))
            {
                return;
            }

            foreach (var authorId in authrosId)
            {
                if (!await _libraryDbContext.Authors.AnyAsync(x => x.Id == authorId))
                {
                    continue;
                }

                _libraryDbContext.BookAuthors.Add(new BookAuthor() { BookId = bookId, AuthorId = authorId });
            }

            await _libraryDbContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task AddGenresToBookAsync(int bookId, List<int> genresId)
        {
            if (!await _libraryDbContext.Books.AnyAsync(x => x.Id == bookId))
            {
                return;
            }

            foreach (var genreId in genresId)
            {
                if (!await _libraryDbContext.Genres.AnyAsync(x => x.Id == genreId))
                {
                    continue;
                }

                _libraryDbContext.BookGenres.Add(new BookGenre() { BookId = bookId, GenreId = genreId });
            }

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

        public List<Author> GetAuthors(int bookId)
        {
            var bookAuthors = _libraryDbContext.BookAuthors.Where(x => x.BookId == bookId).Select(ba => ba.AuthorId).ToList();

            if (bookAuthors.Count == 0)
            {
                return new List<Author>();
            }

            return _libraryDbContext.Authors.Where(a => bookAuthors.Contains(a.Id)).ToList();
        }

        public async Task<List<Author>> GetAuthorsAsync(int bookId)
        {
            var bookAuthors = await _libraryDbContext.BookAuthors.Where(x => x.BookId == bookId).Select(ba => ba.AuthorId).ToListAsync();

            if (bookAuthors.Count == 0)
            {
                return new List<Author>();
            }

            return await _libraryDbContext.Authors.Where(a => bookAuthors.Contains(a.Id)).ToListAsync();
        }

        public List<Genre> GetGenres(int bookId)
        {
            var bookGenres = _libraryDbContext.BookGenres.Where(x => x.BookId == bookId).Select(bg => bg.GenreId).ToList();

            if (bookGenres.Count == 0)
            {
                return new List<Genre>();
            }

            return _libraryDbContext.Genres.Where(g => bookGenres.Contains(g.Id)).ToList();
        }

        public async Task<List<Genre>> GetGenresAsync(int bookId)
        {
            var bookGenres = await _libraryDbContext.BookGenres.Where(x => x.BookId == bookId).Select(bg => bg.GenreId).ToListAsync();

            if (bookGenres.Count == 0)
            {
                return new List<Genre>();
            }

            return await _libraryDbContext.Genres.Where(g => bookGenres.Contains(g.Id)).ToListAsync();
        }

        public async Task UpdateAsync(int id, Book entity)
        {
            var book = await _libraryDbContext.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (book is null)
            {
                return;
            }

            book.Title = entity.Title;
            book.Publication_year = entity.Publication_year;
            book.CountPage = entity.CountPage;
            book.Available = entity.Available;

            await _libraryDbContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task UpdateAuthorsAsync(int bookId, List<int> authorsId)
        {
            if (!await _libraryDbContext.Books.AnyAsync(x => x.Id == bookId))
            {
                return;
            }

            var bookAuthors = await _libraryDbContext.BookAuthors.Where(x => x.BookId == bookId).ToListAsync();

            foreach (var authorId in authorsId)
            {
                if (!bookAuthors.Any(x => x.AuthorId == authorId))
                {
                    _libraryDbContext.BookAuthors.Add(new BookAuthor() { BookId = bookId, AuthorId = authorId });
                }
            }

            foreach (var bookAuthor in bookAuthors)
            {
                if (!authorsId.Contains(bookAuthor.AuthorId))
                {
                    _libraryDbContext.BookAuthors.Remove(bookAuthor);
                }
            }

            await _libraryDbContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task UpdateGenresAsync(int bookId, List<int> genresId)
        {
            if (!await _libraryDbContext.Books.AnyAsync(x => x.Id == bookId))
            {
                return;
            }

            var bookGenres = await _libraryDbContext.BookGenres.Where(x => x.BookId == bookId).ToListAsync();

            foreach (var genreId in genresId)
            {
                if (!bookGenres.Any(x => x.GenreId == genreId))
                {
                    _libraryDbContext.BookGenres.Add(new BookGenre() { BookId = bookId, GenreId = genreId });
                }
            }

            foreach (var bookGenre in bookGenres)
            {
                if (!genresId.Contains(bookGenre.GenreId))
                {
                    _libraryDbContext.BookGenres.Remove(bookGenre);
                }
            }

            await _libraryDbContext.SaveChangesAsync(CancellationToken.None);
        }
    }
}
