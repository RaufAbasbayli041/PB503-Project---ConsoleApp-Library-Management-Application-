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
            if (loan is null) throw new NullExceptions("loan cannot be null");
            ILoanRepository loanRepository = new LoanRepository();
            loan.CreatedDate = DateTime.UtcNow.AddHours(4);
            loan.LoanDate = loan.CreatedDate;
            loanRepository.Create(loan);
        }

        public void DeleteLoan(int id)
        {
            if (id < 0) throw new NotFound("loan not found");
            ILoanRepository loanRepo = new LoanRepository();
            var data = loanRepo.GetById(id);
            if (data is null) throw new NullExceptions("loan cannot be null");
            loanRepo.Delete(data);
            loanRepo.Commit();
            if (data.IsDeleted is true) throw new DeletedException("loan has deleted");
        }

        public List<Loan> GetAllLoans()
        {
            ILoanRepository loanRepo = new LoanRepository();
            var datas = loanRepo.GetAll();
            foreach (var data in datas)
            {
                Console.WriteLine($"loan Id - {data.Id};" +
                    $"loan Created date - {data.CreatedDate}; " +
                    $"loan updated date - {data.UpdatedDate}; " +
                    $"loan's borrower - {data.Borrowers.Id}");
            }
            return datas;
        }

        public Loan GetBLoanById(int id)
        {
            if (id < 0) throw new NotFound("loan not found");
            ILoanRepository loanRepo = new LoanRepository();
            return loanRepo.GetById(id);
        }

        public void UpdateLoan(int id, Loan loan)
        {
            if (id < 0) throw new NotFound("loan not found");
            if (loan is null) throw new NullExceptions("loan cannot be null");
            ILoanRepository loanRepo = new LoanRepository();
            var exsistLoan = loanRepo.GetById(id);
            if (exsistLoan == null) throw new NullExceptions("loan cannot be null");
            exsistLoan.UpdatedDate = DateTime.UtcNow.AddHours(4);
            loanRepo.Commit();

        }
    }
}
