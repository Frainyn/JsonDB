using Microsoft.EntityFrameworkCore;
using Tutorial3.Database;
using Tutorial3.Database.Entity;

namespace tutor;


class exp 
{ 
    public void Ex()
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            Student user1 = new Student { Name = "Tom" };
            Student user2 = new Student { Name = "Alice" };
            Student user3 = new Student { Name = "Bob" };
            db.students.AddRange(user1, user2, user3);

            Course algoritgms  = new Course {  Name = "Алгоритм" };
            Course basics = new Course { Name = "Основы программирования" };
            db.courses.AddRange(algoritgms, basics);

            //user1.courses.Add(algoritgms);
            //user1.courses.Add(basics);
            //user2.courses.Add(basics);
            //user3.courses.Add(algoritgms);

            //db.SaveChanges();
            
            //var courses = db.courses.Include(c=>c.students).ToList();

            //foreach (var course in courses)
            //{
            //    Console.WriteLine($"Course: {course.Name}");
            //    // выводим всех студентов для данного кура
            //    foreach (Student s in course.students)
            //        Console.WriteLine($"Name: {s.Name}");
            //    Console.WriteLine("-------------------");
            //}

            ////удаление
            //Student? userOne = db.students.Include(s=>s.courses).FirstOrDefault(s=>s.Name == "Tom");
            //Course? algoritgm = db.courses.FirstOrDefault(c => c.Name == "Алгоритм");
            //Course? bas = db.courses.FirstOrDefault(c => c.Name == "Основы программирования");
            //if (userOne != null && algoritgm != null && bas != null)
            //{
            //    userOne.courses.Remove(algoritgm);
            //    userOne.courses.Remove(basics);
            //    db.SaveChanges();
            //}

            //foreach (var course in courses)
            //{
            //    Console.WriteLine($"Course: {course.Name}");
            //    // выводим всех студентов для данного кура
            //    foreach (Student s in course.students)
            //        Console.WriteLine($"Name: {s.Name}");
            //    Console.WriteLine("-------------------");
            //}

            Console.WriteLine("|________________________________________|");

            user1.enrollments.Add(new Enrollment { Course = algoritgms });
            user1.courses.Add(basics);
            user2.enrollments.Add(new Enrollment { Course = algoritgms, Mark = 4 });
            user3.enrollments.Add(new Enrollment { Course = basics, Mark = 5 });

            db.SaveChanges();

            var courses = db.courses.Include(c => c.students).ToList();
            foreach (var course in courses)
            {
                Console.WriteLine($"Course: {course.Name}");
                foreach (Student s in course.students)
                {
                    Console.WriteLine($"Name: {s.Name}");
                }
                Console.WriteLine("----------------------");
            }

            Console.WriteLine("|________________________________________|");

          
            foreach (var c in courses)
            {
                Console.WriteLine($"Course: {c.Name}");
                foreach (var s in c.enrollments)
                {
                    Console.WriteLine($"Name: {s.Student.Name}  Mark: {s.Mark}");
                }
                Console.WriteLine("----------------------");
            }

        }
    }

    
}




class Program
{
    static void Main(string[] args)
    {
        exp exp = new exp();
        exp.Ex();



    }
}