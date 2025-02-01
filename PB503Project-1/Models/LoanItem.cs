using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB503Project_1.Models
{
    public class LoanItem : BaseEntity
    {
        public int LoanId { get; set; }
        public Loan Loan { get; set; }

    }
}
