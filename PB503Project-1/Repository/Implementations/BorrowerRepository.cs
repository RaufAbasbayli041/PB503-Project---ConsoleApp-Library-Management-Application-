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
    public class BorrowerRepository : GenericRepostory<Borrower>, IBorrowerRepository
    {
        private readonly AppDbContext _appDbContext;

        public BorrowerRepository()
        {
            _appDbContext = new AppDbContext();
        }
        public List<Borrower> GetAllByInclude()
        {
            return _appDbContext.Borrowers.Include(x=>x.Loans).ToList();
        }

        public Borrower? GetByIdInclude(int id)
        {
            var data = _appDbContext.Borrowers.Include(x=>x.Loans).FirstOrDefault(x=>x.Id == id);
            return data;
        }
    }
}
