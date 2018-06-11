using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Entities.Contracts;
using Insurance.Mocky;

namespace Insurance.Service
{
    public class PolicyService : IPolicyService
    {
        #region Members
        private readonly IMockyService _mockyApiService;
        private readonly IClientService _clientService;
        #endregion

        #region Constructor
        public PolicyService(IClientService clientService, IMockyService mockyApiService)
        {
            _clientService = clientService;
            _mockyApiService = mockyApiService;
        }
        #endregion

        #region Methods
        public IEnumerable<Policy> GetByUserName(string name)
        {
            Client client = _clientService.GetClientByName(name);

            IEnumerable<Policy> policies = _mockyApiService.GetPolicies();

            return policies.Where(e => e.ClientId == client.Id).ToList();
        }

        public Client GetUserByPolicyNumber(string number)
        {
            IEnumerable<Policy> policies = _mockyApiService.GetPolicies();

            Policy policy = policies.Where(e => e.Id == number).FirstOrDefault();

            if (policy == null)
                return null;

            return _clientService.GetClient(policy.ClientId);
        }

        public IEnumerable<Policy> GetPoliciesByClientId(String clientId)
        {
            IEnumerable<Policy> policies = _mockyApiService.GetPolicies();

            return policies.Where(e => e.ClientId == clientId).ToList();
        }

       
        #endregion
    }
}
