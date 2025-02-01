using PB503Project_1.Models;
using PB503Project_1.MyExceptions;
using PB503Project_1.Repository.Implementations;
using PB503Project_1.Repository.Interface;
using PB503Project_1.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB503Project_1.Services.Implementation
{
    public class LoanServices : IloanServices
    {
        public void CreateLoan(Loan loan)
        {
            if (loan is null) throw new NullExceptions("borrower not found");

            ILoanRepository loanRepository = new LoanRepository();
            loan.CreatedDate = DateTime.UtcNow.AddHours(4);
            loan.LoanDate = loan.CreatedDate;
            loanRepository.Create(loan);
            
        }

        public void DeleteLoan(int id)
        {
            if (id < 0) throw new InvalidException("loan id cannot be less than 0");
            ILoanRepository loanRepo = new LoanRepository();
              loanRepo.Delete(id);
            
        }

        public List<Loan> GetAllLoans()
        {
            ILoanRepository loanRepo = new LoanRepository();
            return loanRepo.GetAll();
        }

        public Loan GetBLoanById(int id)
        {
            if (id < 0) throw new InvalidException("loan id cannot be less than 0");
            ILoanRepository loanRepo = new LoanRepository();
            return loanRepo.GetById(id);
        }

        public void UpdateLoan(int id, Loan loan)
        {
            if (id < 0) throw new InvalidException("loan id cannot be less than 0");
            if (loan is null) throw new NullExceptions("borrower not found");
            ILoanRepository loanRepo = new LoanRepository();
            var exsistLoan = loanRepo.GetById(id);
            if (exsistLoan == null) throw new NullExceptions("exist loan cannot be null");
            exsistLoan.UpdatedDate = DateTime.UtcNow.AddHours(4);
            loanRepo.Commit();

        }
    }
}
