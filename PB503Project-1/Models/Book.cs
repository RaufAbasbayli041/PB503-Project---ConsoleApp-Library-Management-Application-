using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB503Project_1.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public int PublishedYear { get; set; }
        public List<Author> Authors { get; set; }


        public bool IsBorrow {  get; set; } // false



    }
}
