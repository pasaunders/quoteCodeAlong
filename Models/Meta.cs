using System.ComponentModel.DataAnnotations;

namespace quoteCodeAlong.Models
{
    public class Meta : BaseEntity
    {
        [Required]
        public int id {get; set;}
        [Required]
        public string note {get; set;}
    }
}