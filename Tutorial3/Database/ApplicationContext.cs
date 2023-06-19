using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial3.Database.Entity;

namespace Tutorial3.Database;

public class ApplicationContext : DbContext
{
    public DbSet<Course> courses { get; set; }
    public DbSet<Student> students { get; set; }
    public ApplicationContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;user=root;password=123;database=tutor;", new MySqlServerVersion(new Version(8, 10, 28)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ////Добавление промежуточной таблицы
        //modelBuilder.Entity<Course>()
        //    .HasMany(c => c.students)
        //    .WithMany(s => s.courses)
        //    .UsingEntity(j => j.ToTable("Enrollments"));


        modelBuilder
            .Entity<Course>()
            .HasMany(c => c.students)
            .WithMany(s => s.courses)
            .UsingEntity<Enrollment>(
                j => j
                    .HasOne(pt => pt.Student)
                    .WithMany(t => t.enrollments)
                    .HasForeignKey(pt => pt.StudentId), // связь с таблицей Students через StudentId
                j => j
                    .HasOne(pt => pt.Course)
                    .WithMany(p => p.enrollments)
                    .HasForeignKey(pt => pt.CourseId), // связь с таблицей Courses через CourseId
                j =>
                {
                    j.Property(pt => pt.Mark).HasDefaultValue(3);
                    j.HasKey(t => new { t.CourseId, t.StudentId });
                    j.ToTable("Enrollments");
                });
    }
}
