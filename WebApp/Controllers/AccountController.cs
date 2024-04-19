using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class AccountController : Controller
{
    public IActionResult Details()
    {
        var viewModel = new AccountDetailsViewModel();
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult UpdateBasicInfo(AccountDetailsViewModel model)
    {

        if (TryValidateModel(model.Basic!))
        {


        }

        TempData["StatusMessage"] = "Unable to save information.";
        return RedirectToAction("Details", "Account");
    }

    [HttpPost]
    public IActionResult UpdateAdressInfo(AccountDetailsViewModel model)
    {
        TempData["StatusMessage"] = "Unable to save information.";
        return RedirectToAction("Details", "Account");
    }

}
