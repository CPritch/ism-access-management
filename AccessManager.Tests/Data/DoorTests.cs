using AccessManager.Data;
using Xunit;

namespace AccessManager.Tests.Data
{
    public class DoorTests
    {
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            var door = new Door(1, "Test Door");

            Assert.Equal(1, door.Id);
            Assert.Equal("Test Door", door.Name);
            Assert.False(door.IsOpen);
            Assert.False(door.IsLocked);
            Assert.False(door.IsAlarmed);
        }
    }
}
