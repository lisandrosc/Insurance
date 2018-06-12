using System.Threading.Tasks;
using System.Web.Mvc;
using Web.UI.Models;
using Insurance.Service;
using Insurance.Entities.Contracts;

namespace Web.UI.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly IClientService _clientService;

        public AccountController(IClientService clientService)
        {
            this._clientService = clientService;
        }
         
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
                   
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            Client client = _clientService.GetClientByEmail(model.Email);

            if(client != null)
            {
                Session.Add("User", client);
                return RedirectToAction("Index","Policy");
            }
            
            ModelState.AddModelError("", "Cliente inválido.");
            return View(model);
        }               

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.Remove("User");
            return RedirectToAction("Index", "Home");
        }

      
        protected override void Dispose(bool disposing)
        {           
            base.Dispose(disposing);
        }

    
    }
}