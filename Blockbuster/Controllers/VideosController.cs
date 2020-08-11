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
      var thisVideo = _db.Videos.FirstOrDefault(videos => videos.VideoId == id);
      return View(thisVideo);
    }

    [HttpPost]
    public ActionResult AddCustomer(Video video, int CustomerId)
    {
      if (CustomerId != 0)
      {
        _db.CustomerVideo.Add(new CustomerVideo() { CustomerId = CustomerId, VideoId = video.VideoId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}