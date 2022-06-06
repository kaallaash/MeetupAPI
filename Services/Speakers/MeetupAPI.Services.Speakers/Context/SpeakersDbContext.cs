using MeetupAPI.Services.Speakers.Context.Entities;

using Microsoft.EntityFrameworkCore;

namespace MeetupAPI.Services.Speakers.Context;

public class SpeakersDbContext : DbContext
{
    public DbSet<SpeakerRow> Speakers { get; set; } = null!;

    public SpeakersDbContext(DbContextOptions<SpeakersDbContext> options) 
        : base(options)
    {
    }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        BuildSpeakerRow(modelBuilder);
    }

    private static void BuildSpeakerRow(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<SpeakerRow>()
            .HasIndex(e => e.Id);
        modelBuilder
            .Entity<SpeakerRow>()
            .Property(e => e.Name);
        modelBuilder
            .Entity<SpeakerRow>()
            .Property(e => e.LastName);
        modelBuilder
            .Entity<SpeakerRow>()
            .Property(e => e.Phone);
        modelBuilder
            .Entity<SpeakerRow>()
            .Property(e => e.DateCreated);
        modelBuilder
           .Entity<SpeakerRow>()
           .Property(e => e.DateUpdated);

        modelBuilder
            .Entity<SpeakerRow>()
            .HasIndex(e => new { e.Id, e.Phone })
            .IsUnique();
    }

}
