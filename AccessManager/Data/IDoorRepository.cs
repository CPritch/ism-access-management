namespace AccessManager.Data
{
    public interface IDoorRepository
    {
        List<Door> GetAllDoors();
        Door GetDoorById(int id);
        void SetOpen(int id, bool open);
        void SetLocked(int id, bool locked);
        void SetAlarmed(int id, bool alarmed);
    }
}
