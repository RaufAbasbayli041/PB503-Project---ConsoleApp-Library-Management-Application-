using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using PB503Project_1.Models;
using PB503Project_1.MyExceptions;
using PB503Project_1.Repository.Implementations;
using PB503Project_1.Repository.Interface;
using PB503Project_1.Services.Implementation;
using PB503Project_1.Services.Interface;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace PB503Project_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool Menu = true;
            do
            {
                Console.WriteLine(
          @"1 - Author actions.
            2 - Book Actions.");
                Console.WriteLine();
                string inputMenu = Console.ReadLine();

                switch (inputMenu)
                {
                    case "0":
                        Menu = false;
                        break;
                    case "1":
                        Console.Clear();
                    AuthorMenu:
                        Console.WriteLine(@"Author menu:
            1 - Butun authorlarin siyahisi
            2 - Author yaratmaq
            3 - Author editlemek
            4 - Author silmek
            0 - Exit ");
                        AuthorServices authorServices = new AuthorServices();
                        string inputAuthorMenu = Console.ReadLine();
                        Author author = new Author();

                        switch (inputAuthorMenu)
                        {
                            case "0":
                                Menu = false;
                                break;

                            case "1":
                                authorServices.GetAllAuthors();
                                break;
                            case "2":
                            AuthorCreat:
                                Console.WriteLine("Enter author name:");
                                string authorName = Console.ReadLine();
                                author.Name = authorName;
                                if (authorName == null) throw new NullExceptions("enter author name correct");
                                if (string.IsNullOrWhiteSpace(authorName)) throw new Exception();
                                foreach (var a in authorName)
                                {
                                    if (char.IsDigit(a))
                                    {
                                        Console.WriteLine("incorrect format");
                                        goto AuthorCreat;
                                    }
                                    authorServices.CreateAuthor(author);
                                }
                                goto AuthorMenu;

                            case "3":
                                authorServices.GetAllAuthors();
                            AuhorUpdate:
                                Console.WriteLine("enter updated author's id");
                                var updateauthor = int.TryParse(Console.ReadLine(), out int updatedAuthorsId);
                                if (updateauthor == true)
                                {
                                    Console.WriteLine("enter updated author's name");
                                    string updatedAuthorName = Console.ReadLine();
                                    try
                                    {
                                        if (string.IsNullOrWhiteSpace(updatedAuthorName)) throw new Exception();
                                        foreach (var a in updatedAuthorName)
                                        {
                                            if (char.IsDigit(a))
                                            {
                                                Console.WriteLine("incorrect format");
                                                goto AuhorUpdate;
                                            }
                                            else
                                            {
                                                authorServices.UpdateAuthor(updatedAuthorsId, new Author() { Name = updatedAuthorName, });
                                            }
                                        }
                                    }
                                    catch (NotFound ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        goto AuhorUpdate;
                                    }

                                    catch (NullExceptions ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        goto AuhorUpdate;
                                    }


                                    catch (Exception)
                                    {
                                        Console.WriteLine("duz deyil"); goto AuhorUpdate;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("incorrect format");
                                    goto AuhorUpdate;
                                }
                                goto AuthorMenu;
                            case "4":
                                authorServices.GetAllAuthors();
                            AuthorDelete:
                                Console.WriteLine("enter wanted to delete author's id ");
                                var deleteAuthor = int.TryParse(Console.ReadLine(), out int deletedAuthorId);

                                if (deleteAuthor == true)
                                {
                                    try
                                    {
                                        authorServices.DeleteAuthor(deletedAuthorId);
                                    }
                                    catch (NotFound ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        goto AuthorDelete;
                                    }
                                    catch (DeletedException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        goto AuthorDelete;
                                    }
                                    catch (NullExceptions ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        goto AuthorDelete;
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("duz deyil");
                                        goto AuthorDelete;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("incorrect format");
                                }
                                goto AuthorMenu;
                            default:
                                Console.WriteLine("enter function");
                                goto AuthorMenu;
                        }
                        break;

                    case "2":
                        Console.Clear();
                    BookMenu:
                        Console.WriteLine(@"Book menu:
            1 - Butun booklarin siyahisi
            2 - Book yaratmaq
            3 - Book editlemek
            4 - Book silmek
            0 - Exit ");
                        BookServices bookServices = new BookServices();
                        string inputBookMenu = Console.ReadLine();
                        Book book = new Book();

                        switch (inputBookMenu)
                        {
                            case "0":
                                Menu = false;
                                break;

                            case "1":
                                bookServices.GetAllBooks();
                                break;
                            case "2":
                            BookCreat:
                                Console.WriteLine("Enter book title:");
                                string bookTitle = Console.ReadLine();
                                if (bookTitle == null) throw new NullExceptions("enter book title correct");
                                if (string.IsNullOrWhiteSpace(bookTitle)) throw new Exception();
                                book.Title = bookTitle;

                                Console.WriteLine("Enter author name:");
                                string bookDesc = Console.ReadLine();
                                if (bookDesc == null) throw new NullExceptions("enter book description correct");
                                if (string.IsNullOrWhiteSpace(bookDesc)) throw new Exception();
                                book.Desc = bookDesc;
                                Console.WriteLine("enter published year");
                                publishedyear:
                                var publishedYear = int.TryParse(Console.ReadLine(), out var bookPublishedYear);
                                if (publishedYear == false)
                                {
                                    Console.WriteLine("enter correct format");
                                    goto publishedyear;
                                }
                                if (bookPublishedYear >= DateTime.Today.Day)
                                {
                                    Console.WriteLine("enter correct year");
                                    goto publishedyear;
                                }

                                    foreach (var a in bookTitle)
                                    {
                                        if (char.IsDigit(a))
                                        {
                                            Console.WriteLine("incorrect format");
                                            goto BookCreat;
                                        }
                                        bookServices.CreateBook(book);
                                    }
                                foreach (var a in bookDesc)
                                {
                                    if (char.IsDigit(a))
                                    {
                                        Console.WriteLine("incorrect format");
                                        goto BookCreat;
                                    }
                                    bookServices.CreateBook(book);
                                }
                                goto BookCreat;

                            case "3":
                                bookServices.GetAllBooks();
                            BookUpdate:
                                Console.WriteLine("enter updated book's id");
                                var updateabook = int.TryParse(Console.ReadLine(), out int updatedBooksId);
                                if (updateabook == true)
                                {
                                    Console.WriteLine("enter updated book's title");
                                    string updatedBookTitle = Console.ReadLine();
                                    Console.WriteLine("enter updated book's description");
                                    string updatedBookDesc = Console.ReadLine();
                                    try
                                    {
                                        if (string.IsNullOrWhiteSpace(updatedBookTitle)) throw new Exception();
                                        foreach (var a in updatedBookTitle)
                                        {
                                            if (char.IsDigit(a))
                                            {
                                                Console.WriteLine("incorrect format");
                                                goto BookUpdate;
                                            }
                                            else
                                            {
                                                bookServices.UpdateBook(updatedBooksId, new Book() { Title = updatedBookTitle, });
                                            }
                                        }

                                    }
                                    catch (NotFound ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        goto BookUpdate;
                                    }

                                    catch (NullExceptions ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        goto BookUpdate;
                                    }


                                    catch (Exception)
                                    {
                                        Console.WriteLine("duz deyil"); //goto AuhorUpBookUpdatedate;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("incorrect format");
                                    goto BookUpdate;
                                }
                                goto BookMenu;
                            case "4":
                                bookServices.GetAllBooks();
                            AuthorDelete:
                                Console.WriteLine("enter wanted to delete author's id ");
                                var deleteAuthor = int.TryParse(Console.ReadLine(), out int deletedAuthorId);

                                if (deleteAuthor == true)
                                {
                                    try
                                    {
                                        bookServices.DeleteBook(deletedAuthorId);
                                    }
                                    catch (NotFound ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        goto AuthorDelete;
                                    }
                                    catch (DeletedException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        goto AuthorDelete;
                                    }
                                    catch (NullExceptions ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        goto AuthorDelete;
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("duz deyil");
                                        goto AuthorDelete;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("incorrect format");
                                }
                                goto AuthorMenu;
                            default:
                                Console.WriteLine("enter function");
                                goto AuthorMenu;
                        }
                        break;



                        break;


                }
            } while (Menu);

            //IBookServices bookServices = new BookServices();
            // bookServices.GetAllBooks();

            // bookServices.UpdateBook(7, new Book() { Title = "dddddddddddddddddddddddddddddd" });
            // Console.WriteLine("======");
            // bookServices.GetAllBooks();




        }
    }
}
