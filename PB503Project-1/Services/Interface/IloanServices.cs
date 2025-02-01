using PB503Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB503Project_1.Services.Interface
{
    public interface IloanServices 
    {
        void CreateLoan(Loan loan);
        void UpdateLoan(int id, Loan loan);
        void DeleteLoan(int id);
        Loan GetBLoanById(int id);
        List<Loan> GetAllLoans();
    }
}

