using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VibeQuestV2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SkillProgress> SkillProgresses => Set<SkillProgress>();
        public DbSet<QuestTask> QuestTasks => Set<QuestTask>();
        public DbSet<JournalEntry> JournalEntries => Set<JournalEntry>();
    }
}
