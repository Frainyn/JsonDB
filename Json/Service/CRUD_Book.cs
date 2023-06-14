using Json.Data;
using Json.Database.Entity;
using Json.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Json.Service;

public static class CRUD_Book
{

    public static Book Add(BookModel model)
    {

        ConsoleAppDatabase consoleAppDatabase = new ConsoleAppDatabase();

        var res = consoleAppDatabase.books.FirstOrDefault(x => x.Id1C == model.Id1C);
        if (res == null)
        {

            res = model.ToEntity();
            consoleAppDatabase.Add(res);
            consoleAppDatabase.SaveChanges();
            Console.WriteLine($"--------- Данные {res.Title} добавлены ---------");
        }
        else
        {
            Console.WriteLine($"--------- Запись c именем {res.Title} уже создана ---------");

            ConsoleAppDatabase db = new ConsoleAppDatabase();
            UpdateDB(model);
        }
        if (res == null)
        {
            throw new Exception("");
        }
        return res;
    }


    public static Book ToEntity(this BookModel model) => new()
    {
        Id1C = model.Id1C,
        Description = model.Description,
        Title = model.Title,
        Price = model.Price,
        Category = model.Category,
        AuthorID = model.AuthorID
    };


    public static void UpdateDB(BookModel model)
    {
        ConsoleAppDatabase db = new ConsoleAppDatabase();
        Book book = db.books.FirstOrDefault(x => x.Id1C == model.Id1C);
        if (book != null)
        {
            //book.Author = model.Author;
           
            book.Description = model.Description;
            book.Title = model.Title;
            book.Price = model.Price;
            book.Category = model.Category;
            book.AuthorID = model.AuthorID;
            db.SaveChanges();
            Console.WriteLine($"--------- Запись c именем {model.Title} обновлена ---------");
        }
    }
}
