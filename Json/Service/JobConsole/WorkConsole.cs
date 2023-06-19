using Json.Data;
using Json.Database.Entity;
using Json.Model;
using Json.Service.DownloadExchangeJson;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json.Service.JobConsole
{
    internal class WorkConsole
    {

        private ConsoleAppDatabase _db;
        private DatabaseRefresher _workDB;
        internal WorkConsole(ConsoleAppDatabase db, DatabaseRefresher workDB)
        {
            _db = db;
            _workDB = workDB;
        }
        

        public void Run()
        {
            bool isOpen = true;
            

            while (isOpen) 
            {
                
                Console.WriteLine("Библиотека");
                Console.WriteLine("\n1 - добавить книгу.\n2 - изменить книгу.\n3 - удалить книгу.\n4 - каталог.\n5 - выход.\n");
                Console.Write("Введите команду: ");


                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        List<Info> obj = new List<Info>();
                        List<string> books = new List<string>();
                        List<string> authors = new List<string>();
                        
                        Console.WriteLine("Добавьте книгу:");
                        Console.Write("Название книги:");
                        string title = Console.ReadLine();
                        books.Add(title);
                        Console.Write("Категория книги:");
                        string Category = Console.ReadLine();
                        books.Add(Category);
                        Console.Write("Описание:");
                        string Description = Console.ReadLine();
                        books.Add(Description);
                        Console.Write("Стоимость");
                        string Price = Console.ReadLine();
                        books.Add(Price);
                        Console.Write("Автор");
                        string AuthorID = Console.ReadLine();
                        books.Add(AuthorID);

                        obj.AddRange(books, authors);
                        Console.WriteLine(obj);


                        break;
                    case 2:
                        Console.WriteLine("Какую книгу вы хотите изменить? ");
                        
                        break;
                    case 3:
                        Console.WriteLine("Какую книгу вы хотите удалить? ");
                        int record = Convert.ToInt32(Console.ReadLine());
                        if (_db.books.Count() >= record || record > 0)
                        {
                            _workDB.DeleteBook(record);
                            Console.WriteLine("Книга успешно удалена !");
                        }
                        Console.WriteLine("Такой книги нет");
                        break;
                    case 4:
                        Catalog();
                        break;
                    case 5:
                        isOpen = false;
                        break;
                    default: Console.WriteLine("Нет такой команды"); break;
                }

                Console.ReadKey();
                Console.Clear();
            }
            

        }

         

        


        public void Catalog() 
        {
            Console.WriteLine("Библиотека");
            var books = _db.books
                    .Include(book => book.Author)
                    .ToList();

            Console.WriteLine("\nК А Т А Л О Г");
            foreach (var book in books)
            {
                Console.WriteLine($"ID - {book.Id1C}  |  Книга - \"{book.Title}\"   |  Автор - \"{book.Author?.Name}\"");
            }
        }







    }
}
