using MeetupAPI.Services.Meetups.Context.Entities;

using Microsoft.EntityFrameworkCore;

namespace MeetupAPI.Services.Meetups.Context;

public class MeetupsDbContext : DbContext
{
    public DbSet<MeetupRow> Meetups { get; set; } = null!;

    public MeetupsDbContext(DbContextOptions<MeetupsDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        BuildMeetupRow(modelBuilder);
    }

    private static void BuildMeetupRow(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<MeetupRow>()
            .HasIndex(m => m.Id);
        modelBuilder
            .Entity<MeetupRow>()
            .Property(m => m.Title);
        modelBuilder
            .Entity<MeetupRow>()
            .Property(m => m.Description);
        modelBuilder
            .Entity<MeetupRow>()
            .Property(m => m.SpeakerId);
        modelBuilder
            .Entity<MeetupRow>()
            .Property(m => m.Date);
        modelBuilder
            .Entity<MeetupRow>()
            .Property(m => m.DateCreated);
        modelBuilder
           .Entity<MeetupRow>()
           .Property(m => m.DateUpdated);

        modelBuilder
            .Entity<MeetupRow>()
            .HasIndex(e => new { e.Id})
            .IsUnique();
    }
}
