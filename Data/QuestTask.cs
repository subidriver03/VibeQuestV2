namespace VibeQuestV2.Data
{
    public class QuestTask
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; }

        public string Title { get; set; } = string.Empty;
        public string SkillCategory { get; set; } = string.Empty;
        public int Difficulty { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int XP => Difficulty * 10;
    }
}
