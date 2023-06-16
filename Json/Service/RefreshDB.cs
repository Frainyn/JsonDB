using Json.Data;
using Json.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json.Service;

//Записи в таблицу
public class RefreshDB
{
    public void RefreshDatabase(Info obj)
    {
        ConsoleAppDatabase consoleAppDatabase = new ConsoleAppDatabase();
        for (int i = 0; i < obj.Authors?.Count; i++)
        {
            var authorModel = obj.Authors[i];
            var author = AuthorRepository.Add(authorModel);
        }
        for (int i = 0; i < obj.Books?.Count; i++)
        {
            // модель книги из файлика json
            var bookModel = obj.Books[i];
            var book = BookRepository.Add(bookModel);
        }

        foreach (var bookModel in obj.Books)
        {
            LibraryRepository.Add(bookModel.Id1C, bookModel.AuthorID);
        }
    }

}
