using Microsoft.EntityFrameworkCore;
using VibeQuest.Core.Interfaces;
using VibeQuest.Core.Models;
using VibeQuest.Infrastructure.Data;

namespace VibeQuest.Infrastructure.Services;

public class QuestService(AppDbContext db) : IQuestService
{
    public async Task<IEnumerable<Quest>> GetQuestsAsync(string userId)
    {
        return await db.Quests.Where(q => q.UserId == userId).ToListAsync();
    }

    public async Task AddQuestAsync(Quest quest)
    {
        db.Quests.Add(quest);
        await db.SaveChangesAsync();
    }

    public async Task CompleteQuestAsync(int questId)
    {
        var quest = await db.Quests.FindAsync(questId);
        if (quest != null)
        {
            quest.IsCompleted = true;
            await db.SaveChangesAsync();
        }
    }
}
