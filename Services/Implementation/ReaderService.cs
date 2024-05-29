using LibraryBlazor.Entity.DbContexts;
using LibraryBlazor.Entity.Entities;
using LibraryBlazor.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryBlazor.Services.Implementation
{
    public class ReaderService : IReaderService
    {
        private readonly ILibraryDbContext _libraryDbContext;

        public ReaderService(ILibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public async Task AddAsync(Reader entity)
        {
            if (entity is null)
            {
                return;
            }

            _libraryDbContext.Readers.Add(entity);
            await _libraryDbContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task DeleteAsync(int id)
        {
            var reader = await _libraryDbContext.Readers.FirstOrDefaultAsync(x => x.Id == id);

            if (reader is null)
            {
                return;
            }

            _libraryDbContext.Readers.Remove(reader);
            await _libraryDbContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<List<Reader>> GetAllAsync() => await _libraryDbContext.Readers.ToListAsync();

        public async Task<Reader?> GetAsync(int id) => await _libraryDbContext.Readers.FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(int id, Reader entity)
        {
            var reader = await _libraryDbContext.Readers.FirstOrDefaultAsync(x => x.Id == id);

            if (reader is null)
            {
                return;
            }

            reader.FirstName = entity.FirstName;
            reader.LastName = entity.LastName;
            reader.Email = entity.Email;
            reader.PhoneNumber = entity.PhoneNumber;

            await _libraryDbContext.SaveChangesAsync(CancellationToken.None);
        }
    }
}
