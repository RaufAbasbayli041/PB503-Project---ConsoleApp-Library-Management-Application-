using Microsoft.EntityFrameworkCore;
using PB503Project_1.DataBase;
using PB503Project_1.Models;
using PB503Project_1.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB503Project_1.Repository.Implementations
{
    public class BookRepository : GenericRepostory<Book>, IBookRepository
    {
        private readonly AppDbContext _appDbContext;

        public BookRepository()
        {
            _appDbContext = new AppDbContext();
        }

        public Book? GetByIdInclude(int id)
        {
            var data = _appDbContext.Books.Include(x => x.Authors).FirstOrDefault(x=> x.Id == id);  
            return data;
        }

        public List<Book> GetAllByInclude()
        {
           return _appDbContext.Books.Include(x=>x.Authors).ToList();
        }
    }
}
