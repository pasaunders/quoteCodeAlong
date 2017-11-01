using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace quoteCodeAlong.Models
{
    public class Category
    {
        public int id {get; set;}
        public string category {get; set;}
        public List<categoryJoin> categoryJoin {get; set;}

        public Category()
        {
            categoryJoin = new List<categoryJoin>();
        }
    }
}