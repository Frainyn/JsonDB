using Json.Data;
using Json.Database;
using Json.Database.Entity;
using Json.Model;
using Json.Options;
using Json.Service.DownloadExchangeJson;
using Json.Service.JobConsole;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Text.Json;


namespace Json;


class Program
{


  
    static void Main(string[] args)
    {
        

        ReaderOptions options = new()
        {
            JsonFilesDirectory = "C:\\TestStorage"
        };

        

        ConsoleAppDatabase db = new ConsoleAppDatabase();
        db.migration();

        FileReader fileReader = new FileReader(options, db);
        FileReadedJson fileReadedJson = new FileReadedJson();
        DatabaseRefresher databaseRefresher = new DatabaseRefresher(db);
        FileCheckImport fileCheckImport = new FileCheckImport(db);
        WorkConsole workConsole = new WorkConsole(db, databaseRefresher);

        

        


       

        

        //Получение не импорт файлов
        var filesNotImported = fileReader.GetNotImportedFiles();
        //Метка файла
        var fileMark = fileCheckImport.FileCheck(filesNotImported);
        //Десериализация файлов
        var fileObject = fileReadedJson.GetFileObject(fileMark);
        //Запись в БД
        databaseRefresher.DataRefresher(fileObject, fileMark);
        //Работа консоли
        workConsole.Run();

        
 

    }
    
}