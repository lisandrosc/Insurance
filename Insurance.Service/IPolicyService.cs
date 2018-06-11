using Insurance.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Service
{
    public interface IPolicyService
    {
        /// <summary>
        /// Get list of policies by user name
        /// </summary>
        IEnumerable<Policy> GetByUserName(string name);

        /// <summary>
        /// Get the user linked to a policy number
        /// </summary>
        Client GetUserByPolicyNumber(string number);

        /// <summary>
        /// Get list of policies by user id
        /// </summary>
        IEnumerable<Policy> GetPoliciesByClientId(String clientId);
    }
}
