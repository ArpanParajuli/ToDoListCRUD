using System.ComponentModel.DataAnnotations;

namespace ToDoListCRUD.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 20 , MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(maximumLength:50)]
        public string Email { get; set; } = string.Empty; // for scaling to use auth

        [Required]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 255)] // bcrypt le garda
        public string Password { get; set; } = string.Empty; // for scaling to use auth


        public List<TaskList> TaskLists = new List<TaskList>();
    }



}
