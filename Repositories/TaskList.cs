using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Collections;
using ToDoListCRUD.Datas;
using ToDoListCRUD.Dtos;
using ToDoListCRUD.Models;


namespace ToDoListCRUD.Repositories
{
    public class TaskList : ITaskList
    {

        private readonly AppDbContext appDbContext;
        public TaskList(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<ReadTaskRes>> GetAllTask(ReadTaskReq readTaskReq)
        {
            var AllTask = await appDbContext.TaskLists
                .AsNoTracking() // performance readonly db no track
                .Where(t => t.UserId == readTaskReq.UserId)
                .Select(t => new ReadTaskRes
               {
                 Id = t.Id,
                 Name = t.Name,
                 Description = t.Description,
                 IsCompleted = t.IsCompleted
               }).ToListAsync();

            return AllTask;
        }


        public async Task<bool> FindUserById(int UserId)
        {
            var IsUserExists = await appDbContext.Users
                .AsNoTracking() // performance readonly db no track
                .FirstOrDefaultAsync(u => u.Id == UserId);

            if(IsUserExists == null)
            {
                return false;
            }

            else
            {
                return true;
            }
        }


        public async Task AddTaskList(AddTaskReq addTaskReq)
        {
            var TaskData = new Models.TaskList
            {
                UserId = addTaskReq.UserId,
                Name = addTaskReq.Name,
                Description = addTaskReq.Description
            };

             await appDbContext.TaskLists.AddAsync(TaskData);

            await appDbContext.SaveChangesAsync();
        }


        public async Task DeleteAllTaskById(int UserId)
        {
             var tasks = await appDbContext.TaskLists
             .Where(t => t.UserId == UserId)
             .ToListAsync();

            if (tasks.Any())
            {
                appDbContext.TaskLists.RemoveRange(tasks);
                await appDbContext.SaveChangesAsync();
            }


            //////////// alternative method unsafe ////////////////
            ///
          //  await appDbContext.Database
            //    .ExecuteSqlInterpolatedAsync($"DELETE FROM TaskLists WHERE UserId = {UserId}");
        }



    }
}
