using System.ComponentModel.DataAnnotations;

namespace quoteCodeAlong.Models
{
    public class AuthorViewModel : BaseEntity
    {
        [Required]
        [MinLength(6)]
        public string name {get; set;}
    }
}