using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial3.Database.Entity;
public class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Course> courses { get; set; } = new();
    public List<Enrollment> enrollments { get; set; } = new();
    
}

