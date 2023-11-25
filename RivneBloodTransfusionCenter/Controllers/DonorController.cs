using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RivneBloodTransfusionCenter.Data.Entities;
using RivneBloodTransfusionCenter.Data.Entities.AppUsers;
using RivneBloodTransfusionCenter.Data.Interfaces.DonorInterfaces;
using RivneBloodTransfusionCenter.ViewModels.Donor;
using System;
using System.Data;
using System.Net;

namespace RivneBloodTransfusionCenter.Controllers
{
    [Authorize(Roles = "Donor")]
    public class DonorController : Controller
    {
        private readonly IDonorService donorService;
        public DonorController(IDonorService donorService)
        {
            this.donorService = donorService;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Registration()
        {
            RegistrationViewModel model = donorService.GetRegistrationData();
            return View(model);
        }
        [AllowAnonymous]
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
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
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
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            HttpStatusCode logoutResult = await donorService.Logout();
            if (logoutResult == HttpStatusCode.OK)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult HomePage()
        {
           return View();
        }

    }
}
