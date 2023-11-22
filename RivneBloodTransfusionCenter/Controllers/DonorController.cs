using Microsoft.AspNetCore.Mvc;
using RivneBloodTransfusionCenter.Data.Interfaces.DonorInterfaces;
using RivneBloodTransfusionCenter.ViewModels;

namespace RivneBloodTransfusionCenter.Controllers
{
    public class DonorController : Controller
    {
        private readonly IDonorService donorService;
        public DonorController(IDonorService donorService) 
        {
            this.donorService = donorService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Registration()
        {
            DonorRegistrationViewModel model = donorService.GetRegistrationData();
            return View(model);
        }
    }
}
