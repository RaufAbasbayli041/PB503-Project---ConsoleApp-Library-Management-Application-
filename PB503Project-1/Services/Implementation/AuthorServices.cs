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

            if (author is null) throw new NullExceptions("author cannot be null");
            if (string.IsNullOrWhiteSpace(author.Name)) throw new NullExceptions("author name cannot be null");
           


            IAuthorRepository authorRepository = new AuthorRepository();
           

            authorRepository.Create(author);

        }

        public void DeleteAuthor(int id)
        {
            if (id < 0) throw new NotFound("author not found");
            IAuthorRepository authorRepository = new AuthorRepository();
            var data = authorRepository.GetById(id);
            if (data is null) throw new NotFound("author not found");
            authorRepository.Delete(data);
            authorRepository.Commit();

            if (data.IsDeleted is true) throw new DeletedException("author has deleted");

        }

        public List<Author> GetAllAuthors()
        {
            IAuthorRepository authorRepository = new AuthorRepository();
            var datas = authorRepository.GetAll();
            foreach (var data in datas)
            {
                Console.WriteLine($"Author Id - {data.Id}; " +
                    $"Author name - {data.Name};" +
                    $"author books - {data.Books}"); 
                    //$"author Created date - {data.CreatedDate};" +
                    //$"author updated date - {data.UpdatedDate};") 
                    //;
            }
            return datas;
        }

        public Author GetAuthorById(int id)
        {
            if (id < 0) throw new NotFound("author not found");
            IAuthorRepository authorRepository = new AuthorRepository();
            return authorRepository.GetById(id);
        }

        public void UpdateAuthor(int id, Author author)
        {
            if (id < 0) throw new NotFound("author not found");
            if (string.IsNullOrWhiteSpace(author.Name)) throw new NullExceptions("author name cannot be null");
            if (author is null) throw new NullExceptions("author cannot be null");
            foreach (var a in author.Name)
            {
                if (!char.IsDigit(a))
                {
                    throw new InvalidException("incorrect format");

                }
            }


            IAuthorRepository authorRepository = new AuthorRepository();
            var existAuthor = authorRepository.GetById(id);
            if (existAuthor is null) throw new NullExceptions("author cannot be null");

            existAuthor.Name = author.Name;
            existAuthor.UpdatedDate = DateTime.UtcNow.AddHours(4);
            authorRepository.Commit();
        }

        public List<Author> FilterBookByAuthors(string authorName)
        {
            IAuthorRepository authorRepository = new AuthorRepository();
            if (string.IsNullOrWhiteSpace(authorName)) throw new NullExceptions("author name cannot be null");
            if (authorName is null) throw new NullExceptions("author cannot be null");
            List<Author> authorList = new List<Author>();
            foreach (var item in authorRepository.GetAll())
            {
                if (item.Name.Trim().ToLower().Contains(authorName.Trim().ToLower()))
                {
                    authorList.Add(item);
                }
            }
            return authorList;
        }
    }
}
