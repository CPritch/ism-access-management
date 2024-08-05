using AccessManager.Data;
using Microsoft.AspNetCore.SignalR;

namespace AccessManager.Hubs
{
    public class DoorStatusHub : Hub
    {
        private readonly IDoorRepository _doorRepository;

        public DoorStatusHub(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public async Task UpdateDoorState(int doorId, bool isOpen, bool isLocked, bool isAlarmed)
        {
            // Todo: Implement locking mechanism here

            var door = _doorRepository.GetDoorById(doorId);
            if (door != null)
            {
                door.UpdateState(isOpen, isLocked, isAlarmed);
                _doorRepository.UpdateDoor(door);

                await Clients.All.SendAsync("DoorStateChanged", door);
            }
        }
    }
}
