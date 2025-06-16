using Microsoft.EntityFrameworkCore;

namespace VibeQuestV2.Data
{
    public class TaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all tasks for a user
        public async Task<List<QuestTask>> GetTasksAsync(string userId)
        {
            return await _context.QuestTasks
                .Where(t => t.ApplicationUserId == userId)
                .ToListAsync();
        }

        // Add a new task
        public async Task AddTaskAsync(QuestTask task)
        {
            _context.QuestTasks.Add(task);
            await _context.SaveChangesAsync();
        }

        // Mark task as completed and award XP
        public async Task CompleteTaskAsync(int taskId, string userId)
        {
            var task = await _context.QuestTasks.FindAsync(taskId);
            if (task == null || task.IsCompleted || task.ApplicationUserId != userId) return;

            task.IsCompleted = true;

            var user = await _context.Users
                .Include(u => u.SkillProgress)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                int xp = task.Difficulty * 10;
                switch (task.SkillCategory.ToLower())
                {
                    case "mind": user.SkillProgress.Mind += xp; break;
                    case "body": user.SkillProgress.Body += xp; break;
                    case "creativity": user.SkillProgress.Creativity += xp; break;
                    case "focus": user.SkillProgress.Focus += xp; break;
                }

                await _context.SaveChangesAsync();
            }
        }

        // Add journal entry and boost Mind XP
        public async Task AddJournalEntryAsync(JournalEntry entry, string userId)
        {
            entry.ApplicationUserId = userId;
            entry.Timestamp = DateTime.Now;

            _context.JournalEntries.Add(entry);

            var user = await _context.Users
                .Include(u => u.SkillProgress)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                user.SkillProgress.Mind += 5;
                await _context.SaveChangesAsync();
            }
        }

        // Get journal entries for a user
        public async Task<List<JournalEntry>> GetJournalEntriesAsync(string userId)
        {
            return await _context.JournalEntries
                .Where(j => j.ApplicationUserId == userId)
                .OrderByDescending(j => j.Timestamp)
                .ToListAsync();
        }


        // Spend XP (from highest pool down)
        public async Task<bool> SpendXPAsync(string userId, int amount)
        {
            var user = await _context.Users
                .Include(u => u.SkillProgress)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null || user.SkillProgress.TotalXP < amount)
                return false;

            var pools = new List<(string Skill, int XP)>
            {
                ("Mind", user.SkillProgress.Mind),
                ("Body", user.SkillProgress.Body),
                ("Creativity", user.SkillProgress.Creativity),
                ("Focus", user.SkillProgress.Focus)
            }.OrderByDescending(p => p.XP).ToList();

            foreach (var (skill, _) in pools)
            {
                int available = GetSkillXP(user.SkillProgress, skill);
                int toDeduct = Math.Min(available, amount);
                SetSkillXP(user.SkillProgress, skill, available - toDeduct);
                amount -= toDeduct;

                if (amount <= 0) break;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        private int GetSkillXP(SkillProgress progress, string skill) =>
            skill switch
            {
                "Mind" => progress.Mind,
                "Body" => progress.Body,
                "Creativity" => progress.Creativity,
                "Focus" => progress.Focus,
                _ => 0
            };

        private void SetSkillXP(SkillProgress progress, string skill, int value)
        {
            switch (skill)
            {
                case "Mind": progress.Mind = value; break;
                case "Body": progress.Body = value; break;
                case "Creativity": progress.Creativity = value; break;
                case "Focus": progress.Focus = value; break;
            }
        }
    }
}
