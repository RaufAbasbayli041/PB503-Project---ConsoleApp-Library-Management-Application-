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
    public class AuthorRepository : GenericRepostory<Author>, IAuthorRepository
    {
        private readonly AppDbContext _appDbContext;

        public AuthorRepository()
        {
            _appDbContext = new AppDbContext();
        }
        public List<Author> GetAllByInclude()
        {
            return _appDbContext.Authors.Where(x => !x.IsDeleted)
                                        .Include(x=>x.Books)
                                        .ToList();
        }

        public Author? GetByIdInclude(int id)
        {
            return _appDbContext.Authors.Where(x => !x.IsDeleted)
                                        .Include(x => x.Books)
                                        .FirstOrDefault(x => x.Id == id);
            
        }
    }
}
