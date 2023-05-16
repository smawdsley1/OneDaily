using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OneDaily.Controllers;
using OneDaily.Models;

namespace OneDaily.Context
{
    public partial class OneDailyContext : DbContext
    {
        public OneDailyContext()
        {
        }

        public OneDailyContext(DbContextOptions<OneDailyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Conversation> Conversations { get; set; } = null!;
        public virtual DbSet<Interest> Interests { get; set; } = null!;
        public virtual DbSet<Match> Matches { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserInterest> UserInterests { get; set; } = null!;
        public DbSet<PotentialMatch> MatchedUserPairs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=cs-10\\SQLEXPRESS;Database=OneDaily;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conversation>(entity =>
            {
                modelBuilder.Entity<PotentialMatch>().HasNoKey().ToView(null);

                entity.ToTable("Conversation");

                entity.Property(e => e.StartTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Conversations)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Conversat__match__47DBAE45");
            });

            modelBuilder.Entity<Interest>(entity =>
            {
                entity.ToTable("Interest");

                entity.HasIndex(e => e.InterestName, "UQ__Interest__DFDA5A9D75B96092")
                    .IsUnique();

                entity.Property(e => e.InterestName).HasMaxLength(100);
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.ToTable("Match");

                entity.Property(e => e.MatchDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MatchStatus).HasMaxLength(50);

                entity.Property(e => e.User1Status).HasColumnName("user1_status");

                entity.Property(e => e.User2Status).HasColumnName("user2_status");

                entity.HasOne(d => d.User1)
                    .WithMany(p => p.MatchUser1s)
                    .HasForeignKey(d => d.User1Id)
                    .HasConstraintName("FK_Match_User1");

                entity.HasOne(d => d.User1StatusNavigation)
                    .WithMany(p => p.MatchUser1StatusNavigations)
                    .HasForeignKey(d => d.User1Status)
                    .HasConstraintName("FK_Match_Status");

                entity.HasOne(d => d.User2)
                    .WithMany(p => p.MatchUser2s)
                    .HasForeignKey(d => d.User2Id)
                    .HasConstraintName("FK_Match_User");

                entity.HasOne(d => d.User2StatusNavigation)
                    .WithMany(p => p.MatchUser2StatusNavigations)
                    .HasForeignKey(d => d.User2Status)
                    .HasConstraintName("FK_Match_Status1");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.ContentType).HasMaxLength(50);

                entity.Property(e => e.TimeStamp).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Conversation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ConversationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Messages__conver__4BAC3F29");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Messages__sender__4CA06362");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.StatusId).ValueGeneratedNever();

                entity.Property(e => e.Status1)
                    .HasMaxLength(50)
                    .HasColumnName("Status");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Email, "UQ__Users__AB6E6164232B07E4")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "UQ__Users__F3DBC57249F9C6C8")
                    .IsUnique();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PasswordHash).HasMaxLength(255);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<UserInterest>(entity =>
            {
                entity.ToTable("UserInterest");

                entity.HasOne(d => d.Interest)
                    .WithMany(p => p.UserInterests)
                    .HasForeignKey(d => d.InterestId)
                    .HasConstraintName("FK__User_Inte__inter__403A8C7D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserInterests)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User_Inte__user___3F466844");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}