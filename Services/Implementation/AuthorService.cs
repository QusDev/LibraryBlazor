using LibraryBlazor.Entity.DbContexts;
using LibraryBlazor.Entity.Entities;
using LibraryBlazor.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryBlazor.Services.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly ILibraryDbContext _libraryDbContext;

        public AuthorService(ILibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public async Task AddAsync(Author entity)
        {
            if (entity is null)
            {
                return;
            }

            _libraryDbContext.Authors.Add(entity);
            await _libraryDbContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task DeleteAsync(int id)
        {
            var author = await _libraryDbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);

            if (author is null)
            {
                return;
            }

            _libraryDbContext.Authors.Remove(author);
            await _libraryDbContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<List<Author>> GetAllAsync() => await _libraryDbContext.Authors.ToListAsync();

        public async Task<Author?> GetAsync(int id) => await _libraryDbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(int id, Author entity)
        {
            var author = await _libraryDbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);

            if (author is null)
            {
                return;
            }

            author.FirstName = entity.FirstName;
            author.LastName = entity.LastName;

            await _libraryDbContext.SaveChangesAsync(CancellationToken.None);
        }
    }
}
