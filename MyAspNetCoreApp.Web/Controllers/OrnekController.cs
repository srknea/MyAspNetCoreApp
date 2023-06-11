using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class OrnekController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.name = "Asp.Net Core";

            //ViewBag.students = new List<string>(){"Serkan", "Berkin", "Enes", "Furkan", "Enes" };

            ViewBag.person = new { Id = 1, Name = "Serkan", Surname = "IŞIK" };


            ViewData["city"] = "London";

            ViewData["names"] = new List<string>() { "Serkan", "Berkin", "Enes", "Furkan", "Enes" };


            return View();
        }

        public IActionResult Index2()
        {
            return RedirectToAction("Index");
            //return RedirectToAction("Index","Ornek");

            //return View();
        }


        //{controller=Home}/{action=Index}/{id?}
        public IActionResult ParametreView(int id) //{id?} 
        {
            return RedirectToAction("JsonResultParametre", "Ornek", new {id=id}); //Ornek/JsonResultParametre/999
        }

        public IActionResult JsonResultParametre(int id)
        {
            return Json(new { Id = id });
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
