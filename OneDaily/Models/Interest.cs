using System;
using System.Collections.Generic;

namespace OneDaily.Models;

public partial class Interest
{
    public long InterestId { get; set; }

    public string InterestName { get; set; } = null!;

    public virtual ICollection<UserInterest> UserInterests { get; set; } = new List<UserInterest>();
}
