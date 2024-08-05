using AccessManager.Data;

namespace AccessManager.Tests.Data
{
    public class DoorTests
    {
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            var door = new Door(id: 1, name: "Test Door");

            Assert.Equal(1, door.Id);
            Assert.Equal("Test Door", door.Name);
            Assert.False(door.IsOpen);
            Assert.False(door.IsLocked);
            Assert.False(door.IsAlarmed);
        }

        [Fact]
        public void UpdateState_UpdatesPropertiesCorrectly()
        {
            var door = new Door(id: 1, name: "Test Door");
            door.UpdateState(isOpen: true, isLocked: true, isAlarmed: true);

            Assert.True(door.IsOpen);
            Assert.True(door.IsLocked);
            Assert.True(door.IsAlarmed);
        }

        [Fact]
        public void Constructor_ThrowsArgumentException_ForInvalidId()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Door(0, "Test Door"));
        }

        [Fact]
        public void Constructor_ThrowsArgumentException_ForEmptyName()
        {
            Assert.Throws<ArgumentException>(() => new Door(1, ""));
        }

        [Fact]
        public void Constructor_ThrowsArgumentException_ForTooLongName()
        {
            var longName = new string('a', 51);
            Assert.Throws<ArgumentException>(() => new Door(1, longName));
        }

        [Theory]
        [InlineData(true, false, false)]
        [InlineData(false, true, false)]
        [InlineData(false, false, true)]
        public void UpdateState_UpdatesPropertiesCorrectly_MultipleScenarios(bool isOpen, bool isLocked, bool isAlarmed)
        {
            var door = new Door(1, "Test Door");
            door.UpdateState(isOpen, isLocked, isAlarmed);

            Assert.Equal(isOpen, door.IsOpen);
            Assert.Equal(isLocked, door.IsLocked);
            Assert.Equal(isAlarmed, door.IsAlarmed);
        }
    }
}
