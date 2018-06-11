using Insurance.Entities.Contracts;
using Insurance.Service;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Insurance.Api.Controllers
{
    /// <summary>
    /// Supports user operations.-
    /// </summary>
    [RoutePrefix("api/v1/user")]
    public class UserController : ApiController
    {
        private readonly IClientService _clientService;

        public UserController(IClientService service)
        {
            _clientService = service;
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <returns>Returns a client</returns>
        [HttpGet]
        [ResponseType(typeof(Client))]
        [Route("{id}")]
        public IHttpActionResult Get(string id)
        {
            Client client = _clientService.GetClient(id);

            return this.Ok(client);
        }

        /// <summary>
        /// Get user by name
        /// </summary>
        /// <returns>Returns a client</returns>
        [HttpGet]
        [ResponseType(typeof(Client))]
        [Route("name/{name}")]
        public IHttpActionResult GetByName(String name)
        {
            Client client = _clientService.GetClientByName(name);

            return this.Ok(client);
        }
    }
}