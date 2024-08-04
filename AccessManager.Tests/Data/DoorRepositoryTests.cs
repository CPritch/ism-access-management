﻿using AccessManager.Data;

namespace AccessManager.Tests.Data
{
    public class DoorRepositoryTests
    {
        private readonly DoorRepository _repository;

        public DoorRepositoryTests() 
        {
            _repository = new DoorRepository();
        }

        [Fact]
        public void GetAllDoors_ReturnsAllDoors()
        {
            var doors = _repository.GetAllDoors();
            Assert.Equal(4, doors.Count); //Be careful as number of doors is assumed to be 4
        }

        [Fact]
        public void GetDoorById_ReturnsCorrectDoor()
        {
            var door = _repository.GetDoorById(1);
            Assert.NotNull(door);
            Assert.Equal("Front Entrance", door.Name);
        }

        [Fact]
        public void GetDoorById_ThrowsKeyNotFoundException_ForInvalidId()
        {
            Assert.Throws<KeyNotFoundException>(() => _repository.GetDoorById(999));
        }

        [Fact]
        public void UpdateDoor_UpdatesDoorState()
        {
            var originalDoor = _repository.GetDoorById(1);
            originalDoor.UpdateState(isOpen: true, isLocked: false, isArmed: true);

            _repository.UpdateDoor(originalDoor);

            var retrievedDoor = _repository.GetDoorById(1);
            Assert.True(retrievedDoor.IsOpen);
            Assert.False(retrievedDoor.IsLocked);
            Assert.True(retrievedDoor.IsArmed);
        }
    }
}