using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace VibeQuestV2.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string HeroName { get; set; } = string.Empty;

        public SkillProgress SkillProgress { get; set; } = new();
        public ICollection<QuestTask> Tasks { get; set; } = new List<QuestTask>();
        public ICollection<JournalEntry> JournalEntries { get; set; } = new List<JournalEntry>();
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string HeroClass { get; set; } = "Adventurer"; // default
        public string AvatarUrl { get; set; } = "/images/avatars/avatar1.jpeg";


    }
}
