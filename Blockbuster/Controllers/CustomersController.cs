using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using BlockBuster.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blockbuster.Controllers
{
  public class CustomersController : Controller
  {
    private readonly BlockbusterContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public ItemsController(UserManager<ApplicationUser> userManager, ToDoListContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
      List<Customer> model = _db.Customers.ToList();
      return View(model);
    }
  }
}