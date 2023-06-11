using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class OrnekController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return RedirectToAction("Index");
            //return RedirectToAction("Index","Ornek");

            //return View();
        }

        public IActionResult ContentResult()
        {
            return Content("ContentResult");
        }

        public IActionResult JsonResult()
        {
            return Json(new { Id=1, name = "Serkan", age = "24" });
        }

        public IActionResult EmptyResult()
        {
            return new EmptyResult();
        }
    }
}
