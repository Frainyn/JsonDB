using Microsoft.EntityFrameworkCore;
using Tutorial.Database;
using Tutorial2.Database.Entity;

namespace Tutorial;


class Option
{
    //public void Option1()
    //{
    //    using (ApplicationContext db = new ApplicationContext())
    //    {
    //        Company google = new Company { Name = "Google" };
    //        Company micrasoft = new Company { Name = "Micrasoft" };
    //        UserProfile user1 = new UserProfile { Name = "Tom", Company = google };
    //        UserProfile user2 = new UserProfile { Name = "Bob", Company = google };
    //        UserProfile user3 = new UserProfile { Name = "Sam", Company = micrasoft };
    //        UserProfile user4 = new UserProfile { Name = "Boris" };


    //        db.Companies.AddRange(google, micrasoft);
    //        db.Users.AddRange(user1, user2, user3, user4);
    //        db.SaveChanges();

    //        foreach (var user in db.Users.ToList())
    //        {
    //            if (user.Company?.Name == null)
    //                Console.WriteLine($"{user.Name} безработный");

    //            else
    //                Console.WriteLine($"{user.Name} работает в {user.Company?.Name}");
    //        }
    //    }
    //}
    //public void Option2()
    //{
    //    using (ApplicationContext db = new ApplicationContext())
    //    {
    //        Company google = new Company { Name = "Google" };
    //        Company micrasoft = new Company { Name = "Micrasoft" };
    //        db.Companies.AddRange(google, micrasoft);
    //        db.SaveChanges();


    //        UserProfile user1 = new UserProfile { Name = "Tom", CompanyId = google.Id };
    //        UserProfile user2 = new UserProfile { Name = "Bob", CompanyId = micrasoft.Id };
    //        UserProfile user3 = new UserProfile { Name = "Sam", CompanyId = micrasoft.Id };
    //        UserProfile user4 = new UserProfile { Name = "Boris" };
    //        db.Users.AddRange(user1, user2, user3, user4);
    //        db.SaveChanges();


    //        foreach (var user in db.Users.ToList())
    //        {
    //            if (user.Company?.Name == null)
    //                Console.WriteLine($"{user.Name} безработный");

    //            else
    //                Console.WriteLine($"{user.Name} работает в {user.Company?.Name}");
    //        }
    //    }
    //}
    //public void Option3()
    //{
    //    using (ApplicationContext db = new ApplicationContext())
    //    {
    //        UserProfile user1 = new UserProfile { Name = "Tom" };
    //        UserProfile user2 = new UserProfile { Name = "Bob" };
    //        UserProfile user3 = new UserProfile { Name = "Sam" };
    //        UserProfile user4 = new UserProfile { Name = "Boris" };

    //        Company google = new Company { Name = "Google", Users = { user1, user2 } };
    //        Company micrasoft = new Company { Name= "Micrasoft", Users = {user3 } };

    //        db.Companies.AddRange(google, micrasoft);
    //        db.Users.AddRange (user1, user2, user3, user4);
    //        db.SaveChanges();


    //        foreach (var user in db.Users.ToList())
    //        {
    //            if (user.Company?.Name == null)
    //                Console.WriteLine($"{user.Name} безработный");

    //            else
    //                Console.WriteLine($"{user.Name} работает в {user.Company?.Name}");
    //        }

    //    };
    //}
    //public void Option4()
    //{
    //    using (ApplicationContext db = new ApplicationContext())
    //    {
           

    //        Company google = new Company { Name = "Google" };
    //        Company micrasoft = new Company { Name = "Micrasoft" };
    //        db.companies.AddRange(google, micrasoft);
    //        db.SaveChanges();





    //        UserProfile user1 = new UserProfile { Name = "Tom", Company = micrasoft };
    //        UserProfile user2 = new UserProfile { Name = "Bob", Company = google };
    //        UserProfile user3 = new UserProfile { Name = "Sam", Company = micrasoft };
    //        UserProfile user4 = new UserProfile { Name = "Boris", Company = google };

    //        db.users.AddRange(user1, user2, user3, user4);
    //        db.SaveChanges();

    //        var users = db.users.ToList();
    //        foreach (var user in users) Console.WriteLine($"{user.Name} работает в {user.Company?.Name}");

    //        var comp = db.Companies.FirstOrDefault();
    //        if(comp!=null) db.Companies.Remove(comp);
    //        db.SaveChanges();
    //        Console.WriteLine("\nСписок пользователей полсе удаления компаний");

    //        users =db.Users.ToList();
    //        foreach (var user in users) Console.WriteLine($"{user.Name} работает в {user.Company?.Name}");

    //    };
    //}

    public void Option5()
    {
        using(ApplicationContext db = new ApplicationContext())
        {
            //добавление данных
            Company google = new Company { Name = "Google" };
            Company micrasoft = new Company { Name = "Micrasoft" };
            db.companies.AddRange(google, micrasoft);

            //добавление данных 
            User user1 = new User { Login = "maximch", Password = "1234" };
            User user2 = new User { Login = "ivan", Password = "1234" };
            db.users.AddRange(user1, user2);

            //добавление данных
            UserProfile profile1 = new UserProfile { Age = 22, Name = "Max", User = user1, Company =  google};
            UserProfile profile2 = new UserProfile { Age = 18, Name = "Ivan", User = user2, Company =  micrasoft};
            db.userProfiles.AddRange(profile1, profile2);

            db.SaveChanges();

            //Перечисление и принт
            foreach(User usero in db.users.Include(u => u.Profile))
            {
                Console.WriteLine($"Name: {usero.Profile.Name} | Age: {usero.Profile.Age} | Company: {usero.Profile.Company?.Name}");
                Console.WriteLine($"Login: {usero.Login} | Password: {usero.Password} \n");
            }

            //редактирование
            User user = db.users.FirstOrDefault();
            if(user != null)
            {
                user.Password = "lo";
                db.SaveChanges();
            }

            UserProfile profile = db.userProfiles.FirstOrDefault(p => p.User.Login == "ivan");
            if (profile != null)
            {
                profile.Name = "Max2";
                db.SaveChanges();
            }

            //Перечисление и принт
            foreach (User usero in db.users.Include(u => u.Profile))
            {
                Console.WriteLine($"Name: {usero.Profile.Name} | Age: {usero.Profile.Age} | Company: {usero.Profile.Company?.Name}");
                Console.WriteLine($"Login: {usero.Login} | Password: {usero.Password} \n");
            }

            //удаление
            //if(user != null)
            //{
            //    db.users.Remove(user);
            //    db.SaveChanges();
            //}

            //if(profile != null)
            //{
            //    db.userProfiles.Remove(profile);
            //    db.SaveChanges();
            //}

            //foreach (User usero in db.users.Include(u => u.Profile))
            //{
            //    //Console.WriteLine($"Name: {usero.Profile.Name} | Age: {usero.Profile.Age} | Company: {usero.Profile.Company?.Name}");
            //    Console.WriteLine($"Login: {usero.Login} | Password: {usero.Password} \n");
            //}

        }
    }
}


class Program 
{ 
    static void Main(string[] args)
    {
        Option op = new Option();
        op.Option5();
        

        
    }
}