using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial2.Database.Entity;

namespace Tutorial2.Database.Entity;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;

    public UserProfile Profile { get; set; } = null!;
}
