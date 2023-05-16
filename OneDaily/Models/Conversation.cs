using System;
using System.Collections.Generic;

namespace OneDaily.Models;

public partial class Conversation
{
    public long ConversationId { get; set; }

    public long? MatchId { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public virtual Match Match { get; set; } = null!;

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}