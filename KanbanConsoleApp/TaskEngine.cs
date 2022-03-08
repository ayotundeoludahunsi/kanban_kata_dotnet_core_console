using System.Collections.Generic;
using System.Linq;
using KanbanConsoleApp.Features.Clients;
using KanbanConsoleApp.Features.Tasks;

namespace KanbanConsoleApp
{
    public class TaskEngine
    {
        //Object reference maintains access to the Collection object storing the Task objects.
        private readonly TaskRepository _taskRepository = new TaskRepository();

        //Object reference maintains access to the Collection object storing the Client objects.
        private readonly ClientRepository _clientRepository = new ClientRepository();

        public void SaveTask(Task task)
        {
            /**
             * Confirm Task contains ClientName, 
             * if it does, check if the corresponding Client exists before saving else throw an exception.
             * 
             * Else if Task doesn't contain ClientName, save Task
             * 
             * Implemented for Test 1, 5, 6 & 7.
             */
            
            if (!string.IsNullOrEmpty(task.ClientName))
            {
                var clients = _clientRepository.GetClients();

                if (clients.Any(e => e.Name == task.ClientName))
                {
                    _taskRepository.SaveTask(task);
                }
                else
                {   
                    //throws Exception with a custom message
                    throw new System.Exception("The supplied Client could not be found.");
                }
            }
            else
            {
                _taskRepository.SaveTask(task);
            }
        }

        public Task RetrieveTaskById(string id)
        {
            var allTasks = _taskRepository.GetTasks();
            foreach (var task in allTasks)
            {
                //check if task Id is equal to the argument supplied, then return task, needed for Test 1
                if (task.Id == id)
                    return task;
            }

            return null;
        }

        public void SaveClient(Client client)
        {
            // Implemented for Test 2, 3, 4, 5 & 7.
            _clientRepository.SaveClient(client);
        }

        public List<Client> GetClients()
        {
            // Return all clients from the List object alphabetically needed for Test 3
            var client = _clientRepository.GetClients();
            client = client?.OrderBy(e => e.Name)?.ToList();

            return client;
        }

        //Implemented for Test 7
        public void PerformReOrderingOnTasks(int toBeReplacedItemNumber, int replacingItemNumber)
        {
             //Implemented for Test 7
             _taskRepository.PerformReOrderingOnTasks(toBeReplacedItemNumber, replacingItemNumber);
        }

        public List<Client> RemoveClientByName(string name)
        {
            //Implemented for Test 4
            return _clientRepository.RemoveClientByName(name);
        }

        public List<Task> GetTasksForClient(string clientName)
        {
            /** 
             * Implemented for Test 6. 
             * Check if argument is set before filtering Collection with the client's Name,
             * else return an empty List.
            */

            var result = new List<Task>();
            if (!string.IsNullOrEmpty(clientName))
            {
                var tasks = _taskRepository.GetTasks();
                result = tasks.Where(e => e.ClientName == clientName)?.ToList();
            }

            return result;
        }
    }
}