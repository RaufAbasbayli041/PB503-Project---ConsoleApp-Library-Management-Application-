using PB503Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB503Project_1.Repository.Interface
{
    public interface ILoanRepository : IGenericRepository<Loan>
    {
        List<Loan> GetAllByInclude();
        Loan? GetByIdInclude(int id);
    }
}
