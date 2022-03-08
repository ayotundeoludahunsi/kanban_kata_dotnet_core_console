using System;
using System.Collections.Generic;
using System.Linq;

namespace KanbanConsoleApp.Features.Tasks
{
    public class TaskRepository
    {
        private readonly List<Task> _tasks = new List<Task>();

        public void SaveTask(Task task)
        {
            _tasks.Add(task);
        }

        public List<Task> GetTasks()
        {
            var tasksToReturn = new List<Task>();

            foreach (var task in _tasks)
            {
                tasksToReturn.Add(new Task
                {
                    Id = task.Id,
                    Description = task.Description,

                    //Included setting of ClientName property for Test 5
                    ClientName = task.ClientName
                });
            }
            return tasksToReturn;
        }


        /** 
         * Reorders the some items in the Task Collection based on the corresponding 2 indices provided.
         * Reusable and for implemented Test 7.
         */
        public void PerformReOrderingOnTasks(int toBeReplacedItemNumber, int replacingItemNumber)
        {
            //convert item numbering to list index 
            var toBeReplacedIndex = toBeReplacedItemNumber - 1;

            //convert item numbering to list index 
            var replacingIndex = replacingItemNumber - 1;

            //Check to confirm Tasks object already exists and for correct item indices to catch NullReferenceException and IndexOutOfRangeException.
            if (_tasks != null && toBeReplacedIndex > 0 && replacingIndex > 0 &&
                toBeReplacedIndex < _tasks.Count && replacingIndex < _tasks.Count)
            {
                try
                {
                    //Swap items
                    Task temp = _tasks[toBeReplacedIndex];
                    _tasks[toBeReplacedIndex] = _tasks[replacingIndex];
                    _tasks[replacingIndex] = temp;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

}
