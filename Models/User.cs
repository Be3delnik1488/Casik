using System;
using System.Collections.Generic;

namespace WebApplication9.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Balance>? Balances { get; set; } = new List<Balance>();

    public virtual ICollection<Player>? Players { get; set; } = new List<Player>();
}
