namespace LibraryBlazor.Services.Interfaces
{
    public interface ICrud<T>
    {
        Task<T?> GetAsync(int id);
        Task<List<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, T entity);
    }
}
