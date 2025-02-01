using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB503Project_1.Models
{
    public class Borrower : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int BookId { get; set; }
        public List<Loan> Loans { get; set; }       
    }
}
