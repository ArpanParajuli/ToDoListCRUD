using ToDoListCRUD.Datas;

using ToDoListCRUD.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

using ToDoListCRUD.Dtos;


namespace ToDoListCRUD.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext applicationDbContext;
        public AuthRepository(AppDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<User> ValidateUser(LoginRequestDto obj , CancellationToken ct)
        {
            var User = await applicationDbContext.Users
                .FirstOrDefaultAsync(u => u.Email == obj.Email , ct);

            if(User == null)
            {
                return null;
            }

            bool isPasswordMatched =  BCrypt.Net.BCrypt.Verify(obj.Password , User.Password);

            return User;
        }


        public async Task<User> RegisterUser(RegisterRequestDto obj , CancellationToken ct)
        {
            var User = await applicationDbContext.Users
                .FirstOrDefaultAsync(u => u.Email == obj.Email, ct);

            if (User != null)
            {
                return null;
            }

            else
            {
                string HashPassword = BCrypt.Net.BCrypt.HashPassword(obj.Password);
                var AddUser = new User
                {
                    Email = obj.Email,
                    Name = obj.Name,
                    Password = HashPassword // saving hash password in DB | brcypt like i used in node js
                };
                    
                await applicationDbContext.Users.AddAsync(AddUser, ct);

                await applicationDbContext.SaveChangesAsync();

                return AddUser;
            }

            
        }
    }

}
