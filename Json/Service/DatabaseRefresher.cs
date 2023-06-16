﻿using Json.Data;
using Json.Database.Entity;
using Json.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json.Service;

public class DatabaseRefresher
{
    private ConsoleAppDatabase db = new ConsoleAppDatabase();
    private AuthorModel author = new AuthorModel();
    private BookModel book = new BookModel();
    private Library library = new Library();

    public void DataRefresher(List<Info> obj, List<FileInfo> file)
    {
   

        
        for (int i = 0; i < file.Count; i++)
        {
            
            for (int j = 0; j < obj[i].Authors.Count; j++) 
            {
                var authorModel = obj[i].Authors?[j];
                var res = db.authors.FirstOrDefault(x => x.Id == authorModel.Id);
                if (res == null)
                {
                    var author = new Author
                    {
                        Id = authorModel.Id,
                        Name = authorModel?.Name
                    };
                    db.authors.Add(author);
                    db.SaveChanges();
                }
                
            }
            

            for (int j = 0; j < obj[i].Books?.Count; j++)
            {
                var bookModel = obj[i].Books?[j];
                var res = db.books.FirstOrDefault(x => x.Id1C == bookModel.Id1C);
                if (res == null)
                {
                    var book = new Book
                    {
                        Id = bookModel.Id,
                        Id1C = bookModel.Id1C,
                        Category = bookModel.Category,
                        Title = bookModel.Title,
                        Description = bookModel.Description,
                        Price = bookModel.Price,
                        AuthorID = bookModel.AuthorID
                    };
                    db.books.Add(book);
                    db.SaveChanges();
                }
            };

            foreach (var book in obj[i].Books)
            {
                var res = db.libraries.FirstOrDefault(x => x.Id == book.Id);
                if (res == null)
                {
                    var library = new Library()
                    {
                        BookID = book.Id1C,
                        AuthorID = book.AuthorID
                    };
                    db.libraries.Add(library);
                    db.SaveChanges();
                }
            }

            FileCheckImport fileCheckImport = new FileCheckImport();
            fileCheckImport.UpdateImport(file[i].Name);



            
        }
        
    }
}