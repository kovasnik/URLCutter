

namespace URLCutter.DTO
{
    public class AddShortUrlDTO
    {
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
