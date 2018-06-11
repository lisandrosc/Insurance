using Insurance.Entities.Contracts;
using Insurance.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.UI.Models;

namespace Web.UI.Controllers
{
    public class PolicyController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IPolicyService _policyService;
        public PolicyController(IClientService clientService, IPolicyService policyService)
        {
            _clientService = clientService;
            _policyService = policyService;
        }

       
        public ActionResult Index()
        {
            PoliciesModel model = new PoliciesModel();
            model.ClientList = _clientService.GetClientList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Grid(PoliciesModel model)
        {
            model.ClientList = _clientService.GetClientList();
            model.ClientPolicies = _policyService.GetPoliciesByClientId(model.ClientIdSelected);

            return View(model);
        }
    }
}