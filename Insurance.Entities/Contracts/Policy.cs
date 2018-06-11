using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Insurance.Entities.Contracts
{
    public class Policies
    {
        [JsonProperty(PropertyName = "policies")]
        public List<Policy> policies { get; set; }
    }
    public class Policy
    {
        [JsonProperty(PropertyName = "id")]
        public String Id { get; set; }

        [JsonProperty(PropertyName = "amountInsured")]
        public String amountInsured { get; set; }

        [JsonProperty(PropertyName = "Email")]
        public String Email { get; set; }

        [JsonProperty(PropertyName= "inceptionDate")]
        public String InceptionDate { get; set; }

        [JsonProperty(PropertyName = "installmentPayment")]
        public String InstallmentPayment { get; set; }

        [JsonProperty(PropertyName = "clientId")]
        public String ClientId { get; set; }
    }
}
