using Insurance.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Mocky
{
    public interface IMockyService
    {
        IEnumerable<Client> GetClients();

        IEnumerable<Policy> GetPolicies();
    }
}
