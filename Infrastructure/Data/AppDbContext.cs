using Microsoft.EntityFrameworkCore;
using VibeQuest.Core.Models;

namespace VibeQuest.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<HeroProfile> HeroProfiles => Set<HeroProfile>();
    public DbSet<Quest> Quests => Set<Quest>();
    public DbSet<JournalEntry> JournalEntries => Set<JournalEntry>();
}
