using HierarchicalData.Database;
using HierarchicalData.Database.Entity;
using System.Data.Common;

namespace Hierarchical;

class Exp
{
    public void exp()
    {

        using (ApplicationContext db = new ApplicationContext())
        {

        MenuItem file = new MenuItem { Title = "File" };
        MenuItem edit = new MenuItem { Title = "Edit" };
        MenuItem open = new MenuItem { Title = "Open", Parent =file };
        MenuItem save = new MenuItem { Title = "Save", Parent =file };

        MenuItem copy = new MenuItem { Title = "Copy", Parent = edit };
        MenuItem paste = new MenuItem { Title = "Paste", Parent = edit };
        
        
        db.MenuItems.AddRange(file, edit, open, save, copy, paste);
        db.SaveChanges();



            var menuItems = db.MenuItems.ToList();
            Console.WriteLine("All Menu");
            foreach (MenuItem m in menuItems)
            {
                Console.WriteLine(m.Title);
            }
            Console.WriteLine();

            var fileMenu = db.MenuItems.FirstOrDefault(m => m.Title == "File");
            if (fileMenu != null)
            {
                Console.WriteLine(fileMenu.Title);
                foreach(var m in fileMenu.Children)
                {
                    Console.WriteLine($"---{m.Title}");
                }
            }


        }


        

    }
}


class Program
{
    static void Main(string[] args)
    {
        Exp exp = new Exp();
        exp.exp();
    }
}