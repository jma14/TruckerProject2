using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TruckerProject2.Models;
using TruckerProject2.ViewModels;

namespace TruckerProject2.Controllers
{
    public class HomeController : Controller
    {
        private TruckerDbEntities db = new TruckerDbEntities();

        // GET: Truckers
        public ActionResult Index(string searchCriteria)
        {
            List<Trucker> truckers = db.Truckers.Where(p => p.FirstName.Contains(searchCriteria)).ToList();
            IndexViewModel indexViewModel = new IndexViewModel(truckers, db.Licenses.ToList(), searchCriteria);
                
            return View(indexViewModel);
        }

        public ActionResult Create()
        {
            CreateViewModel createViewModel = new CreateViewModel(db.Licenses.ToList(), db.States.ToList());
            return View(createViewModel);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "TruckerID, FirstName, LastName, Address, City, State, Zip, LicenseNumber, ExpirationDate")] Trucker trucker, string[] licenseList)
        {
            if(ModelState.IsValid)
            {
                trucker.TruckerID = db.Truckers.Count() == 0 ? 1 : db.Truckers.OrderByDescending(p => p.TruckerID).FirstOrDefault().TruckerID + 1;
                foreach (var license in licenseList)
                {
                    trucker.Licenses.Add(db.Licenses.Where(p => p.LicenseType == license).FirstOrDefault());
                }
                db.Truckers.Add(trucker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            CreateViewModel createViewModel = new CreateViewModel(db.Licenses.ToList(), db.States.ToList());

            return View(createViewModel);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trucker trucker = db.Truckers.Find(id);
            EditViewModel editViewModel = new EditViewModel(trucker, db.Licenses.ToList(), db.States.ToList());
            if (trucker == null)
            {
                return HttpNotFound();
            }
            return View(editViewModel);

        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "TruckerID, FirstName, LastName, Address, City, State, Zip, LicenseNumber, ExpirationDate")] Trucker trucker, int id, string[] licenseList)
        {
            trucker.TruckerID = id;
            Trucker dbTrucker = db.Truckers.Find(id);
            if (ModelState.IsValid)
            {
                foreach (var license in licenseList)
                {
                    trucker.Licenses.Add(db.Licenses.Where(p => p.LicenseType == license).FirstOrDefault());
                }
                db.Database.ExecuteSqlCommand("DELETE FROM dbo.TruckerLicense WHERE TruckerID = {0}", trucker.TruckerID);
                db.Truckers.Remove(dbTrucker);
                db.Truckers.Add(trucker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            EditViewModel editViewModel = new EditViewModel(dbTrucker, db.Licenses.ToList(), db.States.ToList());

            return View(editViewModel);
        }
        


        // POST: Truckers/Delete
        [HttpGet, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            Trucker trucker = db.Truckers.Find(id);
            db.Database.ExecuteSqlCommand("DELETE FROM dbo.TruckerLicense WHERE TruckerID = {0}", trucker.TruckerID);
            db.Truckers.Remove(trucker);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}