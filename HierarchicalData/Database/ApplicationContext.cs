using HierarchicalData.Database.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchicalData.Database;

public class ApplicationContext : DbContext
{

    public DbSet<MenuItem> MenuItems { get; set; } = null!;

    public ApplicationContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;user=root;password=123;database=tutor;", new MySqlServerVersion(new Version(8, 10, 28)));
    }
}
