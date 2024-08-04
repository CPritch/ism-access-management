using System.ComponentModel.DataAnnotations;

namespace AccessManager.Data
{
    public class Door
    {
        [Required]
        public int Id { get; private set; }
        [Required]
        [StringLength(50, ErrorMessage = "Door name cannot exceed 50 characters.")]
        public string Name { get; private set; }
        public bool IsOpen { get; private set; }
        public bool IsLocked { get; private set; }
        public bool IsArmed { get; private set; }

        public Door(int id, string name, bool isOpen = false, bool isLocked = false, bool isArmed = false)
        {
            Id = id;
            Name = name;
            IsOpen = isOpen;
            IsLocked = isLocked;
            IsArmed = isArmed;
        }

        public void UpdateState(bool isOpen, bool isLocked, bool isArmed)
        {
            IsOpen = isOpen;
            IsLocked = isLocked;
            IsArmed = isArmed;
        }
    }
}
