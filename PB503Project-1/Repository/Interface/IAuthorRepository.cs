using PB503Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB503Project_1.Repository.Interface
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        List<Author> GetAllByInclude();
        Author? GetByIdInclude(int id);
    }
}
