using ToDoListCRUD.Models;

namespace ToDoListCRUD.Services
{
    public interface IJwtService
    {
        public string GenerateJwtToken(User obj);

    }
}
