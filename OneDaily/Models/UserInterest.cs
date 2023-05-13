using System;
using System.Collections.Generic;

namespace OneDaily.Models;

public partial class UserInterest
{
    public long UserInterestId { get; set; }

    public long UserId { get; set; }

    public long InterestId { get; set; }

    public virtual Interest Interest { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
