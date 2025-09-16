using System.ComponentModel.DataAnnotations;

namespace ToDoListCRUD.Models
{
    public class TaskList
    {
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 25 , MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [StringLength(maximumLength: 100, MinimumLength = 5)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public bool IsCompleted { get; set; } = false;

        public int UserId { get; set; }

        public User? User { get; set; }
    }
}
