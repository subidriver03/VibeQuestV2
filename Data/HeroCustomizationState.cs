namespace VibeQuestV2.Data;

public class HeroCustomizationState(string? avatarUrl, string? heroClass)
{
    public string? AvatarUrl { get; private set; } = avatarUrl;
    public string? HeroClass { get; private set; } = heroClass;

    public string? OriginalAvatarUrl { get; } = avatarUrl;
    public string? OriginalHeroClass { get; } = heroClass;

    public bool CanSave =>
        Normalize(AvatarUrl) != Normalize(OriginalAvatarUrl)
        || HeroClass != OriginalHeroClass;

    public void UpdateAvatar(string? avatar)
    {
        AvatarUrl = avatar;
    }

    public void UpdateHeroClass(string? heroClass)
    {
        HeroClass = heroClass;
    }

    private static string Normalize(string? val) =>
        val?.Trim().ToLowerInvariant() ?? "";
}
