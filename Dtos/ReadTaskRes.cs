using System.ComponentModel.DataAnnotations;

namespace ToDoListCRUD.Dtos
{
    public class ReadTaskRes
    {

        public int? Id { get; set; }

        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 3)]
        public string? Name { get; set; } = string.Empty;

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 5)]
        public string? Description { get; set; }

        [Required]
        public bool IsCompleted { get; set; }
    }
}
