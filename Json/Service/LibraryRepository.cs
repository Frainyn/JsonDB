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

public static class LibraryRepository
{

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
            consoleAppDatabase.SaveChanges();
            var Author = consoleAppDatabase.authors.Where(x => x.Id == authorID).ToList();
            var Book = consoleAppDatabase.books.Where(x => x.Id1C == bookID).ToList();
            Console.WriteLine($"- Книга \"{Book[0].Title}\" привязана к автору \"{Author[0].Name}\"");
        }
        else
        {
            var Author = consoleAppDatabase.authors.Where(x => x.Id == authorID).ToList();
            var Book = consoleAppDatabase.books.Where(x => x.Id1C == bookID).ToList();
            Console.WriteLine($"- У книги \"{Book[0].Title}\" автор обновлён на \"{Author[0].Name}\"");  
            
        }
    }
}

