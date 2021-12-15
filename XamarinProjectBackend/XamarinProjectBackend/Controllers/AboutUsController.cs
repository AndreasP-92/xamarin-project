using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinProjectBackend.Data;
using XamarinProjectBackend.Models;

namespace XamarinProjectBackend.Controllers
{
    public class AboutUsController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment IWebHostEnviroment;

        public AboutUsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<AboutUs> obj = _db.aboutUs;
            return View(obj);
        }

        public IActionResult Create(AboutUs obj)
        {
            _db.aboutUs.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
