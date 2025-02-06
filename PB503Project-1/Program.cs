﻿using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using PB503Project_1.Models;
using PB503Project_1.MyExceptions;
using PB503Project_1.Repository.Implementations;
using PB503Project_1.Repository.Interface;
using PB503Project_1.Services.Implementation;
using PB503Project_1.Services.Interface;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace PB503Project_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Author author = new Author();
            bool Menu = true;
            do
            {

                Console.WriteLine(@"
            1 - Author actions.
            2 - Book Actions.
            3 - Borrower Actions
            4 - BorrowBook");

                string inputMenu = Console.ReadLine();
                Console.Clear();
                switch (inputMenu)
                {
                    case "0":
                        Menu = false;
                        break;
                    case "1":
                    AuthorMenu:

                        Console.WriteLine(@"Author menu:
            1 - Butun authorlarin siyahisi
            2 - Author yaratmaq
            3 - Author editlemek
            4 - Author silmek
            0 - Exit ");
                        AuthorServices authorServices = new AuthorServices();
                        string inputAuthorMenu = Console.ReadLine();

                        Console.Clear();
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
                                try
                                {
                                    string authorName = Console.ReadLine();
                                    author.Name = authorName;
                                    authorServices.CreateAuthor(author);
                                }
                                catch (NullExceptions ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    goto AuthorCreat;
                                }
                                catch (InvalidException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    goto AuthorCreat;
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
                                        authorServices.UpdateAuthor(updatedAuthorsId, new Author() { Name = updatedAuthorName, });
                                    }
                                    catch (NotFound ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        goto AuhorUpdate;
                                    }
                                    catch (InvalidException ex)
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
                                    catch (InvalidException ex)
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
                        Console.Clear();
                        switch (inputBookMenu)
                        {
                            case "0":
                                Menu = false;
                                break;
                            case "1":
                                bookServices.GetAllBooks();
                                break;
                            case "2":
                            BookCreate:
                                try
                                {
                                    Console.WriteLine("Enter book title:");
                                    book.Title = Console.ReadLine();

                                    Console.WriteLine("Enter book description name:");
                                    book.Desc = Console.ReadLine();

                                publishedyear:
                                    Console.WriteLine("enter published year");
                                    var publishedYear = int.TryParse(Console.ReadLine(), out var bookPublishedYear);

                                    book.PublishedYear = bookPublishedYear;
                                    if (publishedYear == false)
                                    {
                                        Console.WriteLine("false year");
                                        goto publishedyear;
                                    }

                                    author.Id = Convert.ToInt32(Console.ReadLine());


                                isBorrowBook:
                                    Console.WriteLine(@"book is borrowed:
            1 - Yes
            2 - No");
                                    string IsBorrow = Console.ReadLine();
                                    if (IsBorrow == "1")
                                    {
                                        book.IsBorrow = true;

                                    }
                                    else if (IsBorrow == "2")
                                    {
                                        book.IsBorrow = false;

                                    }
                                    else
                                    {
                                        Console.WriteLine("enter again");
                                        goto isBorrowBook;
                                    }


                                    bookServices.CreateBook(book);
                                }
                                catch (NullExceptions ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    goto BookCreate;
                                }
                                catch (NotFound ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    goto BookCreate;
                                }
                                catch (InvalidException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    goto BookCreate;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("salam");
                                    goto BookCreate;
                                }
                                goto BookMenu;
                            case "3":
                            BookUpdate:
                                try
                                {
                                    bookServices.GetAllBooks();
                                    Console.WriteLine("enter updated book's id");
                                    var updateabook = int.TryParse(Console.ReadLine(), out int updatedBooksId);
                                    book.Id = updatedBooksId;
                                    if (updateabook == true)
                                    {
                                        Console.WriteLine("enter updated book's title");
                                        book.Title = Console.ReadLine();

                                        Console.WriteLine("enter updated book's description");
                                        book.Desc = Console.ReadLine();

                                    BookUpdatePublishedYear:
                                        Console.WriteLine("enter published year");
                                        var publishedYear = int.TryParse(Console.ReadLine(), out var bookPublishedYear);

                                        book.PublishedYear = bookPublishedYear;
                                        if (publishedYear == false)
                                        {
                                            Console.WriteLine("false year");
                                            goto BookUpdatePublishedYear;
                                        }
                                    }
                                    bookServices.UpdateBook(updatedBooksId, book);
                                }
                                catch (NotFound ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    goto BookUpdate;
                                }
                                catch (InvalidException ex)
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
                                goto BookMenu;
                            case "4":
                            BookDelete:
                                bookServices.GetAllBooks();
                                try
                                {
                                    Console.WriteLine("enter wanted to delete author's id ");
                                    var deleteAuthor = int.TryParse(Console.ReadLine(), out int deletedAuthorId);
                                    book.Id = deletedAuthorId;
                                    bookServices.DeleteBook(deletedAuthorId);
                                }
                                catch (NotFound ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    goto BookDelete;
                                }
                                catch (DeletedException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    goto BookDelete;
                                }
                                catch (NullExceptions ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    goto BookDelete;
                                }
                                catch (InvalidException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    goto BookDelete;
                                }
                                catch (Exception)
                                {

                                    Console.WriteLine("incorrect format");
                                    goto BookDelete;
                                }
                                break;
                            default:
                                Console.WriteLine("enter function");
                                goto BookMenu;
                        }
                        break;

                    case "3":
                    BorrowerMenu:
                        Console.Clear();
                        Console.WriteLine(@"Borrower menu:
            1 - Butun Borrowerlarin siyahisi
            2 - Borrower yaratmaq
            3 - Borrower editlemek
            4 - Borrower silmek
            0 - Exit ");
                        BorrowerServices borrowerServices = new BorrowerServices();
                        string inputBorrowerMenu = Console.ReadLine();
                        Borrower borrower = new Borrower();

                        Console.Clear();
                        switch (inputBorrowerMenu)
                        {
                            case "0":
                                Menu = false;
                                break;
                            case "1":
                                borrowerServices.GetAllBorrowers();
                                break;
                            case "2":
                            BorrowerCreate:
                                try
                                {
                                    Console.WriteLine("Enter borrower name:");
                                    borrower.Name = Console.ReadLine();

                                    Console.WriteLine("Enter borrower email name:");
                                    borrower.Email = Console.ReadLine();

                                    borrowerServices.CreateBorrower(borrower);
                                }
                                catch (NullExceptions ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    goto BorrowerCreate;
                                }
                                catch (InvalidException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    goto BorrowerCreate;
                                }
                                catch (NotFound ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    goto BorrowerCreate;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    goto BorrowerCreate;
                                }
                                goto BorrowerMenu;

                            case "3":
                            BorrowerUpdate:
                                borrowerServices.GetAllBorrowers();
                                try
                                {
                                    Console.WriteLine("enter updated borrower's id");
                                    var updateaborrower = int.TryParse(Console.ReadLine(), out int updateaBorrowerId);
                                    borrower.Id = updateaBorrowerId;
                                    if (updateaborrower == true)
                                    {
                                        Console.WriteLine("enter updated borrower's name");
                                        borrower.Name = Console.ReadLine();

                                        Console.WriteLine("enter updated borrower's email");
                                        borrower.Email = Console.ReadLine();
                                    }
                                    borrowerServices.UpdateBorrower(updateaBorrowerId, borrower);
                                }
                                catch (NotFound ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    goto BorrowerUpdate;
                                }
                                catch (NullExceptions ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    goto BorrowerUpdate;
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("duz deyil");
                                }
                                goto BorrowerMenu;

                            case "4":
                            BorrowerDelete:
                                borrowerServices.GetAllBorrowers();
                                try
                                {
                                    Console.WriteLine("enter wanted to delete borrower's id ");
                                    var deleteBorrower = int.TryParse(Console.ReadLine(), out int deletedBorrowerId);
                                    borrower.Id = deletedBorrowerId;
                                    borrowerServices.DeleteBorrowed(borrower.Id);
                                }
                                catch (NotFound ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    goto BorrowerDelete;
                                }
                                catch (DeletedException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    goto BorrowerDelete;
                                }
                                catch (NullExceptions ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    goto BorrowerDelete;
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("incorrect format");
                                    goto BorrowerDelete;
                                }
                                break;

                            default:
                                Console.WriteLine("enter function");
                                goto BorrowerMenu;
                        }
                        break;

                    case "4":

                        BookServices bookServices1 = new BookServices();                                                   

                        List<Book> books = new List<Book>();
                        foreach (var items in bookServices1.GetAllBooks().Where(x => x.IsBorrow == true))
                        {

                            Console.WriteLine(items.Id + " not available");
                            books.Add(items);
                        }

                        LoanServices loanServices = new LoanServices();

                        Loan loan = new Loan();
                        {
                            loan.BorrowerId = 2;
                        };

                      loanServices.CreateLoan(loan);


                        LoanItemServices loanItemServices = new LoanItemServices();

                        loanItemServices.CreateLoanItem(new LoanItem() { LoanId = loan.Id, BookId = 2 });

//                     IBorrowerRepository borrowerRepository = new BorrowerRepository();

                        
//                        Console.WriteLine(@"1 - borrow another book
//2- add borrower");
//                        string borrowBookMenu = Console.ReadLine();
//                        if (borrowBookMenu == "2")
//                        {
//                            borrowerRepository.GetAllByInclude().Where(x=>x.Loans)
//                        }


                        break;
                    default:
                        Console.WriteLine("enter function");
                        break;

                }
            } while (Menu);

            

        }
    }
}
