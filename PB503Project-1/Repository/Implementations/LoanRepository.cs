using Microsoft.EntityFrameworkCore;
using PB503Project_1.DataBase;
using PB503Project_1.Models;
using PB503Project_1.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB503Project_1.Repository.Implementations
{
    public class LoanRepository : GenericRepostory<Loan>, ILoanRepository
    {
        private readonly AppDbContext _appDbContext;

        public LoanRepository()
        {
                _appDbContext = new AppDbContext();
        }
        public List<Loan> GetAllByInclude()
        {
            return _appDbContext.Loans.Include(x => x.Borrowers).Include(x => x.LoanItems).ToList();
        }

        public Loan? GetByIdInclude(int id)
        {
            var data = _appDbContext.Loans.Include(x => x.Borrowers).Include(x => x.LoanItems).FirstOrDefault(x=>x.Id == id);
            return data;
        }
    }
}
