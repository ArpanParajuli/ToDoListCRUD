using ToDoListCRUD.Dtos;
using ToDoListCRUD.Models;

namespace ToDoListCRUD.Repositories
{
    public interface IAuthRepository
    {
        Task <User> ValidateUser(LoginRequestDto obj, CancellationToken ct);
        Task<User> RegisterUser(RegisterRequestDto obj , CancellationToken ct);
    }
}
