using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial2.Database.Entity;

public class UserProfile
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int CompanyId { get; set; }
    public Company? Company { get; set; } 


}
