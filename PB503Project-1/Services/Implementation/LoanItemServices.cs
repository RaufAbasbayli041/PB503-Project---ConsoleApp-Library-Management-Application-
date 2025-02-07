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
    public class LoanItemServices : ILoanItemServices
    {
        public void CreateLoanItem(LoanItem loanItem)
        {
            if (loanItem is null) throw new NullExceptions("loan item cannot be null");
            ILoanItemRepository loanItemRepository = new LoanItemRepository();

            
            loanItemRepository.Create(loanItem);

            loanItemRepository.Commit();
           
        }

        public void DeleteLoanItem(int id)
        {
            if (id < 0) throw new NotFound("loan item not found");
            ILoanItemRepository loanItemRepository = new LoanItemRepository();
            var data = loanItemRepository.GetById(id);
            if (data is null) throw new NotFound("loan item not found");
            if (data.IsDeleted is true) throw new DeletedException("loan item has deleted");
            loanItemRepository.Delete(data);
            loanItemRepository.Commit();
        }

        public List<LoanItem> GetAllLoanItems()
        {
            ILoanItemRepository loanItemRepository = new LoanItemRepository();


            var datas = loanItemRepository.GetAll();
            foreach (var data in datas)
            {
                Console.WriteLine($"loan item Id - {data.Id};" +                    
                    //$"borrowe Created date - {data.CreatedDate}; " +
                    //$"borrower updated date - {data.UpdatedDate}; " +
                    $"loan item's book id - {data.BookId}" +
                    $"loan item's book title - {data.Book.Title}");

            }
            datas.Where(x => !x.IsDeleted).ToList();
            return loanItemRepository.GetAll();
        }

        public LoanItem GetLoanItemById(int id)
        {
            if (id < 0) throw new NotFound("loan item not found");
            ILoanItemRepository loanItemRepository = new LoanItemRepository();

           return loanItemRepository.GetById(id);
        }

        public void UpdateLoanItem(int id, LoanItem loanItem)
        {
           // if (id < 0) throw new InvalidException("loan item id cannot be less than 0");
           // if (loanItem is null) throw new NullExceptions("loan item not found");
           // ILoanItemRepository loanItemRepository = new LoanItemRepository();
           //var existLoanItem = loanItemRepository.GetById(id);
           // existLoanItem.
        }
    }
}
