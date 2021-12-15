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
            AboutUs obj = _db.aboutUs.Find(1);
            return View(obj);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create(AboutUs obj)
        {
            _db.aboutUs.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            var obj = _db.aboutUs.Find(id);
            _db.aboutUs.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
