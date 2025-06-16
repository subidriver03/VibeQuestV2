using Moq;
using Microsoft.EntityFrameworkCore;
using VibeQuest.Core.Models;
using VibeQuest.Infrastructure.Data;
using VibeQuest.Infrastructure.Services;
using Xunit;

public class ProfileServiceTests
{
    [Fact]
    public async Task GetProfileAsync_ReturnsProfile()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("test").Options;
        using var context = new AppDbContext(options);
        context.HeroProfiles.Add(new HeroProfile { Id = 1, UserId = "u" });
        await context.SaveChangesAsync();

        var service = new ProfileService(context);
        var profile = await service.GetProfileAsync("u");
        Assert.Equal(1, profile.Id);
    }
}
