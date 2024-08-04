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
        public bool IsAlarmed { get; private set; }

        public Door(int id, string name)
        {
            Id = id;
            Name = name;
            IsOpen = false;
            IsLocked = false;
            IsAlarmed = false;
        }
    }
}
