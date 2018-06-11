using Insurance.Entities.Contracts;
using Insurance.Service;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Insurance.Api.Security
{
    public class BasicAuthAttribute : AuthorizationFilterAttribute
    {
       
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string clientID = actionContext.Request.Headers.Authorization.Parameter;
                if (string.IsNullOrEmpty(clientID))
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
                else
                {
                    // Add user role validation
                    Client client = new ClientService(new Mocky.MockyService()).GetClient(clientID);
                    if (client == null || client.Role != "admin")
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}