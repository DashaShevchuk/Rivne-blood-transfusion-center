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
using System.Security.Claims;

namespace RivneBloodTransfusionCenter.Controllers
{
    [Authorize(Roles = "Donor")]
    public class DonorController : Controller
    {
        private readonly IDonorService donorService;
        private readonly UserManager<DbUser> userManager;
        private readonly SignInManager<DbUser> signInManager;
        public DonorController(IDonorService donorService,
                               UserManager<DbUser> userManager,
                               SignInManager<DbUser> signInManager)
        {
            this.donorService = donorService;
            this.userManager= userManager;
            this.signInManager= signInManager;
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
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                TempData["ErrorMessage"] = "Користувача не знайдено";
                return RedirectToAction("Login");
            }
            var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    TempData["ErrorMessage"] = "Цей акаунт заблоковано";
                    return RedirectToAction("Login");
                }
                else
                {
                    await signInManager.SignInAsync(user, model.RememberMe);
                    return RedirectToAction("HomePage", "Donor");
                }
            }
            TempData["ErrorMessage"] = "Неправильний пароль";
            return RedirectToAction("Login");
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
        public IActionResult Profile()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId != null)
            {
                DonorProfileViewModel donorProfile = donorService.GetDonorProfileById(userId);
                return View(donorProfile);
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditProfile(DonorProfileViewModel model)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId != null)
            {
                HttpStatusCode editProfileResult = donorService.EditProfile(model, userId);
                if (editProfileResult == HttpStatusCode.OK)
                {
                    return RedirectToAction("Profile", "Donor");
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return NotFound();
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult Donations()
        {
            AddDonationViewModel model = donorService.GetAddDonationData();
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddDonation(AddDonationViewModel model)
        {
            HttpStatusCode addDonationResult = donorService.AddDonation(model);
            if (addDonationResult == HttpStatusCode.OK)
            {
                return RedirectToAction("Donations", "Donor");
            }
            else
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult WhereDonate()
        {
            return View();
        }
    }
}
