using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using XamarinProjectBackend.Data;
using XamarinProjectBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace XamarinProjectBackend.Controllers
{

    public class CoordInfoController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _IWebHostEnvironment;

        public CoordInfoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<CoordInfo> objList = _db.Coordinfo;
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CoordInfo obj)
        {
            _db.Coordinfo.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

//            return View(obj);
        }

        public IActionResult update(int? id)
        {
            var obj = _db.Coordinfo.Find(id);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult updateCoordInfo(CoordInfo obj)
        {
            _db.Coordinfo.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ImportJsonFile(CoordInfo obj)
        {


            string text = string.Empty;

            using (StreamReader r = new StreamReader("Places.json"))
            {

                text = r.ReadToEnd();

            }
            var resultObject = JsonConvert.DeserializeObject<Places>(text);


            foreach (var place in resultObject.features)
                {
                    obj.name = place.properties.Name;
                    obj.description = place.properties.description;
                    obj.type = place.geometry.type;
                    obj.lat = place.geometry.coordinates[0].ToString();
                    obj.lon = place.geometry.coordinates[1].ToString();

                // identity_insert is set to off sql server
                // SET IDENTITY_INSERT tableName ON
                _db.Database.ExecuteSqlRaw($"INSERT INTO dbo.Coordinfo (name, description, type, lat, lon) values ('{place.properties.Name}', '{place.properties.description}', '{obj.type = place.geometry.type}', '{place.geometry.coordinates[0]}', '{place.geometry.coordinates[1]}');");
                    _db.SaveChanges();

            }



            return RedirectToAction("Index");
        }

        public IActionResult getAllCoordinates()
        {

            IEnumerable<CoordInfo> objList = _db.Coordinfo;

            return Json(new
            {
                features = objList
            });
        }

        public IActionResult Delete(int? id)
        {

            var obj = _db.Coordinfo.Find(id);
            _db.Coordinfo.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
