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
    internal class LoanItemRepository : GenericRepostory<LoanItem>, ILoanItemRepository
    {
        private readonly AppDbContext _appDbContext;

        public LoanItemRepository()
        {
            _appDbContext = new AppDbContext();
        }
        public List<LoanItem> GetAllByInclude()
        {
            return _appDbContext.LoanItems.Where(x=>!x.IsDeleted)
                                          .Include(x=>x.Book)
                                          .Include(x=>x.Loan)
                                          .ThenInclude(x=>x.Borrowers)
                                          .ToList();
        }

        public LoanItem? GetByIdInclude(int id)
        {
           return _appDbContext.LoanItems.Where(x => !x.IsDeleted)
                                          .Include(x => x.Book)
                                          .Include(x => x.Loan)
                                          .ThenInclude(x => x.Borrowers)
                                          .FirstOrDefault(x=>x.Id == id);
          
        }

    }
}
