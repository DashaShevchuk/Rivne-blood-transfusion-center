using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RivneBloodTransfusionCenter.Data.Interfaces.DonorInterfaces;
using RivneBloodTransfusionCenter.Data.Interfaces.HomeInterfaces;
using RivneBloodTransfusionCenter.Data.Services;
using RivneBloodTransfusionCenter.Models;
using RivneBloodTransfusionCenter.ViewModels.Home;
using System.Diagnostics;
using System.Net;

namespace RivneBloodTransfusionCenter.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;
        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Centers()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult RecipientRegistration()
        {
            RegistrationViewModel model = homeService.GetRegistrationData();
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterRecipient(RegistrationViewModel model)
        {
            HttpStatusCode registrationResult = await homeService.Registration(model);
            if (registrationResult == HttpStatusCode.OK)
            {
                return RedirectToAction("RecipientRegistration", "Home");
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}