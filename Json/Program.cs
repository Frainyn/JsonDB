using Json.Data;
using Json.Database;
using Json.Database.Entity;
using Json.Model;
using Json.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
//using Newtonsoft.Json;

using System.Text.Json;


namespace Json;

class ReadFile 
{
    PathInData pathInData = new PathInData();
    public List<string> GetFileList() //используется для получения списка файлов в сетевой папке.
        => Directory.GetFiles(pathInData.networkFolderSettings) //для получения списка файлов в сетевой папке, указанной в настройках.
        .Select(path => Path.GetFileName(path)) //преобразования списка файлов в список имен файлов.
        .ToList(); //преобразования результирующего списка в объект типа

    public Info ReadFileJson(string name)
    {   
        string path = Path.Combine(pathInData.networkFolderSettings, name);
        using var fStream = File.OpenRead(path);
        var obj = JsonSerializer.Deserialize<Info>(fStream);
        if (obj == null) throw new Exception("Не удается десериализовать файл: " + path);
        return obj;
    }

    public string GetExchangeFilePath(string name) //принимает имя файла в качестве аргумента и возвращает строку - путь к файлу.
        => Path.Combine(pathInData.networkFolderSettings, name); //использует метод Combine класса Path, чтобы объединить путь к папке для обмена файлами и имя файла в один путь.


    public async Task ReadName()
    {
        Console.WriteLine("--------- Loading --------- ");
        var filesNames = GetFileList();
        Console.WriteLine($"--------- Получение количество файлов --------- : {filesNames}");
        for (int i = 0; i < filesNames.Count; i++)
        {
            var path = GetExchangeFilePath(filesNames[i]); //этот код получает путь к файлу, используя имя файла из списка.
            Console.WriteLine($"--------- Получение пути: {path} --------- ");
            var fileInfo = ReadFileJson(filesNames[i]); // этот код читает содержимое файла и сохраняет его в объект
            RefreshDatabase(fileInfo); //этот код обновляет базу данных с помощью информации из файла.                                    
        }
    }
    
    public void RefreshDatabase(Info obj)
    {

        ConsoleAppDatabase consoleAppDatabase = new ConsoleAppDatabase();

        Dictionary<int, List<Book>> dictionaryBook = new Dictionary<int, List<Book>>();

        for (int i = 0; i < obj.Books?.Count; i++)
        {

            // моедль книги из файлика json
            var bookModel = obj.Books[i];
            var book = CRUD_Book.Add(bookModel);
            if (dictionaryBook.ContainsKey(bookModel.AuthorID)) {
                dictionaryBook[bookModel.AuthorID].Add(book);
            }
            else {
                dictionaryBook[bookModel.AuthorID] = new List<Book>() { 
                    book
                };
            }
        }

        Dictionary<int, List<Author>> dictionaryAuthor = new Dictionary<int, List<Author>>();

        for (int i = 0; i < obj.Authors?.Count; i++)
        {
            //CRUD_Book book = new CRUD_Book();
            
            var authorModel = obj.Authors[i];
            var author = CRUD_Author.Add(authorModel); 
            if (dictionaryAuthor.ContainsKey(authorModel.BookID))
            {
                dictionaryAuthor[authorModel.BookID].Add(author);
            }
            else
            {
                dictionaryAuthor[authorModel.BookID] = new List<Author>() {
                author
                };
            };
        }

        //var booksCount = dictionaryBook.Count;
        //var authorsCount = dictionaryAuthor.Count;

        //for (int i = 0; i < booksCount; i++)
        //{
        //    var books = dictionaryBook[obj.Books[i].AuthorID];
        //    for (int j = 0; j < authorsCount; j++)
        //    {
        //        var authors = dictionaryAuthor[obj.Authors[i].BookID];
        //        if (books[i].AuthorID == authors[j].Id)
        //        {
        //            //CRUD_Library.Add(books[i], authors[j]);
        //            Console.WriteLine("+");
        //        }
        //        Console.WriteLine("-");
        //    }
        //}

        //CRUD_Library.Add(books[i], authors[i]);


        foreach (var bookModel in obj.Books) 
        {
            CRUD_Library.Add(bookModel.Id1C, bookModel.AuthorID);
        }

















    }

    class Program
    {
        static void Main(string[] args)
        {
            using (ConsoleAppDatabase db = new ConsoleAppDatabase())
            {
                //db.Database.EnsureCreated();
                db.Database.Migrate();
            }

            ConsoleAppDatabase consoleAppDatabase = new ConsoleAppDatabase();
            string name = "01.json";
            ReadFile readFile = new ReadFile();
            readFile?.ReadName();

          
            //var books = consoleAppDatabase.books.ToList();

            var books = consoleAppDatabase.books
                .Include(book => book.Author)
                .ToList();

            Console.WriteLine("\nК А Т А Л О Г");
            foreach (var book in books)
            {
                Console.WriteLine($"Книга - \"{book.Title}\" : Автор - \"{book.Author.Name}\"");
            }

        }
    }
}