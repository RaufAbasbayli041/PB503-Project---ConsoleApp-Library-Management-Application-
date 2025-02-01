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
    public class BookServices : IBookServices
    {
        public void CreateBook(Book book)
        {
            if (book is null) throw new NullExceptions("book not found");
            if (string.IsNullOrWhiteSpace(book.Title)) throw new NullExceptions(nameof(book.Title));
            if (string.IsNullOrWhiteSpace(book.Desc)) throw new NullExceptions(nameof(book.Desc));
            if (book.PublishedYear < 0) throw new InvalidException("punlished year cannot be less than 0");
           

            IBookRepository bookRepository = new BookRepository();
            bookRepository.Create(book);
          
        }

        public void DeleteBook(int id)
        {
            if (id < 0) throw new InvalidException("book id cannot be less than 0");
            IBookRepository bookRepository = new BookRepository();
            bookRepository.Delete(id);
        }

        public List<Book> GetAllBooks()
        {
            IBookRepository bookRepository= new BookRepository();
            return bookRepository.GetAll();
        }

        public Book GetBookById(int id)
        {
            if (id < 0) throw new InvalidException("book id cannot be less than 0");
            IBookRepository bookRepository = new BookRepository();
            return bookRepository.GetById(id);
        }

        public void UpdateBook(int id, Book book)
        {
            if (id < 0) throw new InvalidException("book id cannot be less than 0");
            if (string.IsNullOrWhiteSpace(book.Title)) throw new NullExceptions(nameof(book.Title));
            if (string.IsNullOrWhiteSpace(book.Desc)) throw new NullExceptions(nameof(book.Desc));
            if (book.PublishedYear < 0) throw new InvalidException("punlished year cannot be less than 0");
            

            IBookRepository bookRepository = new BookRepository();
            var existBook = bookRepository.GetById(id);
            if (existBook == null) throw new NullExceptions("exist book cannot be null");
            existBook.Title = book.Title;
            existBook.Authors = book.Authors;            
            existBook.Desc = book.Desc;
            existBook.UpdatedDate = DateTime.UtcNow.AddHours(4);

            bookRepository.Commit();
        }
    }
}
