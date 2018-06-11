using Insurance.Entities.Contracts;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Mocky
{
    public class MockyService: IMockyService
    {
        #region Members    
        private readonly String _clientResourceName = "/v2/5808862710000087232b75ac";

        private readonly String _policyResourceName = "/v2/580891a4100000e8242b75c5";

        private readonly String _baseURL = "http://www.mocky.io";

        private readonly IRestClient _client;

        #endregion

        #region Constructor
        public MockyService()
        {
            _client = new RestClient();
            _client.BaseUrl = new Uri(_baseURL);
        }
        #endregion

        #region Methods
        public IEnumerable<Client> GetClients()
        {
            RestRequest request = new RestRequest(this._clientResourceName, Method.GET);

            IRestResponse<Clients> response = _client.Execute<Clients>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new MockyException(string.Format("There are errors with the client mocky data. Detail {0}", response.ErrorMessage));

            return response.Data.clients.AsEnumerable();
        }
        public IEnumerable<Policy> GetPolicies()
        {
            RestRequest request = new RestRequest(this._policyResourceName, Method.GET);

            IRestResponse<Policies> response = _client.Execute<Policies>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new MockyException(string.Format("There are errors with the policy mocky data. Detail {0}", response.ErrorMessage));

            return response.Data.policies.AsEnumerable();
        }
        #endregion


    }
}
