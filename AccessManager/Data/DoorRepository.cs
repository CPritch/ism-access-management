namespace AccessManager.Data
{
    public class DoorRepository : IDoorRepository
    {
        private List<Door> _doors = new List<Door>
        {
            new Door(id: 1, name: "Front Entrance"),
            new Door(id: 2, name: "Side Entrance" ),
            new Door(id: 3, name: "Rear Entrance" ),
            new Door(id: 4, name: "Secure Locker", isLocked: true),
        };

        public List<Door> GetAllDoors() => _doors;

        public Door GetDoorById(int id)
        {
            Door? door = _doors.FirstOrDefault(d => d.Id == id);
            if (door == null)
            {
                throw new KeyNotFoundException($"Door with ID {id} not found.");
            }
            return door;
        }

        public void UpdateDoor(Door updatedDoor) // Yes this is redundant but would be where I'd perform a DB transaction.
        {
            int index = _doors.FindIndex(d => d.Id == updatedDoor.Id);
            if (index != -1)
            {
                _doors[index] = updatedDoor;
            }
        }
    }
}
