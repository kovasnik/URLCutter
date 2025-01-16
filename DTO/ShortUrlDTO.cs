using Microsoft.AspNetCore.Mvc;

namespace URLCutter.DTO
{
    public class ShortUrlDTO : Controller
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
