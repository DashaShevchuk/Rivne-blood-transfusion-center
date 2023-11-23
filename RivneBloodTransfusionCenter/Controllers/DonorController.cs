using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RivneBloodTransfusionCenter.Data.Entities;
using RivneBloodTransfusionCenter.Data.Entities.AppUsers;
using RivneBloodTransfusionCenter.Data.Interfaces.DonorInterfaces;
using RivneBloodTransfusionCenter.ViewModels.Donor;
using System;
using System.Net;

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
        public IActionResult Registration()
        {
            RegistrationViewModel model = donorService.GetRegistrationData();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            HttpStatusCode registrationResult = await donorService.Registration(model);
            if (registrationResult == HttpStatusCode.OK)
            {
                return RedirectToAction("Login", "Donor");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            HttpStatusCode loginResult = await donorService.Login(model);
            if (loginResult == HttpStatusCode.OK)
            {
                return RedirectToAction("HomePage", "Donor");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult HomePage()
        {
            return View();
        }
    }
}
