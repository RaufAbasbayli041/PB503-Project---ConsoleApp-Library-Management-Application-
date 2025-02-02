using PB503Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB503Project_1.Repository.Interface
{
    public interface ILoanItemRepository : IGenericRepository<LoanItem>
    {
        List<LoanItem> GetAllByInclude();
        LoanItem? GetByIdInclude(int id);
    }
}
