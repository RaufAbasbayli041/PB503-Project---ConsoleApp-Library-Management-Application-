using PB503Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB503Project_1.Services.Interface
{
    public interface ILoanItemServices
    {
        void CreateLoanItem (LoanItem loanItem);
        void UpdateLoanItem(int id, LoanItem loanItem);
        void DeleteLoanItem(int id);
        LoanItem GetLoanItemById(int id);
        List<LoanItem> GetAllLoanItems();
    }
}
