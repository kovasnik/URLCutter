using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using URLCutter.BLL.Interfaces;
using URLCutter.Data.Interfaces;
using URLCutter.DTO;
using URLCutter.Helper;
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

        public async Task<ServiceResult<ShortUrlDTO>> AddAsync(AddShortUrlDTO shortURL)
        {
            var existingUrl = _shortUrlRepository.GetByOriginalUrlAsync(shortURL.OriginalUrl);
            if (existingUrl == null)
            {
                return new ServiceResult<ShortUrlDTO>
                {
                    Success = false,
                    Message = "This URL already exists."
                };
            }
            var newUrl = _mapper.Map<ShortURL>(shortURL);
            await _shortUrlRepository.AddAsync(newUrl);

            return new ServiceResult<ShortUrlDTO>
            {
                Success = true,
                Data = _mapper.Map<ShortUrlDTO>(newUrl)
            };
        }

        public async Task<bool> DeleteAsync(int urlId)
        {
            var url = await _shortUrlRepository.GetByIdAsync(urlId);
            if (url == null)
            {
                return false;
            }

            await _shortUrlRepository.DeleteAsync(url);
            return true;
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
