
using Microsoft.EntityFrameworkCore;
using ToDoListCRUD.Datas;
using ToDoListCRUD.Repositories;

namespace ToDoListCRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer("Data Source=desktop-930ejbl;Initial Catalog=todolist;Integrated Security=True;Trust Server Certificate=True"));

            builder.Services.AddControllers();
           
            builder.Services.AddOpenApi();


            builder.Services.AddScoped<ITaskList, TaskList>(); // making scoped due to crud operation 

            var app = builder.Build();
      
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
