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

        public Door(int id, string name, bool isOpen = false, bool isLocked = false, bool isAlarmed = false)
        {
            ValidateId(id);
            ValidateName(name);

            Id = id;
            Name = name;
            IsOpen = isOpen;
            IsLocked = isLocked;
            IsAlarmed = isAlarmed;
        }

        public void UpdateState(bool isOpen, bool isLocked, bool isAlarmed)
        {
            // Optional: Add more validation logic here in the future for state changes like opening a locked door
            IsOpen = isOpen;
            IsLocked = isLocked;
            IsAlarmed = isAlarmed;
        }

        // Have to implement validation manually due to no EF implementation
        private void ValidateId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be a positive integer.");
            }
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));   
            }

            if (name.Length > 50)
            {
                throw new ArgumentException("Name cannot be longer than 50 characters.", nameof(name));
            }
        }
    }
}
