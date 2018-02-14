using DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interfaces
{
    public interface ITaskRepository
    {
        void AddTask(TaskDTO taskDTO);
        void AssignStatus(int taskid, Status stat);
        void AssignDueDate(int taskid, DateTime duedate);
        void AssignPriority(int taskid, int priority);
        void DeleteTask(int taskid);


        void UpdateTask(TaskDTO taskDTO);
        List<TaskDTO> GetAll();
        List<TaskDTO> GetTaskByStatus();
        List<TaskDTO> GetTaskByTitle();
        List<TaskDTO> GetTaskByPriority();
    }
}
