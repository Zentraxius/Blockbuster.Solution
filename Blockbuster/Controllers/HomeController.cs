using Microsoft.AspNetCore.Mvc;

namespace Blockbuster.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}