﻿using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager) : Controller
{

    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;

    public IActionResult SignUp()
    {
        return View();
    }



    [HttpPost]
    public async Task <IActionResult> SignUp(SignUpViewModel model)
    {
        return RedirectToAction("Home", "Default");
    }



    public IActionResult SignIn()
    {
        return View();
    }



    [HttpPost]
    public async Task<IActionResult> SignIn(SignInViewModel model, string returnUrl)
    {
       if (ModelState.IsValid) 
        {
        
        
        }


        return RedirectToAction("Home", "Default");
    }


    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Home", "Default");
    }


}
