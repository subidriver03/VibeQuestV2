using VibeQuestV2.Data;
using Xunit;

namespace VibeQuestV2.Tests
{
    public class HeroCustomizationStateTests
    {
        [Fact]
        public void CanSave_ShouldBeFalse_WhenNothingChanges()
        {
            var state = new HeroCustomizationState("/img.png", "Mind Mage");
            Assert.False(state.CanSave);
        }

        [Fact]
        public void CanSave_ShouldBeTrue_WhenAvatarChanges()
        {
            var state = new HeroCustomizationState("/img.png", "Mind Mage");
            state.UpdateAvatar("/new.png");
            Assert.True(state.CanSave);
        }

        [Fact]
        public void CanSave_ShouldBeTrue_WhenHeroClassChanges()
        {
            var state = new HeroCustomizationState("/img.png", "Mind Mage");
            state.UpdateHeroClass("Focus Ranger");
            Assert.True(state.CanSave);
        }
    }
}
