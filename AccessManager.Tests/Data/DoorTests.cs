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
    }
}
