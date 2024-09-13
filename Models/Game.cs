using System;
using System.Collections.Generic;

namespace WebApplication9.Models;

public partial class Game
{
    public int Id { get; set; }

    public int IdType { get; set; }

    public int IdDealer { get; set; }

    public string? TimeBegin { get; set; }

    public string? TimeEnd { get; set; }

    public virtual Dealer? IdDealerNavigation { get; set; } = null!;

    public virtual TypeBook? IdTypeNavigation { get; set; } = null!;

    public virtual ICollection<Player>? Players { get; set; } = new List<Player>();
}
