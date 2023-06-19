using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial3.Database.Entity;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Student> students { get; set; } = new();
    public List<Enrollment> enrollments { get; set; } = new();
}
