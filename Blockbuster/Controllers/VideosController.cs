using Microsoft.AspNetCore.Mvc;
using Blockbuster.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Blockbuster.Controllers
{
  public class VideosController : Controller
  {
    private readonly BlockbusterContext _db;
    
    public VideosController(BlockbusterContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Video> model = _db.Videos.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Video video)
    {
      _db.Videos.Add(video);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var thisVideo = _db.Videos
        .Include(video => video.Customers)
        .ThenInclude(join => join.Customer)
        .FirstOrDefault(videos => videos.VideoId == id);
      return View(thisVideo);
    }

    public ActionResult AddCustomer(int id)
    {
      var thisVideo = _db.Videos
      .Include(video => video.Customers)
      .ThenInclude(join => join.Customer)
      .FirstOrDefault(videos => videos.VideoId == id);
      // ViewBag.CustomerId = new SelectList(_db.Customers, "CustomerId", "Name");
      return View(thisVideo);
    }

    [HttpPost]
    public ActionResult AddCustomer(Video video)
    {
      var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (userId != null)
      {
        _db.CustomerVideo.Add(new CustomerVideo() { CustomerId = userId, VideoId = video.VideoId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteCustomer()
    {
      var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
      var joinEntry = _db.CustomerVideo.FirstOrDefault(entry => entry.CustomerId == userId);
      _db.CustomerVideo.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}