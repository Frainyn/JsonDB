using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial2.Database.Entity;

public class Company
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public List<UserProfile> Users { get; set; } = new();
}
