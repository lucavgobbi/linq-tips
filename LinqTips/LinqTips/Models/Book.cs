using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTips.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public virtual Author Author { get; set; }
        public virtual City PublishedIn {get;set;}
    }
}
