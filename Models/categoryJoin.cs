using System.ComponentModel.DataAnnotations;

namespace quoteCodeAlong.Models
{
    public class categoryJoin
    {
        public int id {get; set;}
        public int categoryId {get; set;}
        public Category category {get; set;}
        public int quoteId {get; set;}
        public Quote quote {get; set;}
    }
}