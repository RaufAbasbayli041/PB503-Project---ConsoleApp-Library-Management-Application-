using PB503Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB503Project_1.Services.Interface
{
    public interface IBookServices
    {
        void CreateBook(Book book);
        void UpdateBook(int id, Book book);
        void DeleteBook(int id);
        Book GetBookById(int id);
        List<Book> GetAllBooks();
    }
}
