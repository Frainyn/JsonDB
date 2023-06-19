using Json.Data;
using Json.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json.Service;



public class Display
{

    

    public void BookAuthor()
    {
        ConsoleAppDatabase db = new ConsoleAppDatabase();
        var books = db.books
                .Include(book => book.Author)
                .ToList();

        Console.WriteLine("\nК А Т А Л О Г");
        foreach (var book in books)
        {
            Console.WriteLine($"Книга - \"{book.Title}\" : Автор - \"{book.Author?.Name}\"");
        }
    }

    //Список не импортируемых файлов
    public void NoImportFiles()
    {
        
        Console.WriteLine("Список не импортируемых файлов:");
        //var file = fileReader.GetNotImportedFiles();
        //foreach (var item in file)
        //{
        //    var pathf = fileReader.GetExchangeFilePath(item.Name);
        //    var info = fileReader.GetFileInfo(pathf);
        //    Console.WriteLine($"Имя файла: {item.Name}\n" +
        //        $"Дата создания: {info.CreationTime}\n" +
        //        $"Путь: {info.FullName}\n"); ;
        //}
    }

}
