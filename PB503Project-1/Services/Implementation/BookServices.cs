using Microsoft.EntityFrameworkCore;
using PB503Project_1.DataBase;
using PB503Project_1.Models;
using PB503Project_1.MyExceptions;
using PB503Project_1.Repository.Implementations;
using PB503Project_1.Repository.Interface;
using PB503Project_1.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PB503Project_1.Services.Implementation
{
    public class BookServices : IBookServices
    {
        public void CreateBook(Book book)
        {

            if (book is null) throw new NullExceptions("book cannot be null");

            if (string.IsNullOrWhiteSpace(book.Title)) throw new NullExceptions("book cannot be null");
            if (string.IsNullOrWhiteSpace(book.Desc)) throw new NullExceptions("book cannot be null");
            if (book.PublishedYear < 0) throw new NotFound("punlished year cannot be less than 0");

            IBookRepository bookRepository = new BookRepository();
            // author table-a author id add kodu 
            //var authors = bookRepository._appDbContext.Authors
            //    .Where(x=>book.Authors.));
            bookRepository.Create(book);

        }

        public void DeleteBook(int id)
        {
            if (id < 0) throw new NotFound("book not found");
            IBookRepository bookRepository = new BookRepository();
            var data = bookRepository.GetById(id);
            if (data is null) throw new NullExceptions("enter id");
            if (data.IsDeleted is true) throw new DeletedException("book has deleted");
            bookRepository.Delete(data);
            bookRepository.Commit();
        }

        public List<Book> GetAllBooks()
        {
            IBookRepository bookRepository = new BookRepository();
            var datas = bookRepository.GetAll();
            foreach (var data in datas)
            {
                Console.WriteLine($"Book Id - {data.Id};" +
                    $"Book title - {data.Title};" +
                    $"book descriotion - {data.Desc};" +
                    //$"book Created date - {data.CreatedDate}; " +
                    //$"book updated date - {data.UpdatedDate}; " +
                    $"published year - {data.PublishedYear};");

            }
            datas.Where(x => !x.IsDeleted).ToList();
            return datas;

        }

        public Book GetBookById(int id)
        {
            if (id < 0) throw new NotFound("book not found");
            IBookRepository bookRepository = new BookRepository();

            return bookRepository.GetById(id);
        }

        public void UpdateBook(int id, Book book)
        {
            if (id < 0) throw new NotFound("book not found");
            if (book is null) throw new NullExceptions("book cannot be null");
            if (string.IsNullOrWhiteSpace(book.Title)) throw new NullExceptions("book cannot be null");
            if (string.IsNullOrWhiteSpace(book.Desc)) throw new NullExceptions("book cannot be null");
            if (book.PublishedYear < 0) throw new NotFound("punlished year cannot be less than 0");
            foreach (var a in book.Desc)
            {
                if (!char.IsLetterOrDigit(a))
                {
                    throw new InvalidException("incorrect format");

                }
            }
            foreach (var a in book.Title)
            {
                if (!char.IsLetterOrDigit(a))
                {
                    throw new InvalidException("incorrect format");

                }
            }

            IBookRepository bookRepository = new BookRepository();
            var existBook = bookRepository.GetById(id);
            if (existBook is null) throw new NullExceptions("book cannot be null");
            existBook.Title = book.Title;
            existBook.Desc = book.Desc;
            existBook.PublishedYear = book.PublishedYear;
            existBook.UpdatedDate = DateTime.UtcNow.AddHours(4);

            bookRepository.Commit();
        }

        public List<Book> FilterBooksByTitle(string title)
        {
            IBookRepository bookRepository = new BookRepository();
            if (string.IsNullOrWhiteSpace(title)) throw new NullExceptions("title cannot be null");
            if (title is null) throw new NullExceptions("book cannot be null");

            List<Book> wantedBooks = new List<Book>();
            foreach (Book book in bookRepository.GetAll())
            {
                if (book.Title.Trim().ToLower().Contains(title.Trim().ToLower()))
                {
                    wantedBooks.Add(book);
                }
            }

            return wantedBooks;

        }




    }
}
