using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Feb1.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Student()
        {
            List<Models.Student> obj = new List<Models.Student>();
            obj.Add(new Models.Student {Id=1 , Name="Mayyas", Major="Developer"  , Faculity = "IT"});
            obj.Add(new Models.Student { Id = 2, Name = "Sohaib", Major = "Developer", Faculity = "IT" });
            obj.Add(new Models.Student { Id = 3, Name = "Momen", Major = "Developer", Faculity = "IT" });
            obj.Add(new Models.Student { Id = 4, Name = "Malek", Major = "Developer", Faculity = "IT" });
            obj.Add(new Models.Student { Id = 5, Name = "Mohammad", Major = "Developer", Faculity = "IT" });

            return View(obj);
        }
    }
}