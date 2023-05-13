using System;
using System.Collections.Generic;

namespace OneDaily.Models;

public partial class User
{
    public long UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Username { get; set; } = null!;

    public string? Email { get; set; }

    public string PasswordHash { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    public string? Bio { get; set; }

    public string? ProfilePicture { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? LastLogin { get; set; }

    public virtual ICollection<Match> MatchUser1s { get; set; } = new List<Match>();

    public virtual ICollection<Match> MatchUser2s { get; set; } = new List<Match>();

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual ICollection<UserInterest> UserInterests { get; set; } = new List<UserInterest>();
}
