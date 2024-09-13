using System;
using System.Collections.Generic;

namespace WebApplication9.Models;

public partial class Balance
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public string? Money { get; set; }

    public string? History { get; set; }

    public virtual User? IdUserNavigation { get; set; } = null!;
}
