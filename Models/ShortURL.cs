using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace URLCutter.Models
{
    public class ShortURL
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("original_url")]
        public string OriginalUrl { get; set; }
        [Column("shortened_url")]
        public string ShortenedUrl { get; set; }
        [ForeignKey(nameof(User))]
        [Column("created_by")]
        public string CreatedBy { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }
        public virtual User User { get; set; }
    }
}
