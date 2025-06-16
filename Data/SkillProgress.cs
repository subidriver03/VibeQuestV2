namespace VibeQuestV2.Data
{
    public class SkillProgress
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; }

        public int Mind { get; set; }
        public int Body { get; set; }
        public int Creativity { get; set; }
        public int Focus { get; set; }

        public int TotalXP => Mind + Body + Creativity + Focus;
    }
}
