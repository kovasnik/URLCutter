using AutoMapper;
using URLCutter.BLL.Interfaces;
using URLCutter.Data.Interfaces;
using URLCutter.DTO;
using URLCutter.Models;

namespace URLCutter.BLL.Services
{
    public class ShortUrlService : IShortUrlService
    {
        private readonly IShortURLRepository _shortUrlRepository;
        private readonly IMapper _mapper;
        public ShortUrlService(IShortURLRepository shortUrlRepository, IMapper mapper)
        {
            _shortUrlRepository = shortUrlRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(AddShortUrlDTO shortURL)
        {
            var newUrl = _mapper.Map<ShortURL>(shortURL);
            await _shortUrlRepository.AddAsync(newUrl);
        }

        public async Task DeleteAsync(ShortUrlDTO shortURL)
        {
            var url = _mapper.Map<ShortURL>(shortURL);
            await _shortUrlRepository.DeleteAsync(url);
        }

        public async Task<IEnumerable<ShortUrlDTO>> GetAllAsync()
        {
            var urls = await _shortUrlRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ShortUrlDTO>>(urls);
        }

        public async Task<ShortUrlDTO> GetByIdAsync(int urlId)
        {
            var url = await _shortUrlRepository.GetByIdAsync(urlId);
            return _mapper.Map<ShortUrlDTO>(url);

        }
    }
}
