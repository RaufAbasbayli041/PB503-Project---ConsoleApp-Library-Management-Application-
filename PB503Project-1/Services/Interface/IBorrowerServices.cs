using PB503Project_1.Models;
using PB503Project_1.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB503Project_1.Services.Interface
{
    public interface IBorrowerServices
    {
        void CreateBorrower(Borrower borrower);
        void UpdateBorrower(int id, Borrower borrower);
        void DeleteBorrowed(int id);
        Borrower GetBorrowerById(int id);
        List<Borrower> GetAllBorrowers();
    }
}
