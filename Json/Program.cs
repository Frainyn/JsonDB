using Json.Data;
using Json.Database;
using Json.Database.Entity;
using Json.Model;
using Json.Options;
using Json.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Text.Json;
namespace Json;




//class FileProcessing
//{
//    public void Process()
//    {
//        ConsoleAppDatabase db = new ConsoleAppDatabase();
//        FileReader fileReader = new FileReader();
//        FileCheckImport fileCheckImport = new FileCheckImport();
//        RefreshDB refreshDB = new RefreshDB();
//        Display display = new Display();

//        //Информация об не импортированных файлов



//        //Чтение файлов 
//        var filesNames = fileReader.GetFileList();

//        ////Проверка импортированности файлов
//        //for (int i = 0; i < filesNames.Count; i++)
//        //{
//        //    string name = filesNames[i];
//        //    fileCheckImport.FileCheck(name);
//        //}
//        //


//        fileReader.GetNotImportedFiles();
//        Console.WriteLine(fileReader.ToString);

//        display.NoImportFiles();

//        //Прогрузка файлов
//        for (int i = 0; i < filesNames.Count; i++)
//        {
//            string name = filesNames[i];
//            if (fileCheckImport.FileCheck(name)) Console.WriteLine($"Файл \"{name}\" - импортирован ");
//            else
//            {
//                var fileInfo = fileReader.ReadFileJson(filesNames[i]); // этот код читает содержимое файла и сохраняет его в объект
//                refreshDB.RefreshDatabase(fileInfo); //этот код обновляет базу данных с помощью информации из файла.
//                fileCheckImport.UpdateImport(name); //обновляет статус импорта файла}
//            }
//        }
//        display.BookAuthor();
//    }
//}








class Program
{
    static void Main(string[] args)
    {
        ConsoleAppDatabase db = new ConsoleAppDatabase();
        db.migration();

        ReaderOptions options = new() { 
            JsonFilesDirectory = "C:\\TestStorage"
        };

        FileReader fileReader = new FileReader(options);
        FileReadedJson fileReadedJson = new FileReadedJson();
        DatabaseRefresher databaseRefresher = new DatabaseRefresher();
        FileCheckImport fileCheckImport = new FileCheckImport();

        //Получение не импорт файлов
        var filesNotImported = fileReader.GetNotImportedFiles();
        //Метка файла
        var fileMark = fileCheckImport.FileCheck(filesNotImported);
        //Десериализация файлов
        var fileObject = fileReadedJson.GetFileObject(fileMark);
        //Запись в БД
        databaseRefresher.DataRefresher(fileObject, fileMark);
        
        

        

        ///1. Десериализировать  (отдельный класс с методом list fileInfo и выдаёт список info)
        ///2. DatabaseRefresher метод refresh получает метод info и зановит в базу
        ///3. 

    }
    
}