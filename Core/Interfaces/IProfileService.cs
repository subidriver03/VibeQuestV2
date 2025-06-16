using VibeQuest.Core.Models;

namespace VibeQuest.Core.Interfaces;

public interface IProfileService
{
    Task<HeroProfile> GetProfileAsync(string userId);
    Task UpdateProfileAsync(HeroProfile profile);
}
