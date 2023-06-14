using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial2.Database.Entity;

namespace Tutorial.Database;

public class ApplicationContext : DbContext
{
    public DbSet<User> users { get; set; } = null!;
    public DbSet<Company> companies { get; set; } = null!;
    public DbSet<UserProfile> userProfiles { get; set; } = null!;
    public ApplicationContext() 
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;user=root;password=123;database=tutor;", new MySqlServerVersion(new Version(8, 10, 28)));
    }
    protected override void OnModelCreating(ModelBuilder ModelBuilder)
    {
        ModelBuilder
            .Entity<User>()
            .HasOne(u => u.Profile)
            .WithOne(p => p.User)
            .HasForeignKey<UserProfile>(p => p.UserId);
    }




}
