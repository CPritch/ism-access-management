namespace AccessManager.Data
{
    public class DoorRepository : IDoorRepository
    {
        private List<Door> _doors = new List<Door>
        {
            new Door(id: 1, name: "Front Entrance"),
            new Door(id: 2, name: "Side Entrance" ),
            new Door(id: 3, name: "Rear Entrance" ),
            new Door(id: 4, name: "Secure Locker" ),
        };

        public List<Door> GetAllDoors() { return _doors; }

        public Door GetDoorById(int id) { return _doors[id]; }
    }
}
