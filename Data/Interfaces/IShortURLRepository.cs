using URLCutter.Models;

namespace URLCutter.Data.Interfaces
{
    public interface IShortURLRepository
    {
        Task AddAsync(ShortURL shortURL);
        Task UpdateAsync(ShortURL shortURL);
        Task DeleteAsync(ShortURL shortURL);
        Task<IEnumerable<ShortURL>> GetAllAsync();
        Task<ShortURL> GetByIdAsync(int id);
        Task<ShortURL> GetByOriginalUrlAsync(string originalUrl);
    }
}
