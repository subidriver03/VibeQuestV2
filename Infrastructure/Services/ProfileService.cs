using Microsoft.EntityFrameworkCore;
using VibeQuest.Core.Interfaces;
using VibeQuest.Core.Models;
using VibeQuest.Infrastructure.Data;

namespace VibeQuest.Infrastructure.Services;

public class ProfileService(AppDbContext db) : IProfileService
{
    public async Task<HeroProfile> GetProfileAsync(string userId)
    {
        return await db.HeroProfiles.FirstAsync(p => p.UserId == userId);
    }

    public async Task UpdateProfileAsync(HeroProfile profile)
    {
        db.HeroProfiles.Update(profile);
        await db.SaveChangesAsync();
    }
}
