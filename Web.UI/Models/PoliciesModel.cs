using Insurance.Entities.Contracts;
using Insurance.Service;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Web.UI.Models
{
    public class PoliciesModel
    {
       
        #region Members
        public IEnumerable<Client> ClientList { get; set; }

        public IEnumerable<Policy> ClientPolicies { get; set; }

        public string ClientIdSelected { get; set; }
    #endregion
}
}