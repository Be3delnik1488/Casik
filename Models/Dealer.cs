using System;
using System.Collections.Generic;

namespace WebApplication9.Models;

public partial class Dealer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Game>? Games { get; set; } = new List<Game>();
}
