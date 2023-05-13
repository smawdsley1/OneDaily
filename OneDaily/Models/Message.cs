using System;
using System.Collections.Generic;

namespace OneDaily.Models;

public partial class Message
{
    public long MessageId { get; set; }

    public long ConversationId { get; set; }

    public long UserId { get; set; }

    public string? Content { get; set; }

    public string? ContentType { get; set; }

    public DateTime? TimeStamp { get; set; }

    public virtual Conversation Conversation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
