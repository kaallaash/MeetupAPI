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
            .HasIndex(s => s.Id);
        modelBuilder
            .Entity<SpeakerRow>()
            .Property(s => s.Name);
        modelBuilder
            .Entity<SpeakerRow>()
            .Property(s => s.LastName);
        modelBuilder
            .Entity<SpeakerRow>()
            .Property(s => s.Phone);
        modelBuilder
            .Entity<SpeakerRow>()
            .Property(s => s.DateCreated);
        modelBuilder
           .Entity<SpeakerRow>()
           .Property(s => s.DateUpdated);

        modelBuilder
            .Entity<SpeakerRow>()
            .HasIndex(s => new { s.Id, s.Phone })
            .IsUnique();
    }
}
