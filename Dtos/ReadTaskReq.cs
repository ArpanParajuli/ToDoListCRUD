using System.ComponentModel.DataAnnotations;

namespace ToDoListCRUD.Dtos
{
    public class ReadTaskReq
    {
        [Required]
        public int UserId { get; set; }
    }
}
