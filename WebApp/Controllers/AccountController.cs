using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
                    TempData["StatusMessage"] = "Updated basic address successfully.";
                }
                else
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
