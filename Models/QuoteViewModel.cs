using System.ComponentModel.DataAnnotations;

namespace quoteCodeAlong.Models
{
    public class QuoteViewModel : BaseEntity
    {
        [Required]
        [MinLength(10)]
        public string text {get; set;}
        [Required]
        public int categoryId {get; set;}
        [Required]
        public int authorId {get; set;}
        [Required]
        public string meta {get; set;}
    }
}