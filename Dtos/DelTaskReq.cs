using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ToDoListCRUD.Dtos
{
    public class DelTaskReq
    {
        [Required]
        [NotNull]
        public int UserId { get; set; }
    }
}
