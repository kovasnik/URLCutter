using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using URLCutter.DTO;
using URLCutter.Helper;

namespace URLCutter.BLL.Interfaces
{
    public interface IShortUrlService
    {
        Task<ServiceResult<ShortUrlDTO>> AddAsync(AddShortUrlDTO shortURL);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ShortUrlDTO>> GetAllAsync();
        Task<ShortUrlDTO> GetByIdAsync(int urlId);
    }
}
