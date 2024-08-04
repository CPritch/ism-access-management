using System.ComponentModel.DataAnnotations;

namespace AccessManager.Data
{
    public class Door
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Door name cannot exceed 50 characters.")]
        public string Name { get; set; }
        public bool IsOpen { get; set; }
        public bool IsLocked { get; set; }
        public bool IsAlarmed { get; set; }

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
