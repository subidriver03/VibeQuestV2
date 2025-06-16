using VibeQuest.Core.Models;

namespace VibeQuest.Core.Interfaces;

public interface IJournalService
{
    Task<IEnumerable<JournalEntry>> GetEntriesAsync(string userId);
    Task AddEntryAsync(JournalEntry entry);
}
