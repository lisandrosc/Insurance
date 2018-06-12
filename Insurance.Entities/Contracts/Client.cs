using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Insurance.Entities.Contracts
{
    public class Clients
    {
        [JsonProperty(PropertyName = "clients")]
        public List<Client> clients { get; set; }
    }

    [Serializable]
    public class Client
    {
        [JsonProperty(PropertyName = "id")]
        public String Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public String Email { get; set; }

        [JsonProperty(PropertyName = "role")]
        public String Role { get; set; } 
    }
}
