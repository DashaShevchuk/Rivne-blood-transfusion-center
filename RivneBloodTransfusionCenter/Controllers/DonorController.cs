﻿using Microsoft.AspNetCore.Mvc;

namespace RivneBloodTransfusionCenter.Controllers
{
    public class DonorController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
