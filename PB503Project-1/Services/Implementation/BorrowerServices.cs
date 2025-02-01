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
    public class BorrowerServices : IBorrowerServices
    {
        public void CreateBorrower(Borrower borrower)
        {
            if (borrower is null) throw new NullExceptions("borrower not found");
            if (string.IsNullOrWhiteSpace(borrower.Name)) throw new NullExceptions("borrower name cannot be null or empty");
            if (borrower.Name is null) throw new NullExceptions(" borrower  not found");
            if (borrower.Email is null) throw new NullExceptions(" borrower email not found");
            IBorrowerRepository borrowerRepository = new BorrowerRepository();
            borrowerRepository.Create(borrower);
        }

        public void DeleteBorrowed(int id)
        {
            if (id < 0) throw new InvalidException("borrower id cannot be less than 0");
            IBookRepository bookRepository = new BookRepository();
            bookRepository.Delete(id);
        }

        public List<Borrower> GetAllBorrowers()
        {
            IBorrowerRepository borrowerRepository = new BorrowerRepository();
            return borrowerRepository.GetAll();
        }

        public Borrower GetBorrowerById(int id)
        {
            if (id < 0) throw new InvalidException("borrower id cannot be less than 0");
            IBorrowerRepository borrowerRepository = new BorrowerRepository();
            return borrowerRepository.GetById(id);
        }

        public void UpdateBorrower(int id, Borrower borrower)
        {
            if (id < 0) throw new InvalidException("borrower id cannot be less than 0");
            if (borrower is null) throw new NullExceptions("borrower not found");
            if (string.IsNullOrWhiteSpace(borrower.Name)) throw new NullExceptions("borrower name cannot be null or empty");
            if (borrower.Name is null) throw new NullExceptions(" borrower  not found");
            if (borrower.Email is null) throw new NullExceptions(" borrower email not found");

            IBorrowerRepository borrowerRepository = new BorrowerRepository();
            var existBorrower = borrowerRepository.GetById(id);
            if (existBorrower == null) throw new NullExceptions("exist book cannot be null");
            existBorrower.Name = borrower.Name;
            existBorrower.Email = borrower.Email;
            existBorrower.UpdatedDate = DateTime.UtcNow.AddHours(4);
            borrowerRepository.Commit();

        }
    }
}
