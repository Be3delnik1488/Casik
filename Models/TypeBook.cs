using System;
using System.Collections.Generic;

namespace WebApplication9.Models;

public partial class TypeBook
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Rules { get; set; }

    public virtual ICollection<Game>? Games { get; set; } = new List<Game>();
}
