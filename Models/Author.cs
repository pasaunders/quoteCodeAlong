using System.Collections.Generic;

namespace quoteCodeAlong.Models
{
    public class Author : BaseEntity
    {
        public int id {get;set;}
        public string name {get;set;}
        public List<Quote> quotes {get; set;}

        public Author()
        {
            quotes = new List<Quote>();
        }
    }
}