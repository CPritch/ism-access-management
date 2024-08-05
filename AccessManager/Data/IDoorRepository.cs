﻿namespace AccessManager.Data
{
    public interface IDoorRepository
    {
        List<Door> GetAllDoors();
        Door GetDoorById(int id);
        void UpdateDoor(Door door);
    }
}
