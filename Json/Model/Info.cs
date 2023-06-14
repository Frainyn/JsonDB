using Json.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json.Model;

public class Info
{
    public List<BookModel>? Books { get; set; }
    public List<AuthorModel>? Authors { get; set; }
    public List<Library> Libraries { get; set; }
}
