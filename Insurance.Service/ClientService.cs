using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Entities.Contracts;
using Insurance.Mocky;

namespace Insurance.Service
{
    public class ClientService : IClientService
    {
        #region Members
        private readonly IMockyService _mockyApiService;
        #endregion

        #region Constructor
        public ClientService(IMockyService mockyApiService)
        {
            _mockyApiService = mockyApiService;
        }
        #endregion

        #region Methods
        public Client GetClient(string id)
        {
            IEnumerable<Client> clients = _mockyApiService.GetClients();

            return clients.Where(e => e.Id == id).FirstOrDefault();
        }

        public Client GetClientByName(string name)
        {
            IEnumerable<Client> clients = _mockyApiService.GetClients();

            return clients.Where(e => e.Name == name).FirstOrDefault();
        }
        
        public Boolean IsAdmin(string id)
        {
            Client client = GetClient(id);
            if (client != null && client.Role == "Admin")
                return true;

            return false;
        }

        public Client GetClientByEmail(string email)
        {
            IEnumerable<Client> clients = _mockyApiService.GetClients();

            return clients.Where(e => e.Email == email).FirstOrDefault();
        }

        public IEnumerable<Client> GetClientList()
        {
            IEnumerable<Client> clientList = _mockyApiService.GetClients();

            return clientList;
        }
        #endregion
    }
}
