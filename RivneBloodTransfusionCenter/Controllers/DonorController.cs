using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RivneBloodTransfusionCenter.Data.Entities;
using RivneBloodTransfusionCenter.Data.Entities.AppUsers;
using RivneBloodTransfusionCenter.Data.Interfaces.DonorInterfaces;
using RivneBloodTransfusionCenter.ViewModels.Donor;
using System;

namespace RivneBloodTransfusionCenter.Controllers
{
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
            this.userManager = userManager;
            this.signInManager = signInManager;
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
            var roleName = "Donor";

            DonorProfile donorProfile = new()
            {
                BloodTypeId = model.BloodTypeId,
            };

            var user = new DbUser()
            {
                Email = model.Email,
                Name= model.Name,
                SerName=model.SerName,
                LastName=model.LastName,
                UserName = model.Email,
                PhoneNumber = model.PhoneNumber,
                SexId = model.SexId,
                DonorProfile = donorProfile
            };

            var result = await userManager.CreateAsync(user, model.Password);
            result = userManager.AddToRoleAsync(user, roleName).Result;
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
                return RedirectToAction("Login", "Donor");
            }
            else
            {
                return View(model);
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
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return NotFound();
            }
            var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    return NotFound();
                }
                else
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("HomePage", "Donor");
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult HomePage()
        {
            return View();
        }
    }
}
