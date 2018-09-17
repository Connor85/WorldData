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
      List<World> countryName =  World.GetAll();
      return View(countryName);
    }
    [HttpGet("/results")]
    public ActionResult Results()
    {
      List<City> newCities = City.GetAllCities();
      return View(newCities);
    }
    [HttpPost("/data")]
    public ActionResult AscendingData()
    {
      List<World> countryName =  World.FilterCountry(Request.Form["order"].ToString());
      return View("WorldData", countryName);
    }
  }
}
