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

public static class CRUD_Author
{

    public static Author Add(AuthorModel model)
    {

        ConsoleAppDatabase consoleAppDatabase = new ConsoleAppDatabase();
        var res = consoleAppDatabase.authors.FirstOrDefault(x => x.Id == model.Id);

        if (res == null)
        {
            res = model.ToEntity();
            consoleAppDatabase.Add(res);
            consoleAppDatabase.SaveChanges();
            Console.WriteLine($"--------- Данные {res.Name} добавлены ---------");
        }
        else
        {
            Console.WriteLine($"--------- Запись c именем {res.Name} уже создана ---------");
            try
            {
                ConsoleAppDatabase db = new ConsoleAppDatabase();
                UpdateDB(model);

            }
            catch (Exception ex) { Console.WriteLine(ex); }

        }
        if (res == null)
        {
            throw new Exception("");
        }

        return res;

        //res.Libraries = new();
        //foreach (var book in books)
        //{
        //    var chek = consoleAppDatabase.libraries.FirstOrDefault(x => x.BookID == model.BookID);
        //    var library = new Library()
        //    {
        //        Author = res,
        //        Book = book
        //    };
        //    res.Libraries.Add(library);
        //}

        //consoleAppDatabase.SaveChanges();

        //return res;
    }


    public static Author ToEntity(this AuthorModel model) => new()
    {
        Id = model.Id,
        Name = model.Name
    };

    public static void UpdateDB(AuthorModel model)
    {
        ConsoleAppDatabase db = new ConsoleAppDatabase();
        Author? author = db.authors.FirstOrDefault(x => x.Id == model.Id);
        if (author != null)
        {
            //book.Author = model.Author;
            author.Name = model.Name;
            db.SaveChanges();
        }
        Console.WriteLine($"--------- Запись c именем {model.Name} обновлена ---------");
    }
}
