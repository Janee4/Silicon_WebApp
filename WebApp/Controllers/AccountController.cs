﻿using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApp.ViewModels;

namespace WebApp.Controllers;

[Authorize]

public class AccountController : Controller
{

    private readonly UserManager<UserEntity> _userManager;
    private readonly ApplicationContext _context;

    public AccountController(UserManager<UserEntity> userManager, ApplicationContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public IActionResult Details()
    {
        var viewModel = new AccountDetailsViewModel();
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateBasicInfo(AccountDetailsViewModel model)
    {

        if (TryValidateModel(model.Basic!))
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                user.FirstName = user.FirstName;
                user.LastName = user.LastName;
                user.Email = user.Email;
                user.PhoneNumber = user.PhoneNumber;
                user.UserName = user.UserName;
                user.Bio = user.Bio;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    TempData["StatusMessage"] = "Updated basic information successfully.";
                }
                else
                {
                    TempData["StatusMessage"] = "Unable to save basic information.";
                }

            }

        }
        else
        {
            TempData["StatusMessage"] = "Unable to save basic information.";
        }

        return RedirectToAction("Details", "Account");
    }

    [HttpPost]
    public async Task<IActionResult> UpdateAdressInfo(AccountDetailsViewModel model)
    {

        if (TryValidateModel(model.Adress!))
        {
            var nameIdentifier = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var user = await _context.Users.Include (i=> i.Adress).FirstOrDefaultAsync(x => x.Id == nameIdentifier);
            if (user != null)
            {
                try
                {
                    if (user.Adress != null)
                    {
                        user.Adress.AdressLine_1 = model.Adress!.AdressLine_1;
                        user.Adress.AdressLine_2 = model.Adress!.AdressLine_2;
                        user.Adress.PostalCode = model.Adress!.PostalCode;
                        user.Adress.City = model.Adress!.City;
                    }
                    else
                    {
                        user.Adress = new AdressEntity
                        {
                            AdressLine_1 = model.Adress!.AdressLine_1,
                            AdressLine_2 = model.Adress!.AdressLine_2,
                            PostalCode = model.Adress!.PostalCode,
                            City = model.Adress!.City
                        };
                    }

                    _context.Update(user);
                    await _context.SaveChangesAsync();
                    TempData["StatusMessage"] = "Updated basic address successfully.";
                }

                catch
                {
                    TempData["StatusMessage"] = "Unable to save address information.";

                }

            }

        }
        else
        {
            TempData["StatusMessage"] = "Unable to save address information.";
        }

        return RedirectToAction("Details", "Account");
    }

}
