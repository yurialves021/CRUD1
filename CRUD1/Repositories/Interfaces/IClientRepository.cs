using CRUD1.Models;

namespace CRUD1.Repositories.Interfaces
{
    public interface IClientRepository
    {
        public IEnumerable<Client> Clients { get; }

        public Client getClientById(int id);
        public Client addClient(Client client);
        public Client UpdateClient(Client client);
        public bool RemoveClient(int id);


    }
}
