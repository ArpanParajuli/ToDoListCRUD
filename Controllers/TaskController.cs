using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoListCRUD.Dtos;
using ToDoListCRUD.Repositories;

namespace ToDoListCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskList taskList;
        public TaskController(ITaskList taskList)
        {
            this.taskList = taskList;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromBody] ReadTaskReq readTaskReq)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var CheckUserExits = await taskList.FindUserById(readTaskReq.UserId);

            if(CheckUserExits == false)
            {
                return NotFound("User not found");
            }

            else
            {
                var TaskResponse = await taskList.GetAllTask(readTaskReq);

                if(TaskResponse == null)
                {
                    return NotFound("User doesn't have any task list");
                }

                else
                {
                    return Ok(TaskResponse);
                }
                    
            }

               
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(AddTaskReq addTaskReq)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await taskList.AddTaskList(addTaskReq);
                return Ok($"{addTaskReq.Name} Task Added!");
            }

            catch(Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
                return BadRequest("Exception occured on saving data");
            }
             
        }


        [HttpDelete("remove")]
        public async Task<IActionResult> Remove(DelTaskReq delTaskReq)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            try
            {

                var IsUserExists = await taskList.FindUserById(delTaskReq.UserId);

                if (IsUserExists == false)
                {
                    return NotFound("User not found");
                }

                await taskList.DeleteAllTaskById(delTaskReq.UserId);
                return Ok("Remove method");
            }


            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
                return BadRequest("Exception occured on Deleting data");
            }
            
        }

        [HttpPatch("update")]
        public IActionResult Update()
        {
            return Ok("Update method");
        }
    }
}
