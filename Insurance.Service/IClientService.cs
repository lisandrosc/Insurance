using Insurance.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Service
{
    public interface IClientService
    {
        /// <summary>
        /// Get client by Id
        /// </summary>
        /// <returns>The client</returns>
        Client GetClient(string id);

        /// <summary>
        /// Get client by name
        /// </summary>
        /// <returns>The client</returns>
        Client GetClientByName(string name);

        /// <summary>
        /// Validate Admin role 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Is admin client</returns>
        Boolean IsAdmin(string id);

        /// <summary>
        /// Get client by name
        /// </summary>
        /// <returns>The client</returns>
        Client GetClientByEmail(string email);

        /// <summary>
        /// Get the list of all clients
        /// </summary>
        /// <returns>Client list</returns>
        IEnumerable<Client> GetClientList();

    }
}
