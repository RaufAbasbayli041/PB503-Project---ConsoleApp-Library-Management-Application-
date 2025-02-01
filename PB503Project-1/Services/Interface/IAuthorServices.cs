using PB503Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB503Project_1.Services.Interface
{
    public interface IAuthorServices
    {
        void CreateAuthor(Author author);
        void UpdateAuthor(int id, Author author);
        void DeleteAuthor(int id);
        Author GetAuthorById(int id);
        List<Author> GetAllAuthors();
    }
}
