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
            if (borrower is null) throw new NullExceptions("borrower cannot be null");
            if (string.IsNullOrWhiteSpace(borrower.Name)) throw new NullExceptions("borrower cannot be null");
            if (borrower.Name is null) throw new NullExceptions(" borrower cannot be null");
            if (borrower.Email is null) throw new NullExceptions(" borrower cannot be null");
            //foreach (var a in borrower.Name)
            //{
            //    if (!char.IsDigit(a))
            //    {
            //        throw new InvalidException("incorrect format");

            //    }
            //}
            //foreach (var a in borrower.Email)
            //{
            //    if (!char.IsLetterOrDigit(a))
            //    {
            //        throw new InvalidException("incorrect format");

            //    }
            //}

            IBorrowerRepository borrowerRepository = new BorrowerRepository();
            borrowerRepository.Create(borrower);
        }

        public void DeleteBorrowed(int id)
        {
            if (id < 0) throw new NotFound("borrower not found");
            IBorrowerRepository borrowerRepository = new BorrowerRepository();
            var data = borrowerRepository.GetById(id);
            if (data is null) throw new NotFound("borrower not found");
            if (data.IsDeleted is true) throw new DeletedException("borrower has deleted");
            borrowerRepository.Delete(data);
            borrowerRepository.Commit();
        }

        public List<Borrower> GetAllBorrowers()
        {
            IBorrowerRepository borrowerRepository = new BorrowerRepository();
            var datas = borrowerRepository.GetAll();
            foreach (var data in datas)
            {
                Console.WriteLine($"Borrower Id - {data.Id};" +
                    $"borrower name - {data.Name}" +
                    $"borrower email - {data.Email};" +
                    //$"borrowe Created date - {data.CreatedDate}; " +
                    //$"borrower updated date - {data.UpdatedDate}; " +
                    $"borrower's loan name - {data.Loans}");
                
            }
            datas.Where(x => !x.IsDeleted).ToList();

            return datas;
        }

        public Borrower GetBorrowerById(int id)
        {
            if (id < 0) throw new NotFound("borrower not found");
            IBorrowerRepository borrowerRepository = new BorrowerRepository();
            var data = borrowerRepository.GetById(id);
            if (data.IsDeleted is true) throw new DeletedException("borrower has deleted");
           
            return data;
        }

        public void UpdateBorrower(int id, Borrower borrower)
        {
            if (id < 0) throw new NotFound("borrower not found");
            if (borrower is null) throw new NullExceptions("borrower cannot be null");
            if (string.IsNullOrWhiteSpace(borrower.Name)) throw new NullExceptions("borrower cannot be null");
            if (borrower.Name is null) throw new NullExceptions(" borrower cannot be null");
            if (borrower.Email is null) throw new NullExceptions(" borrower cannot be null");
            //foreach (var a in borrower.Name)
            //{
            //    if (!char.IsDigit(a))
            //    {
            //        throw new InvalidException("incorrect format");

            //    }
            //}
            //foreach (var a in borrower.Email)
            //{
            //    if (!char.IsLetterOrDigit(a))
            //    {
            //        throw new InvalidException("incorrect format");

            //    }
            //}


            IBorrowerRepository borrowerRepository = new BorrowerRepository();
            var existBorrower = borrowerRepository.GetById(id);
            if (existBorrower == null) throw new NullExceptions("borrower cannot be null");
            existBorrower.Name = borrower.Name;
            existBorrower.Email = borrower.Email;
            existBorrower.UpdatedDate = DateTime.UtcNow.AddHours(4);

            borrowerRepository.Commit();

        }
    }
}
