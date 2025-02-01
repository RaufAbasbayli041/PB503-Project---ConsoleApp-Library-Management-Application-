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
    public class AuthorServices : IAuthorServices
    {
        public void CreateAuthor(Author author)
        {

            if (author is null) throw new NullExceptions("author not found");
            if (string.IsNullOrWhiteSpace(author.Name)) throw new NullExceptions("author name cannot be null or empty");

            IAuthorRepository authorRepository = new AuthorRepository();
            authorRepository.Create(author);
            
        }

        public void DeleteAuthor(int id)
        {
            if (id < 0) throw new InvalidException("punlished year cannot be less than 0");
            IAuthorRepository authorRepository = new AuthorRepository();
            authorRepository.Delete(id);
          
        }

        public List<Author> GetAllAuthors()
        {
            IAuthorRepository authorRepository = new AuthorRepository();
            return authorRepository.GetAll();

        }

        public Author GetAuthorById(int id)
        {
            if (id < 0) throw new InvalidException("punlished year cannot be less than 0");
            IAuthorRepository authorRepository = new AuthorRepository(); return authorRepository.GetById(id);
        }

        public void UpdateAuthor(int id, Author author)
        {
            if (id < 0) throw new InvalidException("punlished year cannot be less than 0");
            if (string.IsNullOrWhiteSpace(author.Name)) throw new NullExceptions("author name cannot be null or empty");


            IAuthorRepository authorRepository = new AuthorRepository();
            var existAuthor = authorRepository.GetById(id);
            if (existAuthor is null) throw new NullExceptions("exist book cannot be null");

            existAuthor.Name = author.Name;
            existAuthor.UpdatedDate = DateTime.UtcNow.AddHours(4);
      

        }
    }
}
