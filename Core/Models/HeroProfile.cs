namespace VibeQuest.Core.Models;

public class HeroProfile
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string HeroName { get; set; } = string.Empty;
    public string HeroClass { get; set; } = string.Empty;
    public string? AvatarUrl { get; set; }
    public int Experience { get; set; }
    public int Streak { get; set; }
    public int HeroCoins { get; set; }
}
