using System.Collections;
using System.Collections.Generic;
using ToDoListCRUD.Dtos;
using ToDoListCRUD.Models;
namespace ToDoListCRUD.Repositories
{
    public interface ITaskList
    {
        public Task<IEnumerable<ReadTaskRes>> GetAllTask(int UserId);

        public Task<bool> FindUserById(int UserId);

        public Task AddTaskList(int UserIdFromJwt, AddTaskReq addTaskReq);

        public Task DeleteAllTaskById(int UserId);
    }
}
