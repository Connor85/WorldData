using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorldData.Models;

namespace WorldData.Controllers
{
  public class WorldDataController : Controller
  {
    [HttpGet("/data")]
    public ActionResult WorldData()
    {
      return View();
    }
  }
}
