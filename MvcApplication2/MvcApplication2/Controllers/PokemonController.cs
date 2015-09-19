using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class PokemonController : Controller
    {
        private ReportSupEntities db = new ReportSupEntities();

        //
        // GET: /Pokemon/

        public ActionResult Index()
        {
            return View(db.OPinfoes.ToList());
        }

        //
        // GET: /Pokemon/Details/5

        public ActionResult Details(int id = 0)
        {
            OPinfo opinfo = db.OPinfoes.Find(id);
            if (opinfo == null)
            {
                return HttpNotFound();
            }
            return View(opinfo);
        }

        //
        // GET: /Pokemon/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Pokemon/Create

        [HttpPost]
        public ActionResult Create(OPinfo opinfo)
        {
            if (ModelState.IsValid)
            {
                db.OPinfoes.Add(opinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(opinfo);
        }

        //
        // GET: /Pokemon/Edit/5

        public ActionResult Edit(int id = 0)
        {
            OPinfo opinfo = db.OPinfoes.Find(id);
            if (opinfo == null)
            {
                return HttpNotFound();
            }
            return View(opinfo);
        }

        //
        // POST: /Pokemon/Edit/5

        [HttpPost]
        public ActionResult Edit(OPinfo opinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opinfo);
        }

        //
        // GET: /Pokemon/Delete/5

        public ActionResult Delete(int id = 0)
        {
            OPinfo opinfo = db.OPinfoes.Find(id);
            if (opinfo == null)
            {
                return HttpNotFound();
            }
            return View(opinfo);
        }

        //
        // POST: /Pokemon/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            OPinfo opinfo = db.OPinfoes.Find(id);
            db.OPinfoes.Remove(opinfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}