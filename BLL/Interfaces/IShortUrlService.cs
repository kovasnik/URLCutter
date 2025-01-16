using System.Threading.Tasks;
using URLCutter.DTO;
using URLCutter.Models;

namespace URLCutter.BLL.Interfaces
{
    public interface IShortUrlService
    {
        Task AddAsync(AddShortUrlDTO shortURL);
        Task DeleteAsync(ShortUrlDTO shortURL);
        Task<IEnumerable<ShortUrlDTO>> GetAllAsync();
        Task<ShortUrlDTO> GetByIdAsync(int urlId);
    }
}
