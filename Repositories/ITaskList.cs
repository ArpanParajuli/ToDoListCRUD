using System.Collections;
using System.Collections.Generic;
using ToDoListCRUD.Dtos;
namespace ToDoListCRUD.Repositories
{
    public interface ITaskList
    {
        public Task<IEnumerable<ReadTaskRes>> GetAllTask(ReadTaskReq readTaskReq);

        public Task<bool> FindUserById(int UserId);

        public Task AddTaskList(AddTaskReq addTaskReq);

        public Task DeleteAllTaskById(int UserId);
    }
}
