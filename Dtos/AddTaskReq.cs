using System.ComponentModel.DataAnnotations;

namespace ToDoListCRUD.Dtos
{
    public class AddTaskReq
    {
        //[Required]
        //public int UserId { get; set; }

        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 3)]
        public string? Name { get; set; } = string.Empty;

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 5)]
        public string? Description { get; set; }
    }
}
