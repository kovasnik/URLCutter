using Microsoft.EntityFrameworkCore;
using URLCutter.Data.Interfaces;
using URLCutter.Models;

namespace URLCutter.Data.Repository
{
    public class ShortURLRepository : IShortURLRepository
    {
        private readonly ApplicationDbContext _context;
        public ShortURLRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ShortURL shortURL)
        {
            await _context.AddAsync(shortURL);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ShortURL shortURL)
        {
            _context.Remove(shortURL);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ShortURL>> GetAllAsync()
        {
            return await _context.ShortURLs.ToListAsync();
        }

        public async Task<ShortURL> GetByIdAsync(int urlId)
        {
            return await _context.ShortURLs.FindAsync(urlId);

        }

        public async Task UpdateAsync(ShortURL shortURL)
        {
            _context.Update(shortURL);
            await _context.SaveChangesAsync();
        }
    }
}
