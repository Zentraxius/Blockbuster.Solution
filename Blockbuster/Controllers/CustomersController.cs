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

namespace Blockbuster.Controllers
{
  public class CustomersController : Controller
  {
    private readonly BlockbusterContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public CustomersController(UserManager<ApplicationUser> userManager, BlockbusterContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userCustomers = _db.Customers.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(_db.Customers.ToList());
    }
  }
}