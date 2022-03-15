using CRUD1.Data;
using CRUD1.Models;
using CRUD1.Repositories.Interfaces;

namespace CRUD1.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly Context _context;

        public ClientRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<Client> Clients => _context.Cliente;

        public Client addClient(Client client)
        {
            _context.Cliente.Add(client);
            _context.SaveChanges();
            return client;
        }

        public Client getClientById(int id)
        {
            
          return _context.Cliente.FirstOrDefault(x => x.Id == id);  
          
        }

        public bool RemoveClient(int id)
        {
            var client = getClientById(id);
            if (client is null) throw new Exception("Erro");

            _context.Cliente.Remove(client);
            _context.SaveChanges();
            return true;
        }

        public Client UpdateClient(Client client)
        {
            var clientDB = getClientById(client.Id);
            if (clientDB is null) throw new Exception("Erro");

            clientDB.Name = client.Name;    
            clientDB.Email = client.Email;  
            clientDB.BirthDate = client.BirthDate;
            clientDB.PhoneNumber = client.PhoneNumber;

            _context.Cliente.Update(clientDB);
            _context.SaveChanges();

            return clientDB;




        }
    }
}
