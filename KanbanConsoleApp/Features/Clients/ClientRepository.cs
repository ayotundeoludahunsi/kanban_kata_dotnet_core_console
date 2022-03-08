using System.Collections.Generic;
using System.Linq;

namespace KanbanConsoleApp.Features.Clients
{
    public class ClientRepository
    {
        private readonly List<Client> _clients = new List<Client>();

        public void SaveClient(Client client)
        {
            _clients.Add(client);
        }


        public List<Client> GetClients()
        {
            var clientsToReturn = new List<Client>();

            foreach (var task in _clients)
            {
                clientsToReturn.Add(new Client
                {
                    Name = task.Name
                });
            }

            return clientsToReturn;
        }

        public List<Client> RemoveClientByName(string name)
        {
            /** 
             * Check if the search argument is not null, 
             * then find the client with the name and pass that to the remove method on Collection object.
            */
            if (!string.IsNullOrEmpty(name))
            {
               _clients.Remove(_clients.Find(e => e.Name == name));
            }

            return _clients;
        }
    }
}
