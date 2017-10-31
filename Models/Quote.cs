using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace quoteCodeAlong.Models
{
    public class Quote
    {
        public int id {get; set;}
        public string text {get; set;}
        public int metaId {get; set;}
        public Meta meta {get; set;}
        public int authorId {get; set;}
        public Author author {get; set;}
        public List<categoryJoin> categoryJoin {get; set;}
        
        public Quote()
        {
            categoryJoin = new List<categoryJoin>();
        }
    }
}