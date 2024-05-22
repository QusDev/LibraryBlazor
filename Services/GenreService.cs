using LibraryBlazor.Entity.DbContexts;
using LibraryBlazor.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryBlazor.Services
{
    public class GenreService : IGenreService
    {
        private readonly ILibraryDbContext _libraryDbContext;

        public GenreService(ILibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public async Task AddAsync(Genre entity)
        {
            if (entity is null)
            {
                return;
            }

            if (await _libraryDbContext.Genres.AnyAsync(x => x.Name == entity.Name))
            {
                return;
            }

            _libraryDbContext.Genres.Add(entity);
            await _libraryDbContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task DeleteAsync(int id)
        {
            var genre = await _libraryDbContext.Genres.FirstOrDefaultAsync(x => x.Id == id);

            if (genre is null)
            {
                return;
            }

            _libraryDbContext.Genres.Remove(genre);
            await _libraryDbContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<List<Genre>> GetAllAsync() => await _libraryDbContext.Genres.ToListAsync();

        public async Task<Genre?> GetAsync(int id) => await _libraryDbContext.Genres.FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(int id, Genre entity)
        {
            var genre = await _libraryDbContext.Genres.FirstOrDefaultAsync(x => x.Id == id);
            
            if (genre is null)
            {
                return;
            }

            genre.Name = entity.Name;

            await _libraryDbContext.SaveChangesAsync(CancellationToken.None);
        }
    }
}
