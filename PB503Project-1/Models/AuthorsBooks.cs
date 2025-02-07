using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB503Project_1.Models
{
    public class AuthorsBooks : BaseEntity
    {
        public int BooksId { get; set; }
        
        public int AuthorsId { get; set; }


        public Author Authors { get; set; }
    }
}
