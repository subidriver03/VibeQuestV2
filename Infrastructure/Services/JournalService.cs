using Microsoft.EntityFrameworkCore;
using VibeQuest.Core.Interfaces;
using VibeQuest.Core.Models;
using VibeQuest.Infrastructure.Data;

namespace VibeQuest.Infrastructure.Services;

public class JournalService(AppDbContext db) : IJournalService
{
    public async Task<IEnumerable<JournalEntry>> GetEntriesAsync(string userId)
    {
        return await db.JournalEntries.Where(j => j.UserId == userId)
            .OrderByDescending(j => j.Timestamp)
            .ToListAsync();
    }

    public async Task AddEntryAsync(JournalEntry entry)
    {
        db.JournalEntries.Add(entry);
        await db.SaveChangesAsync();
    }
}
