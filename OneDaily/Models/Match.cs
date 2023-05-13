using System;
using System.Collections.Generic;

namespace OneDaily.Models;

public partial class Match
{


    public long MatchId { get; set; }

    public long? User1Id { get; set; }

    public long? User2Id { get; set; }

    public DateTime? MatchDate { get; set; }

    public string? MatchStatus { get; set; }

    public long? User1Status { get; set; }

    public long? User2Status { get; set; }

    public virtual ICollection<Conversation> Conversations { get; set; } = new List<Conversation>();

    public virtual User? User1 { get; set; }

    public virtual Status? User1StatusNavigation { get; set; }

    public virtual User? User2 { get; set; }

    public virtual Status? User2StatusNavigation { get; set; }
}
