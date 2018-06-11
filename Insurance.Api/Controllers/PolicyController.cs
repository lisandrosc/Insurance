using Insurance.Api.Security;
using Insurance.Entities.Contracts;
using Insurance.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Description;

namespace Insurance.Api.Controllers
{
    /// <summary>
    /// Supports policy operations.-
    /// </summary>
    [RoutePrefix("api/v1/policy")]
    public class PolicyController : ApiController
    {
        private readonly IPolicyService _policyService;

        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }
        /// <summary>
        /// Get list of policies by user name
        /// </summary>
        /// <returns>Returns a policy</returns>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Policy>))]
        [Route("name/{name}")]
        [BasicAuthAttribute]
        public IHttpActionResult GetByUserName(string name)
        {
            IEnumerable<Policy> policies = _policyService.GetByUserName(name);

            return this.Ok(policies);
        }

        /// <summary>
        /// Get the user linked to a policy number
        /// </summary>
        /// <returns>Returns a client</returns>
        [HttpGet]
        [ResponseType(typeof(Client))]
        [Route("user/{number}")]
        [BasicAuthAttribute]
        public IHttpActionResult GetUserByPolicyNumber(string number)
        {
            Client policies = _policyService.GetUserByPolicyNumber(number);
                        
            if(policies == null)
                return this.BadRequest();

            return this.Ok(policies);
        }

    }
}
