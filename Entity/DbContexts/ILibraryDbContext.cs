using LibraryBlazor.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryBlazor.Entity.DbContexts
{
    public interface ILibraryDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Reader> Readers { get; set; }
        DbSet<Issue> Issues { get; set; }
        DbSet<BookGenre> BookGenres { get; set; }
        DbSet<BookAuthor> BookAuthors { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
