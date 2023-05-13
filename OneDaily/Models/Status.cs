using System;
using System.Collections.Generic;

namespace OneDaily.Models;

public partial class Status
{
    public long StatusId { get; set; }

    public string Status1 { get; set; } = null!;

    public virtual ICollection<Match> MatchUser1StatusNavigations { get; set; } = new List<Match>();

    public virtual ICollection<Match> MatchUser2StatusNavigations { get; set; } = new List<Match>();
}
