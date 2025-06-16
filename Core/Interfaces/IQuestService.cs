using VibeQuest.Core.Models;

namespace VibeQuest.Core.Interfaces;

public interface IQuestService
{
    Task<IEnumerable<Quest>> GetQuestsAsync(string userId);
    Task AddQuestAsync(Quest quest);
    Task CompleteQuestAsync(int questId);
}
