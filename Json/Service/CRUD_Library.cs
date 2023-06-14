using Json.Data;
using Json.Database.Entity;
using Json.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Json.Service;

public static class CRUD_Library
{
    //public static void Add(Book book, Author author)
    //{

    //    ConsoleAppDatabase consoleAppDatabase = new ConsoleAppDatabase();
    //    var res = consoleAppDatabase.libraries.FirstOrDefault(x => x.BookID == book.Id && x.AuthorID == author.Id);
    //    if (res == null)
    //    {
    //        var library = new Library()
    //        {
    //            Book = book,
    //            Author = author,
    //        };
    //        consoleAppDatabase.libraries.Add(library);
    //        try
    //        {
    //            consoleAppDatabase.SaveChanges();
    //        }
    //        catch(Exception ex) { Console.WriteLine(ex.ToString()); }
    //    }
    //    else
    //    {
    //        Console.WriteLine("Уже");
    //    }
    //}


    public static void Add(int bookID, int authorID)
    {

        ConsoleAppDatabase consoleAppDatabase = new ConsoleAppDatabase();
        var res = consoleAppDatabase.libraries.FirstOrDefault(x => x.BookID == bookID && x.AuthorID == authorID);
        if (res == null)
        {
            var library = new Library()
            {
                BookID = bookID,
                AuthorID = authorID,
            };
            consoleAppDatabase.libraries.Add(library);
            try
            {
                consoleAppDatabase.SaveChanges();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }
        else
        {
            var Author = consoleAppDatabase.authors.Where(x => x.Id == authorID).ToList();
            var Book = consoleAppDatabase.books.Where(x => x.Id == authorID).ToList();



            Console.WriteLine($"--------- Книга {Book[0].Title} уже привязана к автору {Author[0].Name} --------- ");
        }
    }



    //public static void Add(List<Book> books, List<Author> authors)
    //{

    //    ConsoleAppDatabase consoleAppDatabase = new ConsoleAppDatabase();
    //    var res = consoleAppDatabase.libraries.FirstOrDefault(x => x.BookID == books[0].Id);
    //    if (res == null)
    //    {
    //        res = ToEntity(books, authors);
    //        consoleAppDatabase.Add(res);
    //        consoleAppDatabase.SaveChanges();
    //        Console.WriteLine($"--------- Данные добавлены ---------");
    //    } else
    //    {
    //        Console.WriteLine("--------- Запись уже создана ---------");
    //        UpdateDB(books, authors);
    //    }

    //}

    //public static Library ToEntity(List<Book> books, List<Author> authors) => new()
    //{
    //        BookID = authors[0].Libraries.Where(x => x.AuthorID == books[0].Id).ToList().First().BookID,
    //        AuthorID = books[0].Libraries.Where(x => x.BookID == books[0].Id).ToList().First().AuthorID
    //};

    //public static void UpdateDB(List<Book> books, List<Author> authors)
    //{
    //    ConsoleAppDatabase db = new ConsoleAppDatabase();
    //    Library? library = db.libraries.FirstOrDefault(x => x.BookID == books[0].Id);
    //    if (library != null)
    //    {
    //        library.BookID = authors[0].Libraries.Where(x => x.AuthorID == books[0].Id).ToList().First().BookID;
    //        library.AuthorID = books[0].Libraries.Where(x => x.BookID == books[0].Id).ToList().First().AuthorID;
    //        db.SaveChanges();
    //    }
    //    Console.WriteLine("--------- Обновлено ---------");
    //}

}
//        if (res == null)
//        {
//            //res = new();
//            foreach (var book in books)
//            {
//                var chek = consoleAppDatabase.libraries.FirstOrDefault(x => x.BookID == res.BookID);
//                var library = new Library()
//                {
//                    Author = res.Author,
//                    Book = res.Book
//                };
//                res.Add(library);
//            }

//            consoleAppDatabase.SaveChanges();

//            return res;

//            Console.WriteLine($"--------- Данные добавлены ---------");
//        }
//        else
//        {
//            Console.WriteLine("--------- Запись уже создана ---------");
//            try
//            {
//                ConsoleAppDatabase db = new ConsoleAppDatabase();
//                UpdateDB(model);

//            }
//            catch (Exception ex) { Console.WriteLine(ex); }

//        }
//        if (res == null)
//        {
//            throw new Exception("");
//        }

//        return res;

//        res.Libraries = new();
//        foreach (var book in books)
//        {
//            var chek = consoleAppDatabase.libraries.FirstOrDefault(x => x.BookID == model.BookID);
//            var library = new Library()
//            {
//                Author = res,
//                Book = book
//            };
//            res.Libraries.Add(library);
//        }

//        consoleAppDatabase.SaveChanges();

//        return res;


//    }

//}

//        ConsoleAppDatabase consoleAppDatabase = new ConsoleAppDatabase();

//        var res = consoleAppDatabase.books.FirstOrDefault(x => x.Id1C == model.Id1C);
//        if (res == null)
//        {

//            res = model.ToEntity();
//            consoleAppDatabase.Add(res);
//            consoleAppDatabase.SaveChanges();
//            Console.WriteLine($"--------- Данные добавлены ---------");
//        }
//        else
//        {
//            Console.WriteLine("--------- Запись уже создана ---------");

//            ConsoleAppDatabase db = new ConsoleAppDatabase();
//            UpdateDB(model);
//        }
//        if (res == null)
//        {
//            throw new Exception("");
//        }
//        return res;
//    }


//    public static Book ToEntity(this BookModel model) => new()
//    {
//        Id1C = model.Id1C,
//        Description = model.Description,
//        Title = model.Title,
//        Price = model.Price,
//        Category = model.Category
//    };


//    public static void UpdateDB(BookModel model)
//    {
//        ConsoleAppDatabase db = new ConsoleAppDatabase();
//        Book book = db.books.FirstOrDefault(x => x.Id1C == model.Id1C);
//        if (book != null)
//        {
//            //book.Author = model.Author;
//            book.Description = model.Description;
//            book.Title = model.Title;
//            book.Price = model.Price;
//            book.Category = model.Category;
//            db.SaveChanges();
//            Console.WriteLine("--------- Обновлено ---------");
//        }
//    }
//}
