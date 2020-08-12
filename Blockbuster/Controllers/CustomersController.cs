using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Blockbuster.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using Blockbuster.ViewModels;


namespace Blockbuster.Controllers
{
  public class CustomersController : Controller
  {
    private readonly BlockbusterContext _db;
    private readonly UserManager<Customer> _userManager;
    private readonly SignInManager<Customer> _signInManager;

    public CustomersController (UserManager<Customer> userManager, SignInManager<Customer> signInManager, BlockbusterContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    public ActionResult Index()
    {
      return View();
    }

    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Register (RegisterViewModel model)
    {
      var user = new Customer { UserName = model.Email };
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }

    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }

    [HttpPost]
    public async Task<ActionResult> LogOff()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index");
    }

    public ActionResult Details (int id)
    {
      var thisCustomer = _db.Customers
        .Include(customer => customer.Videos)
        .ThenInclude(join => join.Video)
        .FirstOrDefault(customer => customer.CustomerId == id);
      return View(thisCustomer);
    }

    // public CustomersController(UserManager<ApplicationUser> userManager, BlockbusterContext db)
    // {
    //   _userManager = userManager;
    //   _db = db;
    // }

    // public async Task<ActionResult> Index()
    // {
    //   var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    //   var currentUser = await _userManager.FindByIdAsync(userId);
    //   var userCustomers = _db.Customers.Where(entry => entry.User.Id == currentUser.Id).ToList();
    //   return View(_db.Customers.ToList());
    // }
  }
}